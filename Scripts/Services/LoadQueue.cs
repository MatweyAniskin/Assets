using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoadQueue : MonoBehaviour
{    
    public delegate void LoadQueueDelegate(string serviceName);
    public static event LoadQueueDelegate OnStartLoadService;
    public static event LoadQueueDelegate OnEndLoadService;
    public delegate void LoadStackDelegate();
    public static event LoadStackDelegate OnLoadStackEnd;

    Stack<IService> services;

    private void Start()
    {
        services = new Stack<IService>(GetComponents<IService>().OrderByDescending(i => i.Order).ToList());
        StartCoroutine(LoadCoroutine());
    }
    IEnumerator LoadCoroutine()
    {
        while(services.Count > 0)
        {
            IService service = services.Pop();
            service.StartWork();
            OnStartLoadService?.Invoke(service.Name);
            yield return null;
            while (service.Next())
                yield return null;
            OnEndLoadService?.Invoke(service.Name);
        }
        OnLoadStackEnd?.Invoke();
    }
}