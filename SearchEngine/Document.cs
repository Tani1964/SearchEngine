public class Document
{
    public int DocumentId { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }
    public string FileType { get; set; }
    public DateTime IndexedAt { get; set; }
    public string ContentHash { get; set; }

    public ICollection<DocumentWord> DocumentWords { get; set; }
}
