using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace VRS.DataManagement.Content
{
    /// <summary>
    /// Read/Writes JSON data to designate file paths
    /// </summary>
    public class JSONTranslator
    {
        /// <summary>
        /// Reads JSON data from designate file paths
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="directory"></param>
        public List<T> ReadData<T>(string directory)        
        {
            string dataString = File.ReadAllText(directory);
            return JsonConvert.DeserializeObject<List<T>>(dataString);
        }

        /// <summary>
        /// Writes JSON data to designated file path
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="directory"></param>
        //public void WriteData(Object obj, string directory)
        //{
        //    string data = JsonConvert.SerializeObject(obj, Formatting.Indented);
        //    File.WriteAllText(directory, data);
        //    AssetDatabase.Refresh();
        //}
    }
}
