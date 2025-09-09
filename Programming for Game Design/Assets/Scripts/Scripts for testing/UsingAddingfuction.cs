using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class UsingAddingfuction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int sum = AddingScript.add(1,2);
        print($"This is the sum {sum}");
    }

    // Update is called once per frame
    void Update()
    {

    }

   public static IEnumerator Waiting()
    {
        Debug.Log("start waiting");
        yield return new WaitForSeconds(2);
        Debug.Log("Done waiting 2 seconds");
    }
}
