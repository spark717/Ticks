#if SPARK_DI
namespace Spark
{
    public class LateFrameTickProcessor : IServiceProcessor
    {
        private readonly ILateFrameTickManager _manager;

        public LateFrameTickProcessor(ILateFrameTickManager manager)
        {
            _manager = manager;
        }
        
        public void OnServiceCreated(object service)
        {
            if (service is ILateFrameTick consumer)
                _manager.AddConsumer(consumer);
        }

        public void OnServiceDestroyed(object service)
        {
            if (service is ILateFrameTick consumer)
                _manager.RemoveConsumer(consumer);
        }
    }
}
#endif