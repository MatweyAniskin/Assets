using UnityEngine;

public class MouseDirection : MonoBehaviour
{
    public static Vector2Int GetMouseDir()
    {
        Vector3 mouse = Input.mousePosition;
        float xPercent = mouse.x / Screen.width;
        float yPercent = mouse.y / Screen.height;
        return new Vector2Int(ScreenPercentToDir(yPercent), -ScreenPercentToDir(xPercent));
    }
    static int ScreenPercentToDir(float percent)
    {
        if (percent <= 0.33f)
        { return -1; }
        else
        {
            if (percent <= 0.66f)
            { return 0; }
            else
            { return 1; }
        }
    }
}
