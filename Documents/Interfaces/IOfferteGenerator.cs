using Documents.DTO;

namespace Documents.Interfaces
{
    public interface IOfferteGenerator
    {
        public byte[] FillTemplateWithOfferteData(OfferteDTO dataObject);
    }
}
