using Microsoft.AspNetCore.Mvc.Rendering;
using MvcBook.Areas.Identity.Data;
using System.Collections.Generic;

namespace MvcBook.Models
{
    public class CBAUsersViewModel
    {
        public List<CBAUser> CBAUsers { get; set; }
        public string SearchString { get; set; }
        public string SearchStringLastName { get; set; }
        public string SearchStringEmail { get; set; }
        public SelectList Years { get; set; }
        public int ApplicationYear { get; set; }
    }
}