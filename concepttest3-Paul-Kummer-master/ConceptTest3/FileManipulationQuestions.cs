using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptTest3
{
    public class FileManipulationQuestions
    {
        public void Execute()
        {
            Console.WriteLine("\nFile Manipulation Question:");

            while (true)
            {
                Console.WriteLine("\nEnter a directory name (enter q to quit)");
                string dirname = Console.ReadLine();
                if (dirname.ToLower() == "q") break;

                recursiveDirScanAndPrint(dirname);
            }
        }

        public void recursiveDirScanAndPrint(string tmpPath)
        {
            if (Directory.Exists(tmpPath))
            {
                var curDir = Directory.GetFileSystemEntries(tmpPath);

                var dirs = (from contents in curDir
                            where Directory.Exists(contents)
                            orderby contents descending
                            select contents).ToArray();

                var files = from contents in curDir
                            where File.Exists(contents)
                            orderby contents descending
                            select contents;

                // print out all files in the directory before moving to any subdirectorys
                foreach (var tmpFile in files)
                {
                    Console.WriteLine(Path.GetExtension(tmpFile) +
                            " : " + Path.GetFileNameWithoutExtension(tmpFile) +
                            " : " + File.GetCreationTime(tmpFile));
                }

                foreach(var tmpDir in dirs)
                {
                    Console.WriteLine("Directory" +
                            " : " + tmpDir +
                            " : " + Directory.GetCreationTimeUtc(tmpDir));
                    recursiveDirScanAndPrint(tmpDir);
                }
            }

            else
            {
                Console.WriteLine($"--- Error --- [ The Directory {tmpPath} Could Not Be Found ]");
            }
        }
    }
}
