using System.Threading.Channels;
using Computer_Factory.Data;
using Computer_Factory.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Computer_Factory
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            SerializeDataFromDB(config);
        }

        public static void SerializeDataFromDB(IConfiguration config)
        {
            using (DataContextComputer context = new DataContextComputer(config))
            {
                context.Database.EnsureCreated();
                IEnumerable<Computer> computers = context.Computers.ToList();
                
                string json = JsonConvert.SerializeObject(computers);
                File.WriteAllText("..\\..\\..\\serializedDataFromDb.json", json);
            }
        }

        public static void DeserializeDataSaveToDB(IConfiguration config)
        {
            
            using (var context = new DataContextComputer(config))
            {
                context.Database.EnsureCreated();

                string text = File.ReadAllText("data.json");
                IEnumerable<Computer> computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(text);

                foreach (Computer computer in computers)
                {
                    context.Add(computer);
                }
                context.SaveChanges();
            }
        }
    }
}
