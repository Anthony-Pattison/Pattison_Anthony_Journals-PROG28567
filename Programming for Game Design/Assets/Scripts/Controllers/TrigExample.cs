using UnityEngine;
using UnityEngine.InputSystem;

public class TrigExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.DrawLine(Vector3.zero, mosPos, Color.cyan);

        float zero = 0f;
        float angle = Mathf.Atan(1 / zero) * Mathf.Rad2Deg;

        Debug.Log($"<color=yellow><size=16>{angle}</size></color>");
    }
}
