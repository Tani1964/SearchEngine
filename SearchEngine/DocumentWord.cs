public class DocumentWord
{
    public int DocumentId { get; set; }
    public Document Document { get; set; }

    public int WordId { get; set; }
    public Word Word { get; set; }

    public int Frequency { get; set; }
}
