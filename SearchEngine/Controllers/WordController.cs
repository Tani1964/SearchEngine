using Microsoft.AspNetCore.Mvc;

namespace SearchEngine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordsController : ControllerBase
{
    private readonly WordService _wordService;

    public WordsController(WordService wordService)
    {
        _wordService = wordService;
    }

    [HttpGet("autocomplete")]
    public ActionResult<IEnumerable<string>> AutoComplete([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return BadRequest("Search query cannot be empty.");

        var suggestions = _wordService.GetAutoCompleteSuggestions(query);
        return Ok(suggestions);
    }

    [HttpGet("related")]
    public ActionResult<IEnumerable<string>> RelatedWords([FromQuery] string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return BadRequest("Word cannot be empty.");

        var related = _wordService.GetRelatedWords(word);
        return Ok(related);
    }
}
