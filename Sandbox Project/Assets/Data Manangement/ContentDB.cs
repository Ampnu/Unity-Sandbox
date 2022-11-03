using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRS.DataManagement.Content
{
    public class ContentDB : MonoBehaviour
    {
        List<ComponentData> componentData = new List<ComponentData>();

        private void Awake()
        {
            DataMapper.DataInitialize += TestLog;
        }

        public void TestLog()
        {
            //foreach (var item in componentData)
            //{
            //    print(item.content.id + " - " + item.partModel.name);
            //}
        }

        public void SetDBData(ComponentData data)
        {
            componentData.Add(data);
        }

        public ComponentData QueryData(int queryID)
        {
            ComponentData activeData = null;

            foreach (var data in componentData)
            {
                if(data.content.id == queryID)
                {
                    activeData = data;
                }             
            }

            return activeData;
        }
    }
}