using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrentWiels.Viewmodels
{
    public class ValidationErrorModel
    {
        public int ResultCode { get; set; }
        public List<string> Messages { get; set; }
    }
}
