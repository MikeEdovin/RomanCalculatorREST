using SimpleRomanCalculator;
using SimpleRomanCalculator.Converter;
using SimpleRomanCalculator.Parser;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

       addCalculatorServices(builder);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

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