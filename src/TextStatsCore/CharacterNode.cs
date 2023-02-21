namespace TextStats.Core
{
public class CharacterNode
{
    public char Character { get; private set; }

    public bool IsEndOfWordCharacter { get; private set;}

    public CharacterNode()
    {
        
    }

    public CharacterNode(char character)
    {
        this.Character = character;
    }

    public Dictionary<char, CharacterNode> NextLetters { get; private set; } = new Dictionary<char, CharacterNode>();

    public void AddToNode(string remainingWord)
    {
        if(string.IsNullOrEmpty(remainingWord))
        {
            this.IsEndOfWordCharacter = true;
            return;
        }

        var firstLetter = remainingWord.First();
        CharacterNode node;
        if (!this.NextLetters.TryGetValue(firstLetter, out node))           
        {
            node = new CharacterNode(firstLetter);
            this.NextLetters.Add(firstLetter, node);
        }

        var substring = remainingWord.Substring(1);
        node.AddToNode(substring);
    }
}
}