
using TextStats.Core;

internal class Program
{
    static void Main(string[] args)
    {

        var validator = new WordValidator();
        var input = "this is the list of valid words oh thin friend of mine!";

        validator.Setup(input.Split(" ").ToList());

        Console.WriteLine(validator.IsValid("the"));
        Console.WriteLine(validator.IsValid("this"));
        Console.WriteLine(validator.IsValid("th"));
        Console.WriteLine(validator.IsValid("mine"));        
        Console.WriteLine(validator.IsValid("mine!"));
        Console.WriteLine(validator.IsValid("thine"));
        Console.WriteLine("Hello World!");
    }
}