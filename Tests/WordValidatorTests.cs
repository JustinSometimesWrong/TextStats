namespace Tests;
using TextStatsCore;

[TestClass]
public class WordValidatorTests
{
    [TestMethod]
    public void WordValidator_BasicTests()
    {
        var validator = new WordValidator();
        var input = "this is the list of valid words oh thin friend of mine!";

        validator.Setup(input.Split(" ").ToList());

        Assert.IsTrue(validator.IsValid("the"));
        Assert.IsTrue(validator.IsValid("this"));
        Assert.IsFalse(validator.IsValid("th"));
        Assert.IsFalse(validator.IsValid("mine"));        
        Assert.IsTrue(validator.IsValid("mine!"));
        Assert.IsFalse(validator.IsValid("thine"));
    }

        [TestMethod]
    public void WordValidator_WildCardTests()
    {
        var validator = new WordValidator();
        var secondInput = "this `is the `list of valid` words oh thin friend of` mine! A true win `    `";

        validator.Setup(secondInput.Split('`').ToList());
            
        Assert.IsFalse(validator.IsValid("is."));
        Assert.IsTrue(validator.IsValid("list.of.valid"));
        Assert.IsTrue(validator.IsValid("    "));        
        Assert.IsTrue(validator.IsValid("...."));
        Console.WriteLine("Hello World!");
    }
}