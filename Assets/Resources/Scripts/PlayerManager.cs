using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Default
    private Rigidbody2D rb2d;
    public static bool r;
    public bool point0, point1, point2, point3;
    public float s;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        r = false;
        point0 = false;
        point1 = false;
        point2 = false;
        point3 = false;
        s = 1f;
    }

    void Update()
    {
        if (ElementManager.check == false)
        {
            if (point0 == true)
            {
                transform.eulerAngles = Vector3.forward * 0;
            }
            if (point1 == true)
            {
                transform.eulerAngles = Vector3.forward * -90;
            }
            if (point2 == true)
            {
                transform.eulerAngles = Vector3.forward * 180;
            }
            if (point3 == true)
            {
                transform.eulerAngles = Vector3.forward * 90;
            }
        }
    }

    void FixedUpdate()
    {
        if (ElementManager.check == true)
        {
            if (point0 == true)
            {
                rb2d.velocity = Vector2.up * s; // cima 
                transform.eulerAngles = Vector3.forward * 0;
            }
            if (point1 == true)
            {
                rb2d.velocity = Vector2.right * s; // direita
                transform.eulerAngles = Vector3.forward * -90;
            }
            if (point2 == true)
            {
                rb2d.velocity = Vector2.down * s; // baixo
                transform.eulerAngles = Vector3.forward * 180;
            }
            if (point3 == true)
            {
                rb2d.velocity = Vector2.left * s; // esquerda
                transform.eulerAngles = Vector3.forward * 90;
            }
        }
        if (r == true)
        {
            rb2d.velocity = Vector2.zero * 0; // stop
        }
    }
    #endregion

    #region Collisions
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Arrow0") // cima
        {
            point0 = true;
            point1 = false;
            point2 = false;
            point3 = false;
        }
        if (collision.collider.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Arrow1") // direita
        {
            point1 = true;
            point0 = false;
            point2 = false;
            point3 = false;
        }
        if (collision.collider.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Arrow2") // baixo
        {
            point2 = true;
            point0 = false;
            point1 = false;
            point3 = false;
        }
        if (collision.collider.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Arrow3") // esquerda
        {
            point3 = true;
            point0 = false;
            point1 = false;
            point2 = false;
        }
        if (collision.gameObject.tag == "Flag")
        {
            r = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Arrow0") // cima
        {
            point0 = false;
        }
        if (collision.collider.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Arrow1") // direita
        {
            point1 = false;
        }
        if (collision.collider.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Arrow2") // baixo
        {
            point2 = false;
        }
        if (collision.collider.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Arrow3") // esquerda
        {
            point3 = false;
        }
    }
    #endregion
}