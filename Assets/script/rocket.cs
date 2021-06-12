using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    public soundMeneger sm;
    public shipcontrol Ship;

    private void Start()
    {
        sm = GameObject.Find("playZone").GetComponent<soundMeneger>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<simpleEnemy>().Damage(10);
            Destroy(gameObject);
            sm.PlaySound(0);
            sm.PlaySound(1);
          
        }

        if (collision.gameObject.CompareTag("shipenemy"))
        {
            Destroy(collision.gameObject);
           
            sm.PlaySound(0);
            sm.PlaySound(1);
           
        }

        if (collision.gameObject.CompareTag("mine"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            sm.PlaySound(0);
            sm.PlaySound(1);
            
        }
    }
}
