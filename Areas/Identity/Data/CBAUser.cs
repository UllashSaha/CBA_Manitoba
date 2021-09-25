using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MvcBook.Models;


namespace MvcBook.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MvcBookUser class
    public class CBAUser : IdentityUser
    {   
        [PersonalData]
        [Column(TypeName ="nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string ContactNumber { get; set; }


        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }


        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }


        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string PostalCode { get; set; }


        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Province { get; set; }


         public List<BookMvcBookUser> BookMvcBookUser { get; set; }


    }
}
