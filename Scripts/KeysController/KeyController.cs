using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] List<KeyProfile> profiles;
    
    public delegate void KeyChange(KeyProfile key);
    public static event KeyChange OnKeyDown;
    public static event KeyChange OnKeyUp;
    public static event KeyChange OnKeyPress;   
    private void Update()
    {
        profiles.ForEach(k =>
        {
            if (k.CheckKeyDown()) OnKeyDown?.Invoke(k);
            if (k.CheckKeyUp()) OnKeyUp?.Invoke(k);
            if (k.CheckKeyPress()) OnKeyPress?.Invoke(k);
        });
    }
}