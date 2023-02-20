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


}