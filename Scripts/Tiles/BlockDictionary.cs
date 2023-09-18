using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDictionary : MonoBehaviour
{
    [SerializeField] SimpleBlock[] blocks;

    static Dictionary<string, SimpleBlock> blockDictionary;
    public delegate SimpleBlock GetDictionary(string name);
    public static GetDictionary Get;
    private void Awake()
    {
        Get += GetBlock;
        blockDictionary = new Dictionary<string, SimpleBlock>();
        foreach (var i in blocks)
        {
            blockDictionary.Add(i.name, i);
        }
    }
    private void OnDestroy()
    {
        Get -= GetBlock;
    }
    SimpleBlock GetBlock(string name)
    {
        try
        {
            return blockDictionary[name];
        }
        catch
        {
            Debug.LogError($"Not find block {name}");
            return null;   
        }
    }
}
