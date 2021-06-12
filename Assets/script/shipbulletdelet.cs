using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipbulletdelet : MonoBehaviour
{

    public soundMeneger sm;

    void Start()
    {
        sm = GameObject.Find("playZone").GetComponent<soundMeneger>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shipenemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            sm.PlaySound(1);
        }
    }
}
