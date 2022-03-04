using System;

namespace Telephony
{
    public class StationaryPhone : ICallable
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

            return $"Dialing... {num}";
        }
    }
}