using System.Collections.Generic;
using UnityEngine;

public class ChangingAngles : MonoBehaviour
{
    [SerializeField] List<float> listofanlges;
    float time;
    int i = 0;
    public Vector3 one;
    public Vector3 place = Vector3.zero;
    public float radius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time +=  Time.deltaTime;
        if (Input.GetKeyDown("space") || time > 1)
        {
            one = drawInaCircle(listofanlges[i], radius);
            i = (i + 1) % listofanlges.Count;
            time = 0;
        }
        Debug.DrawLine(place, place + one, Color.magenta);
    }

     public static Vector3 drawInaCircle(float angle, float radius)
    {
        float radiance = angle * Mathf.Rad2Deg;
        return new Vector3(Mathf.Cos(radiance), Mathf.Sin(radiance) * radius);
    }
}
