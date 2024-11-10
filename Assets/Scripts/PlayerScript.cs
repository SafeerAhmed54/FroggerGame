using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int positionX;
    [SerializeField] int positionY = -5;
    [SerializeField] float boundaryX;
    [SerializeField] float boundaryY;
    [SerializeField] PlatformScript platform;
    [SerializeField] Vector3 startPos;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        boundaryX = 12;
        boundaryY = positionY;
        platform = FindAnyObjectByType<PlatformScript>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        BoundaryCheck();
    }

    void MovePlayer()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && positionX < -boundaryX)
        {
            if(positionX > -boundaryX)
            {
                positionX--;
            }
            
            transform.position = new Vector3(positionX, transform.position.y, transform.position.z );
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && positionX > boundaryX)
        {
            if (positionX < boundaryX)
            {
                positionX++;
            }

            transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && positionY < -boundaryY)
        {
            if (positionY < -boundaryY)
            {
                positionY++;
            }

            transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && positionY > boundaryY)
        {
            if (positionY > boundaryY)
            {
                positionY--;
            }

            transform.position = new Vector3(transform.position.x, positionY , transform.position.z);
        }

    }

    void BoundaryCheck()
    {
        if(transform.position.y <= boundaryY)
        {
            transform.position = new Vector3(transform.position.x, boundaryY, transform.position.z);
        }
        else if(transform.position.y >= -boundaryY)
        {
            transform.position = new Vector3(transform.position.x, -boundaryY, transform.position.z);
        }
        if (transform.position.x >= boundaryX)
        {
            transform.position = new Vector3(boundaryX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -boundaryX)
        {
            transform.position = new Vector3(-boundaryX, transform.position.y, transform.position.z);
        }
    }

    void PositionReset()
    {
        transform.position = startPos;
        positionX = (int)startPos.x;
        positionY = (int)startPos.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            Debug.Log("Player attached to log");
            transform.SetParent(other.transform);

            // Round the x position to avoid float precision issues
            Vector3 roundedPosition = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
            transform.position = roundedPosition;
        }
        else if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log("Player detached from log");
            PositionReset();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            Debug.Log("Player detached from log");
            transform.SetParent(null);
        }
    }


}
