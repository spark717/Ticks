using System.Collections.Generic;
using Spark;

namespace Tests.Editor.Fakes
{
    public class Consumer3 : IFrameTick
    {
        public int TicksCount;

        public List<int> IntList;
        
        public void OnFrameTick()
        {
            TicksCount++;
            
            if (IntList != null)
                IntList.Add(3);
        }
    }
}