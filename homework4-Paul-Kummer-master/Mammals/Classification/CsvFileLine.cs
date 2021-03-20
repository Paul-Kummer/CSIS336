using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mammals.Classification
{
    public class CsvFileLine
    {
        private readonly string[] lineData;
        private static Dictionary<string, int> headerIndexes = new Dictionary<string, int>();
        public CsvFileLine(string line)
        {
            lineData = line.SplitWithQuotes(',');
        }
        public static void SetColumnHeaders(string line)
        {
            var headers = line.Split(',');
            for (int i = 0; i < headers.Length; i++)
            {
                headerIndexes.Add(headers[i], i);
            }
        }
        public string this[string key]
        {
            get
            {
                if (!headerIndexes.ContainsKey(key)) throw new IndexOutOfRangeException();
                return lineData[headerIndexes[key]];
            }
        }
    }
    public static class StringExtensions
    { 
        public static string[] SplitWithQuotes(this string line, char separator)
        {
            bool inQuoted = false;
            List<string> splitLine = new List<string>();
            StringBuilder word = new StringBuilder("");
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                char lookAhead = line.Length == i + 1 ? ' ' : line[i + 1];
                switch (c)
                {
                    case '"' when inQuoted && lookAhead == '"':
                        word.Append(c);
                        i++;
                        break;
                    case '"':
                        inQuoted = !inQuoted;
                        break;
                    case ',' when !inQuoted:
                        splitLine.Add(word.ToString());
                        word = new StringBuilder("");
                        break;
                    case ',' when inQuoted:
                    default:
                        word.Append(c);
                        break;
                }
            }
            return splitLine.ToArray();
        }
    }
}
