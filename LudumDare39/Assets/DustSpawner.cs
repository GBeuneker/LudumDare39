using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustSpawner : MonoBehaviour
{
    private GameObject dustObject;
    private Vector2 roomSize;
    private Vector2 stepSize;

    // Use this for initialization
    void Start()
    {
        dustObject = Resources.Load<GameObject>("Prefabs/Dust");
        roomSize = GetComponent<SpriteRenderer>().bounds.size;
        stepSize = dustObject.GetComponent<SpriteRenderer>().bounds.size / 1.5f;

        GenerateDust();
    }

    private void GenerateDust()
    {
        for (float y = 0; y < roomSize.y; y += stepSize.y * Random.Range(0.5f, 2f))
            for (float x = 0; x < roomSize.x; x += stepSize.x * Random.Range(0.5f, 2f))
            {
                float xPos = x - roomSize.x / 2;
                float yPos = y - roomSize.y / 2;
                SpawnDust(dustObject, new Vector2(xPos, yPos));
            }
    }

    private void SpawnDust(GameObject dust, Vector2 position)
    {
        GameObject newDust = Instantiate(dust, position, Quaternion.identity);
        newDust.transform.SetParent(transform);
    }
}
