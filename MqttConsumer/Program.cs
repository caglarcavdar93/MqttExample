using System;

namespace MqttConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var myConsumer = new MqttConsumer();
            myConsumer.SubscribeTopic(new string[] { "myTag" });
        }
    }
}
