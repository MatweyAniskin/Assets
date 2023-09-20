using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class TileCacheLoader : MonoBehaviour
{
    [SerializeField] TextAsset xmlFile;
    [SerializeField] int scale = 64;
    private void Start()
    {
        Load();
    }
    void Load()
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xmlFile.text);
        string tileName = string.Empty;
        int x, y, z;
        string blockName;        
        SimpleBlock[,,] blocks;
        foreach (XmlElement tileElement in xmlDocument.GetElementsByTagName("Tile"))
        {
            tileName = tileElement.Attributes["Name"].InnerText;
            blocks = new SimpleBlock[scale, scale, scale];
            foreach (XmlElement blockElement in tileElement.GetElementsByTagName("Block"))
            {
                blockName = blockElement.InnerText;
                x = GetIntAttribute("X", blockElement);
                y = GetIntAttribute("Y", blockElement);
                z = GetIntAttribute("Z", blockElement);
                blocks[x, y, z] = BlockRepository.Get(blockName);
            }
            TileCacheRepository.SetTile(tileName, blocks);
        }
    }
    int GetIntAttribute(string name, XmlElement xmlElement) => Convert.ToInt32(xmlElement.Attributes[name].InnerText);
}
