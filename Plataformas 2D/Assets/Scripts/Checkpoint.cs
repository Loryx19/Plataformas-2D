using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Player_Movement player;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource audio;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindAnyObjectByType<Player_Movement>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            audio.PlayOneShot(audio.clip);
            StartCoroutine(StarAnim());
            player.inicialPoint = transform.position;
        }
    }
    IEnumerator StarAnim()
    {
        anim.SetBool("Gived", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Flag", true);
    }
}
