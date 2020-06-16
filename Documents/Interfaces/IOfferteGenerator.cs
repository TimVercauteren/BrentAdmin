using Documents.DTO;

namespace Documents.Interfaces
{
    public interface IOfferteGenerator
    {
        byte[] FillTemplateWithOfferteData(OfferteDTO dataObject);
    }
}
