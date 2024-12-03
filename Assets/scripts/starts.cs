using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class starts : MonoBehaviour
{
    public AudioClip background_music_clip;
    private AudioSource background_music_source;
    private void Start()
    {
        GetComponent<AudioSource>().Play();
        DontDestroyOnLoad(this.gameObject);
    }
    public void button_see()
    {
        SceneManager.LoadScene(2); 
    }
    
    public void button_space()
    {
        SceneManager.LoadScene(1); 
    }

    public void button_forest()
    {
        SceneManager.LoadScene(4);
    }

    public void button_city()
    {
        SceneManager.LoadScene(3);
    }

    // audacityteam;
}
