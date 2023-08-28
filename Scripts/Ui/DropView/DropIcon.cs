using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropIcon : ItemDragHandler
{
    [SerializeField] Image image;
    [SerializeField] float animationMaxY = 10;
    [SerializeField] float animationSpeed = 3;
    [SerializeField] CanvasGroup group;

    public delegate void ChangeDropIcon(Drop drop);
    public static event ChangeDropIcon OnCursorDrag;
    public static event ChangeDropIcon OnCursorEnd;

    Camera camera;
    Drop drop;
    bool toDestroy = false;
    public void SetDrop(Drop drop, Camera camera)
    {
        image.sprite = drop.GetItem().Icon;
        this.drop = drop;
        this.item = drop.GetItem();
        this.camera = camera;
        StartCoroutine(Animation());
    }
    public void Destroy()
    {
        toDestroy = true;
        StartCoroutine(DestroyAnimation());
    }
    private void Update()
    {
        if (drop is null || toDestroy)
            return;
        transform.position = camera.WorldToScreenPoint(drop.transform.position);
    }
    IEnumerator DestroyAnimation()
    {
        float index = 0;
        Vector3 baseImagePosition = image.transform.localPosition;
        Vector3 downImagePosition = baseImagePosition + Vector3.down * animationMaxY;
        while (index < 1)
        {
            index += Time.deltaTime * animationSpeed;
            group.alpha = 1 - index;
            image.transform.localPosition = Vector3.Lerp(baseImagePosition, downImagePosition, index);
            yield return null;
        }
        Destroy(gameObject);
    }
    IEnumerator Animation()
    {
        float index = 0;
        Vector3 baseImagePosition = image.transform.localPosition;
        Vector3 upImagePosition = baseImagePosition + Vector3.up * animationMaxY;
        while (index < 1)
        {

            index += Time.deltaTime * animationSpeed;
            group.alpha = index;
            image.transform.localPosition = Vector3.Lerp(baseImagePosition, upImagePosition, index);
            yield return null;
        }
        while (index > 0)
        {

            index -= Time.deltaTime * animationSpeed;
            image.transform.localPosition = Vector3.Lerp(baseImagePosition, upImagePosition, index);
            yield return null;
        }
    }

    
}
