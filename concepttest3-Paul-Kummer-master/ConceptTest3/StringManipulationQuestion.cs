using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptTest3
{
    public class StringManipulationQuestion
    {
        public void Execute()
        {
            Console.WriteLine("\nString Manipulation Question:");
            var userData = GetText();
            string[] userText = userData.Item1;
            string searchTerm = userData.Item2;

            //----------------------------------------------------------------------------------------------------------
            // Question #1: Use string manipulation statements to output the entered userText with the searchTerm 
            //              printed in red.  Match the searchTerm using case-insensitive search.  Use the ColorWrite() 
            //              method to change the color of outputted text.

            ColorWrite(ConsoleColor.Blue, "\nOutput with Highlighted Search Term:", true);
           
            foreach (var uText in userText)
            {
                if(uText.ToLower().Split(' ').Contains(searchTerm.ToLower()))
                {
                    foreach(var word in uText.Split(' '))
                    {
                        if( word.ToLower() == searchTerm.ToLower())
                        {
                            ColorWrite(ConsoleColor.Red, word + " ");
                        }

                        else
                        {
                            Console.Write(word + " ");
                        }
                    }
                    Console.Write("\n");
                }

                else
                {
                    Console.WriteLine(uText);
                }
            }
        }

        #region HelperCode
        private void ColorWrite(ConsoleColor color, string text, bool addNewline = false)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            if (addNewline) Console.WriteLine();
            Console.ResetColor();
        }

        private Tuple<string[], string> GetText()
        {
            ColorWrite(ConsoleColor.Blue, "Enter text (q to quit):", true);
            List<string> text = new List<string>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line.ToLower() == "q") break;
                text.Add(line);
            }
            ColorWrite(ConsoleColor.Blue, "Enter a search term:", true);
            string term = Console.ReadLine();
            return new Tuple<string[], string>(text.ToArray(), term);
        }
        #endregion
    }
}
