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
        if(ScoreManager.instance.score > 5)
        {
            NGHelper.instance.unlockMedal(84544);
        }
        if (ScoreManager.instance.score > 10)
        {
            NGHelper.instance.unlockMedal(84545);
        }
        if (ScoreManager.instance.score > 15)
        {
            NGHelper.instance.unlockMedal(84546);
        }
        if (ScoreManager.instance.score > 20)
        {
            NGHelper.instance.unlockMedal(84547);
        }
        if (ScoreManager.instance.score > 25)
        {
            NGHelper.instance.unlockMedal(84548);
        }
    }
}
