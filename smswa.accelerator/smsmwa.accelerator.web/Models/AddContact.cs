﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smsmwa.accelerator.web.Models
{
    public class AddContact
    {
        public int Id { get; set; }
        public int ContactTypeId { get; set; }
        public string Value { get; set; }
    }
}