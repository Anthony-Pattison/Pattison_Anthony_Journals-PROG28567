using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    
    private void Update()
    {
       
    }
    public void Start()
    {
        Debug.Log(normalize(new Vector2(3, 4)));
        Debug.Log(normalize(new Vector2(-3, 2)));
        Debug.Log(normalize(new Vector2(1.5f, -3.5f)));
    }
    public static Vector2 normalize(Vector2 input)
    {
        float mag = input.magnitude;
        input = new Vector2(input.x/mag, input.y/mag);
        return input;
    }
}
