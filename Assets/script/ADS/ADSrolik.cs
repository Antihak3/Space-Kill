using UnityEngine;
using UnityEngine.Advertisements;

public class ADSrolik : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            PlayerPrefs.SetInt("DC", 0);
        }
    }
}
