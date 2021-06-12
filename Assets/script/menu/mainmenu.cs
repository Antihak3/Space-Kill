using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    public int hs;
    public int coins;
    public Image[] ships;
    public int shipNum;
    public Image Selector;
    public Color[] SelectorColors;
    public Color[] ShipColors;
    public GameObject priceInCoins;
    public GameObject priceInDollars;
    public string[] PlayButtonTexts;
    public Text PlayButText;
    public Color[] playBotColors;
    public Text CoinsText;
    public Text HS_T;
    public bool[] shipUnlock;

    public bool sound;
    public Color[] SoundColors;
    public Text soundBtn;
    public GameObject soundVKL;
    public GameObject soundViiikl;
    public GameObject NoAds;

    void Start()
    {
        if (PlayerPrefs.GetInt("noads") == 1)
        {
            NoAds.SetActive(false);
        }


            Time.timeScale = 1;

        if (AudioListener.volume == 0)
        {
            soundVKL.SetActive(false);
            soundViiikl.SetActive(true);
            sound = false;
            soundBtn.color = SoundColors[1];
        }
        else
        {
            soundVKL.SetActive(true);
            soundViiikl.SetActive(false);
            sound = true;
            soundBtn.color = SoundColors[0];
        }

        hs = PlayerPrefs.GetInt("HS", 0);
        coins = PlayerPrefs.GetInt("coins",0);
        if(PlayerPrefs.GetInt("ship2") ==1)
        {
            shipUnlock[1] = true;
        }
        else
        {
            shipUnlock[1] = false ;
        }

        if (PlayerPrefs.GetInt("ship3") == 1)
        {
            shipUnlock[2] = true;
        }
        else
        {
            shipUnlock[2] = false;
        }

        ChangeShip(1);
    }

    // Update is called once per frame
    void Update()
    {
        CoinsText.text = coins.ToString();
        HS_T.text = "HIGHSCORE:" + hs.ToString();
    }

    public void Sound()
    {
        if (sound == true)
        {
            soundVKL.SetActive(false);
            soundViiikl.SetActive(true);
            AudioListener.volume = 0;
            sound = false;
            soundBtn.color = SoundColors[1];
            return;
        }

        if (sound == false)
        {
            soundVKL.SetActive(true);
            soundViiikl.SetActive(false);
            soundBtn.color = SoundColors[0];
            AudioListener.volume = 1;
            sound = true;
            return;
        }
    }


    public void ChangeShip(int num)
    {
        switch (num)
        {
            case 1:
                Selector.transform.position = ships[0].transform.position;
                ships[0].color = ShipColors[0];
                ships[1].color = ShipColors[1];
                ships[2].color = ShipColors[1];
                shipNum = 0;
                PlayButText.text = PlayButtonTexts[0];
                PlayButText.color = playBotColors[0];
                priceInCoins.SetActive(false);
                priceInDollars.SetActive(false);
                Selector.GetComponent<Image>().color = SelectorColors[0];
                break;


            case 2:
                Selector.transform.position = ships[1].transform.position;
                ships[0].color = ShipColors[1];
                ships[1].color = ShipColors[0];
                ships[2].color = ShipColors[1];
                shipNum = 1;

                if (shipUnlock[1] == false)
                {
                    Selector.GetComponent<Image>().color = SelectorColors[1];
                    priceInCoins.SetActive(true);
                    priceInDollars.SetActive(false);
                    PlayButText.text = PlayButtonTexts[1];
                    PlayButText.color = playBotColors[1];
                }
                else
                {
                    Selector.GetComponent<Image>().color = SelectorColors[0];
                    priceInCoins.SetActive(false);
                    priceInDollars.SetActive(false);
                    PlayButText.text = PlayButtonTexts[0];
                    PlayButText.color = playBotColors[0];
                }
                break;


            case 3:
                Selector.transform.position = ships[2].transform.position;
                ships[0].color = ShipColors[1];
                ships[1].color = ShipColors[1];
                ships[2].color = ShipColors[0];
                shipNum = 2;
                if (shipUnlock[2] == false)
                {
                    priceInCoins.SetActive(false);
                    priceInDollars.SetActive(true);
                    PlayButText.text = PlayButtonTexts[1];
                    PlayButText.color = playBotColors[1];
                }
                else
                {
                    priceInCoins.SetActive(false);
                    priceInDollars.SetActive(false);
                    PlayButText.text = PlayButtonTexts[0];
                    PlayButText.color = playBotColors[0];
                }
                break;
        }
    }


    public void PlayBtn()
    {
        if (shipNum == 0)
        {
            Application.LoadLevel("Play");
            
        }
        if(shipNum == 1)
        {
            if (shipUnlock[1] == false)
            {
                if(coins >= 200)
                {
                    coins = coins - 200;
                    shipUnlock[1] = true;
                    PlayerPrefs.SetInt("ship2", 1);
                    ChangeShip(2);
                }
            }
            else
            {
                Application.LoadLevel("Play");
            }
        }
        
        PlayerPrefs.SetInt("ship", shipNum);

        if(shipNum == 2)
        {
            if(shipUnlock[2] == false)
            {
                GetComponent<IapManager>().BuyShip();
            }
            else
            {
                Application.LoadLevel("Play");
            }
        }

        PlayerPrefs.SetInt("ship", shipNum);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
