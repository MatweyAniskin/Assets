using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingController : MonoBehaviour
{
    List<UsingObject> usingObjects = new List<UsingObject>();

    public delegate void ChangeUsingController(UsingObject usingObject);
    public static ChangeUsingController AddUsingObject;
    public static ChangeUsingController RemoveUsingObject;
    private void Start()
    {
        AddUsingObject += AddObject;
        RemoveUsingObject += RemoveObject;
    }
    private void OnDestroy()
    {
        AddUsingObject -= AddObject;
        RemoveUsingObject -= RemoveObject;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseObjects();
        }
    }
    void UseObjects()
    {        
        for (int i = 0; i < usingObjects.Count; i++)
        {        
            usingObjects[i].UseObject();
        }
    }
    void AddObject(UsingObject usingObject)
    {
        usingObjects.Add(usingObject);
    }
    void RemoveObject(UsingObject usingObject)
    {
        try
        {
            usingObjects.Remove(usingObject);
        }
        catch { }        
    }
}
