using Microsoft.AspNetCore.Mvc;

namespace SearchEngine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly ILogger<SearchController> _logger;
    private readonly SearchService _searchService;

    public SearchController(ILogger<SearchController> logger, SearchService searchService)
    {
        _logger = logger;
        _searchService = searchService;
    }

    [HttpGet("documents")]
    public ActionResult<IEnumerable<Document>> Search([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return BadRequest("Search query cannot be empty.");

        var results = _searchService.SearchDocuments(query);
        return Ok(results);
    }

    [HttpPost("score")]
    public IActionResult ScoreDocument([FromQuery] int documentId, [FromQuery] int score)
    {
        if (documentId <= 0 || score < 0)
            return BadRequest("Invalid document ID or score.");

        var success = _searchService.ScoreDocument(documentId, score);
        if (!success)
            return NotFound("Document not found.");

        return Ok("Document scored successfully.");
    }
}
