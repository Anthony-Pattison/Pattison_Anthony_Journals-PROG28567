using UnityEngine;

public class Turret : MonoBehaviour
{
    public float angleSpeed = 60f;
    [SerializeField] Transform EnemyTransform;
    void Update()
    {

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

        if (dot < 0) Debug.Log($"<color=red><size=16>In front!</size></color>");
        if (dot > 0) Debug.Log($"<color=blue><size=16>Behind!</size></color>");
    }
    private float CalculateDegAngleFromVector(Vector2 position)
    {
        return Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
    }
}
