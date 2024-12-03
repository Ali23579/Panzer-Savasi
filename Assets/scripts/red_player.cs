using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class red_player : MonoBehaviour
{
    public bool isslow = false;
    public float time = 10, number_roket_red = 0;
    public static red_player rp { get; private set; }
    public Text who_won;
    public GameObject game_ower_panel, d, e, f;

    public bool Red_is_notcollision;

    private void Awake()
    {
        if (rp != null && rp != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            rp = this;
        }
    }

    private void Start()
    {
        float redspeed = Movement.Instance.red;
        float bluespeed = Movement.Instance.blue;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("roket"))
        {
            Red_is_notcollision = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("roket") && blue_player.bp.Blue_is_notcollision)
        {
            Time.timeScale = 0;
            game_ower_panel.SetActive(true);
            Destroy(d);
            Destroy(e);
            Destroy(f);
            who_won.text = "Blue Player Won";
            who_won.color = Color.blue;
        }

        if (other.gameObject.name == "rocket_cricle(Clone)")
        {
            Destroy(other.gameObject);
            number_roket_red += 1;
        }
        else if (other.gameObject.name == "slow_cricle(Clone)")
        {
            Destroy(other.gameObject);
            Movement.Instance.blue = 1;
            StartCoroutine(timmerSLOW());
        }
        else if (other.gameObject.name == "fast_cricle(Clone)")
        {
            Destroy(other.gameObject);
            Movement.Instance.red = 5;
            StartCoroutine(timmerFAST());
        }
        else if (other.gameObject.name == "stop_cricle(Clone)")
        {
            Destroy(other.gameObject);
            Debug.Log("red player :" + other.gameObject.name + "");
            Movement.Instance.blue = 0;
            StartCoroutine(timmerSTOP());
        }
    }

    private IEnumerator timmerSTOP()
    {
        yield return new WaitForSeconds(time);
        Movement.Instance.blue = 3;
    }

    private IEnumerator timmerFAST()
    {
        yield return new WaitForSeconds(time);
        Movement.Instance.red = 3;
    }

    private IEnumerator timmerSLOW()
    {
        yield return new WaitForSeconds(time);
        Movement.Instance.blue = 3;
    }
}
