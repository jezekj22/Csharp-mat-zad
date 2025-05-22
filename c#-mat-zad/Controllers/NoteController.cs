using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesAppAspNet.Data;
using c__mat_zad.Models;
using c__mat_zad.Attributes;

namespace c__mat_zad.Controllers
{
    [AuthorizeSession]
    public class NoteController : Controller
    {
        private readonly AppDbContext _context;

        public NoteController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(bool showImportantOnly = false)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var notes = _context.Notes
                .Where(n => n.UserId == userId);

            if (showImportantOnly)
                notes = notes.Where(n => n.Important);

            var sorted = await notes.OrderByDescending(n => n.CreatedAt).ToListAsync();
            return View(sorted);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            Console.WriteLine($"POST /Note/Create");
            Console.WriteLine($"Title: {note.Title}");
            Console.WriteLine($"Content: {note.Content}");
            Console.WriteLine($"UserId from session: {userId}");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState není validní:");
                foreach (var kvp in ModelState)
                {
                    foreach (var error in kvp.Value.Errors)
                    {
                        Console.WriteLine($" - {kvp.Key}: {error.ErrorMessage}");
                    }
                }
                return View(note);
            }

            if (userId == null)
            {
                Console.WriteLine("Uživatel není přihlášen.");
                return RedirectToAction("Login", "Auth"); // Pokud máš login
            }

            note.UserId = userId.Value;
            note.CreatedAt = DateTime.Now;

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            Console.WriteLine("Poznámka byla uložena.");
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null || note.UserId != HttpContext.Session.GetInt32("UserId"))
                return NotFound();

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ToggleImportant(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null || note.UserId != HttpContext.Session.GetInt32("UserId"))
                return NotFound();

            note.Important = !note.Important;
            await _context.SaveChangesAsync();
            Console.WriteLine("Note created.");
            return RedirectToAction("Index");
        }
    }
}
