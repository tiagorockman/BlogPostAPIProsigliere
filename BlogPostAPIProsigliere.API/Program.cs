using BlogPostAPIProsigliere.Domain.BlogContext.Repositories;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Handlers;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Handlers.Interfaces;
using BlogPostAPIProsigliere.Infra.Repository;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog API Prosigliere Challenge", Version = "v1" });
    s.EnableAnnotations();
});

//Dependency Injection
builder.Services.AddSingleton<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddTransient<IBlogPostHandler, BlogPostHandler>();

//CORS policy - Open All to test purposes
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API Prosigliere Challenge"));
}
else
{
    app.UseExceptionHandler("/Error"); // Generic error page for production
    app.UseHsts(); // Enable HSTS (HTTP Strict Transport Security)
}

app.UseHttpsRedirection();

//Use CORS added before
app.UseCors("AllowAll"); 

app.UseAuthorization();

app.MapControllers();

app.Run();
