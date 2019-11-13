using BrentWiels.Viewmodels;
using BrentWiels.ViewModels;

namespace BrentWiels.Data.Interfaces
{
    interface IKlantenValidationService
    {
        ValidationErrorModel ValidateForAdd(KlantViewModel klantViewModel);
        ValidationErrorModel ValidateForUpdate(KlantViewModel klantViewModel, int klantId);

    }
}
