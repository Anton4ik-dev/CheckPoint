using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Services
{
    [System.Serializable]
    public class StringData
    {
        public string someData;
    }

    [System.Serializable]
    public class DataHolder
    {
        public StringData[] data;
    }

    public class SQLDataLoader
    {
        public void LoadStringData<T>(TextAsset textAsset, Dictionary<T, List<string>> dataBase)
        {
            List<List<string>> dataLoaded = JsonUtility.FromJson<DataHolder>(textAsset.text).data
                .Select(v => v.someData.Split(',', '\"').ToList())
                .ToList();
            List<List<string>> dataSorted = new List<List<string>>();
            for (int i = 0; i < dataLoaded.Count; i++)
            {
                List<string> strings = new List<string>();
                for (int j = 0; j < dataLoaded[i].Count; j++)
                {
                    if (dataLoaded[i][j].Length != 0)
                        strings.Add(dataLoaded[i][j]);
                }
                dataSorted.Add(strings);
            }
            for (int i = 0; i < dataBase.Count; i++)
            {
                dataBase[dataBase.ElementAt(i).Key] = dataSorted[i];
            }
        }
    }
}