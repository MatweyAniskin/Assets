using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropViewWindow : MonoBehaviour
{
    [SerializeField] DropIcon dropIcon;
    
    Dictionary<Drop, DropIcon> dropIcons = new Dictionary<Drop, DropIcon>();
    Camera camera;

    private void Start()
    {
        camera = Camera.main;
        Drop.OnViewDrop += View;
        Drop.OnEndViewDrop += Destroy;
    }
    private void OnDestroy()
    {
        Drop.OnViewDrop -= View;
        Drop.OnEndViewDrop -= Destroy;
    }
    void View(Drop drop)
    {
        DropIcon temp = Instantiate(dropIcon, camera.WorldToScreenPoint(drop.transform.position), Quaternion.Euler(Vector3.zero), transform) as DropIcon;
        temp.SetDrop(drop,camera);
        dropIcons.Add(drop, temp);
    }
    void Destroy(Drop drop)
    {
        if (dropIcons.TryGetValue(drop, out DropIcon dropIcon))
        {
            dropIcon.Destroy();
            dropIcons.Remove(drop);
        }            
    }
}
