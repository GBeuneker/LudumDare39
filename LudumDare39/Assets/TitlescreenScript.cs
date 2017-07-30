using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlescreenScript : MonoBehaviour
{
    [SerializeField]
    Animator titleAnimator, startAnimator, menuAnimator, characterSelectAnimator;

    private bool startedMenu = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !startedMenu)
            PressStart();

        if (Input.GetButtonDown("Cancel_1"))
        {
            characterSelectAnimator.SetTrigger("Disappear");
            menuAnimator.SetTrigger("Appear");
        }
    }

    public void ToCharacterSelection()
    {
        menuAnimator.SetTrigger("Disappear");
        characterSelectAnimator.SetTrigger("Appear");
    }

    public void PressStart()
    {
        startedMenu = true;

        startAnimator.SetTrigger("Disappear");
        menuAnimator.SetTrigger("Appear");
    }
}
