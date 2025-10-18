using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float angleSpeed = 60f;
    [SerializeField] Transform EnemyTransform;
    [SerializeField] Transform Playerposition;
    void Update()
    {
        DrawacircleAroundturret(8,3,Playerposition.position);
        Vector2 direction = (EnemyTransform.position - transform.position).normalized;

        float upangle = CalculateDegAngleFromVector(transform.up);
        float directionAngle = CalculateDegAngleFromVector(direction);

        float deltaAngle = Mathf.DeltaAngle(upangle, directionAngle);
        float sign = Mathf.Sign(deltaAngle);

        float angleStep = angleSpeed * Time.deltaTime * sign;
   
        if (Mathf.Abs(angleStep) < Mathf.Abs(deltaAngle))
            transform.Rotate(0, 0, angleStep);
        else
            transform.Rotate(0, 0, deltaAngle);

        float dot = Vector3.Dot(transform.up, direction);

        Debug.DrawLine(transform.position, transform.position + transform.up, Color.green);

    }
    private float CalculateDegAngleFromVector(Vector2 position)
    {
        return Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
    }
    void DrawacircleAroundturret(int howmanypoints, float radiusoflaser, Vector3 PlayerPos)
    {
        Color linecolor = Color.green;
        Vector2 enemypos = PlayerPos;

        float distance = Vector2.Distance(transform.position, enemypos);
        if (distance <= radiusoflaser)
        {
            linecolor = Color.red;
        }
        else
        {
            linecolor = Color.green;
        }

        float anglestep = 360f / howmanypoints;
        float radius = anglestep * Mathf.Deg2Rad;
        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < howmanypoints; i++)
        {
            float adjustment = radius * i;
            points.Add(new Vector2(Mathf.Cos(radius + adjustment) * radiusoflaser, Mathf.Sin(radius + adjustment) * radiusoflaser));
        }

        for (int i = 0; i < points.Count - 1; i++)
        {
            Debug.DrawLine(transform.position + points[points.Count - 1], transform.position + points[0], linecolor);

            Debug.DrawLine(transform.position + points[i], transform.position + points[i + 1], linecolor);
        }
    }
}
