using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    [SerializeField] float maxSpeed = 1f;
    [SerializeField] float accelerationTime = 1f;
    [SerializeField] float speed = 0.01f;
    public Vector3 PlayerSpeed;
    public Vector3 Velocity;
    [Space(10)]
    [Header ("For the circle around player")]
    [SerializeField] List<float> listofanlges;
    void Update()
    {
        DrawacircleAroundPlayer();


        float acceleration = maxSpeed / accelerationTime;
        Velocity += Input.GetAxisRaw("Horizontal") * acceleration * Time.deltaTime * Vector3.right;
        Velocity += Input.GetAxisRaw("Vertical") * acceleration * Time.deltaTime * Vector3.up;

        if (Input.GetAxisRaw("Horizontal") == 0 && Velocity.x >= 0.01f)
        {
            Velocity +=  acceleration * Time.deltaTime * Vector3.left;
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && Velocity.x <= -0.01f)
        {
            Velocity += acceleration * Time.deltaTime * Vector3.right;
        }
        if (Input.GetAxisRaw("Vertical") == 0 && Velocity.y >= 0.01f)
        {
            Velocity += acceleration * Time.deltaTime * Vector3.down;
        }
        if (Input.GetAxisRaw("Vertical") == 0 && Velocity.y <= -0.01f)
        {
            Velocity += acceleration * Time.deltaTime * Vector3.up;
        }
        Velocity = Vector3.ClampMagnitude(Velocity, maxSpeed);
        transform.position += Velocity * Time.deltaTime;
        playerOUtdiseofscreen(transform.position);
    }
    
    void DrawacircleAroundPlayer()
    {
        //for (int i = 1; i<listofanlges.Count; i++)
        //{
        //    Debug.DrawLine(transform.position + ChangingAngles.drawInaCircle(i, 1), transform.position  + ChangingAngles.drawInaCircle(i-1,1), Color.green);
        //}

        float anglestep = 360f / 6;
        float radius = anglestep * Mathf.Deg2Rad;

        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < 6; i++)
        {
            float adjustment = radius * i;
            points.Add(new Vector2(Mathf.Cos(radius * adjustment), Mathf.Sin(radius*adjustment)));
        }
        
        for(int i = 0;i < points.Count; i++)
        {
            Debug.DrawLine(transform.position + points[points.Count-1], transform.position + points[0], Color.green);

            Debug.DrawLine(transform.position + points[i], transform.position + points[i + 1], Color.green);
        }
    }
    private void playerOUtdiseofscreen(Vector2 playerpos)
    {
        Vector3 playerscreenpoint = Camera.main.WorldToScreenPoint(playerpos);

        if (Screen.width <= playerscreenpoint.x)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            Velocity = Vector3.zero;
        }
        if (0 >= playerscreenpoint.x)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            Velocity = Vector3.zero;
        }
        if (Screen.height <= playerscreenpoint.y)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            Velocity = Vector3.zero;
        }
        if (0 >= playerscreenpoint.y)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            Velocity = Vector3.zero;
        }
    }
   
}