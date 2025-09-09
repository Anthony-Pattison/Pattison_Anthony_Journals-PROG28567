using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    [SerializeField] float bombBuffer;
    // Update is called once per frame
    void Update()
    {
        Vector3 playerpos = transform.position;
        if (Input.GetKeyDown("w"))
        {

        }
        if (Input.GetKeyDown("b"))
        {
            StartCoroutine(SpawnBombAtOffset(playerpos, new Vector3(0, 1, 0), bombBuffer, bombPrefab));
        }
    }
 
    //Vector3 playerpos, Vector3 inOffset, float waitTime, GameObject bombPrefab
    IEnumerator SpawnBombAtOffset(Vector3 playerpos, Vector3 inOffset, float waitTime, GameObject bombPrefab)
    {
        yield return new WaitForSeconds(waitTime);
        Vector3 pos = playerpos + inOffset;
        Instantiate(bombPrefab, pos, Quaternion.identity);
    }

}
