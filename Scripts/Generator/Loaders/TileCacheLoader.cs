using System;
using System.Collections;
using System.Collections.Generic;
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
    Queue<XmlElement> tileElement;
    void Load()
    {
       
        
       
        foreach (XmlElement tileElement in )
        {
            tileName = tileElement.Attributes["Name"].InnerText;
            blocks = new SimpleBlock[scale, scale, scale];
            foreach (XmlElement blockElement in tileElement.GetElementsByTagName("Block"))
            {
                blockName = blockElement.InnerText.Trim();
                x = GetIntAttribute("X", blockElement);
                y = GetIntAttribute("Y", blockElement);
                z = GetIntAttribute("Z", blockElement);
                blocks[x, y, z] = BlockRepository.Get(blockName);
            }
            TileCacheRepository.SetTile(tileName, blocks);
        }
    }
    int GetIntAttribute(string name, XmlElement xmlElement) => Convert.ToInt32(xmlElement.Attributes[name].InnerText);

    public void StartWork()
    {
        xmlDocument.LoadXml(xmlFile.text);
        tileElement = new Queue<XmlElement>(xmlDocument.GetElementsByTagName("Tile").);
    }

    public bool Next()
    {
        throw new NotImplementedException();
    }
}
