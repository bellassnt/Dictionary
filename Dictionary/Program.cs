using Microsoft.Extensions.DependencyInjection;

namespace Dictionary
{
    public class Program
    {
        public static void Main()
        {       
            var serviceCollection = new ServiceCollection()
                .AddScoped<IRepository, Repository>()
                .AddScoped<IWildcardsForbider, WildcardsForbider>()
                .AddScoped<IMyDictionary, MyDictionary>()
                .AddScoped<IInputValidator, InputValidator>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var repository = serviceProvider.GetService<IRepository>();
            var inputValidator = serviceProvider.GetService<IInputValidator>();
            var myDictionary = serviceProvider.GetService<IMyDictionary>();

            var dictionary = new Dictionary<string, string>();
            var dic = repository!.Load(dictionary);

            // Não implementa Open-Closed Principle (OCP) =(
            do
            {
                Console.Clear();

                Console.WriteLine("DICIONÁRIO\n");
                Console.WriteLine("Digite 1 para adicionar uma palavra;");
                Console.WriteLine("digite 2 para buscar uma palavra;");
                Console.WriteLine("digite 0 para sair.\n");

                var option = inputValidator!.ValidateInput();

                if (option == 1)
                {
                    Console.Clear();

                    Console.WriteLine("Que palavra deseja adicionar?");
                    var word = Console.ReadLine();

                    Console.WriteLine("\nQual é o seu significado?");
                    var meaning = Console.ReadLine();

                    myDictionary!.Add(dic, word!, meaning!);
                }

                else if (option == 2)
                {
                    Console.Clear();

                    Console.WriteLine("Que palavra deseja buscar?");
                    var word = Console.ReadLine();
                    myDictionary!.Search(dic, word!);
                    Console.ReadLine();
                }

                else
                    break;

            } while (true);
        }
    }
}
