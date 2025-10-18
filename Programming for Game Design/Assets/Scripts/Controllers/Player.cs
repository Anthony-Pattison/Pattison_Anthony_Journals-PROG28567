using System.Collections.Generic;
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
    [Header("For the circle around player")]
    [SerializeField] int NumOfPoints;
    float radius;
    public float laserradius;
    [Space(10)]
    [Header("For Spawning Power Ups")]
    public int HowMany;
    public float bombradius;
    [SerializeField] GameObject PowerUpPrefab;
    void Update()
    {
        DrawacircleAroundPlayer(NumOfPoints, laserradius);
        if (Input.GetKeyDown("space"))
        {
            SpawnPowerUps(HowMany, bombradius);
        }

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
    void SpawnPowerUps(int HowManyPowerUps, float radious)
    {
        float anlgelocation = 360f / HowManyPowerUps;
        float PowerUpRadius = anlgelocation * Mathf.Deg2Rad;
        for (int i = 0; i < HowManyPowerUps; i++)
        {
            float adjustment = PowerUpRadius * i;
            Vector2 position = transform.position + new Vector3(Mathf.Cos(PowerUpRadius + adjustment)* radious, Mathf.Sin(PowerUpRadius + adjustment)* radious);
            
            Instantiate(PowerUpPrefab, position, Quaternion.identity);
        }
    }
    void DrawacircleAroundPlayer(int howmanypoints, float radiusoflaser)
    {
        Color linecolor = Color.green;
        Vector2 enemypos = enemyTransform.position;

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
        radius = anglestep * Mathf.Deg2Rad;
        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < howmanypoints; i++)
        {
            float adjustment = radius * i;
            points.Add(new Vector2(Mathf.Cos(radius + adjustment)* radiusoflaser, Mathf.Sin(radius+adjustment)* radiusoflaser));
        }
        
        for(int i = 0;i < points.Count - 1; i++)
        {
            Debug.DrawLine(transform.position + points[points.Count-1], transform.position + points[0], linecolor);

            Debug.DrawLine(transform.position + points[i], transform.position + points[i + 1], linecolor);
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