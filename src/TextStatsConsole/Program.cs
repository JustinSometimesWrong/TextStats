
using TextStats.Core;

internal class Program
{
    static void Main(string[] args)
    {

        var library = new WordLibrary();
        var input = "this is the list of valid words oh thin friend of mine!";

        foreach(var item in input.Split(' '))
        {
            library.AddWord(item);
        }

            
        var validator = new WordValidator(library);
 


        Console.WriteLine(validator.IsValid("the"));
        Console.WriteLine(validator.IsValid("this"));
        Console.WriteLine(validator.IsValid("th"));
        Console.WriteLine(validator.IsValid("mine"));        
        Console.WriteLine(validator.IsValid("mine!"));
        Console.WriteLine(validator.IsValid("thine"));
        Console.WriteLine("Hello World!");
    }
}