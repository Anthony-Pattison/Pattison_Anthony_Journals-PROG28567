using UnityEngine;

public class DrawingSquares : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        Vector2 tempscale = transform.localScale;
        tempscale.x = tempscale.x + Input.mouseScrollDelta.y; tempscale.y = tempscale.y + Input.mouseScrollDelta.y;
        transform.localScale = tempscale;
    }
}
