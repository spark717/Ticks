namespace Spark
{
    public interface ILateFrameTick : ITick
    {
        public void OnLateFrameTick();
    }
}