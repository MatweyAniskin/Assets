using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] Transform canvas;
    public static Window RequestWindow { get; set; }
    static Window curWindow;
    static Transform _canvas;
    public static Window CurWindow
    {
        get
        {
            return curWindow;
        }
        protected set
        {
            ForceClose();
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
            OnWindowOpen?.Invoke(value);
        }
    }
    public static void InstantiateWindow(WindowProfile window)
    {
        CurWindow = Instantiate(window.Window, _canvas) as Window;
        CurWindow.SetPosition();
    }
    public static void ForceClose()
    {
        if(CurWindow.IsDestroyed())
            return;
        CurWindow.Close();
    }

    private void Awake()
    {
        _canvas = canvas;
    }
}
