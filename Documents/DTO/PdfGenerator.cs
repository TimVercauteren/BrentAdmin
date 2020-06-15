using System;
using System.Collections.Generic;
using System.Text;

namespace Documents.DTO
{
    public class PdfGenerator
    {
        public byte[] GenerateDocumentFromString(string document)
        {
            return Encoding.UTF8.GetBytes(document);
        }
    }
}
