﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Routing.Trie;

namespace ContactManagementBackend
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
    }
}