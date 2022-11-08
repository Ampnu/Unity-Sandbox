using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRS.Labels
{
    /// <summary>
    /// Spawn indicators for target gameobjects
    /// </summary>
    public class IndicatorSpawner : MonoBehaviour
    {
        List<Transform> target = new List<Transform>();
        public GameObject indicatorPrefab;
        public Vector3 indicatorOffset;
        Bounds bounds;

        private void Start()
        {
            SetTarget();
            SpawnObjAtSpawnPoint();
        }

        void SetTarget()
        {
            if (this.transform.childCount > 0)
            {
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    target.Add(this.transform.GetChild(i));
                }
            }
            else
            {
                target.Add(this.transform);
            }
        }

        void SpawnObjAtSpawnPoint()
        {
            Vector3 newPosition = GetTargetCenterPoint() + indicatorOffset;
            GameObject indicatorObj = Instantiate(indicatorPrefab);
            indicatorObj.transform.position = newPosition;
        }

        Vector3 GetTargetCenterPoint()
        {
            if (target.Count == 1)
            {
                return target[0].position;
            }

            bounds = new Bounds(target[0].position, Vector3.zero);

            for (int i = 0; i < target.Count; i++)
            {
                bounds.Encapsulate((target[i].position));
            }

            //if (target.Count == 1)
            //{
            //    if (target[0].gameObject.GetComponent<Renderer>())
            //    {
            //        //boundTestObj.transform.localScale = target[0].gameObject.GetComponent<Renderer>().bounds.size;
            //        return target[0].GetComponent<Renderer>().bounds.center;
            //    }
            //}

            //bounds = new Bounds(target[0].gameObject.GetComponent<Renderer>().bounds.center, target[0].gameObject.GetComponent<Renderer>().bounds.size);

            //for (int i = 0; i < target.Count; i++)
            //{
            //    bounds.Encapsulate((target[i].gameObject.GetComponent<Renderer>().bounds.center));
            //}

            return bounds.center;
        }       
    }
}
