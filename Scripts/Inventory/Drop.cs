using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : UsingObject
{    
    [SerializeField] protected SpriteRenderer renderer;
    [SerializeField] protected Item item;
    [SerializeField] Rigidbody2D rigidbody;   
    public delegate void ViewDrop(Drop drop);
    public static event ViewDrop OnViewDrop;
    public static event ViewDrop OnEndViewDrop;
    private void Start() //Unit
    {
        if (item is null)
            return;
        SetItem(item);

    }
    public Item GetItem() => item;

    public void SetItem(Item item)
    {
        this.item = item;
        renderer.sprite = item.Icon;
        StartPlayerCheck();
    }     
    private void OnDestroy()
    {
        OnEndViewDrop?.Invoke(this);
    }

    protected override void OnView()
    {
        OnViewDrop?.Invoke(this);
    }

    protected override void OnExitView()
    {
        OnEndViewDrop?.Invoke(this);
    }

    protected override void OnExitActiveDistance()
    {
        Destroy(gameObject);
    }

    public override void UseObject()
    {
        Inventory inventory = PlayerObject.GetComponent<Inventory>();        
        if (inventory.TakeItem(this))
        {
            OnEndViewDrop?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
