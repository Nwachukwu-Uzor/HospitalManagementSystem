using HospitalManagement.Helpers.Contracts;
using System;

namespace HospitalManagement.Helpers
{
    public class DateTimeValidator : IDateTimeValidator
    {
        private readonly decimal min = 8.30m;
        private readonly decimal max = 19.00m;

        public bool Validate(DateTime date)
        {
            var hour = date.Hour;
            var minutes = date.Minute;

            var timeTotal = (decimal)hour + ((decimal)minutes / 100);

            if (timeTotal < min || timeTotal > max)
            {
                return false;
            }
            return true;
        }
    }
}
