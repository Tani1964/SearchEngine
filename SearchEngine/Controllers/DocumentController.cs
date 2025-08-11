using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SearchEngine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentController : ControllerBase
{
    private readonly ILogger<DocumentController> _logger;
    private readonly AppDbContext _context;

    public DocumentController(ILogger<DocumentController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET: api/document
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Document>>> Get()
    {
        return await _context
            .Documents.Include(d => d.DocumentWords)
            .ThenInclude(dw => dw.Word)
            .ToListAsync();
    }

    // GET: api/document/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Document>> GetById(int id)
    {
        var document = await _context
            .Documents.Include(d => d.DocumentWords)
            .ThenInclude(dw => dw.Word)
            .FirstOrDefaultAsync(d => d.DocumentId == id);

        if (document == null)
            return NotFound();

        return document;
    }

    // POST: api/document
    [HttpPost]
    public async Task<ActionResult<Document>> AddDocument(Document document)
    {
        if (document == null)
            return BadRequest("Document cannot be null.");

        _context.Documents.Add(document);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = document.DocumentId }, document);
    }

    // PUT: api/document/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDocument(int id, Document document)
    {
        if (id != document.DocumentId)
            return BadRequest("Document ID mismatch.");

        _context.Entry(document).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Documents.Any(e => e.DocumentId == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/document/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDocument(int id)
    {
        var document = await _context.Documents.FindAsync(id);
        if (document == null)
            return NotFound();

        _context.Documents.Remove(document);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
