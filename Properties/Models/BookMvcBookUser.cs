using Microsoft.AspNetCore.Identity;
using MvcBook.Models;
using MvcBook.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBook.Models
{
    public class BookMvcBookUser

    {
       

       

        [Column(TypeName = "nvarchar(450)")]
        public string MvcBookUserId { set; get; }
        public CBAUser MvcBookUser { set; get; }

        public int BookId { get; set; }
        public Book Book { get; set; }



    }
}