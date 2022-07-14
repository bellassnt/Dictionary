namespace Dictionary
{
    public interface IMyDictionary
    {
        void Add(Dictionary<string, string> dictionary, string word, string meaning);

        void Search(Dictionary<string, string> dictionary, string word);
    }
}
