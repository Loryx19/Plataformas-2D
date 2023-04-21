using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer PlayerSprite;
    [SerializeField] Animator Anim;
    [SerializeField] AudioSource Audio;
    [SerializeField] Player_Audio ListaClips;
    [SerializeField] InputsGame Inputs;

    [Header("Move")]
    [SerializeField] float speed;
    [HideInInspector]public Vector3 inicialPoint;

    [Header("Jump")]
    [SerializeField] float JumpForce;
    [SerializeField] Transform[] RayPositions;
    [SerializeField] LayerMask MaskGround;
    [SerializeField] float GroundCheckLengh;
    [Header("DobleJump")]
    bool IsAir;
    [SerializeField] float DobleForce;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerSprite = GetComponent<SpriteRenderer>();  
        Anim= GetComponent<Animator>();
        Audio = GetComponentInChildren<AudioSource>();
        ListaClips = GetComponentInChildren<Player_Audio>();
        Inputs = GetComponent<InputsGame>();
    }
    private void Start()
    {
        inicialPoint = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpPlayer();
        DobleJump();
        Flip();
        Anim.SetBool("IsGrounded", IsGrounded());
        Anim.SetBool("Jump", Inputs.Jump);
    }
    public void MovePlayer()
    {
        rb.velocity = new Vector2(Inputs.Horizontal * speed, rb.velocity.y);
        Anim.SetFloat("Move", Inputs.Horizontal);
    }
    public void JumpPlayer()
    {
        if(IsGrounded())
        {
            if(Inputs.Jump)
            {
                Audio.PlayOneShot(ListaClips.JumpClip);
                rb.AddForce(new Vector2(rb.velocity.x, JumpForce), ForceMode2D.Impulse);
                IsAir = true;
            }
        }
    }
    public void DobleJump()
    {
        if(!IsGrounded() && IsAir)
        {         
            if (Inputs.Jump)
            {
                Audio.PlayOneShot(ListaClips.JumpClip);
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(rb.velocity.x, DobleForce), ForceMode2D.Impulse);
                IsAir = false;
            }           
        }
    }
    public bool IsGrounded()
    {
        for(int i = 0; i < RayPositions.Length; i++)
        {
            if (Physics2D.Raycast(RayPositions[i].position, Vector2.down, GroundCheckLengh, MaskGround))
            {
                return true;
            }
        }
        return false;
    }

    
    public void Flip()
    {
        if(Inputs.Horizontal <0)
        {
            PlayerSprite.flipX = true;
        }
        else if (Inputs.Horizontal > 0)
        {
            PlayerSprite.flipX = false;
        }
    }
}
