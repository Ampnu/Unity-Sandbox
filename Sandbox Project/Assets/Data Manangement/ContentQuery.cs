using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRS.DataManagement.Content
{
    [RequireComponent(typeof(ContentDB))]
    public class ContentQuery: MonoBehaviour
    {
        static ContentDB contentDB;

        private void Awake()
        {
            contentDB = GetComponent<ContentDB>();
        }

        /// <summary>
        /// Returns part display name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetPartName(int id)
        {
            string partName = string.Empty;

            partName = contentDB.QueryData(id).content.displayName;

            return partName;
        }

        /// <summary>
        /// Returns part description
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetPartDescription(int id)
        {
            string partDescription = string.Empty;

            partDescription = contentDB.QueryData(id).content.description;

            return partDescription;
        }

        /// <summary>
        /// Returns scene gameobject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GameObject GetPartGameObject(int id)
        {
            GameObject partGameObj = null;

            partGameObj = contentDB.QueryData(id).partModel;

            return partGameObj;
        }
    }
}
