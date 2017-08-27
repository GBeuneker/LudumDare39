using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaAnimator : MonoBehaviour
{
    private static GameObject instance;

    public float animationDelay = 0.5f;

    private PlayerNumber playerNumber;
    private SpriteRenderer spriteRenderer;
    private Sprite[] frames;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerNumber = GetComponent<RoombaScript>().PlayerNumber;

        LoadSpriteFrames();
        StartCoroutine(AnimateRoomba());
    }

    private void LoadSpriteFrames()
    {
        frames = Resources.LoadAll<Sprite>("Sprites/" + playerNumber);
    }

    IEnumerator AnimateRoomba()
    {
        while (true)
        {
            while (GetComponent<RoombaScript>().PlugScript.PluggedIn)
            {
                spriteRenderer.sprite = frames[0];
                yield return new WaitForSeconds(animationDelay);
                spriteRenderer.sprite = frames[1];
                yield return new WaitForSeconds(animationDelay);
            }

            spriteRenderer.sprite = frames[0];
            yield return null;
        }
    }
}
