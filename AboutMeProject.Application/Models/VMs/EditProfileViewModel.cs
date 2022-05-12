using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Models.VMs
{
   public class EditProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Display(Name = "User Name")]
        public string UserName { get; set; }
        public string ImageUrl { get; set; }

        [FileExtensions]
        public IFormFile Image { get; set; }
    }
}
