using UnityEngine;

public class DotExercise : MonoBehaviour
{
    public float redAngle;
    public float blueAngle;
    
    // Update is called once per frame
    void Update()
    {
        Vector2 redVector = PositionBasedOnAngle(redAngle);
        Vector2 blueVector = PositionBasedOnAngle(blueAngle);
        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);
        if (Input.GetKeyDown("space"))
        {
            Debug.Log($"<color=yellow><size=16>{CalculateDotProduct(redVector, blueVector)}</size></color>");
        }
    }

    public static Vector2 PositionBasedOnAngle(float angle)
    {
        angle = angle * Mathf.Deg2Rad;
        Vector2 Pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Pos = Pos.normalized;
        return Pos;
    }

    public static float CalculateDotProduct(Vector2 a, Vector2 b)
    {
        return a.x * b.x + a.y * b.y;
    }
}
