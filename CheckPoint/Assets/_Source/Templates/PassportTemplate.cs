using TMPro;
using UnityEngine;

namespace Templates
{
    public class PassportTemplate : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _sex;
        [SerializeField] private TextMeshProUGUI _country;
        [SerializeField] private TextMeshProUGUI _city;
        [SerializeField] private TextMeshProUGUI _date;

        public string Name
        {
            get => _name.text;
            set
            {
                _name.text = value;
            }
        }

        public string Sex
        {
            get => _sex.text;
            set
            {
                _sex.text = value;
            }
        }

        public string Country
        {
            get => _country.text;
            set
            {
                _country.text = value;
            }
        }

        public string City
        {
            get => _city.text;
            set
            {
                _city.text = value;
            }
        }

        public string Date
        {
            get => _date.text;
            set
            {
                _date.text = value;
            }
        }
    }
}