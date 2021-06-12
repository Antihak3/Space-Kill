using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineboom : MonoBehaviour
{
    public float disToActive;
    public GameObject Ship;
    public float speed;
    public soundMeneger sm;

   
    // Start is called before the first frame update
    void Start()
    {
        Ship = GameObject.Find("PLayerShip");
        sm = GameObject.Find("playZone").GetComponent<soundMeneger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -14)
        {
            Destroy(gameObject);
        }

        if (Vector2.Distance(transform.position, Ship.transform.position)<= disToActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, Ship.transform.position, Time.deltaTime * speed);
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShip"))
        {
            Ship.GetComponent<shipcontrol>().Damage(3);
            Destroy(gameObject);
            sm.PlaySound(0);
        }

        if (collision.gameObject.CompareTag("shipbull"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            sm.PlaySound(0);
            desc();
        }

        if (collision.gameObject.CompareTag("rocket"))
        {
            desc();
           
            sm.PlaySound(0);

        }

        if (collision.gameObject.CompareTag("shipenemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            sm.PlaySound(0);
        }
    }

    void desc()
    {
       
        Ship.GetComponent<shipcontrol>().AddScore(1);
    }
}
