using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDictionary : MonoBehaviour
{
    [SerializeField] Block[] blocks;

    static Dictionary<string, Block> blockDictionary;
    public delegate Block GetDictionary(string name);
    public static GetDictionary Get;
    private void Awake()
    {
        Get += GetBlock;
        blockDictionary = new Dictionary<string, Block>();
        foreach (var i in blocks)
        {
            blockDictionary.Add(i.name, i);
        }
    }
    private void OnDestroy()
    {
        Get -= GetBlock;
    }
    Block GetBlock(string name)
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
