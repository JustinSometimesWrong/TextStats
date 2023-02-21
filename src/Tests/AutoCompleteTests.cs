namespace Tests
{
    using TextStats.Core;

    [TestClass]
    public class AutoCompleteTests
    {
        [TestMethod]
        public void AutoCompleteTests_BasicTests()
        {
            // Arrange
            var library = new WordLibrary();
            string[] wordList = {"this", "that" , "the", "there", "other", "thing", "Thing"};
            library.Build(wordList);

            
            var autoComplete = new AutoComplete(library);

            // Act and Assert
            Assert.AreEqual("the", autoComplete.SuggestWord("the"));
            Assert.AreEqual("this", autoComplete.SuggestWord("th"));
            Assert.AreEqual("there", autoComplete.SuggestWord("ther"));
            Assert.AreEqual("them", autoComplete.SuggestWord("them"));
        }
    }
}