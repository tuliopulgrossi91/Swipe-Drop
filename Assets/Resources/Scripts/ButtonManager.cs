using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private Animator anim_Button;

    void Start()
    {
        #region ANIMATOR COMPONENT
        // get animator component of button
        anim_Button = GetComponent<Animator>();
        #endregion
    }

    public void AnimatorButton(bool check)
    {
        // check = false
        if (check)
        {
            // set animator by buttonCheck true
            anim_Button.SetBool("buttonCheck", true);
        }
        // check = true
        else
        {
            // set animator by buttonCheck false
            anim_Button.SetBool("buttonCheck", false);
        }
    }
}