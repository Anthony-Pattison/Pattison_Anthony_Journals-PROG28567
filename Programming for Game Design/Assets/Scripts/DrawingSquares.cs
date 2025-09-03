using UnityEngine;

public class DrawingSquares : MonoBehaviour
{
    public GameObject Prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Prefab = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        Vector2 tempscale = transform.localScale;
        tempscale.x = tempscale.x + Input.mouseScrollDelta.y; tempscale.y = tempscale.y + Input.mouseScrollDelta.y;
        transform.localScale = tempscale;

        if (Input.GetMouseButtonDown(0))
        {
            createCircle(mousePos, tempscale);
        }
    }

    private void createCircle(Vector2 temppos, Vector2 tempscale)
    {
        
        GameObject tempsquare =  Instantiate(Prefab);
        tempsquare.transform.position = temppos;
        tempsquare.GetComponent<SpriteRenderer>().color = Color.white;
        tempsquare.GetComponent<DrawingSquares>().enabled = false;
        tempsquare.transform.localScale = tempscale;
    }
}
