using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip startButtonSound;

    public void MainMenu() 
    {
        SceneManager.LoadScene(0);
    }   

    public void playSoundEffect()
    {
        audioSource.PlayOneShot(startButtonSound);
    }
  
    
}
