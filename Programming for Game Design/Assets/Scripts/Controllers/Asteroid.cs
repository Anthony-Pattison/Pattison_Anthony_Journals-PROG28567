using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    bool running = false;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Movementspeed(moveSpeed));
    }
    
    IEnumerator Movementspeed(float speed)
    {
        bool runningCorutine = true;
        Vector3 obtainedpos = AsteroidMovement();
        Vector3 endpos = transform.position + obtainedpos;
        if (!running)
        {
            while (runningCorutine)
            {
                running = true;
                transform.position += new Vector3(speed * 10 * obtainedpos.x, speed *10 * obtainedpos.y) * Time.deltaTime; 
                if (round(transform.position) == round(endpos))
                {
                    runningCorutine=false;
                    running = false;
                }
                yield return null;
            }
        }
    }
    public static Vector3 round(Vector3 pos)
    {
        pos.x = Mathf.Round(pos.x *10);
         pos.y = Mathf.Round(pos.y * 10);
         return pos = new Vector3(pos.x*0.1f, pos.y*0.1f);
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
