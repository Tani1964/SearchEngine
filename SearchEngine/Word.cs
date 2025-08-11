public class Word
{
    public int WordId { get; set; }
    public string Text { get; set; }
    public bool IsStopWord { get; set; }

    public ICollection<DocumentWord> DocumentWords { get; set; }
}
