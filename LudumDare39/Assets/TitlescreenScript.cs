using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlescreenScript : MonoBehaviour
{
    [SerializeField]
    Animator titleAnimator;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToCharacterSelection()
    {
        titleAnimator.SetTrigger("Exit");
        titleAnimator.SetTrigger("ToCharacterSelection");
    }

    public void EnableButtons()
    {
        GameObject.Find("Start").SetActive(true);
    }
}
