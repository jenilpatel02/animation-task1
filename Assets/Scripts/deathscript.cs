using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathscript : MonoBehaviour
{
    
    public Animator anim1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim1.SetTrigger("death");
    }
}
