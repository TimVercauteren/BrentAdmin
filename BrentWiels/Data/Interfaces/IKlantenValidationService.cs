using BrentWiels.Viewmodels;

namespace BrentWiels.Data.Interfaces
{
    interface IKlantenValidationService
    {
        ValidationErrorModel ValidateForAdd(KlantViewModel klantViewModel);
        ValidationErrorModel ValidateForUpdate(KlantViewModel klantViewModel, int klantId);

    }
}
