using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventPlanner3.Data;
using EventPlanner3.Models;

namespace EventPlanner3.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventTypeController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: EventTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventType.ToListAsync());
        }

        // GET: EventTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = await _context.EventType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (eventType == null)
            {
                return NotFound();
            }

            return View(eventType);
        }

        // GET: EventTypes/Create
        public IActionResult Create()
        {
            return View( );
        }

        // POST: EventTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] EventType eventType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eventType);
        }

        // GET: EventTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = await _context.EventType.SingleOrDefaultAsync(m => m.Id == id);
            if (eventType == null)
            {
                return NotFound();
            }
            return View(eventType);
        }

        // POST: EventTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] EventType eventType)
        {
            if (id != eventType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTypeExists(eventType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(eventType);
        }

        // GET: EventTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = await _context.EventType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (eventType == null)
            {
                return NotFound();
            }

            return View(eventType);
        }

        // POST: EventTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventType = await _context.EventType.SingleOrDefaultAsync(m => m.Id == id);
            _context.EventType.Remove(eventType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EventTypeExists(int id)
        {
            return _context.EventType.Any(e => e.Id == id);
        }
    }
}
