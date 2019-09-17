using UnityEngine;

public class ElementManager : MonoBehaviour
{
    #region Default
    public static Vector3 pos;
    private float x, y;
    public static int i;
    public static bool check;
    public static bool d;
    public bool game;
    public static SpriteRenderer spr_Element;
    public static Sprite[] spritesElements = new Sprite[4];
    private AudioSource audio_Source;

    void Start()
    {
        i = 0;
        check = false;
        d = false;
        game = true;

        spr_Element = GetComponent<SpriteRenderer>();
        spr_Element.sprite = spritesElements[i];

        audio_Source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (PlayerPrefs.GetInt("AUDIO") == 1)
            {
                audio_Source.PlayOneShot(SettingsManager.auClipSfx[SettingsManager.random_Sfx]);
                audio_Source.volume = PlayerPrefs.GetFloat("VOLUMEAUDIO");
            }

            if (check == false)
            {
                i++;
                if (i > 3)
                {
                    i = 0;
                }
                spr_Element.sprite = spritesElements[i];
            }
        }
        if (game == false)
        {
            game = true;
        }
    }
    #endregion

    #region On Mouse
    void OnMouseDown()
    {
        pos = Camera.main.WorldToScreenPoint(transform.position);
        x = Input.mousePosition.x - pos.x;
        y = Input.mousePosition.y - pos.y;
    }

    void OnMouseDrag()
    {
        if (check == false || game == true)
        {
            Vector2 l = new Vector2(Input.mousePosition.x - x, Input.mousePosition.y - y);
            Vector2 w = Camera.main.ScreenToWorldPoint(l);
            transform.position = w;
        }
        if (check == true)
        {
            pos = new Vector3(Element.pos.x, Element.pos.y, Element.pos.z);
            transform.position = pos;
        }
    }

    void OnMouseExit()
    {
        if (check == false || game == false)
        {
            d = true;
            Destroy(gameObject);
        }
    }

    void OnMouseUp()
    {
        if (check == false || game == false)
        {
            d = true;
            Destroy(gameObject);
        }
    }
    #endregion

    #region Collision
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Element")
        {
            if (spr_Element.sprite.name == Element.spr_Element.sprite.name)
            {
                check = true;
            }
        }
    }
    #endregion

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Game")
        {
            game = false;
        }
    }
}