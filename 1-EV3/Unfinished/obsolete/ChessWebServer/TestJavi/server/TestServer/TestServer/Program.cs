using System.Text.Json;

namespace TestServer
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthorization();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            var app = builder.Build();
            app.UseAuthorization();
            app.UseCors("AllowAll");



            app.MapPost("/login", async (HttpContext httpContext) =>
            {
                using (var reader = new StreamReader(httpContext.Request.Body))
                {
                    var body = await reader.ReadToEndAsync();
                    var login = JsonSerializer.Deserialize<Login>(body);
                    // Conexion a una base de datos
                    var session = new Session()
                    {
                        token = login.username + " - " + login.password
                    };
                    Console.WriteLine(JsonSerializer.Serialize(session));
                    return session;
                }
            });

            app.MapGet("/formats", async (HttpContext httpContext) =>
            {
                try 
                {
                    var result = RestAPI.GetAllGameFormats();
                    httpContext.Response.StatusCode = StatusCodes.Status200OK;
                    return (object)result;
                }
                catch (Exception ex)
                {
                    ErrorMessage result = new ErrorMessage();
                    result.error_code = 10;
                    result.message = ex.Message;
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    return (object)result;
                }
            });

            app.Run();
        }
    }
}