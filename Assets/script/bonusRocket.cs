using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusRocket : MonoBehaviour
{
    
    public shipcontrol Ship;
    public soundMeneger sm;


    void Start()
    {
        sm = GameObject.Find("playZone").GetComponent<soundMeneger>();
        Ship = GameObject.Find("PLayerShip").GetComponent<shipcontrol>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

       
        if (collision.gameObject.CompareTag("PlayerShip"))
            {
            sm.PlaySound(4);
            Destroy(gameObject);
            Ship.rocketCont+=2;
        }
    }
}
