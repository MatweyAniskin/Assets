using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastExit : MonoBehaviour
{   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            Application.Quit();
    }
}
