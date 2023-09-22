using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

public class TileCacheLoader : MonoBehaviour, IService
{
    [SerializeField] int order = 2;
    [SerializeField] string nameService;
    [SerializeField] TextAsset xmlFile;
    [SerializeField] int scale = 64;

    public int Order => order;

    public string Name => nameService;

    XmlDocument xmlDocument = new XmlDocument();
    string tileName = string.Empty;
    int x, y, z;
    string blockName;
    SimpleBlock[,,] blocks;
    Queue<XmlElement> tileElementQueue;   
    int GetIntAttribute(string name, XmlElement xmlElement) => Convert.ToInt32(xmlElement.Attributes[name].InnerText);

    public void StartWork()
    {
        xmlDocument.LoadXml(xmlFile.text);
        tileElementQueue = new Queue<XmlElement>(xmlDocument.GetElementsByTagName("Tile").Cast<XmlElement>());
        TileCacheRepository.BlocksLengthSide = scale;
    }

    public bool Next()
    {
        if (tileElementQueue.Count == 0)
            return false;
        XmlElement tileElement = tileElementQueue.Dequeue();
        tileName = tileElement.Attributes["Name"].InnerText;
        blocks = new SimpleBlock[scale, scale, scale];
        foreach (XmlElement blockElement in tileElement.GetElementsByTagName("Block"))
        {
            blockName = blockElement.InnerText.Trim();
            x = GetIntAttribute("X", blockElement);
            y = GetIntAttribute("Y", blockElement);
            z = GetIntAttribute("Z", blockElement);
            if (x >= scale || y >= scale || z >= scale)
                continue;
            blocks[x, y, z] = BlockRepository.Get(blockName);
        }
        TileCacheRepository.SetTile(tileName, blocks);
        return true;
    }
}
