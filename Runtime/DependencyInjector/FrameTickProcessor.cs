#if SPARK_DI
namespace Spark
{
    public class FrameTickProcessor : IServiceProcessor
    {
        private readonly IFrameTickManager _manager;

        public FrameTickProcessor(IFrameTickManager manager)
        {
            _manager = manager;
        }
        
        public void OnServiceCreated(object service)
        {
            if (service is IFrameTick consumer)
                _manager.AddConsumer(consumer);
        }

        public void OnServiceDestroyed(object service)
        {
            if (service is IFrameTick consumer)
                _manager.RemoveConsumer(consumer);
        }
    }
}
#endif
