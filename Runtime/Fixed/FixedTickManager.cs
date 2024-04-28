using System;

namespace Spark
{
    public interface IFixedTickManager : ITickManager<IFixedTick>
    {
    }
    
    public class FixedTickManager : TickManagerBase<IFixedTick>, IFixedTickManager
    {
        public FixedTickManager(Type[] order) : base(order)
        {
        }

        protected override void ExecuteTick(IFixedTick item)
        {
            item.OnFixedTick();
        }
    }
}