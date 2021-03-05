using System;

namespace IsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsSubstring("soladez", "dez"));
        }
        static bool IsSubstring(string firstString, string secondString)
        {
            bool isSubstring = false;
            int index = 0;

            for(int firstIndex = 0; firstString.Length > firstIndex; firstIndex++)
            {
                index = 0;

                for (int secondIndex = 0; secondString.Length > secondIndex; secondIndex++)
                {
                    if (firstString[firstIndex + index] == secondString[secondIndex])
                    {
                        index++;

                        if (index == (secondString.Length - 1))
                            return true;

                        continue;
                    }
                    else
                    {
                        isSubstring = false;
                        break;
                    }
                }
            }
            return isSubstring;
        }
    }
}
