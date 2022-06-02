using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaballs : MonoBehaviour
{
    float lavaspeed = 10f;
    Rigidbody2D ballrb;
    PlayerBehaviour player;
    float horizontalspeed;
    bool faceright = true;
    // Start is called before the first frame update
    void Start()
    {
        ballrb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerBehaviour>();
        horizontalspeed = player.transform.localScale.x * lavaspeed;
    }

    // Update is called once per frame
    void Update()
    {
        ballrb.velocity = new Vector2(horizontalspeed, 0f);
        
        if (horizontalspeed > 0 && !faceright)
        {
            Flip(horizontalspeed);
        }

        else if (horizontalspeed < 0 && faceright)
        {
            Flip(horizontalspeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void Flip(float x)
{
    faceright = !faceright;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
}


}
