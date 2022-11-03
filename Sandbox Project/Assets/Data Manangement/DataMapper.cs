using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace VRS.DataManagement.Content
{
    [RequireComponent(typeof(ContentDB))]
    [RequireComponent(typeof(ContentQuery))]
    public class DataMapper : MonoBehaviour
    {
        public GameObject model;
        DataImporter importer;
        List<ContentData> content;
        ContentDB contentDB;

        public static Action DataInitialize;
        public static void OnDataInitialze() => DataInitialize.Invoke();

        private void Awake()
        {
            importer = new DataImporter();
            contentDB = GetComponent<ContentDB>();
        }

        private void Start()
        {
            GetContent();
            MapModelToContent();
        }

        void GetContent()
        {
            if (importer.ImportData() == null) { Debug.LogError("No JSON found for " + this); return; }
            content = importer.ImportData();
        }

        public void MapModelToContent()
        {
            if (model == null) { Debug.LogError("No Model found for " + this); return; }

            if (model.transform.childCount > 0)
            {
                for (int i = 0; i < model.transform.childCount; i++)
                {
                    if (model.transform.GetChild(i).GetComponent<PartID>())
                    {
                        MapModel(model.transform.GetChild(i).gameObject);
                    }
                }

                OnDataInitialze();
            }
        }

        void MapModel(GameObject part)
        {
            foreach (var data in content)
            {
                if (part.GetComponent<PartID>().id == data.id)
                {
                    ComponentData comptData = new ComponentData();

                    comptData.content = data;
                    comptData.partModel = part;

                    contentDB.SetDBData(comptData);
                }
            }
        }
    }
}
