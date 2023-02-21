namespace TextStats.Core;

public class AutoComplete
{
    private IWordLibrary wordLibrary;

    public AutoComplete(IWordLibrary wordLibrary)
    {
        this.wordLibrary = wordLibrary;
    }

    public string SuggestWord(string inputString)
    {
        var rootNode = this.wordLibrary.GetWordTrie();



        return GetSuggestion(rootNode, inputString, string.Empty);
    }

    public string NextSuggestedWord()
    {
        return "";
    }

    public void BuildLibrary(List<string> words)
    {

    }

    public void AddWord(string word)
    {
        this.wordLibrary.AddWord(word);
    }

    private static string GetSuggestion(CharacterNode currentNode, string inputString, string suggestion)
    {        
        var numberOfChildNodes = currentNode.NextLetters.Count;
        var remainingLetters = inputString.Length;
        if(remainingLetters == 0)
        {
            if(numberOfChildNodes == 0 || currentNode.IsEndOfWordCharacter)            
            {
                return suggestion;
            }
            else
            {
                var firstChild = currentNode.NextLetters.First(); // alternatively find the child with the shortest depth
                return GetSuggestion(firstChild.Value, inputString, suggestion + firstChild.Key);
            }
        }

        var firstLetter = inputString.First();
        CharacterNode node;
        var remainingInput = inputString.Substring(1);
        if ( !currentNode.NextLetters.TryGetValue(firstLetter, out node))
        {
            // no matches in Trie so return the initial input
            return suggestion + inputString;
        }   

        return GetSuggestion(node, remainingInput, suggestion + node.Character);
    }
}