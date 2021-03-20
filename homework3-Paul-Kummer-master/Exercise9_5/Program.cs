using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * a. use linq to sort the list in ascending order
 * b. use ling to sor the list in descending order
 * c. display the list in asceinding order with duplicates romoved.
 */

namespace Exercise9_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> newList = CreateRandList(30);
            AscendingList(newList);
            DescendingList(newList);
            UniqueList(newList);        
        }

        //Create random character list of 30 alphabet characters
        static List<char> CreateRandList (int numOfChars)
        {
            var badInts = new List<int>() {91,92,93,94,95,96}; //Ascii characters between 65 and 122 that are not in the alphabet
            var newInt = new Random();
            var listToReturn = new List<char>();
            int randInt;

            foreach (int count in Enumerable.Range(1,numOfChars))
            {
                //Selects a ascii number that represents an alphabet character
                do
                {
                    randInt =  newInt.Next(65,123); // changed upper bound to include lowercase z
                }while (badInts.Contains(randInt)); //eliminate non alphabet characters
                
                listToReturn.Add((char)randInt);
            }

            return listToReturn;
        }
        

        //Part a
        static void AscendingList(List<char> tmpList)
        {
            Console.WriteLine("These are chars ascending");

            var ascQuery =
                from tmpChar in tmpList
                orderby tmpChar ascending
                select tmpChar;

            foreach (var tmp in ascQuery)
            {
                Console.Write((char)tmp + ", ");
            }
        }

        //Part b
        static void DescendingList(List<char> tmpList)
        {
            Console.WriteLine("\n\nThese are chars descending");

            var descQuery =
                from tmpChar in tmpList
                orderby tmpChar descending
                select tmpChar;

            foreach (var tmp in descQuery)
            {
                Console.Write((char)tmp + ", ");
            }
        }

        //Part c
        static void UniqueList(List<char> tmpList)
        {
            Console.WriteLine("\n\nThese are Distinct chars ascending");

             var distQuery =
                from tmpChar in tmpList
                orderby tmpChar ascending // changed to ascending as it should be
                select tmpChar;

            foreach (var tmp in distQuery.Distinct())
            {
                Console.Write((char)tmp + ", ");
            }
        }
      
    }
}
