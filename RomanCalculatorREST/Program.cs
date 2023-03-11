using Microsoft.AspNetCore.Diagnostics;
using SimpleRomanCalculator;
using SimpleRomanCalculator.Converter;
using SimpleRomanCalculator.Parser;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        AddCalculatorServices(builder);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseExceptionHandler(app => app.Run( async context =>
        {
           await GotException(context);
        }));

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }

    private static void AddCalculatorServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRomanArabicConverter , RomanArabicConverter>();
        builder.Services.AddScoped<IInfixToPostfix,InfixToPostfix>(); 
        builder.Services.AddScoped<IPostfixToResult,PostfixToResult>();   
        builder.Services.AddScoped<ICalculator,RomanCalculator>();
    }

    private static async Task GotException(HttpContext context)
    {
        var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
        if (exception is ArgumentException)
        {
            var response = new { error = exception.Message };
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(response);
        }
        else
        {
            var response = new { error = exception.Message };
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(response);
        }
    }

}

