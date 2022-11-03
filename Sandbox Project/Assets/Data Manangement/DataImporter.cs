using System.Collections.Generic;
using UnityEngine;
using File = System.IO.File;

namespace VRS.DataManagement.Content
{
    /// <summary>
    /// Imports JSON data for core system
    /// </summary>
    public class DataImporter
    {       
        string path = "Assets/Resources/JSON/";
        string fileName = "ComponentContent.txt";

        public List<ContentData> ImportData()
        {
            if (File.Exists(path + fileName))
            {               
                JSONTranslator translator = new JSONTranslator();
                var content = translator.ReadData<ContentData>(path + fileName);
                return content;
            }
            else
            {
                Debug.LogWarning("File path: " + path + fileName + " does not exist");
                return null;
            }
        }       
    }
}
