using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Items
{
    public class Drop : MatrixTransform, IInteractiveObject
    {
        [SerializeField] Item item;

        public event IInteractiveObject.DragDelegate OnDetectorEnter;
        public event IInteractiveObject.DragDelegate OnDetectorExit;

        /// <summary>
        /// Set item and matrix start position, use once
        /// </summary>
        /// <param name="item"></param>
        /// <param name="position">global matrix position</param>
        public void SetItem(Item item, Vector2Int position)
        {
            SetItem(item);
            SetStartPosition(position);
        }
        /// <summary>
        /// Just set item
        /// </summary>
        /// <param name="item"></param>
        public void SetItem(Item item)
        {
            this.item = item;
        }

        public void UseObject(MatrixTransform user)
        {
            Inventory inventory = user.GetComponent<Inventory>();
            if (inventory.TakeItem(item))
                TakeItem();
        }
        public void TakeItem()
        {
            Destroy();
        }

        public void OnEnter() => OnDetectorEnter?.Invoke();

        public void OnExit() => OnDetectorExit?.Invoke();

        public Item Item => item;

        public Sprite Icon => item.Icon;

        public string Title => item.Title;

        public string Description => item.Description;

        Vector3 IInteractiveObject.Position => transform.position;
    }
}
