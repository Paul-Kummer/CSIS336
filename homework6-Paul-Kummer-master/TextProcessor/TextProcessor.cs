using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TextUtilities
{
    public class TextProcessor
    {
        /// <summary>
        /// Read all text from uri asynchronously and summarize in a dictionary by word count
        /// </summary>
        /// <param name="fromUri">The uri of the text resource to read</param>
        /// <returns>A dictionary of all words from the text resource with word count</returns>
        public async Task<Dictionary<string,int>> ProcessTextAsync(Uri fromUri)
        {
            string text = await Task.Run(() => DownloadText(fromUri));
            return await Task.Run(() => CountWords(text));
        }

        /// <summary>
        /// Read all text from uri and summarize in a dictionary by word count
        /// </summary>
        /// <param name="fromUri">The uri of the text resource to read</param>
        /// <returns>A dictionary of all words from the text resource with word count</returns>

        public Dictionary<string, int> ProcessText(Uri fromUri)
        {
            string text = DownloadText(fromUri);
            return CountWords(text);
        }
        string DownloadText(Uri fromUri)
        {
            WebClient client = new WebClient();
            client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
            Random r = new Random();
            string text = client.DownloadString(fromUri + "?Unused=" + r.Next().ToString());
            return text;
        }
        Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> wordcounts = new Dictionary<string, int>();
            foreach (var word in text.Split(' '))
            {
                var term = RemovePunctuation(word);
                if (!string.IsNullOrWhiteSpace(term))
                {
                    if (wordcounts.ContainsKey(term))
                    {
                        wordcounts[term]++;
                    }
                    else
                    {
                        wordcounts.Add(term, 1);
                    }
                }
            }

            return wordcounts;
        }
        string RemovePunctuation(string term)
        {
            string newTerm = "";
            foreach (char c in term)
            {
                if (!Char.IsPunctuation(c)) newTerm += c;
            }
            return newTerm;
        }
    }
}
