using Documents.DTO;

namespace Documents.Interfaces
{
    public interface IOfferteGenerator
    {
        public string FillDocumentTemplate(DocumentDto dataObject);
        byte[] GetPdfBytes(OfferteDTO offerteDto);
    }
}
