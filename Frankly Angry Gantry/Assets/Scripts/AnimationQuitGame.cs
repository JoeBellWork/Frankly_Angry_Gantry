using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationQuitGame : MonoBehaviour
{
    public Animator anim;

    public void FadeOut()
    {
        anim.SetTrigger("MoveToFadeOut");
    }

    public void Quit()
    {
        print("Quit");
        Application.Quit();
    }
}
