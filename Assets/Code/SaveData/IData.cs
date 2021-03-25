namespace Code.SaveData
{
    public interface IData<T>
    {
        void Save(T Data, string path = null);
        T Load(string path = null);
    }
}