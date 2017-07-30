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
        stepSize = dustObject.GetComponent<SpriteRenderer>().bounds.size / 2;

        GenerateDust();
    }

    private void GenerateDust()
    {
        Vector2 dustSize = dustObject.GetComponent<SpriteRenderer>().bounds.size / 2;

        float minPos_x = -roomSize.x / 2 + dustSize.x;
        float maxPos_x = roomSize.x / 2 - dustSize.x;
        float minPos_y = -roomSize.y / 2 + dustSize.y;
        float maxPos_y = roomSize.y / 2 - dustSize.y;

        for (float y = minPos_y; y < maxPos_y; y += stepSize.y)
            for (float x = minPos_x; x < maxPos_x; x += stepSize.x)
            {
                SpawnDust(dustObject, new Vector2(x, y));
            }
    }

    private void SpawnDust(GameObject dust, Vector2 position)
    {
        float randomRotation = Random.Range(0, 360);
        Vector2 randomOffset = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        GameObject newDust = Instantiate(dust, position, Quaternion.Euler(0, 0, randomRotation));
        newDust.transform.SetParent(transform);
    }
}
