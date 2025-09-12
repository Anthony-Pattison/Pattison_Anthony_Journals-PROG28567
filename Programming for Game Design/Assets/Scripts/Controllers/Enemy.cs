using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    
    private void Update()
    {
       
    }
    public void Start()
    {
        
    }
    public static Vector2 normalize(Vector2 input)
    {
        float mag = input.magnitude;
        input = new Vector2(input.x / mag, input.y / mag);
        return input;
    }
}
