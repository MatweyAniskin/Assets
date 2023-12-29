using Loader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    public delegate void LoadScreenDelegate();
    public static event LoadScreenDelegate OnStartLoadScreen;
    public static event LoadScreenDelegate OnEndLoadScreen;
    void Start()
    {
        LoadQueue.OnLoadStackStart += StartLoad;
        LoadQueue.OnLoadStackEnd += EndLoad;
    }

    private void OnDestroy()
    {
        LoadQueue.OnLoadStackStart -= StartLoad;
        LoadQueue.OnLoadStackEnd -= EndLoad;
    }
    public virtual void StartLoad() => OnStartLoadScreen?.Invoke();    
    public virtual void EndLoad() => OnEndLoadScreen?.Invoke();
}
