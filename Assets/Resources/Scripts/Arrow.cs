using UnityEngine;

public class Arrow : MonoBehaviour
{
    #region Collision
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flag")
        {
            gameObject.SetActive(false);
        }
    } 
    #endregion
}
