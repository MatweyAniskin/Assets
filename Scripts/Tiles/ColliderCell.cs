using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColliderCell
{
    [SerializeField] bool upBreak;
    [SerializeField] bool rightBreak;
    [SerializeField] bool downBreak;
    [SerializeField] bool leftBreak;

    public bool IsInsideCollision(Vector2Int dir) // ((dir.y == 1 && upBreak) || (dir.y == -1 && downBreak) && dir.y == 0) | ((dir.x == 1 && rightBreak) || (dir.x == -1 && leftBreak) && dir.x == 0);
    {       
        if (dir.y != 0)
        {
            if (dir.y == 1 && upBreak)
                return true;
            else if (dir.y == -1 && downBreak)
                return true;
        }
        if (dir.x != 0)
        {
            if (dir.x == 1 && rightBreak)
                return true;
            else if (dir.x == -1 && leftBreak)
                return true;
        }
        return false;
    }
    public bool IsOutsideCollision(Vector2Int dir)  //((dir.y == 1 && downBreak) || (dir.y == -1 && upBreak) && dir.y == 0) | ((dir.x == 1 && leftBreak) || (dir.x == -1 && rightBreak) && dir.x == 0);
    {
        if (dir.y != 0)
        {
            if (dir.y == 1 && downBreak)
                return true;
            else if (dir.y == -1 && upBreak)
                return true;
        }
        if (dir.x != 0)
        {
            if (dir.x == 1 && leftBreak)
                return true;
            else if (dir.x == -1 && rightBreak)
                return true;
        }
        return false;
    }
    public ColliderCell(bool upBreak, bool rightBreak, bool downBreak, bool leftBreak)
    {
        this.upBreak = upBreak;
        this.rightBreak = rightBreak;
        this.downBreak = downBreak;
        this.leftBreak = leftBreak;
    }
    public ColliderCell()
    {
        this.upBreak = false;
        this.rightBreak = false;
        this.downBreak = false;
        this.leftBreak = false;
    }

  /*  public static ColliderCell operator +(ColliderCell a, ColliderCell b)
    {
        bool upBreak = a.upBreak || b.upBreak;
        bool rightBreak = a.rightBreak || b.rightBreak;
        bool downBreak = a.downBreak || b.downBreak;
        bool leftBreak = a.leftBreak || b.leftBreak;
        return new ColliderCell(upBreak,rightBreak,downBreak,leftBreak);
    }
    public static ColliderCell operator +(ColliderCell a, Block b)
    {
        bool upBreak = a.upBreak || b.Collider.upBreak;
        bool rightBreak = a.rightBreak || b.Collider.rightBreak;
        bool downBreak = a.downBreak || b.Collider.downBreak;
        bool leftBreak = a.leftBreak || b.Collider.leftBreak;
        return new ColliderCell(upBreak, rightBreak, downBreak, leftBreak);
    }*/
}
