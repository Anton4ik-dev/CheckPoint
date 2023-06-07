using Services;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

namespace DataFactories
{
    public class CityFactory
    {
        private const string COUNTRIES_DATABASE = "\\Countries.csv";
        private Dictionary<string, List<string>> _countries = new Dictionary<string, List<string>>
        {
            {Countries.ARCTOZKA, new List<string>() },
            {Countries.COLECHIA, new List<string>() },
            {Countries.ANTEGRIA, new List<string>() },
            {Countries.ORBISTAN, new List<string>() },
            {Countries.RESPUBLIA, new List<string>() },
            {Countries.OF, new List<string>() },
            {Countries.IMPOR, new List<string>() }
        };
        private string _country;

        public CityFactory(SQLDataLoader sqlDataLoader, [Inject(Id = BindId.PASSPORT_ID)] TextMeshProUGUI book)
        {
            sqlDataLoader.LoadStringData(COUNTRIES_DATABASE, _countries);
            book.text = WriteBook();
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

        private string WriteBook()
        {
            string bookInfo = "";
            for (int i = 0; i < _countries.Count; i++)
            {
                bookInfo += _countries.ElementAt(i).Key + " - ";
                for (int j = 0; j < _countries.ElementAt(i).Value.Count; j++)
                {
                    bookInfo += _countries.ElementAt(i).Value[j];
                    if (j != _countries.ElementAt(i).Value.Count - 1)
                        bookInfo += ", ";
                }
                bookInfo += "\n";
            }
            return bookInfo;
        }
    }

    public static class Countries
    {
        public static string ARCTOZKA = "Арстоцка";
        public static string COLECHIA = "Колечия";
        public static string ANTEGRIA = "Антегрия";
        public static string ORBISTAN = "Орбистан";
        public static string RESPUBLIA = "Республия";
        public static string OF = "ОФ";
        public static string IMPOR = "Импор";
    }
}