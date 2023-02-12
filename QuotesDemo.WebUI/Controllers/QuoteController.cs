using Microsoft.AspNetCore.Mvc;
using QuotesDemo.Core.Dto;
using QuotesDemo.Core.Extensions;
using QuotesDemo.Core.Models;
using QuotesDemo.Core.Services;
using QuotesDemo.Service.Services;
using QuotesDemo.WebUI.Models;

namespace QuotesDemo.WebUI.Controllers
{
    public class QuoteController : BaseController
    {

        private readonly IQuoteService _quoteService;

        private readonly IAuthorService _authorService;


        public QuoteController(IQuoteService quoteService, IAuthorService authorService)
        {
            _quoteService = quoteService;
            _authorService = authorService;
        }

        public async Task<IActionResult> Index(int? AuthorId)
        {
            QuoteVM model = new QuoteVM();
            model.Quotes = await _quoteService.ListQuotesWithAuthor(AuthorId);
            model.Authors = await _authorService.ListAuthors();
            model.SelectedAuthor = AuthorId;
            return View(model);
        }


        public async Task<IActionResult> Add()
        {
            ViewBag.Authors = await _authorService.ListAuthors();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(QuoteDto quoteDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _quoteService.AddQuote(quoteDto);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Authors = await _authorService.ListAuthors();
                return View();
            }
        }


        public async Task<ActionResult> Update(int id)
        {
            try
            {
                Quote? quote = await _quoteService.GetQuoteById(id);
                if (quote != null)
                {
                    ViewBag.Authors = await _authorService.ListAuthors();
                    return View(quote.ToQuoteDto());
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int Id, QuoteDto quote)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _quoteService.UpdateQuote(quote);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _quoteService.DeleteQuote(id);
                return Ok(true);
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> GetRandomQuote()
        {
            try
            {
                var quote = await _quoteService.GetRandomQuote();
                if (quote.Id > 0)
                {
                    return Ok(QuoteAuthorDto.Success(quote.Author.Name ?? "", quote.Text));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
