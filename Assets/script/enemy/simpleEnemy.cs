using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleEnemy : MonoBehaviour
{
    public int Life_points;
    public GameObject bullet;
    public float shootDelay;
    public Transform shootPoint;
    public shipcontrol Ship;
    public bool isDead= false;
    public soundMeneger sm;
    public GameObject Coin;
   
    void Start()
    {
        sm = GameObject.Find("playZone").GetComponent<soundMeneger>();
    
    Ship = GameObject.Find("PLayerShip").GetComponent<shipcontrol>();
        InvokeRepeating("Shoot", 2, shootDelay);
    }


    private void Update()
    {
        if (transform.position.x <= -14)
        {
            Destroy(gameObject);
        }

        if (Life_points <= 0 && !isDead)
        {
            Boom();
        }
    }


    void Boom()
    {
        isDead = true;
        Destroy(gameObject);
        sm.PlaySound(0);
        SpawnCoin();
        Ship.AddScore(1);
    }

    void SpawnCoin()
    {
        GameObject c = Instantiate(Coin, transform.position, Quaternion.identity) as GameObject;
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet, shootPoint.position, Quaternion.identity) as GameObject;
       
    }

    public void Damage(int dmg)
    {
        Life_points -= dmg;
        if (Life_points <= 0)
        {
            Life_points = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shipbull"))
        {
            Damage(Ship.bulletDmg);
            Destroy(collision.gameObject);
            

        }

        if (collision.gameObject.CompareTag("shipenemy"))
        {
           
            Destroy(collision.gameObject);
        }
    }

}
