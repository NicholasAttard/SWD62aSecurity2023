using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string User_fk { get; set; }

        public IdentityUser User { get; set; }
        public Book  Book {get;set;}

        [ForeignKey("Book")]
        public String Isbn_fk { get; set; }

        public DateTime To { get; set; }

        public DateTime From { get; set; }
    }
}
