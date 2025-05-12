using CleanArchitecture.Presentation;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CleanArchitecture.API.Configuration
{
    public static class Documentation
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                var presentationXmlFile = $"{typeof(AssemblyReference).Assembly.GetName().Name}.xml";
                var presentationXmlPath = Path.Combine(AppContext.BaseDirectory, presentationXmlFile);
                if (File.Exists(presentationXmlPath))
                    c.IncludeXmlComments(presentationXmlPath);
            });
        }
    }
}