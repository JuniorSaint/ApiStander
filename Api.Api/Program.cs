using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Api.Application.Interfaces;
using Api.Application.Services;
using Api.CrossCutting.DependencyInjection;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; //access appsetting.json

////////////////////////////////////////////////////////////////////////////
/////////////////// Add services to the container. /////////////////////////
////////////////////////////////////////////////////////////////////////////

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// configure dependency Injection
InjectionRepository.ConfigureDependenciesRepository(builder.Services);
InjectionService.ConfigureDependenciesService(builder.Services);
InjectionJwt.ConfigureDependenciesJwt(builder.Services, configuration);
InjectionJsonSerializer.ConfigureDependencyJsonSerializer(builder.Services);

////////////////////////////////////////////////////////////////////////////
///////////////////  Configure the HTTP request pipeline. //////////////////
////////////////////////////////////////////////////////////////////////////

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();

app.UseRouting();

// fix the problem with date to postgres
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// The configuration of the "Cors" must stay after: app.UseHttpsRedirection
// and app.UseRouting and before app.UseEndpoints
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin() );

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
    RequestPath = new PathString("/Resources")
});

app.MapControllers();

app.Run();

