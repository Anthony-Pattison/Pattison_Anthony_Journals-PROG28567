using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleporting : MonoBehaviour
{
    public int AmountOfPoints;
    public Transform PlayerTransform;
    public float LaserSize;
    public bool PlayerisNear;
   
    void Update()
    {
        DrawDetectionCircle(AmountOfPoints, PlayerTransform.position, LaserSize);
    }

    void DrawDetectionCircle(int AmountOfPoints, Vector3 PlayerPos, float LiserSize)
    {
        float distance = Vector2.Distance(transform.position, PlayerPos);

        float AngleStep = 360f / AmountOfPoints;
        float radius = AngleStep * Mathf.Deg2Rad;
        List<Vector3> Points = new List<Vector3>();

        for (int i = 0; i<AmountOfPoints; i++)
        {
            float adjustment = radius * i;
            Points.Add(new Vector3(Mathf.Cos(radius + adjustment) * LiserSize, Mathf.Sin(radius + adjustment) * LiserSize));
        }

        for (int i = 0; i < Points.Count-1; i++)
        {
            Debug.DrawLine(transform.position + Points[Points.Count - 1], transform.position + Points[0]);

            Debug.DrawLine(transform.position + Points[i] , transform.position + Points[i+1] );
        }

        if (distance<radius)
        {
            PlayerisNear = true;
        }
        else
        {
            PlayerisNear = false;
        }

    }
}
