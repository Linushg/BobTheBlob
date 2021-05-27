using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_QuitGame : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip startButtonSound;

    public void QuitGame() {
        Application.Quit();

    }

    public void playSoundEffect()
    {
        audioSource.PlayOneShot(startButtonSound);
    }
}
