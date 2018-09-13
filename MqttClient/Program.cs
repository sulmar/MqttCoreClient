using MQTTnet;
using MQTTnet.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MqttClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("MQTT Publisher started!");

            await ClientTestAsync();

        }

        // PM> Install-Package MQTTnet.AspNetCore
        public static async Task ClientTestAsync()
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("10.0.75.1", 1883) // Port is optional
                .Build();

            var factory = new MqttFactory();

            var client = factory.CreateMqttClient();

            await client.ConnectAsync(options);

            Random random = new Random();

            Console.WriteLine("Press Esc key to exit.");

            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) break;

                string payload = $"{random.Next(0, 100)}";

                await client.PublishAsync("house/room1/temp1", payload);

                Console.WriteLine($"Sent {payload}");

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            

            //client.ApplicationMessageReceived += (s, e) =>
            //{
            //    Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
            //    Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
            //    Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            //    Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
            //    Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
            //    Console.WriteLine();

            //};

            //client.Connected += async (s, e) =>
            //{
            //    Console.WriteLine("### CONNECTED WITH SERVER ###");

            //    // new TopicFilterBuilder().WithTopic("house/#").Build()
            //    await client.SubscribeAsync("house/#");

            //    Console.WriteLine("### SUBSCRIBED ###");
            //};


        }
    }
}
