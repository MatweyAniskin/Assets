using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowInstaller : MonoBehaviour
{
    [SerializeField] KeyProfile forceCloseKey;
    [SerializeField] List<WindowProfile> windows;

    private void Start()
    {
        windows.ForEach(i => i.Start(this));
    }
    private void OnDestroy()
    {
        windows.ForEach(i => i.End(this));
    }
}
