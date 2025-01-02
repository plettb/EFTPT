using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TptApp.Models;

namespace TptApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>(true)
                .Build();

            var connectionString = configuration.GetConnectionString("TptConnection");

            var options = new DbContextOptionsBuilder<TptContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new TptContext(options))
            {
                context.Database.ExecuteSqlRaw("delete from Sales;");
                RunIt(context, 0);

                context.Database.ExecuteSqlRaw("insert into Sales (SellerId, BuyerId, Quantity) values (7113, 7221, 1);");
                RunIt(context, 1);

                context.Database.ExecuteSqlRaw("insert into Sales (SellerId, BuyerId, Quantity) values (7221, 7113, 2);");
                RunIt(context, 2);
            }
        }

        private static void RunIt(TptContext context, int recCount)
        {
            Console.WriteLine($"Running with {recCount} records");
            try
            {
                var sales = context.Sales.AsNoTracking().ToList();
                Console.WriteLine($"Sales count with nothing: {sales.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var sales = context.Sales.Include(s => s.Buyer).AsNoTracking().ToList();
                Console.WriteLine($"Sales count with buyer: {sales.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var sales = context.Sales.Include(s => s.Seller).AsNoTracking().ToList();
                Console.WriteLine($"Sales count with seller: {sales.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var sales = context.Sales.Include(x => x.Buyer).Include(s => s.Seller).AsNoTracking().ToList();
                Console.WriteLine($"Sales count with both: {sales.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
