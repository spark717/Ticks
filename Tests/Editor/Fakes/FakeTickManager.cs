using System;
using Spark;

namespace Tests.Editor.Fakes
{
    public class FakeTickManager : TickManagerBase<IFrameTick>
    {
        public FakeTickManager(Type[] order) : base(order)
        {
        }

        protected override void ExecuteTick(IFrameTick item)
        {
            item.OnFrameTick();
        }
    }
}