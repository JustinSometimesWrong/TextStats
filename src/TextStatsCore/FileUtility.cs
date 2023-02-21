
using System.Globalization;
using System.Text;

namespace TextStats.Core
{
    public class FileUtility
    {
        public static IEnumerable<string> ParseFileByLine(string fileName)
        {
            using StreamReader reader = File.OpenText(fileName);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        public static IEnumerable<string> ParseFileByWord(string fileName)
        {
            StreamReader reader = File.OpenText(fileName);
            int current;
            StringBuilder word = new StringBuilder();
            while ((current = reader.Read()) > 1)
            {
                var character = (char)current;
                if (character == '-')
                {
                    var nextChar = (char)reader.Peek();
                    var category = Char.GetUnicodeCategory(nextChar);
                    if(category == UnicodeCategory.LineSeparator || category == UnicodeCategory.Control)
                    {
                        while(!Char.IsLetter((char)reader.Peek()))
                        {
                            // hyphen at end of line advance to next letter
                            reader.Read();
                        }
                        continue;
                    }
                }


                if (!IsWordBoundary(character, word))
                {
                    word.Append(character);
                    continue;
                }

                if (word.Length > 0)
                {
                    yield return word.ToString().ToLowerInvariant();
                    word.Clear();
                }
            }

            if (word.Length > 0)
            {
                yield return word.ToString().ToLowerInvariant();
            }
        }

        private static bool IsWordBoundary(char character, StringBuilder word)
        {
            var unicodeCategory = Char.GetUnicodeCategory(character);
            switch (unicodeCategory)
            {
                case System.Globalization.UnicodeCategory.DashPunctuation:
                    return false;
                case System.Globalization.UnicodeCategory.LineSeparator:
                case System.Globalization.UnicodeCategory.Control:
                    return true;

            }


            if (Char.IsSeparator(character))
            {
                return true;
            }
            else if (Char.IsPunctuation(character))
            {
                return true;
            }

            return false;
        }
    }
}