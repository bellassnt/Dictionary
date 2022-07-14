namespace Dictionary
{
    public class InputValidator : IInputValidator
    {
        public int ValidateInput()
        {
            int option;
            bool attempt;
            do
            {
                Console.Write("Dígito: ");
                attempt = int.TryParse(Console.ReadLine()!, out option);
            } while (!attempt || option < 0 || option > 2);

            return option;
        }
    }
}
