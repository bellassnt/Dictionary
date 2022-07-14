namespace Dictionary
{
    public class MyDictionary : IMyDictionary
    {
        private string? Word { get; set; }
        private string? Meaning { get; set; }

        private readonly IRepository? _repository;
        private readonly IWildcardsForbider? _wildcardsForbider;

        public MyDictionary(IRepository repository, IWildcardsForbider wildcardsForbider)
        {
            _repository = repository;
            _wildcardsForbider = wildcardsForbider;
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
            if (!_wildcardsForbider!.ForbidWildcards(word))
            {
                Console.WriteLine("\nA busca deve conter apenas letras e/ou espaços vazios (no caso de verbos frasais).");
                return;
            }

            Console.WriteLine();

            int i = 0;
            foreach (var entry in dictionary)
            {
                if (entry.Key.Contains(word, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}.");
                    i++;
                }                    
            }

            if (i == 0) Console.WriteLine("Não há correspondência para essa busca.");
        }
    }
}
