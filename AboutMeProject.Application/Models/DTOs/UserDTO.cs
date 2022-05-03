﻿using AboutMeProject.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string ImageUrl { get; set; }

        public List<UserMessage> UserMessages { get; set; }
    }
}