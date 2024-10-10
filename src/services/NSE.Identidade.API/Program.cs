using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NSE.Identidade.API.Configuration;
using NSE.Identidade.API.Data;
using NSE.Identidade.API.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//==========================Configura��o tipo de ambiente=================================

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

//================ Mapeamento do dbContext e  Configura��o do Identity===============================================
builder.Services.AddIdentityConfiguration(builder.Configuration);


//=============== Configura��o: Suporte ao JWT ======================================
builder.Services.AddAuthenticationConfiguration(builder.Configuration);

//=============== Configura��o:  Swagger======================================
builder.Services.AddSwaggerConfiguration();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
  });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
