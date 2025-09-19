using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    bool running;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + AsteroidMovement(), moveSpeed);

    }

    Vector3 AsteroidMovement()
    {
        int randomNum = Random.Range(1, 5);
        switch (randomNum)
        {
            case 1:
                return new Vector3(1, 1, 0);
            case 2:
                return new Vector3(-1, 1, 0);
            case 3:
                return new Vector3(1, -1, 0);
            case 4:
                return new Vector3(-1, -1, 0);
            default:
                break;
        }
        return new Vector3(0, 0, 0);

    }
}
