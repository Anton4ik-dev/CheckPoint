using Templates;
using UnityEngine;

namespace DataFactories
{
    public class DataFactory
    {
        private PassportTemplate _passportTemplate;
        private PhotoFactory _photoFactory;
        private CityFactory _cityFactory;
        private NameFactory _nameFactory;
        private DateFactory _dateFactory;

        public DataFactory(PassportTemplate passportTemplate, PhotoFactory photoFactory, CityFactory cityFactory, NameFactory nameFactory, DateFactory dateFactory)
        {
            _passportTemplate = passportTemplate;
            _photoFactory = photoFactory;
            _cityFactory = cityFactory;
            _nameFactory = nameFactory;
            _dateFactory = dateFactory;
        }

        public void CreateData(bool isError = false)
        {
            _passportTemplate.Name = _nameFactory.CreateName();
            _passportTemplate.Country = _cityFactory.CreateCountry();
            _passportTemplate.City = _cityFactory.CreateCity();
            _passportTemplate.Date = _dateFactory.CreateDate();
            _passportTemplate.Sex = _photoFactory.CreateSex();
            _photoFactory.CreatePhoto();
            if(isError)
            {
                switch (Random.Range(0, 4))
                {
                    case 0:
                        _passportTemplate.City = _cityFactory.CreateCity(isError);
                        break;
                    case 1:
                        _passportTemplate.Date = _dateFactory.CreateDate(isError);
                        break;
                    case 2:
                        _passportTemplate.Sex = _photoFactory.CreateSex(isError);
                        break;
                }
            }
        }
    }
}