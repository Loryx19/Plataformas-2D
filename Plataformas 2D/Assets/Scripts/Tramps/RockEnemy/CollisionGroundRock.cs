using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGroundRock : MonoBehaviour
{
    [SerializeField] RockEnemy Rock;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Rock.StartCoroutine(Rock.VuelveEnemigo());
        }
    }
}
