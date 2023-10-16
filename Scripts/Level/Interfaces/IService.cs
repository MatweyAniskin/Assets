using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IService
{
    public int Order { get; }
    public string Name { get; }
    public void StartWork();
    public bool Next();    

}
