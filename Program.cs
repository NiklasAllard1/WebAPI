using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddMvc();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.MapGet("/", () => "Hello World!");

        app.MapGet("/add", (HttpContext context) =>
        {
            int num1 = int.Parse(context.Request.Query["num1"]);
            int num2 = int.Parse(context.Request.Query["num2"]);
            return AddNumbers(num1, num2);
        });

        app.MapGet("/subtract", (HttpContext context) =>
        {
            int num1 = int.Parse(context.Request.Query["num1"]);
            int num2 = int.Parse(context.Request.Query["num2"]);
            return SubtractNumbers(num1, num2);
        });

        app.Run();
    }

    static string AddNumbers(int num1, int num2)
    {
        return $"Summan av {num1} och {num2} är: {num1 + num2}";
    }

    static string SubtractNumbers(int num1, int num2)
    {
        return $"Differensen av {num1} och {num2} är: {num1 - num2}";
    }
}
