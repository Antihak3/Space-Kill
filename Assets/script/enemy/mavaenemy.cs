using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mavaenemy : MonoBehaviour
{
    public float Speed;
    public Vector2 moveDir;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir * Time.deltaTime * Speed);
       
    }
}
