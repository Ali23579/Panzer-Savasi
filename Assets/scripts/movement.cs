using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance { get; private set; }
    public AudioClip gun;
    private AudioSource gun_sound;

    public GameObject player_blue, player_red, mermi, roket;
    private Rigidbody2D rb_blue, rb_red;
    public float blue = 3, red = 3, turn1 = -2, turn2 = 2, life_red = 3, life_blue = 3;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        rb_blue = player_blue.GetComponent<Rigidbody2D>();
        rb_red = player_red.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 blue_player_location = rb_blue.transform.position;
        Vector3 red_player_location = rb_red.transform.position;

        Vector3 mermi_location_blue = new Vector2(blue_player_location.x, blue_player_location.y);
        Vector3 mermi_location_red = new Vector2(red_player_location.x, red_player_location.y);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject yeniMermi = Instantiate(mermi, mermi_location_blue, rb_blue.transform.rotation);
            Rigidbody2D rb_yeniMermi = yeniMermi.GetComponent<Rigidbody2D>();
            rb_yeniMermi.velocity = rb_blue.transform.right * 7;
            GetComponent<AudioSource>().PlayOneShot(gun,1);
            StartCoroutine(DestroyMermi(yeniMermi));
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter) && blue_player.bp.number_roket_blue > 0)
        {
            GameObject new_roket = Instantiate(roket, mermi_location_blue,rb_blue.transform.rotation);
            Rigidbody2D rb_new_roket = new_roket.GetComponent<Rigidbody2D>();
            rb_new_roket.velocity = rb_blue.transform.right * 10;
            StartCoroutine(Destroyroket(new_roket));
            blue_player.bp.number_roket_blue -= 1;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject yeniMermix = Instantiate(mermi, mermi_location_red, rb_red.transform.rotation);
            Rigidbody2D rb_yeniMermix = yeniMermix.GetComponent<Rigidbody2D>();
            rb_yeniMermix.velocity = rb_red.transform.right * -7;
            GetComponent<AudioSource>().PlayOneShot(gun,1);
            StartCoroutine(DestroyMermi(yeniMermix));
        }
        if(Input.GetButtonDown("Fire2") && red_player.rp.number_roket_red > 0)
        {
            GameObject new_roket = Instantiate(roket, mermi_location_red, rb_red.transform.rotation);
            Rigidbody2D rb_new_roket = new_roket.GetComponent<Rigidbody2D>();
            rb_new_roket.velocity = rb_red.transform.right * -10;
            StartCoroutine(Destroyroket(new_roket));
            red_player.rp.number_roket_red -= 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            float angle_up = rb_blue.transform.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angle_up), Mathf.Sin(angle_up));
            rb_blue.velocity = direction * blue;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            float angle_down = rb_blue.transform.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 direction_down = new Vector2(Mathf.Cos(angle_down), Mathf.Sin(angle_down));
            rb_blue.velocity = -direction_down * blue;
        }
        else
        {
            rb_blue.velocity = new Vector2(0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb_blue.transform.Rotate(new Vector3(0, 0, turn1));
        }
        else
        {
            rb_blue.transform.Rotate(new Vector3(0, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb_blue.transform.Rotate(new Vector3(0, 0, turn2));
        }
        else
        {
            rb_blue.transform.Rotate(new Vector3(0, 0, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            float angle_up_red = rb_red.transform.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 directionx = new Vector2(Mathf.Cos(angle_up_red), Mathf.Sin(angle_up_red));
            rb_red.velocity = directionx * red;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            float angle_down_red = rb_red.transform.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 direction_down_red = new Vector2(Mathf.Cos(angle_down_red), Mathf.Sin(angle_down_red));
            rb_red.velocity = -direction_down_red * red;
        }
        else
        {
            rb_red.velocity = new Vector2(0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb_red.transform.Rotate(new Vector3(0, 0, turn1));
        }
        else
        {
            rb_red.transform.Rotate(new Vector3(0, 0, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb_red.transform.Rotate(new Vector3(0, 0, turn2));
        }
        else
        {
            rb_red.transform.Rotate(new Vector3(0, 0, 0));
        }
    }

    private IEnumerator DestroyMermi(GameObject mermi)
    {
        yield return new WaitForSeconds(3);
        Destroy(mermi);
    }
    private IEnumerator Destroyroket(GameObject roket)
    {
        yield return new WaitForSeconds(5);
        Destroy(roket);
    }
}
