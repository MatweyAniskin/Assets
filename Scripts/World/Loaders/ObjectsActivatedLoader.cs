using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsActivatedLoader : Loader
{
    [SerializeField] GameObject[] activateObjects;
    public override bool Next() => false;

    public override void StartWork(MonoBehaviour executor)
    {
        foreach (var i in activateObjects)
            i.SetActive(true);
    }
}
