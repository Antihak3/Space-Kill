using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public GameObject fx;
    private bool isQuit;
    public shipcontrol Ship;

    private void Start()
    {
        Ship = GameObject.Find("PLayerShip").GetComponent<shipcontrol>();
    }
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime, Space.World);    
    }


    private void OnApplicationQuit()
    {
        isQuit = true;
    }
    private void OnDestroy()
    {
        if (!isQuit && Time.timeScale == 1f && !Ship.IsOver)
        {
            GameObject p = Instantiate(fx, transform.position, Quaternion.identity) as GameObject;

            p.GetComponent<ParticleSystem>().Play();
            Destroy(p, p.GetComponent<ParticleSystem>().duration);
        }
    }
}
