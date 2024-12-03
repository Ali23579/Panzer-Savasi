using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public AudioClip background_music_clip;
    private AudioSource background_music_source;

    public GameObject fast, slow, rocket, roket, stop, player_red, player_blue, game_ower_panel, a, b, c, d, e, f;
    public List<GameObject> list = new List<GameObject>();
    public List<Vector2> vectorlist = new List<Vector2>();
    public Text time_text, panel_who_won;
    private float time = 60, red_number = 0, blue_number = 0;
    private bool isplaying;


    void Start()
    {
        Time.timeScale = 1;

        list.Add(slow);
        list.Add(fast);
        list.Add(rocket);
        list.Add(stop);

        vectorlist.Add(new Vector2(-1f, -1.68f));
        vectorlist.Add(new Vector2(2.5f, -1.7f));
        vectorlist.Add(new Vector2(4f, 1.2f));
        vectorlist.Add(new Vector2(-2.3f, -0.25f));
        vectorlist.Add(new Vector2(2.25f, -3.20f));
        vectorlist.Add(new Vector2(2.25f, 2.8f));
        vectorlist.Add(new Vector2(7.4f, -3.2f));
        vectorlist.Add(new Vector2(-6.5f, -3.2f));
        vectorlist.Add(new Vector2(5.6f, 0f));
        vectorlist.Add(new Vector2(-2.4f, 2f));
        vectorlist.Add(new Vector2(-5.7f, -2.8f));
        vectorlist.Add(new Vector2(-5.5f, 0f));

        InvokeRepeating("CreateGameObjects", 0f, 10f);
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            Time.timeScale = 0;
            time = 60;
        }

        time_text.text = Mathf.Ceil(time).ToString();

        if(Input.GetKeyDown(KeyCode.Escape) && isplaying == true)
        {
            GetComponent<AudioSource>().Pause();
            isplaying = false;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isplaying == false)
        {
            GetComponent<AudioSource>().Play();
            isplaying = true;
        }

        if (mermi.x.blue_heart_descared == true)
        {
            blue_number += 1;
            mermi.x.blue_heart_descared = false;
        }

        if (mermi.x.red_heart_descared == true)
        {
            red_number += 1;
            mermi.x.red_heart_descared = false;
        }
        

        if(blue_number == 1)
        {
            Destroy(a);
            Time.timeScale = 1;
        }
        else if(blue_number == 2)
        {
            Destroy(b);
            Time.timeScale = 1;
        }
        else if(blue_number == 3)
        {
            Destroy(c);
            game_ower_panel.SetActive(true);
            Time.timeScale = 0;
            panel_who_won.text = "Red Player Won";
            panel_who_won.color = Color.red;
        }


        if (red_number == 1)
        {
            Destroy(d);
            Time.timeScale = 1;
        }
        else if (red_number == 2)
        {
            Destroy(e);
            Time.timeScale = 1;
        }
        else if (red_number == 3)
        {
            Destroy(f);
            game_ower_panel.SetActive(true);
            Time.timeScale = 0;
            panel_who_won.text = "Blue Player Won";
            panel_who_won.color = Color.blue;
        }

        if(Time.timeScale == 1)
        {
            game_ower_panel.SetActive(false);
        }
    }

    void CreateGameObjects()
    {
        GameObject randomobject = GetRandomObject();
        Vector2 vector = GetRandomVector();

        Instantiate(randomobject, vector, Quaternion.identity);
    }

    GameObject GetRandomObject()
    {
        int randomindex = Random.Range(0, list.Count);
        return list[randomindex];
    }

    Vector2 GetRandomVector()
    {
        int randomindex = Random.Range(0, vectorlist.Count);
        return vectorlist[randomindex];
    }

    public void home()
    {
        SceneManager.LoadScene(0);
    }

    public void restart_see()
    {
        SceneManager.LoadScene(2);
    }

    public void restart_space()
    {
        SceneManager.LoadScene(1);
    }

    public void restart_forest()
    {
        SceneManager.LoadScene(4);
    }

    public void restart_city()
    {
        SceneManager.LoadScene(3);
    }
}
