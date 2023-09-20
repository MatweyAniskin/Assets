using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Material", menuName = "Blocks/Block Material")]
public class BlockMaterial : ScriptableObject
{
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject shiverEffect;
    [SerializeField] int hardnessIndex;

    public static bool operator ==(BlockMaterial a, int b) => a.hardnessIndex == b;
    public static bool operator !=(BlockMaterial a, int b) => a.hardnessIndex != b;
    public static bool operator <(BlockMaterial a, int b) => a.hardnessIndex < b;
    public static bool operator >(BlockMaterial a, int b) => a.hardnessIndex > b;
    public static bool operator <=(BlockMaterial a, int b) => a.hardnessIndex <= b;
    public static bool operator >=(BlockMaterial a, int b) => a.hardnessIndex >= b;
}
