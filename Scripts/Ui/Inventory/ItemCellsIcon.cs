using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCellsIcon : IconWithShadow
{
    [SerializeField] Text infoText;
    [SerializeField] float selectAnimationSpeed = 4;
    [SerializeField] GameObject selectRamp;
    [SerializeField] Vector3 standartScale = Vector3.one;
    [SerializeField] Vector3 maxScale = new Vector3(1.25f, 1.25f, 1.25f);
    [SerializeField] float animationSpeed = 4;
    [SerializeField] Button button;
    [SerializeField] EventTrigger eventTriggerForHighLight;

    protected InventoryItem item;
    public Item Item => item.Item;
    public Vector2 Pos => rect.anchoredPosition;

    private void Start()
    {
        EventController.AddEvent(ref button, Click);
        EventController.AddEvent(ref eventTriggerForHighLight, EventTriggerType.PointerEnter, HighlightStart);
        EventController.AddEvent(ref eventTriggerForHighLight, EventTriggerType.PointerExit, HighlightEnd);
    }    
    void Click()
    {
        Debug.Log("Click");
    }
    void HighlightStart()
    {
        selectRamp.SetActive(true);
        StartCoroutine(SelectAnimation());
    }
    void HighlightEnd()
    {
        selectRamp.SetActive(false);
    }
    public virtual void SetItem(InventoryItem item, Vector2 position)
    {
        SetItem(item);   
        SetPosition(position);
    }
    public virtual void SetItem(InventoryItem item)
    {
        this.item = item;
        infoText.color = item.Item.RarityColor;
        infoText.text = $"{item.Item}: {item.Count}";
        SetIcon(item.Item.Icon);        
    }
    public void OnSelected()
    {
        selectRamp.SetActive(true);
        StartCoroutine(SelectAnimation());
    }
    public void OnUnSelected()
    {
        selectRamp.SetActive(false);
    }    
    IEnumerator SelectAnimation()
    {
        float index = 0;
        Transform rampTransform = selectRamp.transform;
        while (index < 1 && selectRamp.activeSelf)
        {
            index += Time.deltaTime * animationSpeed;
            rampTransform.localScale = Vector3.Lerp(maxScale, standartScale, index);
            yield return null;
        }
    }
}
