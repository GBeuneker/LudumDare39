using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaAnimator : MonoBehaviour
{
    public PlayerNumber playerNumber;
    public float animationDelay = 0.5f;

    private SpriteRenderer spriteRenderer;
    private Sprite[] frames;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

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
            frames = Resources.LoadAll<Sprite>("Sprites/" + playerNumber);
            while (GetComponent<RoombaScript>().PlugScript.PluggedIn)
            {
                frames = Resources.LoadAll<Sprite>("Sprites/" + playerNumber);

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
