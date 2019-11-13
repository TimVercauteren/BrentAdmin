using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class ContactInformatie : EntityBase
    {
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
        public string BtwNummer { get; set; }
    }
}
