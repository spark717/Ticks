#if SPARK_DI
namespace Spark
{
    public class FixedTickProcessor : IServiceProcessor
    {
        private readonly IFixedTickManager _manager;

        public FixedTickProcessor(IFixedTickManager manager)
        {
            _manager = manager;
        }
        
        public void OnServiceCreated(object service)
        {
            if (service is IFixedTick consumer)
                _manager.AddConsumer(consumer);
        }

        public void OnServiceDestroyed(object service)
        {
            if (service is IFixedTick consumer)
                _manager.RemoveConsumer(consumer);
        }
    }
}
#endif
