using BrentWiels.Data.Interfaces;
using BrentWiels.Viewmodels;
using BrentWiels.ViewModels;
using System;

namespace BrentWiels.Data
{
    public class KlantenValidationService : IKlantenValidationService
    {
        public ValidationErrorModel ValidateForAdd(KlantViewModel klantViewModel)
        {
            throw new NotImplementedException();
        }

        public ValidationErrorModel ValidateForUpdate(KlantViewModel klantViewModel, int klantId)
        {
            throw new NotImplementedException();
        }
    }
}
