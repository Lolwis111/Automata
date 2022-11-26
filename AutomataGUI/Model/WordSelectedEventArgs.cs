namespace AutomataGUI.Model
{
    public class WordSelectedEventArgs
    {
        public WordSelectedEventArgs(string word) { Word = word; }
        public string Word { get; } // readonly
    }

    public delegate void WordSelectedHandler(object sender, WordSelectedEventArgs e);
}
