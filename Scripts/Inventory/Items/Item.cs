using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] protected string keyName;
    [SerializeField] protected Sprite icon;  
    [SerializeField] Vector2Int cellSize = Vector2Int.one;
    [SerializeField] int rotateIcon = -30;
    [SerializeField] RarityStatus rarityStatus;
    public abstract string Description
    {
        get;
    }
    public abstract PropertyValue[] GetEffectsValues();
    public Sprite Icon => icon;
    public Color RarityColor => rarityStatus.RarityColor;
    public int XScale => cellSize.x;
    public int YScale => cellSize.y;
    public Vector2 Scale => cellSize;
    public int Rotate => rotateIcon;
    public override string ToString()
    {
        return keyName;
    }    
}
