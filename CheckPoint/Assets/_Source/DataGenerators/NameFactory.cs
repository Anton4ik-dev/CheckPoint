using Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace DataFactories
{
    public class NameFactory
    {
        private const string SPLIT = ", ";
        private Dictionary<int, List<string>> _names = new Dictionary<int, List<string>>
        {
            {NameId.BEFORE_NAME, new List<string>() },
            {NameId.CORE_NAME, new List<string>() },
            {NameId.AFTER_NAME, new List<string>() }
        };
        private Dictionary<int, List<string>> _lastNames = new Dictionary<int, List<string>>
        {
            {NameId.BEFORE_NAME, new List<string>() },
            {NameId.CORE_NAME, new List<string>() },
            {NameId.AFTER_NAME, new List<string>() }
        };

        public NameFactory(SQLDataLoader sqlDataLoader,
            [Inject(Id = BindId.NAMES_ID)] TextAsset names,
            [Inject(Id = BindId.SURNAMES_ID)] TextAsset surnames)
        {
            sqlDataLoader.LoadStringData(names, _names);
            sqlDataLoader.LoadStringData(surnames, _lastNames);
        }

        public string CreateName()
        {
            string name = "";
            string lastName = "";
            for (int i = 0; i < _names.Count; i++)
            {
                name += _names.ElementAt(i).Value[Random.Range(0, _names.ElementAt(i).Value.Count)];
            }
            for (int i = 0; i < _lastNames.Count; i++)
            {
                lastName += _lastNames.ElementAt(i).Value[Random.Range(0, _lastNames.ElementAt(i).Value.Count)];
            }
            return name + SPLIT + lastName;
        }
    }

    public static class NameId
    {
        public static int BEFORE_NAME = 0;
        public static int CORE_NAME = 1;
        public static int AFTER_NAME = 2;
    }
}