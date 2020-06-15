using Documents.DTO;
using Documents.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Documents.Interfaces
{
    interface IDocumentGenerator 
    {
        string FillDocumentTemplate(DocumentDto dto);
    }
}
