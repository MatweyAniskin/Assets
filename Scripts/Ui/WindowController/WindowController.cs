using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] Transform canvas;
    public static Window RequestWindow { get; set; }
    static Window curWindow;
    static WindowProfile curProfile;
    static Transform _canvas;
    
    public static WindowProfile CurWindowProfile 
    {
        get => curProfile;
        protected set
        {            
            curProfile = value;
            if (curProfile is null)
            {
                CloseCurWindow();
                return;
            }
                
            curWindow = Instantiate(curProfile.Window, _canvas) as Window;
            curWindow.SetPosition();
        } 
    }
    public static bool IsOpenWindow => !(CurWindowProfile is null);

    public static void InstantiateWindow(WindowProfile window)
    {
        if (CurWindowProfile == window)
        {
            CurWindowProfile = null;
            return;
        }
        CurWindowProfile = window;
            
    }
    public static void ForceClose() => CurWindowProfile = null;
    static void CloseCurWindow()
    {
        if (curWindow is null)
            return;
        curWindow.Close();
        curWindow = null;
    }

    private void Awake()
    {
        _canvas = canvas;
    }
}
