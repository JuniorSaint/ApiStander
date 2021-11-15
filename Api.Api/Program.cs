using Api.Application.Interfaces;
using Api.Application.Services;
using Api.CrossCutting.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

/////////////////// Add services to the container. \\\\\\\\\\\\\\\\\\\\\\\\\\\\

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
));

// configure Dependency cyclicle
builder.Services.AddControllers().AddNewtonsoftJson(x =>
        x.SerializerSettings.ReferenceLoopHandling =
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

app.MapControllers();

app.Run();

