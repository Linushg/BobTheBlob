using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_StartGame : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip startButtonSound;

    public void StartGame() 
    {
        PlayerPrefs.SetInt("CoinAmount", 0);
        SceneManager.LoadScene(1);
    }   

    public void playSoundEffect()
    {
        audioSource.PlayOneShot(startButtonSound);
    }
  
    
}
