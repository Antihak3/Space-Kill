using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shipcontrol : MonoBehaviour
{
    public int Life_points;
    public Image[] lisePoints;
    public Color[] liseColors;
    public float speed;
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;
    public GameObject bullet;
    public GameObject rocket;
    public int rocketCont;
    public Text rockettext;
    public float shootDelay;
    public Transform[] shootPoints;
    public Transform rocketPoint;
    public bool isFire;
    public bool isReade;
    public int bulletDmg;
    public soundMeneger sm;
    public int coins;
    public Text coinText;
    public int scoreCount;
    public Text scoreCountText;
    public Sprite[] Ships;
    public bool IsOver;
    public GameObject gameOverPannel;
   // public ParticleSystem DeadF;
    public GameObject FireShipTurbo;
    public GameObject DeadFX;
    public ADSrolik AD;
    public int DeadCount = 0;
    public GameObject mainMenu;
    
    

     void Start()
    {
        int shipNuM = PlayerPrefs.GetInt("ship");
        GetComponent<SpriteRenderer>().sprite = Ships[shipNuM];


        isReade = true;
        isFire = false;

        coins = PlayerPrefs.GetInt("coins", 0);

        DeadCount = PlayerPrefs.GetInt("DC", 0);
       
        //.GetComponent<mainmenu>.

    }

    


    public void move (Vector2 dir)
    {
        transform.Translate(dir * Time.deltaTime * speed);
    }






    private void Update()
    {
        ChangeLise();

        scoreCountText.text = scoreCount.ToString();

        coinText.text = coins.ToString();

        rockettext.text = rocketCont.ToString();

        Vector2 curPos = transform.localPosition;
        curPos.y = Mathf.Clamp(transform.localPosition.y, minY, maxY);
        curPos.x = Mathf.Clamp(transform.localPosition.x, minX, maxX);
        transform.localPosition = curPos;

        if (isFire && isReade)
        {
           
            Shoot();
        }
        if(Life_points <= 0 && !IsOver)
        {
            GameOver();
        }


    }

    void GameOver()
    {
        DeadCount++;

        IsOver = true;
        GameObject p = Instantiate(DeadFX, transform.position, Quaternion.identity) as GameObject;

        p.GetComponent<ParticleSystem>().Play();
        Destroy(p, p.GetComponent<ParticleSystem>().duration);

        sm.PlaySound(0);
        Hide();
        Save();
        gameOverPannel.SetActive(true);

        if(DeadCount == 1)
        {
           
            DeadCount = 0;
        }

        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("HS",0);

    }

     void Hide()
    {
        FireShipTurbo.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }

    void ChangeLise()
    {
        for (int l = 0; l < lisePoints.Length; l++)
        {
            if(l < Life_points)
            {
                lisePoints[l].color = liseColors[0];
            }

            else
            {
                lisePoints[l].color = liseColors[1];
            }
        }
    }


    void Shoot()
    {
        
        
            foreach (Transform sp in shootPoints)
            {
                GameObject b = Instantiate(bullet, sp.position, Quaternion.identity) as GameObject;
            Destroy(b, 2.7f);
                if (sp == shootPoints[shootPoints.Length-1])
                {
                    StartCoroutine(ShootDelay());
                }
            }

        sm.PlaySound(6);
      
    }


    public void rocketShoot()
    {
       
        
            if (rocketCont > 0)
            {
                GameObject o = Instantiate(rocket, transform.position, Quaternion.identity) as GameObject;
                rocketCont--;
            }
        sm.PlaySound(2);
    }

    

    IEnumerator ShootDelay()
    {
        isReade = false;
        yield return new WaitForSeconds(shootDelay);
        isReade = true;
    }


    public void Fire(bool fire)
    {
        isFire = fire;
    }

   


    public void Damage(int dmg)
    {
        Life_points -= dmg;
        if (Life_points <= 0)
        {
            Life_points = 0;
        }

        ChangeLise();
    }


    public void AddScore(int scoreToAdd)
    {
        scoreCount += scoreToAdd;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shipenemy"))
        {
            Damage(1);
            Destroy(collision.gameObject);
            sm.PlaySound(5);
        }


        if (collision.gameObject.CompareTag("enemy"))
        {
            Damage(3);
            Destroy(collision.gameObject);
            sm.PlaySound(0);
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            sm.PlaySound(4);
        }
    }


    void Save()
    {
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("NewScore", scoreCount);
        if (!PlayerPrefs.HasKey("HS"))
        {
            PlayerPrefs.SetInt("HS", scoreCount);
        }
        else
        {
            int hs = PlayerPrefs.GetInt("HS");
            if(hs< scoreCount)
            {
                PlayerPrefs.SetInt("HS", scoreCount);
            }
        }
        PlayerPrefs.SetInt("DC", DeadCount);
    }


     void OnApplicationQuit()
    {
        Save();
    }
}
