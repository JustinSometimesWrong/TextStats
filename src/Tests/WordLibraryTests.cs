
namespace Tests
{
    using TextStats.Core;

    [TestClass]
    public class WordLibraryTests
    {
    
        [TestMethod]
        public void WordLibrary_Build_WordCount()
        {
            string[] wordList = {"this", "that" , "the", "other", "thing", "Thing"};

            var wordLibrary = new WordLibrary();
            wordLibrary.Build(wordList);

            Assert.AreEqual(5, wordLibrary.AllWords.Count);

            var thingWord = wordLibrary.AllWords.FirstOrDefault(x => x.ToString() == "thing");
            Assert.AreEqual(2, thingWord.Count);

            var node = wordLibrary.RootTrieNode;
            Assert.AreEqual(2, node.NextLetters.Count);
        }
    }

}