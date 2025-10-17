using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public  bool corutineRunning = false;

    Transform startpos;
    Transform endpos;
    // Update is called once per frame
    void Update()
    {
        if (!corutineRunning)
        {
            StartCoroutine(drawline());
        }
        Debug.DrawLine(startpos.position, endpos.position, Color.red);
    }
    IEnumerator drawline()
    {
        corutineRunning=true;
        for (int i = 1; i < starTransforms.Count; i++)
        {
            endpos = starTransforms[i];
            startpos = starTransforms[i - 1];

            yield return new WaitForSeconds(drawingTime);
        }

        for (int i = starTransforms.Count-1; i > 1; i--)
        {
            endpos = starTransforms[i-1];
            startpos = starTransforms[i - 2];

            yield return new WaitForSeconds(drawingTime);
        }
        corutineRunning = false;
    }
}
