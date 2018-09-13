using MQTTnet;
using MQTTnet.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MqttSubsciber
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            await ClientTestAsync();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        // PM> Install-Package MQTTnet.AspNetCore
        public static async Task ClientTestAsync()
        {
            

            var factory = new MqttFactory();

            var client = factory.CreateMqttClient();

            // await client.SubscribeAsync("house#");

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("10.0.75.1", 1883) // Port is optional
                .Build();

            client.ApplicationMessageReceived += Client_ApplicationMessageReceived;
            client.Connected += Client_Connected;
            client.Disconnected += Client_Disconnected;

            await client.ConnectAsync(options);

            

        }

        private static async void Client_Connected(object sender, MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("# Connected to server." );

            IMqttClient client = (IMqttClient)sender;

            // Subscribe to a topic
            await client.SubscribeAsync(new TopicFilterBuilder().WithTopic("house/#").Build());

            Console.WriteLine("Subscribed.");
        }

        private static void Client_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            Console.WriteLine("# Recevied message");
            Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
            Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
            Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
            Console.WriteLine();
        }

        private static void Client_Disconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            
        }
    }
}
