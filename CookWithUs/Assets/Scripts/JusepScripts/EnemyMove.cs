using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float enemySpeed;
    enum Direction { FORWARD, BACKWARD, LEFT, RIGHT };
    Direction currentDirection = Direction.LEFT;
    bool directionSelected = false;

    void Update()
    {
        if (directionSelected)
        {
            switch (currentDirection)
            {
                case Direction.LEFT:
                    gameObject.transform.position = gameObject.transform.position + Vector3.left * enemySpeed * Time.deltaTime;
                    break;

                case Direction.RIGHT:
                    gameObject.transform.position = gameObject.transform.position + Vector3.right * enemySpeed * Time.deltaTime;
                    break;

                case Direction.FORWARD:
                    gameObject.transform.position = gameObject.transform.position + Vector3.forward * enemySpeed * Time.deltaTime;
                    break;

                case Direction.BACKWARD:
                    gameObject.transform.position = gameObject.transform.position + Vector3.back * enemySpeed * Time.deltaTime;
                    break;
            }
        }
    }

    private List<Direction> availableDirections = new List<Direction>(4);

    private void OnCollisionEnter(Collision collision)
    {
        availableDirections.Clear();
        if (!Physics.Raycast(gameObject.transform.position, Vector3.left, 1f))
            availableDirections.Add(Direction.LEFT);
        if (!Physics.Raycast(gameObject.transform.position, Vector3.right, 1f))
            availableDirections.Add(Direction.RIGHT);
        if (!Physics.Raycast(gameObject.transform.position, Vector3.forward, 1f))
            availableDirections.Add(Direction.FORWARD);
        if (!Physics.Raycast(gameObject.transform.position, Vector3.back, 1f))
            availableDirections.Add(Direction.BACKWARD);

        if (availableDirections.Count > 0)
        {
            currentDirection = availableDirections[Random.Range(0, availableDirections.Count)];
        }
        else
        {
            //Do something else, no direction to move
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        directionSelected = false;
        Debug.DrawLine(transform.position, transform.position + Vector3.left * 5f);
        Debug.DrawLine(transform.position, transform.position + Vector3.right * 5f);
        Debug.DrawLine(transform.position, transform.position + Vector3.forward * 5f);
        Debug.DrawLine(transform.position, transform.position + Vector3.back * 5f);

        while (!directionSelected)
        {
            Random.seed = System.DateTime.Now.Millisecond;
            int checkDirection = Random.Range(0, 4);
            Debug.Log(checkDirection);

            switch (checkDirection)
            {
                case 1:
                    if (!Physics.Raycast(gameObject.transform.position, Vector3.left, 1f))
                    {
                        currentDirection = Direction.LEFT;
                        directionSelected = true;
                    }
                    break;
                case 2:
                    if (!Physics.Raycast(gameObject.transform.position, Vector3.right, 1f))
                    {
                        currentDirection = Direction.RIGHT;
                        directionSelected = true;
                    }
                    break;
                case 3:
                    if (!Physics.Raycast(gameObject.transform.position, Vector3.forward, 1f))
                    {
                        currentDirection = Direction.FORWARD;
                        directionSelected = true;
                    }
                    break;
                case 4:
                    if (!Physics.Raycast(gameObject.transform.position, Vector3.back, 1f))
                    {
                        currentDirection = Direction.BACKWARD;
                        directionSelected = true;
                    }
                    break;
            }
        }
    }*/
}