using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttConsumer
{
    public class MqttConsumer
    {
        private readonly MqttClient _mqttClient;
        private readonly ConsumerDataService _dataService;
       
        public MqttConsumer()
        {
            _mqttClient = new MqttClient("localhost");
            _mqttClient.Connect("myUniqueId");
            _dataService = new ConsumerDataService();
        }
        public bool SubscribeTopic(string[] topic)
        {

            try
            {
                _mqttClient.Subscribe(topic, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                _mqttClient.MqttMsgPublishReceived += _mqttClient_MqttMsgPublishReceived;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void _mqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                Console.WriteLine(Encoding.UTF8.GetString(e.Message));
                var data = new ConsumerData()
                {
                    Tag = e.Topic,
                    Value = Encoding.UTF8.GetString(e.Message),
                    Date = DateTime.UtcNow.ToString()
                };
                _dataService.InsertData(data);
            }
            catch (Exception)
            {
            }
        }
    }
}
