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

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
/*
 * Using MinimalAPI
        app.MapPost("calculate", (JsonInput jsonInput,ICalculator calculator) =>
        {
            try
            {
                string input = jsonInput.Input;
                string result = calculator.Evaluate(input);
                return Results.Json(new JsonOutput(result));
            }catch(ArgumentException e)
            {
                return Results.BadRequest(e.Message);
            }
        });
*/
       
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