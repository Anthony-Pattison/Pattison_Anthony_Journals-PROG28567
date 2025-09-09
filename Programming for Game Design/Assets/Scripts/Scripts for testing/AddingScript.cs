using System.Collections;
using UnityEngine;

public class AddingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int add(int a, int b)
    {
        return a + b;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartCoroutine(UsingAddingfuction.Waiting());
        Drawrectangle(mousepos, Vector2.one, Color.red);
    }

    public static void Drawrectangle(Vector2 pos, Vector2 size, Color color)
    {
        float halfWidth = pos.x / 2;
        float halfHeight = pos.y / 2;

        Vector2 topLeft = new Vector2(pos.x - halfWidth, pos.y + halfHeight);
        Vector2 topRight = topLeft + Vector2.right * size.y;
        Vector2 bottomRight = new Vector2(pos.x + halfWidth, pos.y - halfHeight);
        Vector2 bottomLeft = bottomRight + Vector2.left * size.x;

        Debug.DrawLine(topLeft, topRight, color);
        Debug.DrawLine(topRight, bottomRight, color);
        Debug.DrawLine(bottomRight, bottomLeft, color);
        Debug.DrawLine(bottomLeft, topLeft, color);

    }
   
}
