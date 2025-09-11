using UnityEngine;
using UnityEngine.Rendering;

public class Pipeline : MonoBehaviour
{
    public Vector2 mouseStartpos;
    public Vector2 mouseEndpos;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Input.mousePosition;
        Debug.DrawLine(new Vector2(0,6), new Vector2(5, 6), Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            timer = 0;
            mouseStartpos = Camera.main.ScreenToWorldPoint(mousepos);
        }
        if (Input.GetMouseButton(0))
        {
           
            timer += 0.03f * Time.deltaTime;
            
            if (timer > 0.1f)
            {
                Debug.Log("working");
                mouseEndpos = Camera.main.ScreenToWorldPoint(mousepos);
                Debug.DrawLine(mouseStartpos, mouseEndpos, Color.red);
            }
        }
    }
}
