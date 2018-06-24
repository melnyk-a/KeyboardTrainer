namespace KeyboardTrainer.Models
{
    internal class SourceString
    {
        private int currentIndex = 0;
        private string source;

        public bool HasNext => currentIndex < source.Length;

        public string LeftedSubString => source.Substring(currentIndex);

        public char Next => source[currentIndex];
        
        public string PassedSubstring => source.Substring(0, currentIndex);

        public void Create(int length, int range, bool isCaseSensitive)
        {
            StringCreator stringCreator = new StringCreator();
            source = stringCreator.CreateString(length, range, isCaseSensitive);
            currentIndex = 0;
        }
        
        public void Move()
        {
            ++currentIndex;
        }
    }
}