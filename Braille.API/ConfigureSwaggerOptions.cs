using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BrailleAPI
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(
            IApiVersionDescriptionProvider provider)
            => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var desc in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    desc.GroupName,
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = $"Braille API {desc.ApiVersion}",
                        Version = desc.ApiVersion.ToString(),
                        Description = "A database of Ascii-Braille Special Symbols as published by the ICEB Committee",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "lyndabrf@gmail.com",
                            Name = "Lynda Foster",
                            Url = new Uri("https://www.linkedin.com/in/lynda-foster/")
                        },
                            License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
                        }
                    });

            }

            var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var cmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
            options.IncludeXmlComments(cmlCommentsFullPath);

        }
    }
}
