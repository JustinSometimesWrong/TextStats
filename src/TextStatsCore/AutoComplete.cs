namespace TextStats.Core;

public class AutoComplete
{
    private IWordLibrary wordLibrary;

    public AutoComplete(IWordLibrary wordLibrary)
    {
        this.wordLibrary = wordLibrary;
    }

    public string SuggestWord(string intput)
    {
        var rootNode = this.wordLibrary.GetWordTrie();



        return "";
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

    private static string GetSuggestion(CharacterNode node, string inputString, string suggestion)
    {        
        var numberOfChildNodes = currentNode.NextLetters.Count;
        var remainingLetters = text.Length;
        if(remainingLetters == 0)
        {
            if(numberOfChildNodes == 0 || currentNode.IsEndOfWordCharacter)            
            {
                return suggestion;
            }

            return false;
        }



        var firstLetter = text.First();

        if(firstLetter == '.')
        {
            foreach(var childNode in currentNode.NextLetters.Values)
            {
                var substring = text.Substring(1); 
                if(IsTextValid(childNode, substring))
                {
                    return true;
                }
            }

            return false;
        }

        CharacterNode node;
        if (!currentNode.NextLetters.TryGetValue(firstLetter, out node))
        {
            return false;
        }   

        return IsTextValid(node, text.Substring(1));
    }


}