using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusVert : MonoBehaviour
{
    public float speed;
    public Vector3 dir;


    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
