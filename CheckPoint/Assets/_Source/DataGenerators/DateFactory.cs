using System;
using Random = UnityEngine.Random;

namespace DataFactories
{
    public class DateFactory
    {
        private const int ONE_YEAR = 365;
        private int _dateRange;

        public DateFactory(int howMuchYears)
        {
            _dateRange = howMuchYears * ONE_YEAR;
        }

        public string CreateDate(bool isError = false)
        {
            DateTime newDate = DateTime.Today.AddDays(Random.Range(0, _dateRange));
            if(isError)
                newDate = DateTime.Today.AddDays(-Random.Range(0, _dateRange));
            return $"{newDate.Day}.{newDate.Month}.{newDate.Year}";
        }
    }
}