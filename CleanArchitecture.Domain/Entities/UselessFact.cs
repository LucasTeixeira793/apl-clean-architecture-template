﻿
namespace CleanArchitecture.Domain.Entities;

public class UselessFact
{
    public string Id { get; set; }
    public string Text { get; set; }
    public string Source { get; set; }
    public string SourceUrl { get; set; }
    public string Language { get; set; }
    public string Permalink { get; set; }
}
