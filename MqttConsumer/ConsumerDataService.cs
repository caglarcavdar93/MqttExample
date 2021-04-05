
namespace MqttConsumer
{
    public class ConsumerDataService
    {
        private readonly MyDbContext _dbContext;
        public ConsumerDataService()
        {
            _dbContext = new MyDbContext();
        }
        public async void InsertData(ConsumerData consumerData)
        {
            _dbContext.ConsumerDatas.Add(consumerData);
            await _dbContext.SaveChangesAsync();
        }
    }
}
