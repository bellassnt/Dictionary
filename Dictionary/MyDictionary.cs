namespace Dictionary
{
    public class MyDictionary : IMyDictionary
    {
        private string? Word { get; set; }
        private string? Meaning { get; set; }

        private readonly IRepository? _repository;

        public MyDictionary(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(Dictionary<string, string> dictionary, string word, string meaning)
        {
            Word = word;
            Meaning = meaning;
            dictionary.Add(Word!, Meaning!);
            _repository!.Save(dictionary);
        }

        public void Search(Dictionary<string, string> dictionary, string word)
        {
            if (!dictionary.TryGetValue(word, out _))
                Console.Write("\nNão há correspondência exata para essa busca.\n");

            Console.WriteLine();

            foreach (var entry in dictionary)
            {
                if (entry.Key.Contains(word, StringComparison.InvariantCultureIgnoreCase))
                    Console.WriteLine($"{entry.Key}: {entry.Value}.");                
            }
        }
    }
}
