using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    public Transform center;
    public float speed;
    private void Update()
    {
        transform.RotateAround(center.position, Vector3.forward, speed * Time.deltaTime);
    }
}
