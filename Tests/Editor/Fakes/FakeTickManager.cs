using System;
using Spark;

namespace Tests.Editor.Fakes
{
    public class FakeTickManager : TickManagerBase<IFrameTick>
    {
        public FakeTickManager(Type[] order, ITickProducer tickProducer) : base(order, tickProducer)
        {
        }

        protected override void ExecuteTick(IFrameTick item)
        {
            item.OnFrameTick();
        }
    }
}