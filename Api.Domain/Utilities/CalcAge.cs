using System;
namespace Api.Domain.Utilities
{
    public class CalcAge
    {
        public DateTime EnterDate { get; set; }
        private DateTime _enterDate { get; set; }
        public CalcAge(DateTime EnterDate)
        {
            _enterDate = EnterDate;
        }

        public int AgeAlready()
        {
            var now = DateTime.UtcNow;
            var monthBirth = _enterDate.Month;
            var monthNow = now.Month;
            var dayBirth = _enterDate.Day;
            var nowDay = now.Day;
            var result = 0;

            if (now <= _enterDate) return result;

            result = (now.Year - _enterDate.Year);

            if (monthBirth > monthNow)
            {
                result = result - 1;
            }
            else if (monthBirth == monthNow && dayBirth > nowDay)
            {
                result = result - 1;
            }
            return result;
        }

    }
}


