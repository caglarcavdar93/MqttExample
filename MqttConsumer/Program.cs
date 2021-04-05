using System;

namespace MqttConsumer
{
    class Program
    {
        private static MqttConsumer myConsumer;
        static void Main(string[] args)
        {
            myConsumer = new MqttConsumer();
            myConsumer.SubscribeTopic(new string[] { "myTag" });
            Console.ReadLine();
        }
    }
}
