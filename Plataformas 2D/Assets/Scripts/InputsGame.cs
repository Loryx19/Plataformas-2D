using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsGame : MonoBehaviour
{
     [HideInInspector]public float Horizontal;
     [HideInInspector]public bool Jump;

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Jump = Input.GetButtonDown("Jump");
    }
}
