using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaController : MonoBehaviour
{
    [SerializeField]
    private float movingSpeed = 5;

    private float maxDistance;
    private Rigidbody2D body;
    private new Collider2D collider;
    private PlugScript plugScript;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        plugScript = GetComponent<RoombaScript>().PlugScript;

        maxDistance = Vector2.Distance(transform.position, plugScript.transform.position);
        StartCoroutine(RumbaWalk());
    }

    private bool IsMovementBlocked()
    {
        // Check if we hit a wall
        Vector2 checkPosition = transform.position + transform.right * (collider.bounds.extents.x + 0.1f);
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, transform.right, 0.1f);
        if (hit.collider != null)
            return true;

        // Determine if the cord is stopping us
        Vector2 cordDirection = plugScript.transform.position - transform.position;
        Vector2 driveDirection = transform.right;
        if (Vector2.Distance(transform.position, plugScript.transform.position) >= maxDistance - 1 && Vector2.Angle(driveDirection, cordDirection) >= 150)
            return true;

        return false;
    }

    private void Update()
    {
        body.angularVelocity = 0;
    }

    IEnumerator RumbaWalk()
    {
        while (true)
        {
            while (plugScript.PluggedIn)
            {
                // Pick a random angle
                float targetAngle = Random.Range(-180, 180);
                Quaternion targetQuaternion = Quaternion.Euler(0, 0, targetAngle);

                while (Quaternion.Angle(transform.rotation, targetQuaternion) > 1)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, Time.deltaTime * 100);
                    yield return null;
                }

                float driveTime = 1.0f;
                float timeDriven = 0;

                while (timeDriven < driveTime && !IsMovementBlocked() && plugScript.PluggedIn)
                {
                    timeDriven += Time.deltaTime;
                    body.AddForce(transform.right * movingSpeed * body.mass, ForceMode2D.Force);
                    body.velocity = Vector2.ClampMagnitude(body.velocity, movingSpeed);

                    yield return null;
                }

                body.velocity = Vector2.zero;
                yield return new WaitForSeconds(0.2f);
            }
            yield return null;
        }
    }
}
