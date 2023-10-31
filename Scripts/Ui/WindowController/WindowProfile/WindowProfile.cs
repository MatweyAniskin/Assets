using UnityEngine;

[CreateAssetMenu(fileName = "WindowProfile", menuName = "Logic/Window/WindowsProfile")]
public class WindowProfile : ScriptableObject
{
    [SerializeField] Window window;
    public virtual void Start()
    {

    }
    public virtual void End()
    {

    }
    public virtual void OpenWindow() => WindowController.InstantiateWindow(window);
}
