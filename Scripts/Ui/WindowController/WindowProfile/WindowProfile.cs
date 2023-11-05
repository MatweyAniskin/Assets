using UnityEngine;

[CreateAssetMenu(fileName = "WindowProfile", menuName = "Logic/Window/WindowsProfile")]
public class WindowProfile : ScriptableObject
{
    [SerializeField] protected Window window;
    public virtual void Init(WindowInstaller installer)
    {

    }
    public virtual void End(WindowInstaller installer)
    {

    }
    public virtual void InteractWithThisWindow() => WindowController.InstantiateWindow(this);
    public virtual Window Window => window;
}
