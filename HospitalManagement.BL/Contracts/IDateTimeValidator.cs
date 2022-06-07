using System;

namespace HospitalManagement.BL.Contracts
{
    public interface IDateTimeValidator
    {
        public bool Validate(DateTime date);
        public DateTimeOffset GenerateAlertDate(DateTime date);
    }
}
