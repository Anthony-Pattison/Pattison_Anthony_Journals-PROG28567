using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public List<Vector3> points = new List<Vector3>();
    public AnimationCurve curve;
    public bool RunningCorutine = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OrbitThePlanet(planetTransform.position, 8));
    }

    // Update is called once per frame
    void Update()
    {
        if (!RunningCorutine)
        {
            StartCoroutine(OrbitThePlanet(planetTransform.position, 8));
        }
    }

    IEnumerator OrbitThePlanet(Vector3 orbitPoint, int AmountOfDestinations)
    {
        RunningCorutine = true;

        float AngleStep = 360f / AmountOfDestinations;
        float radius = AngleStep * Mathf.Deg2Rad;
        for (int i = 0; i < AmountOfDestinations; i++)
        {

            float adjustment = radius * i;
            points.Add(new Vector3(Mathf.Cos(radius + adjustment), Mathf.Sin(radius + adjustment)));
        }
        transform.position = orbitPoint + points[0];
        points.Add(points[0]);
        float t = 0;
        for (int i= 0; i < points.Count; i++)
        {
            bool run = true;
            while (run)
            {
                float normalizedTime = Mathf.Clamp01(t / 1);

                t += 0.005f * Time.deltaTime;
                print(t);
                transform.position = Vector3.Lerp(transform.position , orbitPoint + points[i], curve.Evaluate(normalizedTime));
                Debug.DrawLine(transform.position, orbitPoint + points[i]); 
                if (Asteroid.round(transform.position) == Asteroid.round(orbitPoint + points[i]))
                {
                    t = 0;
                    run = false;
                }
                yield return null;
            }
        }
         points.Clear();
         RunningCorutine = false;
         yield return null;
    }
}
