using CleanArchitecture.Domain.Interfaces;
using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repository;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        // parâmetros — ajuste conforme capacidade do seu servidor (memória, tempo)
        var memory = 1 << 16; // 64 MB
        var iterations = 3;
        var degreeOfParallelism = 2;

        byte[] salt = RandomNumberGenerator.GetBytes(16);

        var argon = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = degreeOfParallelism,
            Iterations = iterations,
            MemorySize = memory
        };

        byte[] hash = argon.GetBytes(32); 

        return $"argon2id$v=19$m={memory},t={iterations},p={degreeOfParallelism}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
    }

    public bool Verify(string stored, string password)
    {
        var parts = stored.Split('$');
        if (parts.Length != 5) return false;

        var paramsPart = parts[2];
        var salt = Convert.FromBase64String(parts[3]);
        var hashStored = Convert.FromBase64String(parts[4]);

        var tokens = paramsPart.Split(',');
        var memory = int.Parse(tokens[0].Split('=')[1]);
        var iterations = int.Parse(tokens[1].Split('=')[1]);
        var degree = int.Parse(tokens[2].Split('=')[1]);

        var argon = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = degree,
            Iterations = iterations,
            MemorySize = memory
        };
        var hash = argon.GetBytes(hashStored.Length);
        return CryptographicOperations.FixedTimeEquals(hash, hashStored);
    }
}
