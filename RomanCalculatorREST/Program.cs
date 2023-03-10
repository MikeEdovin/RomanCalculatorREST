using SimpleRomanCalculator;
using SimpleRomanCalculator.Converter;
using SimpleRomanCalculator.Parser;
using RomanCalculatorREST.Entities;
using Microsoft.AspNetCore.Http.HttpResults;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        addCalculatorServices(builder);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }

    private static void addCalculatorServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRomanArabicConverter , RomanArabicConverter>();
        builder.Services.AddScoped<IInfixToPostfix,InfixToPostfix>(); 
        builder.Services.AddScoped<IPostfixToResult,PostfixToResult>();   
        builder.Services.AddScoped<ICalculator,RomanCalculator>();
    }
}