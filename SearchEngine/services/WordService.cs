public class WordService
{
    private readonly AppDbContext _context;

    public WordService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<string> GetAutoCompleteSuggestions(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return Enumerable.Empty<string>();

        return _context
            .Words.Where(w => w.Text.StartsWith(query.ToLower()))
            .OrderBy(w => w.Text)
            .Select(w => w.Text)
            .Take(10)
            .ToList();
    }

    public IEnumerable<string> GetRelatedWords(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return Enumerable.Empty<string>();

        // Placeholder: This could use synonyms or co-occurrence analysis
        return _context
            .DocumentWords.Where(dw =>
                dw.Word.Text != word && dw.Document.DocumentWords.Any(rw => rw.Word.Text == word)
            )
            .Select(dw => dw.Word.Text)
            .Distinct()
            .Take(10)
            .ToList();
    }
}
