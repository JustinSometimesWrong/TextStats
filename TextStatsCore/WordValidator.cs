namespace TextStats.Core;
public class Node
{
    public char Character { get; private set; }

    public bool isEndOfWordCharacter { get; private set;}

    public Node(char character)
    {
        this.Character = character;;
    }

    public Dictionary<char, Node> NextLetters { get; private set; } = new Dictionary<char, Node>();

    public bool IsValid(string letters)
    {
        var numberOfChildNodes = this.NextLetters.Count;
        var remainingLetters = letters.Length;
        if(remainingLetters == 0)
        {
            if(numberOfChildNodes == 0 || this.isEndOfWordCharacter)            
            {
                return true;
            }

            return false;
        }

        var firstLetter = letters.First();
        Node node;
        if(firstLetter == '.')
        {
            foreach(var childNode in this.NextLetters.Values)
            {
                var substring = letters.Substring(1); 
                if(childNode.IsValid(substring))
                {
                    return true;
                }
            }

            return false;
        }
        else 
        {
            if (!this.NextLetters.TryGetValue(firstLetter, out node))
            {
                // no matching node for next letter
                return false;
            }

            var substring = letters.Substring(1); 
            return  node.IsValid(substring);
        }
    }

    public void AddToNode(string remainingWord)
    {
        if(string.IsNullOrEmpty(remainingWord))
        {
            this.isEndOfWordCharacter = true;
            return;
        }

        var firstLetter = remainingWord.First();
        Node node;
        if (!this.NextLetters.TryGetValue(firstLetter, out node))           
        {
            node = new Node(firstLetter);
            this.NextLetters.Add(firstLetter, node);
        }

        var substring = remainingWord.Substring(1);
        node.AddToNode(substring);
    }
}

public class WordValidator
{
    private Dictionary<char, Node> wordTrie = new Dictionary<char, Node>();

    public void Setup(List<string> inputStrings)
    {
        if (inputStrings == null || inputStrings.Count ==0 )
        {
            return;
        }

        foreach (var word in inputStrings)
        {
            //could add optimization to skip adding any duplicate words
            if(string.IsNullOrEmpty(word))
            {
                continue;
            }

            var firstLetter = word.First();
            Node node;
            if (!this.wordTrie.TryGetValue(firstLetter, out node))           
            {
                node = new Node(firstLetter);
                this.wordTrie.Add(firstLetter, node);
            }

            node.AddToNode(word.Substring(1));
        }
    }

    public bool IsValid(string word)
    {
        
        if(string.IsNullOrEmpty(word))
        {
            return false;
        }

        var firstLetter = word.First();
        Node node;
        if(firstLetter == '.')
        {
            foreach(var childNode in this.wordTrie.Values)
            {
                var substring = word.Substring(1); 
                if(childNode.IsValid(substring))
                {
                    return true;
                }
            }

            return false;
        }

        if (!this.wordTrie.TryGetValue(firstLetter, out node))
        {
            return false;
        }   

        return node.IsValid(word.Substring(1));
    }
}