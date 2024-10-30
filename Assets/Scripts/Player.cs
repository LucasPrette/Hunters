using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpForce = 500.0f;

    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator anim;

    public Transform groundCheck;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        float horizontal = Input.GetAxis("Horizontal");
        FlipChar(horizontal);

        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(horizontal));
        
        if(returnGroundCheck() && Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

        // if(Input.GetMouseButtonDown(0)) {
        //     anim.SetTrigger("attack");
        // }

    }

    private void Jump() {
        body.AddForce(new Vector2(0, jumpForce));
        anim.SetTrigger("Jump");
    }
    

    private bool returnGroundCheck() {
        isFalling();
        if(body.velocity.y <= 0){
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.5f, groundLayer);

            for(int i = 0; i < colliders.Length; i++) {

                if(colliders[i].gameObject != gameObject) {
                    return true;
                }
            }
        }
        return false;
    }



    private void FlipChar(float horizontal) {
        if(horizontal > 0){
            sprite.flipX = false;
        } else if(horizontal < 0){
            sprite.flipX = true;
        } 
    }

    private void isFalling() {
        if(body.velocity.y < 0){
            anim.SetBool("Falling", true);
        }else {
            anim.SetBool("Falling", false);
        };
    }
}
