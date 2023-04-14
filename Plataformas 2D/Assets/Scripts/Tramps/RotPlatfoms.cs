using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class RotPlatfoms : MonoBehaviour
{
    
    [SerializeField] BoxCollider2D ColliderBox;
    [SerializeField] GameObject[] PlatfomsList;
    [SerializeField] float AnguleOfRot;
    [SerializeField] float TimeToRot, TimeAgainToRot;
    float time, timeb;
    bool ControlTimeToRoot = true;
    // Update is called once per frame
    void Update()
    {
        if(ControlTimeToRoot)
        {
            time += Time.deltaTime;
            if (time >= TimeToRot)
            {

                ColliderBox.enabled = false;
                for (int i = 0; i < PlatfomsList.Length; i++)
                {
                    PlatfomsList[i].transform.eulerAngles = new Vector3(0, 0, AnguleOfRot);
                }
                time = TimeToRot;
                ControlTimeToRoot = false;
                timeb = 0;
            }
        }
        if(!ControlTimeToRoot)
        {
            timeb += Time.deltaTime;
            if(timeb >= TimeAgainToRot)
            {
                ColliderBox.enabled = true;
                for (int i = 0; i < PlatfomsList.Length; i++)
                {
                    PlatfomsList[i].transform.eulerAngles = new Vector3(0, 0, 0);
                }
                timeb = TimeAgainToRot;
                ControlTimeToRoot = true;
                time = 0;
            }
        }
        Debug.Log(time);
    }
}
