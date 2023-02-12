using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesDemo.Core.Models;
using QuotesDemo.Core.Services;

namespace QuotesDemo.WebUI.Controllers
{
    public class AuthorController : BaseController
    {

        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }


        public async Task<IActionResult> Index()
        {
            var list = await _authorService.ListAuthors();
            return View(list);
        }


        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Author author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _authorService.AddAuthor(author);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        public async Task<ActionResult> Update(int id)
        {
            try
            {
                Author? author = await _authorService.GetAuthorById(id);
                if (author != null)
                {
                    return View(author);
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
        public async Task<ActionResult> Update(int Id, Author author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _authorService.UpdateAuthor(author);
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
                await _authorService.DeleteAuthor(id);
                return Ok(true);
            }
            catch
            {
                return View();
            }
        }


    
        public ActionResult Details(int id)
        {
            return View();
        }






        //// GET: AuthorController/Delete/5


        //// POST: AuthorController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
