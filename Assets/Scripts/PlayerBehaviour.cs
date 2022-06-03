using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Animator animecontroller;
    Rigidbody2D Myrigidbody;
    [SerializeField] float movespeed;
    float direction;
    bool faceright = true;
    Vector2 localscale;
    [SerializeField] GameObject lavaball;
    [SerializeField] Transform gun;
    
    // Start is called before the first frame update
    void Start()
    {
        Myrigidbody = GetComponent<Rigidbody2D>();   
        animecontroller = GetComponent<Animator>();
        localscale = transform.localScale;
        movespeed = 3f;
    }
    void death()
    {
        Destroy(gameObject);    
    }
   
    void onfire()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            animecontroller.SetBool("attack", true);
            Instantiate(lavaball, gun.position, transform.rotation);
        }
        else
        {
            animecontroller.SetBool("attack", false);
        }
    }
    void crouch()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animecontroller.SetBool("crouch", true);
            Debug.Log("crouch");
        }
        else
        {
            animecontroller.SetBool("crouch", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        crouch();
        onfire();
        direction = Input.GetAxis("Horizontal")* movespeed;
        animecontroller.SetBool("walk", true);

        if (Input.GetKeyDown(KeyCode.Space) && Myrigidbody.velocity.y == 0)
            Myrigidbody.AddForce(Vector2.up * 600f);

        if (Mathf.Abs(direction) > 0 && Myrigidbody.velocity.y == 0)
            animecontroller.SetBool("jump", true);
        else
            animecontroller.SetBool("walk", false);

        if (Myrigidbody.velocity.y == 0)
        {
            animecontroller.SetBool("jump", false);
        }
        if (Myrigidbody.velocity.y > 0)
            animecontroller.SetBool("jump", true);
        if (Myrigidbody.velocity.y < 0)
        {
            animecontroller.SetBool("jump", false);
        }
    }
    private void FixedUpdate()
    {
        Myrigidbody.velocity = new Vector2(direction, Myrigidbody.velocity.y);
    }
    private void LateUpdate()
    {
        if (direction > 0)
            faceright = true;
        else if (direction < 0)
            faceright = false;

        if(((faceright)&(localscale.x<0))||((!faceright)&&(localscale.x>0)))
            localscale.x *= -1;
        transform.localScale = localscale;
    }
}
