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
    void Update()
    {
        
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