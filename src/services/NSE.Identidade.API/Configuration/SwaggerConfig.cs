using Microsoft.OpenApi.Models;

namespace NSE.Identidade.API.Configuration
{
  public static class SwaggerConfig
  {
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
      services.AddEndpointsApiExplorer();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "NedStore Enterprise Identity API",
          Description = "Projeto API NerdStore Enterprise Utilizando Identity.",
          Contact = new OpenApiContact
          {
            Name = "Beethoven Souza",
            Email = "bthoven2009@hotmail.com"
          },
          License = new OpenApiLicense
          {
            Name = "MIT",
            Url = new Uri("https://opensourse.org/licenses/MIT")
          }
        });
      });

      return services;
    }
  }
}
