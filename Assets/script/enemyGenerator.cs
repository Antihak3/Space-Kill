using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{

    public GameObject[] enemys;
    public GameObject bonus;
    public float minDelay;
    public float maxDelay;
 
    public float minY;
    public float maxY;
    // Start is called before the first frame update
    void Start()
    {
        Spawnstar();
    }

    // Update is called once per frame
    void Spawnstar()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        Vector2 pos = new Vector2(transform.position.x, Random.Range(minY, maxY));
        GameObject e = Instantiate(enemys[Random.Range(0, enemys.Length)], pos, Quaternion.identity) as GameObject;
        int r = Random.Range(0, 100);
        Vector2 Bonus_pos = new Vector2(transform.position.x, Random.Range(minY, maxY));

        if (r <= 15)
        {
            GameObject ats= Instantiate(bonus, Bonus_pos, Quaternion.identity) as GameObject;
        }

        Spawnstar();
    }
}
