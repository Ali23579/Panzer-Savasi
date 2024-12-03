using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blue_player : MonoBehaviour
{
    private bool isslow = false;
    public float time = 10, number_roket_blue = 0;
    public static blue_player bp { get; private set; }
    public GameObject game_ower_panel, a, b, c;
    public Text who_won;
    public bool Blue_is_notcollision;

    private void Awake()
    {
        if (bp != null && bp != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            bp = this;
        }
    }

    private void Start()
    {
        float redSpeed = Movement.Instance.red;
        float blueSpeed = Movement.Instance.blue;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("roket"))
        {
            Blue_is_notcollision = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("roket") && red_player.rp.Red_is_notcollision)
        {
            Time.timeScale = 0;
            game_ower_panel.SetActive(true);
            Destroy(a);
            Destroy(b);
            Destroy(c);
            who_won.text = "Red Player Won";
            who_won.color = Color.red;
        }

        if (other.gameObject.name == "rocket_cricle(Clone)")
        {
            Destroy(other.gameObject);
            number_roket_blue += 1;
        }
        else if (other.gameObject.name == "slow_cricle(Clone)")
        {
            Destroy(other.gameObject);
            Movement.Instance.red = 1;
            StartCoroutine(TimerSLOW());
        }
        else if (other.gameObject.name == "fast_cricle(Clone)")
        {
            Destroy(other.gameObject);
            Movement.Instance.blue = 5;
            StartCoroutine(TimerFAST());
        }
        else if (other.gameObject.name == "stop_cricle(Clone)")
        {
            Destroy(other.gameObject);
            Movement.Instance.red = 0;
            StartCoroutine(TimerSTOP());
        }
    }

    private IEnumerator TimerSLOW()
    {
        yield return new WaitForSeconds(time);
        Movement.Instance.red = 3;
    }

    private IEnumerator TimerFAST()
    {
        yield return new WaitForSeconds(time);
        Movement.Instance.blue = 3;
    }

    private IEnumerator TimerSTOP()
    {
        yield return new WaitForSeconds(time);
        Movement.Instance.red = 3;
    }
}
