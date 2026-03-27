using Dapper;
using System.Data.SqlClient;

namespace backend
{
    public class Program
    {
        record Data(int Id, string Title);
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors();
            var app = builder.Build();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/podcasts", async () =>
            {
                try
                {
                    var db = new SqlConnection("Server=database,1433;Database=TestDB;User ID=sa;Password=YourStrongP@ssw0rd;TrustServerCertificate=True;");

                    var data = (await db.QueryAsync<Data>("SELECT Id, Title FROM Data")).Select(x => x.Title).ToList();

                    return data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new List<string>
                    {
                        "The Daily (offline)",
                        "Radiolab (offline)",
                        "99% Invisible (offline)",
                        "Stuff You Should Know (offline)",
                        "Reply All (offline)",
                        "Freakonomics Radio (offline)",
                        "The Tim Ferriss Show (offline)",
                        "How I Built This",
                        "Science Vs",
                        "Planet Money",
                        "Hardcore History",
                        "SmartLess",
                        "The Joe Rogan Experience",
                        "TED Radio Hour",
                        "Crime Junkie"
                    };
                }


            }
            );

            app.Run();
        }
    }
}
