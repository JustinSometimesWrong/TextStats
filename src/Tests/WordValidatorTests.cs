namespace Tests
{
    using TextStats.Core;

    [TestClass]
    public class WordValidatorTests
    {
        [TestMethod]
        public void WordValidator_BasicTests()
        {
            // Arrange
            var library = new WordLibrary();
            var input = "this is the list of valid words oh thin friend of mine!";
            foreach (var word in input.Split(" "))
            {
                library.AddWord(word);
            }

            
            var validator = new WordValidator(library);

            // Act and Assert
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
            // Arrange
            var library = new WordLibrary();
            var secondInput = "this `is the `list of valid` words oh thin friend of` mine! A true win `    `";

            foreach(var item in secondInput.Split('`'))
            {
                library.AddWord(item);
            }

            
            var validator = new WordValidator(library);

            // Act and Assert
            Assert.IsFalse(validator.IsValid("is."));
            Assert.IsTrue(validator.IsValid("list.of.valid"));
            Assert.IsTrue(validator.IsValid("    "));        
            Assert.IsTrue(validator.IsValid("...."));
            Console.WriteLine("Hello World!");
        }
    }
}