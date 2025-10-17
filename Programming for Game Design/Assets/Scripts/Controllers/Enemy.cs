using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0f, 1f)]
    public float t;
    public AnimationCurve curve;
    public GameObject Teleportparent;
    public Transform PlayerTransform;
    public List<GameObject> Teleportlocations;
    Transform EndTransform;
    private void Start()
    {
        Teleportlocations = PutChildObjectsIntoAList(Teleportparent, Teleportlocations);
    }
    private void Update()
    {
        foreach (GameObject obj in Teleportlocations)
        {
            if (obj.GetComponent<EnemyTeleporting>().PlayerisNear)
            {
                EndTransform = obj.transform;
                t = 0;
            }
        }
        curve.Evaluate(t);
        if (t < 0.5 && EndTransform != null)
        {
            t += 1 * Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, EndTransform.position, t);
            transform.Rotate(new Vector3(0, 0, 5));
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
            transform.position = Vector3.Lerp(transform.position, PlayerTransform.position, 0.001f);
        }
    }

    List<GameObject> PutChildObjectsIntoAList(GameObject Parent, List<GameObject> templist)
    {
        int childrencount = Parent.transform.childCount;
        for (int i = 0; i < childrencount; i++)
        {
            templist.Add(Parent.transform.GetChild(i).gameObject);
        }
        return templist;
    }
}
