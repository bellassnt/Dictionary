namespace Dictionary
{
    public class WildcardsForbider : IWildcardsForbider
    {
        public bool ForbidWildcards(string word)
        {
            foreach (char c in word)
            {
                if (!char.IsLetter(c) && !(c == ' '))
                    return false;
            }

            return true;
        }
    }
}
