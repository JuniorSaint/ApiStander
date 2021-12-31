using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Api.Application.Interfaces;
using Api.Application.Services;
using Api.CrossCutting.DependencyInjection;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; //access appsetting.json

/////////////////// Add services to the container. \\\\\\\\\\\\\\\\\\\\\\\\\\\\

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          builder =>
                          {
                              builder.AllowAnyOrigin()
                                     .AllowAnyHeader()
                                     .AllowAnyMethod();
                          });
});

// configure Dependency cyclicle, document inside document
builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
                    )
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

// configure dependency Injection
InjectionRepository.ConfigureDependenciesRepository(builder.Services);
InjectionService.ConfigureDependenciesService(builder.Services);
InjectionJwt.ConfigureDependenciesJwt(builder.Services, configuration);

///////////////////  Configure the HTTP request pipeline. \\\\\\\\\\\\\\\\\\\\\


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();

app.UseRouting();

app.UseAuthorization();

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
    RequestPath = new PathString("/Resources")
});
// The configuration of the "Cors" must stay after: app.UseHttpsRedirection
// and app.UseRouting and before app.UseEndpoints
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();

