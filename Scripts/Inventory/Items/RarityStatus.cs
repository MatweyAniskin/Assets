using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rarity",menuName = "Items/RarityStatus")]
public class RarityStatus : ScriptableObject
{
    [SerializeField] Color rarityColor;

    public Color RarityColor => rarityColor;
}
