namespace Tests
{
    using TextStats.Core;

    [TestClass]
    public class FileUtilityTests
    {

        [TestMethod]
        public void FileUtility_ParseFileByLine()
        {
            var fileContentEnumerator = FileUtility.ParseFileByLine("./TestInputs/FileParseByLine.txt").GetEnumerator();
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("This", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("is", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("the", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("file", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("with text on each line.", fileContentEnumerator.Current);
            Assert.IsFalse(fileContentEnumerator.MoveNext());
        }

                [TestMethod]
        public void FileUtility_ParseFileByWord()
        {
            var fileContentEnumerator = FileUtility.ParseFileByWord("./TestInputs/FileParseByWord.txt").GetEnumerator();
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("this", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("is", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("the", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("file", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("with", fileContentEnumerator.Current); 
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("text", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("on", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("one", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual("line", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual( "boo-yah", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual( "more", fileContentEnumerator.Current);
            fileContentEnumerator.MoveNext();
            Assert.AreEqual( "something", fileContentEnumerator.Current);
            Assert.IsFalse(fileContentEnumerator.MoveNext());
        }
    }
}