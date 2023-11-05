using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowInstaller : MonoBehaviour
{
    [SerializeField] KeyProfile forceCloseKey;
    [SerializeField] List<WindowProfile> windows;

    private void Start()
    {
        windows.ForEach(i => i.Init(this));
        KeyController.OnKeyDown += ForceClose;
    }
    private void OnDestroy()
    {
        windows.ForEach(i => i.End(this));
        KeyController.OnKeyDown -= ForceClose;
    }
    public void ForceClose(KeyProfile key)
    {
        if (key == forceCloseKey)
            WindowController.ForceClose();
    }
}
