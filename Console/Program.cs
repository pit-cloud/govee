using Azure.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace PowerIT.Testing
{
    class Program
    {
        static async Task Main(string[] arguments)
        {
            //Account.Login("1aaebbb1-2e82-42cc-a415-2db1a8a8b256");

            //if (Account.IsLoggedIn)
            //{
            //    //List devices
            //    var devices = await Devices.ListAsync();
            //    var device = devices.Data.Devices.First(d => d.Name == "Lounge Light 2");

            //    //Device state
            //    var state = await Device.StateAsync(device.Id, device.Model);
            //    Console.WriteLine(state.Data.Properties.First(p => p.Online != null).Online.ToString().ToLower());

            //    ////Turn off device
            //    //var off = await Device.OffAsync(device.Id, device.Model);
            //    //Console.WriteLine(off.Status);

            //    ////Turn on device
            //    //var on = await Device.OnAsync(device.Id, device.Model);
            //    //Console.WriteLine(on.Status);

            //    ////Change device brightness
            //    //var brightness = await Device.BrightnessAsync(device.Id, device.Model, 100);
            //    //Console.WriteLine(brightness.Status);

            //    //////Change device color
            //    //var color = await Device.ColorAsync(device.Id, device.Model, Color.White);
            //    //Console.WriteLine(color.Status);

            //    ////Change device temprature
            //    //var temprature = await Device.TempratureAsync(device.Id, device.Model, 9000);
            //    //Console.WriteLine(temprature.Status);
            //}
            //else
            //{
            //    Console.Write("Not logged in.");
            //}

            //            var endpoint = "https://pit-cos-sql.documents.azure.com:443/";

            //            using CosmosClient client = new(
            //                accountEndpoint: endpoint,
            //                tokenCredential: new DefaultAzureCredential(),
            //                new CosmosClientOptions()
            //                {
            //                    ConnectionMode = ConnectionMode.Gateway,
            //                }
            //            );

            //            Database database = client.GetDatabase("apikeys");
            //            Container container = database.GetContainer("users");

            //            User user = new(
            //                id: Guid.NewGuid().ToString(),
            //                userId: "testing",
            //                name: "Dan Searle",
            //                apiKey: "1aaebbb1-2e82-42cc-a415-2db1a8a8b256"
            //            );

            //            //User createdUser = await container.CreateItemAsync(user);

            //            Console.WriteLine($"New database:\t{database.Id}");
            //            Console.WriteLine($"New container:\t{container.Id}");
            //            //Console.WriteLine($"Created item:\t{createdUser.id}\t[{createdUser.userId}]");

            //            var query = new QueryDefinition(
            //    query: "SELECT * FROM users p WHERE p.userId = @userId"
            //)
            //    .WithParameter("@userId", "testing");

            //            using FeedIterator<User> feed = container.GetItemQueryIterator<User>(
            //                queryDefinition: query
            //            );

            //            while (feed.HasMoreResults)
            //            {
            //                FeedResponse<User> response = await feed.ReadNextAsync();

            //                foreach (User item in response)
            //                {
            //                    Console.WriteLine($"Found item:\t{item.apiKey}");
            //                }
            //            }

            SqlConnectionStringBuilder builder = new();
            builder.DataSource = "pitsqlgovee.database.windows.net";
            builder.UserID = "goveeadmin";
            builder.Password = "ChelseaFC1995>?<";
            builder.InitialCatalog = "pit-sql-govee";

            using SqlConnection connection = new(builder.ConnectionString);

            string sql = "SELECT UserId, ApiKey FROM Users";

            using SqlCommand command = new(sql, connection);

            connection.Open();

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
            }
        }
    }

    public record User(
        string Id,
        string UserId,
        string Name,
        string ApiKey
    );
}

