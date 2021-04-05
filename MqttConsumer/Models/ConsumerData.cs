using System;
using System.Collections.Generic;
using System.Text;

namespace MqttConsumer.Models
{
    public class ConsumerData
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
    }
}
