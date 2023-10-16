using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

[CreateAssetMenu(menuName = "Loader/TileCache")]
public class TileCacheLoader : Loader
{    
    [SerializeField] TextAsset xmlFile;
     

    XmlDocument xmlDocument = new XmlDocument();
    string tileName = string.Empty;
    int x, y, z;
    string blockName;
    SimpleBlock[,,] blocks;
    Queue<XmlElement> tileElementQueue;   
    int GetIntAttribute(string name, XmlElement xmlElement) => Convert.ToInt32(xmlElement.Attributes[name].InnerText);

    public override void StartWork(MonoBehaviour executor)
    {
        xmlDocument.LoadXml(xmlFile.text);
        tileElementQueue = new Queue<XmlElement>(xmlDocument.GetElementsByTagName("Tile").Cast<XmlElement>());        
    }

    public override bool Next()
    {
        if (tileElementQueue.Count == 0)
            return false;
        XmlElement tileElement = tileElementQueue.Dequeue();
        tileName = tileElement.Attributes["Name"].InnerText;
        int scale = GenerateProperty.TileSideLength;
        blocks = new SimpleBlock[scale, scale, scale];
        string[] directions = new string[4];
        int dirIndex;
        foreach (XmlElement dirElement in tileElement.GetElementsByTagName("Direction"))
        {
            dirIndex = GetIntAttribute("Type", dirElement);
            directions[dirIndex] = dirElement.InnerText;
        }
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
        TileCacheRepository.SetTile(tileName, blocks, directions);
        return true;
    }
}
