using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcBook.Models;
using MvcBook.Data;
using MvcBook.Areas.Identity.Data;

namespace MvcBook.Controllers
{
    //[Authorize]
    public class MembersController : Controller
    {
        private readonly MvcBookContext _context;


        public MembersController(MvcBookContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(int applicationYear, string searchString, string searchStringLastName, string searchStringEmail)
        {
            // Use LINQ to get list of genres.
            IQueryable<int> yearsQuery = from m in _context.CBAUser
                                         orderby m.CreateDate
                                         select m.CreateDate.Year;

            var members = from m in _context.CBAUser
                        select m;

            if (applicationYear != 0)
                members = members.Where(x => x.CreateDate.Year == applicationYear);

            if (!string.IsNullOrEmpty(searchString))     
                members = members.Where(s => s.FirstName.Contains(searchString));
            
            if (!string.IsNullOrEmpty(searchStringLastName))
                members = members.Where(s => s.LastName.Contains(searchStringLastName));
            
            if (!string.IsNullOrEmpty(searchStringEmail))
                members = members.Where(s => s.Email.Contains(searchStringEmail));
           
            var bookGenreVM = new CBAUsersViewModel
            {
                Years = new SelectList(await yearsQuery.Distinct().ToListAsync()),
                CBAUsers = await members.ToListAsync()
            };

            return View(bookGenreVM);
        }



        // GET: Members/Details/"5"
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
                return NotFound();
            
            var member = await _context.CBAUser
                .FirstOrDefaultAsync(m => m.Id.Equals(id));

            if (member == null)
                return NotFound();
            
            return View(member);
        }


        // GET: Members/Edit/"5"
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)     
                return NotFound();
            
            var member = await _context.CBAUser.FindAsync(id);
            
            if (member == null)
                return NotFound();

            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName, LastName, Email, ContactNumber, Address, City, PostalCode, Province, MembershipStatus")] CBAUser member)
        {
            var user = await _context.CBAUser.FindAsync(id);
   
            if (user == null)
                return NotFound();
            
            user.FirstName = member.FirstName;
            user.LastName = member.LastName;
            user.Email = member.Email;
            user.ContactNumber = member.ContactNumber;
            user.Address = member.Address;
            user.City = member.City;
            user.PostalCode = member.PostalCode;
            user.Province = member.Province;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(member.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Members/Delete/"5"
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)   
                return NotFound();
            
            var user = await _context.CBAUser
                .FirstOrDefaultAsync(m => m.Id.Equals(id));

            if (user == null)
                return NotFound();
            
            return View(user);
        }

        // POST: Members/Delete/"5"
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.CBAUser.FindAsync(id);
            _context.CBAUser.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Members/Approve/"5"
        public async Task<IActionResult> Approve(string id)
        {
            if (id == null)
                return NotFound();
           
            var user = await _context.CBAUser
                .FirstOrDefaultAsync(m => m.Id.Equals(id));

            if (user == null)   
                return NotFound();
            
            return View(user);
        }

        // POST: Members/Approve/"5"
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveConfirmed(string id)
        {
            var user = await _context.CBAUser.FindAsync(id);
            if(user.MembershipStatus.Equals("Approved"))
                return RedirectToAction(nameof(Index));

            user.MembershipStatus = "Approved";
            _context.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /* // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }*/
        /*
                // POST: Books/Create
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Create([Bind("Id,Title,Author,PublishDate,Genre,Price,Rating")] Book book)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(book);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    return View(book);
                }*/

        private bool UserExists(string id)
        {
            return _context.CBAUser.Any(e => e.Id.Equals(id));
        }
    }
}
