using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour
{
    public GameObject[] bonuses;
    public int lifePoints = 4;
    public bool isDead = false;
    public GameObject Ship;

    public soundMeneger sm;


    // Start is called before the first frame update
    void Start()
    {

        Ship = GameObject.Find("PLayerShip");

        sm = GameObject.Find("playZone").GetComponent<soundMeneger>();
    }

    private void Update()
    {
        if(lifePoints <= 0 && !isDead)
        {
            Boomm();
            sm.PlaySound(0);
        }
    }
    void Boomm()
    {
        isDead = true;
        GameObject bonus = bonuses[Random.Range(0, bonuses.Length)];
        GameObject b = Instantiate(bonus, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
       

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shipbull"))
        {
            lifePoints--;
            Destroy(collision.gameObject);
            sm.PlaySound(5);
        }

        if (collision.gameObject.CompareTag("rocket"))
        {
            lifePoints=0;
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.CompareTag("PlayerShip"))
        {
            Ship.GetComponent<shipcontrol>().Damage(3);
            Destroy(gameObject);
            sm.PlaySound(0);
        }
    }

  

}
