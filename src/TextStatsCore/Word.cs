namespace TextStats.Core
{
    public class Word : IComparable<Word>
    {
        private string text;

        public Word(string text)
        {
            this.text = text;
            this.Count = 1;
        }

        public int Count { get; set; }

        public int CompareTo(Word? other)
        {
            return this.text.CompareTo(other.text);
        }

        public override string ToString()
        {
            return text;
        }
    }
}