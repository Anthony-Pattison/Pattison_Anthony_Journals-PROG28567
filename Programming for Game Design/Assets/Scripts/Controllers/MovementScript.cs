using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float maxSpeed = 1f;
    [SerializeField] float accelerationTime = 1f;
    [SerializeField] float speed = 0.01f;
    public Vector3 PlayerSpeed;
    public Vector3 Velocity;
    // Update is called once per frame
    void Update()
    {
        float acceleration = maxSpeed / accelerationTime;
        Velocity += Input.GetAxisRaw("Horizontal") * acceleration * Time.deltaTime * Vector3.right;
        Velocity += Input.GetAxisRaw("Vertical") * acceleration * Time.deltaTime * Vector3.up;

        if (Input.GetAxisRaw("Horizontal") == 0 && Velocity.x >= 0.01f)
        {
            Velocity += acceleration * Time.deltaTime * Vector3.left;
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
    }
}
