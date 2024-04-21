using System;

namespace Spark
{
    public interface IFrameTickManager : ITickManager<IFrameTick>
    {
    }
    
    public class FrameTickManager : TickManagerBase<IFrameTick>, IFrameTickManager
    {
        public FrameTickManager(Type[] order) : base(order, FrameTickProducer.Create())
        {
        }

        protected override void ExecuteTick(IFrameTick item)
        {
            item.OnFrameTick();
        }
    }
}