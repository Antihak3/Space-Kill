using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorspeed : MonoBehaviour
{
    public float speed;
    public Vector2 dir;


    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
    }

}
