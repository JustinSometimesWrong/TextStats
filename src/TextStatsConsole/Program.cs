
using TextStats.Core;

internal class Program
{
    static void Main(string[] args)
    {
        
        var library = new WordLibrary();
        // var filePath = Path.Combine(Environment.CurrentDirectory, "engmix.txt");
        string[] wordList = {"this", "that" , "the", "other", "thing", "Thing"};
        library.Build(wordList);

        var autoComplete = new AutoComplete(library);
        Console.WriteLine("Type to suggest a word");
        var input = Console.ReadLine();
        var suggestion = autoComplete.SuggestWord(input);

        Console.WriteLine($"Suggested word is {suggestion}");
    }
}