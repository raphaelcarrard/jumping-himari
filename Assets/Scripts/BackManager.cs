using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackManager : MonoBehaviour
{

    public AudioSource menuSound;

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        menuSound.Play();
    }
}
