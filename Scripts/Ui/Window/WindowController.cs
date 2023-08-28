using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public static Window RequestWindow { get; set; }
    static Window curWindow;
    public static Window CurWindow
    {
        get
        {
            return curWindow;
        }
        set
        {
            if(curWindow != null)
                curWindow.Close();
            curWindow = value;
        }
    }
    static bool isOpened = false;
    
    public delegate void OpenWindow();
    public event OpenWindow OnOpenInventory;
    public event OpenWindow OnWindowClose;
    public delegate void ChangeWindow(bool value);
    public static event ChangeWindow OnWindowOpen;

    public static bool IsOpened
    {
        get
        {
            return isOpened;
        }
        set
        {
            isOpened = value;
            /*if (isOpened = Cursor.visible = value)
            {
                Cursor.lockState = CursorLockMode.None;
                
            }else
            {
                Cursor.lockState = CursorLockMode.Locked;                
            }*/
            OnWindowOpen?.Invoke(value);
        }
    }
    
    private void Start()
    {             
        IsOpened = false;
    }
    private void OnDestroy()
    {        
    }   
}
