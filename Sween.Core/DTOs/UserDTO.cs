﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Core.DTOs
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Tel { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public string ImageURL { get; set; }
    }
}
