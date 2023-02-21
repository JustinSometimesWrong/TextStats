
using TextStats.Core;

internal class Program
{
    static void Main(string[] args)
    {
        
        var library = new WordLibrary();
        library.Build(FileUtility.ParseFileByLine(@"C:\Users\Justi\Projects\TextStats\TextStats\engmix.txt"));

        var autoComplete = new AutoComplete(library);
        Console.WriteLine("Type to suggest a word");
        var input = Console.ReadLine();
        var suggestion = autoComplete.SuggestWord(input);

        Console.WriteLine($"Suggested word is {suggestion}");
    }
}