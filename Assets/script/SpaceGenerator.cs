using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGenerator : MonoBehaviour
{
   
    public GameObject[] stars;
    public float minY;
    public float maxY;
    public float minSpeed;
    public float maxSpeed;
    public float minScale;
    public float maxScale;
    public Color[] colors;
    public float interval;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, interval);
    }

    // Update is called once per frame
    void Spawn()
    {
       GameObject star = stars[Random.Range(0,stars.Length)];
        Vector2 pos = new Vector2(transform.position.x, Random.Range(minY, maxY));
        float scl = Random.Range(minScale, maxScale);
        Vector3 scale = new Vector3(scl, scl, scl);
        float speed = Random.Range(minSpeed, maxSpeed);
        Color color = colors[Random.Range(0,colors.Length)];

        GameObject s = Instantiate(star, pos, Quaternion.identity) as GameObject;
        s.GetComponent<meteorspeed>().speed = speed;
        s.transform.localScale = scale;
        s.GetComponent<SpriteRenderer>().color = color;
    }
}
