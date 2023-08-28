using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UsingObject : MonoBehaviour
{
    [SerializeField] float viewRadius = 1f;
    [SerializeField] float activeRadius = 50f;

    protected void StartPlayerCheck() => StartCoroutine(PlayerCheck());
    IEnumerator PlayerCheck()
    {
        float distance;
        bool isView = false;
        while ((distance = PlayerObject.Distance(transform.position)) <= activeRadius)
        {
            if (distance <= viewRadius)
            {
                if (!isView)
                {
                    OnView();
                    UsingController.AddUsingObject(this);
                    isView = true;
                }
            }
            else
            {
                if (isView)
                {
                    OnExitView();
                    UsingController.RemoveUsingObject(this);
                    isView = false;
                }
            }
            yield return null;
        }
        OnExitActiveDistance();
    }
    private void OnDisable()
    {
        UsingController.RemoveUsingObject(this);
    }
    public abstract void UseObject();
    protected abstract void OnView();
    protected abstract void OnExitView();
    protected abstract void OnExitActiveDistance();
}
