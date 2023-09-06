using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeValue
{
    List<int> values = new List<int>();
    public int Count => values.Count;
    public int GetValue(int index) => values[index];
    public void Add(int value) => values.Add(value);
    public int GeneralValue
    {
        get
        {
            int rez = 0;
            values.ForEach(i =>  rez += i);
            return rez;
        }
    }
}
