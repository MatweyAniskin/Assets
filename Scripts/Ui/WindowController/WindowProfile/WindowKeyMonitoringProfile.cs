using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WindowProfile", menuName = "Logic/Window/WindowsKeyMonitoringProfile")]
public class WindowKeyMonitoringProfile : WindowProfile
{
    [SerializeField] KeyProfile keyProfileMonitoring;
    public override void Start(WindowInstaller installer)
    {
        KeyController.OnKeyUp += KeyUpListener;
    }
    public override void End(WindowInstaller installer)
    {
        KeyController.OnKeyUp -= KeyUpListener;
    }
    void KeyUpListener(KeyProfile profile)
    {
        if (keyProfileMonitoring != profile) return;
        WindowController.InstantiateWindow(this);
    }
}
