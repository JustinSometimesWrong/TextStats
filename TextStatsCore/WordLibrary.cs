namespace TextStats.Core;


public interface IWordLibrary
{
    void AddWord(string text);
    CharacterNode GetWordTrie();
}

public class WordLibrary : IWordLibrary
{
    public SortedSet<Word> allWords = new SortedSet<Word>();

    public CharacterNode rootTrieNode = new CharacterNode();

    public void AddWord(string text)
    {
        var input = this.NormalizeInput(text);
        var foundWord = allWords.FirstOrDefault<Word>(x => x.ToString() == input);
        if(foundWord != null)
        {
            foundWord.Count++;
            return;
        }

        this.allWords.Add(new Word(input));
        this.rootTrieNode.AddToNode(input);
        
    }

    public CharacterNode GetWordTrie()
    {
        return this.rootTrieNode;
    }

    private string NormalizeInput(string text)
    {
        return text.ToLowerInvariant();
    }
}