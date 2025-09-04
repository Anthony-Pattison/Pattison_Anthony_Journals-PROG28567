using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RowGeneration : MonoBehaviour
{
    public GameObject inputfield;
    public GameObject prefab;
    int amountofsquares;
    bool checknum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checknum = int.TryParse(inputfield.GetComponent<TMP_InputField>().text, out amountofsquares);
        
        Debug.Log(checknum);
        if (checknum)
        {
            amountofsquares = int.Parse(inputfield.GetComponent<TMP_InputField>().text);
        }
    }

    public void spawnsquares()
    {
        if (checknum)
        {
            for (int i = 0; i < amountofsquares; i++)
            {
                GameObject tempprefab = Instantiate(prefab);
                tempprefab.transform.position = new Vector2(-9 + i, 0);
            }
        }
    }
}
