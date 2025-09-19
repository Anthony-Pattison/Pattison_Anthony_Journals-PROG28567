using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform PlayerTransform;
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerTransform.position, 0.001f);
    }

}
