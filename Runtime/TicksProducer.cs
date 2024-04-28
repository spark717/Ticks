using UnityEngine;

namespace Spark
{
    public class TicksProducer : MonoBehaviour
    {
        public FrameTickManager Frame;
        public LateFrameTickManager LateFrame;
        public FixedTickManager Fixed;
        
        private void Update()
        {
            Frame?.ProcessTick();
        }

        private void LateUpdate()
        {
            LateFrame?.ProcessTick();
        }

        private void FixedUpdate()
        {
            Fixed?.ProcessTick();
        }
    }
}