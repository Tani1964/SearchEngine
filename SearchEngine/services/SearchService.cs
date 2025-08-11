public class SearchService
{
    private readonly AppDbContext _context;

    public SearchService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Document> SearchDocuments(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return Enumerable.Empty<Document>();

        var keywords = query.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Example: Find documents containing any of the keywords
        return _context
            .Documents.Where(d => d.DocumentWords.Any(dw => keywords.Contains(dw.Word.Text)))
            .OrderByDescending(d => d.DocumentWords.Sum(dw => dw.Frequency))
            .Take(20)
            .ToList();
    }

    public Document? GetDocumentById(int id)
    {
        return _context.Documents.FirstOrDefault(d => d.DocumentId == id);
    }

    public bool ScoreDocument(int documentId, int score)
    {
        var doc = GetDocumentById(documentId);
        if (doc == null)
            return false;

        doc.Score += score;
        _context.SaveChanges();
        return true;
    }
}
