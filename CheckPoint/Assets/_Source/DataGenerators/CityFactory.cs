using Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DataFactories
{
    public class CityFactory
    {
        private const string COUNTRIES_DATABASE = "\\Countries.csv";
        private Dictionary<string, List<string>> _countries = new Dictionary<string, List<string>>
        {
            {"Арстоцка", new List<string>() },
            {"Колечия", new List<string>() },
            {"Антегрия", new List<string>() },
            {"Орбистан", new List<string>() },
            {"Республия", new List<string>() },
            {"ОФ", new List<string>() },
            {"Импор", new List<string>() }
        };
        private string _country;

        public CityFactory(SQLDataLoader sqlDataLoader)
        {
            sqlDataLoader.LoadStringData(COUNTRIES_DATABASE, _countries);
        }

        public string CreateCountry()
        {
            _country = _countries.ElementAt(Random.Range(0, _countries.Count)).Key;
            return _country;
        }

        public string CreateCity(bool isError = false)
        {
            if(isError)
            {
                string errorCountry = _countries.ElementAt(Random.Range(0, _countries.Count)).Key;
                while (errorCountry == _country);
                    errorCountry = _countries.ElementAt(Random.Range(0, _countries.Count)).Key;
                return _countries[errorCountry][Random.Range(0, _countries[errorCountry].Count)];
            }
            else
                return _countries[_country][Random.Range(0, _countries[_country].Count)];
        }
    }
}