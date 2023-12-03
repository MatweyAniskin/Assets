using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SolidType", menuName = "Blocks/SolidType")]
public class SolidType : ScriptableObject
{
    [SerializeField] private string TypeName;
    [SerializeField] bool isNotMovement = true;
    public bool IsNotMovement => isNotMovement;
    public static bool operator ==(SolidType lhs, SolidType rhs) => lhs.TypeName == rhs.TypeName;
    public static bool operator !=(SolidType lhs, SolidType rhs) => !(lhs == rhs);
}
