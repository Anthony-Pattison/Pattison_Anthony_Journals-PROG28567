using System.Collections.Generic;
using UnityEngine;

public class TurretThatShoots : MonoBehaviour
{
    [Header("for circle around turret")]
    [Space(5f)]
    [SerializeField] int AmountOfPoints;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] float LaserSize;
    [Space(10f)]
    [Header("For aming")]
    [Space(5f)]
    [SerializeField] float BaseRotateSpeed;
    [SerializeField] float RotationSpeed;
    [Space(10f)]
    [Header("For Shooting at the player")]
    [Space(5f)]
    [SerializeField] GameObject MissilePrefab;
    public bool MissleFired;
    GameObject Missle;
    // Update is called once per frame
    void Update()
    {
        DrawDetectionCircle(AmountOfPoints, PlayerTransform.position, LaserSize);
    }
    void PointAtThePlayer(Vector2 PlayerPos)
    {
        Vector2 TurretPos = transform.position;
        Vector2 direction = (PlayerPos - TurretPos).normalized;

        float UpDirection = CalculateTheDefFromAVector(transform.up);
        float directionAngle = CalculateTheDefFromAVector(direction);
        float DeltaAngle = Mathf.DeltaAngle(UpDirection, directionAngle);
        float Sign = Mathf.Sign(DeltaAngle);

        float AngleStep = RotationSpeed * Time.deltaTime * Sign;
        float Dot = Vector3.Dot(transform.up, direction);
        if (Mathf.Abs(AngleStep) < Mathf.Abs(DeltaAngle))
        {
            transform.Rotate(0,0,AngleStep);
        }
        else
        {
            transform.Rotate(0, 0, DeltaAngle);
        }
        if(Dot > 1 && MissleFired)
        {
            Missle = Instantiate(MissilePrefab,transform.position, transform.rotation);
            Missle.GetComponent<MIssileScript>().missleParent = this.gameObject;
            MissleFired = false;
        }
    }
    private float CalculateTheDefFromAVector(Vector2 V) { 
        return Mathf.Atan2(V.y,V.x) * Mathf.Rad2Deg;
    }

    void DrawDetectionCircle(int AmountOfPoints, Vector3 PlayerPos, float LiserSize)
    {
        Color LaserColor = Color.green;
        float distance = Vector2.Distance(transform.position, PlayerPos);
        float AngleStep = 360f / AmountOfPoints;
        float radius = AngleStep * Mathf.Deg2Rad;
        List<Vector3> Points = new List<Vector3>();
        if (distance < radius * LiserSize)
        {
            LaserColor = Color.red;
            PointAtThePlayer(PlayerTransform.position);
        }
        else
        {
            transform.eulerAngles += new Vector3(0, 0, BaseRotateSpeed) * Time.deltaTime;
            LaserColor = Color.green;
        }
        for (int i = 0; i < AmountOfPoints; i++)
        {
            float adjustment = radius * i;
            Points.Add(new Vector3(Mathf.Cos(radius + adjustment) * LiserSize, Mathf.Sin(radius + adjustment) * LiserSize));
        }

        for (int i = 0; i < Points.Count - 1; i++)
        {
            Debug.DrawLine(transform.position + Points[Points.Count - 1], transform.position + Points[0], LaserColor);
            Debug.DrawLine(transform.position + Points[i], transform.position + Points[i + 1], LaserColor);
        }
    }
}
