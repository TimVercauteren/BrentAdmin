using Documents.DTO;

namespace Documents.Interfaces
{
    public interface IPreviewGenerator
    {
        string FillDocumentTemplate(DocumentDto dataObject);
        byte[] GetPdfBytes(OfferteDTO offerteDto);
    }
}