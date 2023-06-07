using System;
using TMPro;
using Zenject;
using Random = UnityEngine.Random;

namespace DataFactories
{
    public class DateFactory
    {
        private const int ONE_YEAR = 365;
        private int _dateRange;

        public DateFactory(int howMuchYears, [Inject(Id = BindId.GUEST_ID)] TextMeshProUGUI clocks)
        {
            _dateRange = howMuchYears * ONE_YEAR;
            clocks.text = $"{DateTime.Today.Day}.{DateTime.Today.Month}.{DateTime.Today.Year}";
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