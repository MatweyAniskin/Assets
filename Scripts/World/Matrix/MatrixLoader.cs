using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;
using Repository;

public class MatrixLoader : MonoBehaviour
{
    [SerializeField] TextAsset defaultDocument;

    public SimpleBlock[,,] Load() => Load(defaultDocument.text);
    public SimpleBlock[,,] Load(string xml)
    {
        SimpleBlock[,,] blocks;
        int scale = 0;
        XmlDocument document = new XmlDocument();
        document.LoadXml(defaultDocument.text);
        scale = Convert.ToInt32(document.GetElementsByTagName("Scale")[0].InnerText);
        blocks = new SimpleBlock[scale, scale,scale];
        int x,y,z;
        foreach (XmlElement i in document.GetElementsByTagName("Block"))
        {
           x = Convert.ToInt32(i.GetAttribute("x"));
           y = Convert.ToInt32(i.GetAttribute("y"));
           z = Convert.ToInt32(i.GetAttribute("z"));
            blocks[x, y,z] = BlockRepository.Get(i.InnerText.Trim());
        }

        return blocks;
    }
}
