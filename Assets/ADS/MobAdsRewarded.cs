﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GoogleMobileAds.Api;

public class MobAdsRewarded : MonoBehaviour
{
    private RewardedAd rewardedAd;
   [SerializeField] private Text cointsText;
    public GameObject Ship;
    private int coints = 0;

    void Start()
    {

        Ship = GameObject.Find("PLayerShip");

      
    }


#if UNITY_ANDROID
    private const string rewardedUnitId = "ca-app-pub-3940256099942544/5224354917"; //тестовый айди
#elif UNITY_IPHONE
    private const string rewardedUnitId = "";
#else
    private const string rewardedUnitId = "unexpected_platform";
#endif
    void OnEnable()
    {
        rewardedAd = new RewardedAd(rewardedUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adRequest);

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }

    void OnDisable()
    {
        rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
    }

    public void ShowRewardedAd()
    {
        if (PlayerPrefs.GetInt("noads") != 1)
        {
            if (rewardedAd.IsLoaded())
            {
                rewardedAd.Show();
            }
        }
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
      
        coints = coints + 10;
        cointsText.text = "Coints: " + coints;
        Ship.GetComponent<shipcontrol>().coins = Ship.GetComponent<shipcontrol>().coins + coints;
    }
}
