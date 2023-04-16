using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer PlayerSprite;
    [SerializeField] Animator Anim;
    //AudioSorce

    [Header("Move")]
    [SerializeField] float speed;
    float Horizontal;

    [Header("Jump")]
    [SerializeField] bool Jump;
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
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        MovePlayer();
        JumpPlayer();
        DobleJump();
        Flip();
        Anim.SetBool("IsGrounded", IsGrounded());
        Anim.SetBool("Jump", Jump);
    }
    public void MovePlayer()
    {
        rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);
        Anim.SetFloat("Move", Horizontal);
    }
    public void JumpPlayer()
    {
        if(IsGrounded())
        {
            if(Jump)
            {
                rb.AddForce(new Vector2(rb.velocity.x, JumpForce), ForceMode2D.Impulse);
                IsAir = true;
            }
        }
    }
    public void DobleJump()
    {
        if(!IsGrounded() && IsAir)
        {         
            if (Jump)
            {
                rb.AddForce(new Vector2(rb.velocity.x, DobleForce), ForceMode2D.Impulse);
                IsAir = false;
            }           
        }
    }
    void InputPlayer()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Jump = Input.GetButtonDown("Jump");
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
        if(Horizontal <0)
        {
            PlayerSprite.flipX = true;
        }
        else if  (Horizontal > 0)
        {
            PlayerSprite.flipX = false;
        }
    }
}
