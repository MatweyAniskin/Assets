using UnityEngine;

[CreateAssetMenu(fileName = "WindowProfile", menuName = "Logic/Window/WindowsProfile")]
public class WindowProfile : ScriptableObject
{
    [SerializeField] protected Window window;
    public virtual void Start(WindowInstaller installer)
    {

    }
    public virtual void End(WindowInstaller installer)
    {

    }
    public virtual Window Window => window;
}
