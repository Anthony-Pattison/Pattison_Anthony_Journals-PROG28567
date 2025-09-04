using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RowGeneration : MonoBehaviour
{
    public GameObject inputfield;
    public GameObject prefab;
    float amountofsquares;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        amountofsquares = float.Parse(inputfield.GetComponent<TMP_InputField>().text);
        
    }

    public void spawnsquares()
    {
        for (int i = 0; i < amountofsquares; i++)
        {
            GameObject tempprefab = Instantiate(prefab);
            tempprefab.transform.position = new Vector2(-9 + i, 0);
        }
    }
}
