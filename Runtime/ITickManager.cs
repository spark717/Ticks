namespace Spark
{
    public interface ITickManager<T> where T : ITick
    {
        public void AddConsumer(T consumer);
        public void RemoveConsumer(T consumer);
    }
}