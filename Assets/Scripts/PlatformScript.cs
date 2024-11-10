using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField] float positionX;
    [SerializeField] float speed; // Speed should be float for more precision
    [SerializeField] float boundaryLeft = -12.69f; // Left boundary for respawn
    [SerializeField] float boundaryRight = 12.69f; // Right boundary for respawn

    [SerializeField] public bool isGameOver = false;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (!isGameOver)
        {

            PlatformMove();
            BoundaryCheck();
        }       
    }

    void PlatformMove()
    {
        transform.Translate(new Vector3(positionX * speed * Time.deltaTime, 0, 0)); ;
    }

    void BoundaryCheck()
    {
        // Check if the car has passed the right boundary and reset to the left
        if (transform.position.x > boundaryRight)
        {
            ResetPosition(boundaryLeft);
        }
        // Check if the car has passed the left boundary and reset to the right
        else if (transform.position.x < boundaryLeft)
        {
            ResetPosition(boundaryRight);
        }
    }

    void ResetPosition(float newX)
    {
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // Add logic here if you want to randomize the Y position or offset X to avoid overlap
        // For example:
        // transform.position += new Vector3(Random.Range(0.5f, 1.5f), 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            isGameOver = true;
        }
    }
}
