using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TextUtilities;

namespace DownloadBookText
{
    class Program
    {
        static void Main(string[] args)
        {
            WordScanWithTasks();

            // Run for time comparisons
            #region time differences
            /*
            int oldTime = 0, newTime = 0, runs = 0;

            for(; runs < 5; ++runs)
            {
                newTime += WithTasksTime().Milliseconds;
                oldTime += Original().Milliseconds;
            }
            
            Console.WriteLine($"\n*** Avg Time of Original Code: {oldTime/runs}ms ***");
            Console.WriteLine($"\n*** Avg Time of Code using Tasks: {newTime/runs}ms ***");
            */
            #endregion        

            Console.ReadKey();
        }

        static TimeSpan Original()
        {
            var startTime = DateTime.Now;
            // Get uris for the first 20 chapters of Moby Dick
            var uris = GetMobyDickUris();

            // Initialize variables
            TextProcessor textProcessor = new TextProcessor();
            Dictionary<string, int> masterWordList = new Dictionary<string, int>();
            int numWords = 200;

            foreach (var uri in uris)
            {
                // Download book text and get word count
                var chapterWords = textProcessor.ProcessText(uri);

                // Merge top n words into the master word list
                MergeDictionaries(chapterWords, masterWordList, numWords);
            }

            return DateTime.Now - startTime;
        }

        static TimeSpan WithTasksTime()
        {
            var startTime = DateTime.Now;

            // Get uris for the first 20 chapters of Moby Dick
            var uris = GetMobyDickUris();

            // Initialize variables
            TextProcessor textProcessor = new TextProcessor();
            Dictionary<string, int> masterWordList = new Dictionary<string, int>();
            int numWords = 200;

            Task<Dictionary<string, int>>[] tasks = new Task<Dictionary<string, int>>[uris.Length];
            int arrayPos = 0;

            foreach (var uri in uris)
            {
                // Download book text and get word count
                var chapterWords = textProcessor.ProcessTextAsync(uri);

                tasks[arrayPos++] = chapterWords;

                // Merge top n words into the master word list
                MergeDictionaries(chapterWords.Result, masterWordList, numWords);
            }

            Task.WaitAll(tasks);

            return DateTime.Now - startTime;
        }

        static void WordScanWithTasks()
        {
            // Get uris for the first 20 chapters of Moby Dick
            var uris = GetMobyDickUris();

            // Initialize variables
            TextProcessor textProcessor = new TextProcessor();
            Dictionary<string, int> masterWordList = new Dictionary<string, int>();
            int numWords = 200;

            Task<Dictionary<string, int>>[] tasks = new Task<Dictionary<string, int>>[uris.Length];
            int arrayPos = 0;

            foreach (var uri in uris)
            {
                // Download book text and get word count
                var chapterWords = textProcessor.ProcessTextAsync(uri);
                tasks[arrayPos++] = chapterWords;

                // Merge top n words into the master word list
                MergeDictionaries(chapterWords.Result, masterWordList, numWords);

                // Write out number of words found
                Console.WriteLine($"Got {chapterWords.Result.Count} words from {Path.GetFileName(uri.LocalPath)}");
            }

            Task.WaitAll(tasks);

            // Write out top n words from master word list
            Console.WriteLine($"\nThe top {numWords} words from the first {uris.Count()} chapters of Moby Dick:");

            masterWordList
                .OrderByDescending(w => w.Value)
                .Take(numWords)
                .ToList()
                .ForEach((kvp) => Console.WriteLine($"\t{kvp.Key} : {kvp.Value}"));
        }

        /// <summary>
        /// Get web Uris to the text of the first 10 chapters of Moby Dick
        /// </summary>
        /// <returns>An array of Uris - one for each chapter</returns>

        static Uri[] GetMobyDickUris()
        {
            string url = "https://gist.githubusercontent.com/dseefeld/e29a428d875d9179feab19ddf17ac793/raw/1fa2e2e7f9f6bcf3dde7c07b5565a9f911e27842/";
            Uri[] mobyDickChapterUris = Enumerable.Range(1,20).Select(i => new Uri($"{url}MobyDick{i}.txt")).ToArray();
            return mobyDickChapterUris;
        }

        /// <summary>
        /// Merge one dictionary into another, selecting top n entries by value count
        /// </summary>
        static void MergeDictionaries(Dictionary<string,int> fromDictionary, Dictionary<string, int> toDictionary, int numItems)
        {
            fromDictionary.OrderByDescending(kvp => kvp.Value).Take(numItems).ToList().ForEach(kvp =>
            {
                if (toDictionary.ContainsKey(kvp.Key))
                    toDictionary[kvp.Key] += kvp.Value;
                else
                    toDictionary[kvp.Key] = kvp.Value;
            });
        }
    }
}
