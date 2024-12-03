using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi : MonoBehaviour
{
    public AudioClip bang_clip;
    private AudioSource bang_source;
    public bool red_is_notcollision, blue_is_notcollision, blue_heart_descared, red_heart_descared;
    public static mermi x;

    private void Awake()
    {
        if (x == null)
        {
            x = this;
        }
        else if (x != this)
        {
            Destroy(gameObject);
        }

        bang_source = GetComponent<AudioSource>();
        if (bang_source == null)
        {
            bang_source = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player_red"))
        {
            red_is_notcollision = true;
        }

        if (other.CompareTag("player_blue"))
        {
            blue_is_notcollision = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall"))
        {
            PlaySound();
            Destroy(gameObject);
        }

        if (other.CompareTag("player_blue") && red_is_notcollision == true)
        {
            PlaySound();
            Destroy(gameObject);
            blue_heart_descared = true;
        }
        else
        {
            blue_heart_descared = false;
        }

        if (other.CompareTag("player_red") && blue_is_notcollision == true)
        {
            PlaySound();
            Destroy(gameObject);
            red_heart_descared = true;
        }
        else
        {
            red_heart_descared = false;
        }
    }

    private void PlaySound()
    {
        if (bang_source != null && bang_clip != null)
        {
            bang_source.PlayOneShot(bang_clip, 1f);
        }
    }
}
