using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuPause : MonoBehaviour
{
   public bool Pause = false;
   public bool sound = false;
    public GameObject PausePanel;
    public Color[] colors;
    public Text soundBtn;



    private void Start()
    {
        if(AudioListener.volume == 0)
        {
            sound = false;
            soundBtn.color = colors[1];
        }
        else
        {
            sound = true;
            soundBtn.color = colors[0];
        }
      

    }

    public void pauseMen()
    {
        
        if (Pause == false)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0.00001f;
            Pause = true;
            return;
        }
        if(Pause == true)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1f;
            Pause = false;
            return;
        }

        


        
    }

  
    public void mainMenuBtn()
    {
        Application.LoadLevel("menu");
        

    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


    public void Sound()
    {
        if(sound == true)
        {
            AudioListener.volume = 0;
            sound = false;
            soundBtn.color = colors[1];
            return;
        }

        if (sound == false)
        {
            soundBtn.color = colors[0];
            AudioListener.volume = 1;
            sound = true;
            return;
        }
    }
}
