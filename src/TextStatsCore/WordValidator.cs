namespace TextStats.Core;

public class WordValidator
{
    private IWordLibrary wordLibrary;

    public WordValidator(IWordLibrary wordLibrary)
   {
        this.wordLibrary = wordLibrary;
   }

    public bool IsValid(string word)
    {
        var wordTrieRoot = this.wordLibrary.GetWordTrie();
        if(string.IsNullOrEmpty(word))
        {
            return false;
        }

        return IsTextValid(wordTrieRoot, word);
    }

    public static bool IsTextValid(CharacterNode currentNode, string text)
    {
        var numberOfChildNodes = currentNode.NextLetters.Count;
        var remainingLetters = text.Length;
        if(remainingLetters == 0)
        {
            if(numberOfChildNodes == 0 || currentNode.IsEndOfWordCharacter)            
            {
                return true;
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