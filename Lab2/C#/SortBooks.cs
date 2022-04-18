using System.Collections.Generic;

namespace Lab2_BinaryFiles
{
    public class SortBooks
    {
        public static List<Book> SortByName(List<Book> authorsBooks)
        {
            for (int i = 0; i < authorsBooks.Count; i++)
            {
                int currentLetter = 0;
                for (int j = 0; j < authorsBooks.Count - i - 1;)
                {
                    authorsBooks = _swapByDemands(authorsBooks, ref j, ref currentLetter);
                }
            }

            return authorsBooks;
        }

        private static List<Book> _swapByDemands(List<Book> authorsBooks, ref int j, ref int currentLetter)
        {
            bool areSmallEnough = currentLetter < authorsBooks[j].Name.Length &&
                                  currentLetter < authorsBooks[j + 1].Name.Length;
            bool demands = authorsBooks[j].Name[currentLetter] == authorsBooks[j + 1].Name[currentLetter] &&
                           areSmallEnough;
            if (authorsBooks[j].Name[currentLetter] > authorsBooks[j + 1].Name[currentLetter])
            {
                (authorsBooks[j], authorsBooks[j + 1]) = (authorsBooks[j + 1], authorsBooks[j]);
                j++;
                currentLetter = 0;
            }
            else if (demands)
                currentLetter++;
            else
            {
                j++;
                currentLetter = 0;
            }

            return authorsBooks;
        }
    }
}