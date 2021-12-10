using System.Text.Json.Serialization;
using Api.Application.Interfaces;
using Api.Application.Services;
using Api.CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

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
//InjectionJwt.ConfigureDependenciesJwt(builder.Services);

///////////////////  Configure the HTTP request pipeline. \\\\\\\\\\\\\\\\\\\\\


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
    RequestPath = new PathString("/Resources")
});
// A configuração da Cors tem que ficar depois de: app.UseHttpsRedirection e app.UseRouting e antes de app.UseEndpoints
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();

