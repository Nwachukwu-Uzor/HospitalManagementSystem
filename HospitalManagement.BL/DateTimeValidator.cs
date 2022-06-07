using HospitalManagement.BL.Contracts;
using System;

namespace HospitalManagement.BL
{
    public class DateTimeValidator : IDateTimeValidator
    {
        private readonly decimal min = 8.30m;
        private readonly decimal max = 19.00m;

        public DateTimeOffset GenerateAlertDate(DateTime date)
        {
            var alertDate = date.AddDays(-1);
            var year = alertDate.Year;
            var month = alertDate.Month;
            var day = alertDate.Day - 1;
            var dateTime = new DateTime(year, month, day, 5, 0, 0);
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }

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
