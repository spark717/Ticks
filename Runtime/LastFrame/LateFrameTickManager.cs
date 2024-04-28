using System;

namespace Spark
{
    public interface ILateFrameTickManager : ITickManager<ILateFrameTick>
    {
    }
    
    public class LateFrameTickManager : TickManagerBase<ILateFrameTick>, ILateFrameTickManager
    {
        public LateFrameTickManager(Type[] order) : base(order)
        {
        }

        protected override void ExecuteTick(ILateFrameTick item)
        {
            item.OnLateFrameTick();
        }
    }
}