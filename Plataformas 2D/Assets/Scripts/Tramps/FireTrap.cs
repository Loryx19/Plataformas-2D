using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] Collider2D FireCollider;
    [SerializeField] Animator Anim;
    [SerializeField] float TimeToFire, TimeToOff;
    float time, time2;
    bool on, off;
    // Start is called before the first frame update
    void Awake()
    {
        Anim= GetComponent<Animator>();
        FireCollider.enabled = false;
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            time += Time.deltaTime;
            if (time >= TimeToFire)
            {
                time = TimeToFire;
                Anim.SetBool("On", true);
                FireCollider.enabled = true;
                time2 = 0;
                on= false;
                off = true;
            }
        }
        if(off)
        {
            time2 += Time.deltaTime;
            if (time2 >= TimeToOff)
            {
                time2 = TimeToOff;
                Anim.SetBool("On", false);
                FireCollider.enabled = false;
                time = 0;
                on = true;
                off = false;
            }
        }
    }
}
