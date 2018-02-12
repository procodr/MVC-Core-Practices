using System;

namespace FizFuz
{
    public class FizFuz
    {
        public string Execute(int input)
        {
            string output = "";
            for (int i = 1; i <= input; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    output += "fizfuz,";
                }
                else if (i % 5 == 0)
                {
                    output += "fuz,";
                }
                else if (i % 3 == 0)
                {
                    output += "fiz,";
                }
                else
                {
                    output += i + ",";
                }
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
    }
}
