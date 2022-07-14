namespace Dictionary
{
    public class Program
    {
        public static void Main()
        {
            var dictionary = new Dictionary<string, string>();

            IRepository repository = new Repository();
            IMyDictionary myDictionary = new MyDictionary(repository);
            IInputValidator inputValidator = new InputValidator();

            var dic = repository.Load(dictionary);

            do
            {
                Console.Clear();

                Console.WriteLine("DICIONÁRIO\n");
                Console.WriteLine("Digite 1 para adicionar uma palavra;");
                Console.WriteLine("digite 2 para buscar uma palavra;");
                Console.WriteLine("digite 0 para sair.\n");

                var option = inputValidator.ValidateInput();

                if (option == 1)
                {
                    Console.Clear();

                    Console.WriteLine("Que palavra deseja adicionar?");
                    var word = Console.ReadLine();

                    Console.WriteLine("\nQual é o seu significado?");
                    var meaning = Console.ReadLine();

                    myDictionary.Add(dic, word!, meaning!);
                }

                if (option == 2)
                {
                    Console.Clear();

                    Console.WriteLine("Que palavra deseja buscar?");
                    var word = Console.ReadLine();
                    myDictionary.Search(dic, word!);
                    Console.ReadLine();
                }

                if (option == 0)
                    break;

            } while (true);
        }
    }
}
