using UnityEngine;

public class Element : MonoBehaviour
{
    #region Default
    public static Vector3 pos;
    public static SpriteRenderer spr_Element;

    void Start()
    {
        pos = transform.position;
        spr_Element = GetComponent<SpriteRenderer>();
    } 
    #endregion
}