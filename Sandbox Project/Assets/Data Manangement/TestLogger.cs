using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRS.DataManagement.Content;

public class TestLogger : MonoBehaviour
{
    public int id = 488;

    [ContextMenu("Test")]
    public void Test()
    {
        var foo = ContentQuery.GetPartDescription(id);
        var bar = ContentQuery.GetPartName(id);
        var bee = ContentQuery.GetPartGameObject(id);
        print(bee.gameObject.name);
    }
}
