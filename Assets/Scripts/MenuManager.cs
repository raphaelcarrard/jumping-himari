using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{

    public AudioSource menuSound;
    public Sprite soundOff;
    public Sprite soundOn;
    public Image thisImage;

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void Start()
    {
        menuSound.Play();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #elif UNITY_WEBGL
            Debug.Log("this game not exits in Web");
            #else
            Application.Quit();
            #endif
        }
    }

    public void Help()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void ChangeSound()
    {
        if (menuSound.isPlaying)
        {
            thisImage.sprite = soundOff;
            menuSound.Stop();
        }
        else if(!menuSound.isPlaying)
        {
            thisImage.sprite = soundOn;
            menuSound.Play();
        }
    }
}
