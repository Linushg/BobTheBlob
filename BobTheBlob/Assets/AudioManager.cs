using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake() {
        foreach (Sound s in sounds)
        {
            gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
