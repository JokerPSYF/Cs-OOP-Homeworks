namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (!char.IsDigit(num[i]))
                {
                    return "Invalid number!";
                }
            }

            return $"Calling... {num}";
        }

        public string Browse(string site)
        {
            for (int i = 0; i < site.Length; i++)
            {
                if (char.IsDigit(site[i]))
                {
                    return "Invalid URL!";
                }
            }

            return $"Browsing: {site}!";
        }
    }
}