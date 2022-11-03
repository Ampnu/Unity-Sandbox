using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRS.DataManagement.Content
{
    [System.Serializable]
    public class ComponentData
    {
        public ContentData content;
        public GameObject partModel;
    }

    [System.Serializable]
    public class ContentData
    {
        public int id;
        public string displayName;
        public string description;
    }
}
