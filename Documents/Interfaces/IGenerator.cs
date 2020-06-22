using Documents.DTO;

namespace Documents.Interfaces
{
    public interface IGenerator
    {
        byte[] FillTemplateWithOfferteData(OfferteDTO dataObject);
        byte[] FillTemplateWithFactuurData(FactuurDto dataObject);

    }
}
