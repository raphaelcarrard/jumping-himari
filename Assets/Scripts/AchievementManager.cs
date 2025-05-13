using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    
    public static AchievementManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CheckAchievements()
    {
        if(ScoreManager.instance.score > 100)
        {
            NGHelper.instance.unlockMedal(84544);
        }
        if (ScoreManager.instance.score > 200)
        {
            NGHelper.instance.unlockMedal(84545);
        }
        if (ScoreManager.instance.score > 300)
        {
            NGHelper.instance.unlockMedal(84546);
        }
        if (ScoreManager.instance.score > 400)
        {
            NGHelper.instance.unlockMedal(84547);
        }
        if (ScoreManager.instance.score > 500)
        {
            NGHelper.instance.unlockMedal(84548);
        }
    }
}
