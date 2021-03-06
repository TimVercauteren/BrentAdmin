﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
