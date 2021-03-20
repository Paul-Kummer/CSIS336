using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(ValidateDirectories(args))
            {
                string inDir = args[0];
                string outDir = args[1];

                var currentFiles = System.IO.Directory.GetFiles(inDir, "*.txt", SearchOption.AllDirectories);
                
                foreach(string tmpFilePath in currentFiles)
                {
                    ProcessTextFile(tmpFilePath, inDir, outDir);
                }
            }   
        }

        static bool ValidateDirectories(string[] tmpDirs)
        {
            bool validDirs = false;

            // ensure at least two command line parameters were provided
            // then check that input directory, first param, is a valid directory
            // and output directory, second param, does not exist
            try
            {
                string inputPath = System.IO.Directory.Exists(tmpDirs[0]) ? tmpDirs[0] : null;
                string outputPath = System.IO.Directory.Exists(tmpDirs[1]) ? null : tmpDirs[1];


                if (inputPath == null | outputPath == null)
                {
                    Console.WriteLine("\n--- Invalid Directories ---" +
                        "\nInput directory must exist and Output directory must not exist" +
                        $"\n\nSelected Input Directory: {inputPath}" +
                        $"\nSelected Output Directory: {outputPath}");
                }

                else
                { 
                    validDirs = true;
                }
            }

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"--- ERROR --- \n{e.Message}");
            }

            return validDirs;
        }

        static void ProcessTextFile(string filePath, string inputDir, string outputDir)
        {
            string fileName = filePath.Split('\\').Last().Replace(".txt", "");
            outputDir = outputDir + filePath.Replace(inputDir, "").Replace(fileName + ".txt", ""); // adds subdirectories of where the original file was
            var comments = new List<string> { };
            Dictionary<string, int> wordDict = new Dictionary<string, int>() { };

            //TextReader curFile = System.IO.File.OpenText(filePath); not needed
            var fileLines = System.IO.File.ReadLines(filePath);

            foreach (string line in fileLines)
            {
                // check for comment and add it to a commment list
                if (line.StartsWith("#"))
                {
                    comments.Add(line);
                    Console.WriteLine(line);
                }

                // split the line into words then remove all white spaces and punctuation and put
                // the lowercase word into a dictionary and increase count if it already exists
                else
                {
                    var wordArray = line.Split(' ');

                    foreach (string word in wordArray)
                    {
                        string newWord = "";

                        for (int pos = 0; pos < word.Length; pos++)
                        {
                            if (!char.IsWhiteSpace(word[pos]) & !char.IsPunctuation(word[pos]))
                            {
                                newWord += word[pos];
                            }
                        }

                        newWord = newWord.ToLower();

                        if (wordDict.ContainsKey(newWord))
                        {
                            ++wordDict[newWord];
                        }

                        else
                        {
                            // make sure the line isn't a space before adding to dictionary
                            if (newWord != "") { wordDict[newWord] = 1; }
                        }
                    }
                }
            }

            // keeping the select statement as a single string allows it to be put directly into AppendAllLines
            var wordCounts = (from word in wordDict.Keys
                              orderby wordDict[word] descending
                              select word + " " + wordDict[word].ToString()).ToArray();
                             

            System.IO.Directory.CreateDirectory(outputDir); // adds any child directories to the ouput parent and creates parent if it doesn't exist
            System.IO.File.WriteAllLines(outputDir + @"\" + fileName + "-info.txt", comments);
            System.IO.File.AppendAllLines(outputDir + @"\" + fileName + "-info.txt", wordCounts);        
        }
    }
}

