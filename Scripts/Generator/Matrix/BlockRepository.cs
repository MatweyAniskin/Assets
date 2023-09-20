using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockRepository : MonoBehaviour
{
    [SerializeField] List<SimpleBlock> blocks;
    static Dictionary<string, SimpleBlock> blocksDictionary = new Dictionary<string, SimpleBlock>();    
    private void Awake()
    {
        foreach (var i in blocks)
            blocksDictionary.Add(i.name, i);      
    }
    private void OnDestroy()
    {
        blocksDictionary.Clear();
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
