using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcBook.Models;
using MvcBook.Data;

namespace MvcBook.Controllers
{
    public class MembersPublicController : Controller
    {
        private readonly MvcBookContext _context;

        public MembersPublicController(MvcBookContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(int applicationYear, string searchString, string searchStringLastName, string searchStringEmail)
        {
            // Use LINQ to get list of genres.
            IQueryable<int> yearQuery = from m in _context.CBAUser
                                            orderby m.FirstName
                                            select m.CreateDate.Year;

            var users = from m in _context.CBAUser
                        select m;

            if(applicationYear != 0)
            {
                users = users.Where(x => x.CreateDate.Year == applicationYear);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.FirstName.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(searchStringLastName))
            {
                users = users.Where(s => s.LastName.Contains(searchStringLastName));
            }
            if (!string.IsNullOrEmpty(searchStringEmail))
            {
                users = users.Where(s => s.Email.Contains(searchStringEmail));
            }

            var CBAUsersVM = new CBAUsersViewModel
            {
                Years = new SelectList(await yearQuery.Distinct().ToListAsync()),
                CBAUsers = await users.ToListAsync()
            };

            return View(CBAUsersVM);
        }
    }
}
