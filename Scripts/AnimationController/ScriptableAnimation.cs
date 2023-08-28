using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScriptableAnimation
{
    [SerializeField] string name;
    [SerializeField] Sprite[] sprites;
    int curFrame = 0;
    public Sprite NextFrame
    {
        get => sprites[CurFrame++];        
    }
    public int CurFrame
    {
        set
        {
            curFrame = value;
            if (curFrame >= sprites.Length)
                curFrame = 0;
        }
        get => curFrame;
    }
    public static bool operator ==(ScriptableAnimation a, string b) => a.name == b;
    public static bool operator !=(ScriptableAnimation a, string b) => a.name != b;
}
