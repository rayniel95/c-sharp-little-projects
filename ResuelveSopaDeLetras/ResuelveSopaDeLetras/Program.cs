using System;

namespace ResuelveSopaDeLetras
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] soup = {{'a', 'a', 'f', 't', 'j', 'q', 'w', 'e', 'r', 'o', 'p'},
                            {'g', 'j', 'p', 'b', 'j', 'e', 'r', 'o', 'a', 's', 'k'},
                            {'l', 'x', 'c', 'e', 't', 'y', 'e', 'r', 'a', 'o', 'n'},
                            {'b', 'g', 'j', 'f', 'l', 'd', 'e', 'r', 's', 't', 'o'},
                            {'q', 'u', 'e', 'r', 't', 'o', 'g', 's', 'e', 'm', 't'}};

            Console.WriteLine(IsInSoup(soup, "bacalao"));
   
        }
        static bool IsValid(char[, ] table, int row, int column)
        {
            if ((row < 0) || (row >= table.GetLength(0)) || (column < 0) || (column >= table.GetLength(1)))
                return false;
            return true;
        }
        static bool IsInSoup(char[, ] soup, string word)
        {
            // Norte, Sur, Este, Oeste, NorEste, NorOeste, SurEste, SurOeste

            int[] movRow = { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] movColumn = { 0, 0, -1, 1, -1, 1, -1, 1 };

            int newRow = 0;
            int newColumn = 0;
            
            int first = 0;

            for(int firstIndex = 0; soup.GetLength(0) > firstIndex; firstIndex++)
            {
                for(int secondIndex = 0; soup.GetLength(1) > secondIndex; secondIndex++)
                {
                    for(int index = 0; movRow.Length > index; index++)
                    {
                        newRow = firstIndex;
                        newColumn = secondIndex;

                        first = 0;

                        while(IsValid(soup, newRow, newColumn) && (first < word.Length))
                        {
                            if (soup[newRow, newColumn].ToString() == word.Substring(first, 1))
                            {
                                newRow += movRow[index];
                                newColumn += movColumn[index];

                                first++;

                                if (first == (word.Length - 1))
                                    return true;
                            }
                            else
                                break;
                        }
                    }
                }
            }
            return false;
        }
    }
}
