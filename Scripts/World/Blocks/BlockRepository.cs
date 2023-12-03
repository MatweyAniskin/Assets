using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockRepository : MonoBehaviour
{  
    static Dictionary<string, SimpleBlock> blocksDictionary = new Dictionary<string, SimpleBlock>();

    public static void Clear() => blocksDictionary.Clear();
    public static void Set(SimpleBlock value)
    {
        blocksDictionary.Add(value.BlockName, value);
    }
    public static SimpleBlock Get(string name)
    {
        try
        {
            return blocksDictionary[name];
        }
        catch
        {
            Debug.LogError($"Not found block {name}");
            return null;   
        }
    }   
}
