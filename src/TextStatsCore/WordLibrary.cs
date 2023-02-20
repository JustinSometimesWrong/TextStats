namespace TextStats.Core;

public interface IWordLibrary
{
    void AddWord(string text);
    CharacterNode GetWordTrie();
}

public class WordLibrary : IWordLibrary
{
    private SortedSet<Word> allWords = new SortedSet<Word>();

    public CharacterNode RootTrieNode { get; } = new CharacterNode();

    public IReadOnlySet<Word> AllWords => this.allWords;

    public void Build(IEnumerable<string> words)
    {
        foreach(var item in words)
        {
            this.AddWord(item);
        }
    }

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
        this.RootTrieNode.AddToNode(input);
        
    }

    public CharacterNode GetWordTrie()
    {
        return this.RootTrieNode;
    }

    private string NormalizeInput(string text)
    {
        return text.ToLowerInvariant();
    }
}