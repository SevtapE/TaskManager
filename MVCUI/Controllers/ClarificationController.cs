using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
    public class ClarificationController : Controller
    {
        IClarificationService _clarificationService;


        public ClarificationController(IClarificationService clarificationService)
        {
            _clarificationService = clarificationService;
        }
        public IActionResult Index()
        {
            var clarifications = _clarificationService.GetFull();
            return View(clarifications);
        }

        //task'ın clarificationları. Comments gibi çalışacak iki taraf da yorum yazıyor.
        public IActionResult GetByTaskId(int id)
        {
            var clarificationsForTask = _clarificationService.GetFullByTaskId(id);
            return View(clarificationsForTask);
        }

        [HttpGet]
        public IActionResult AddClarification()
        {;
            return View();
        }

        [HttpPost]
        public IActionResult AddClarification(Clarification clarification)
        {
            _clarificationService.Add(clarification);
            return View();
        }

        [HttpGet]
        public IActionResult UpdateClarification()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult UpdateClarification(Clarification clarification)
        {
            _clarificationService.Update(clarification);
            return View();
        }


        [HttpGet]
        public IActionResult DeleteClarification()
        {

            return View();
        }

        [HttpPost]
        public IActionResult DeleteClarification(Clarification clarification)
        {
            _clarificationService.Delete(clarification);
            return View();
        }
    }
}
