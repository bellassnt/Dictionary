namespace Dictionary
{
    public interface IRepository
    {
        Dictionary<string, string> Load(Dictionary<string, string> dictionary);

        void Save(Dictionary<string, string> dictionary);
    }
}
