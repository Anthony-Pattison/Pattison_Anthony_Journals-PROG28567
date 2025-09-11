using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    public int AmountOfBombs;
    public float bombTrailSpacing;
    [SerializeField] float bombBuffer;
    // Update is called once per frame
    void Update()
    {
        DetectAsteroids(3, asteroidTransforms);
        Vector3 playerpos = transform.position;
        if (Input.GetKeyDown("w"))
        {

        }
        if (Input.GetKeyDown("b"))
        {
            StartCoroutine(SpawnBombAtOffset(playerpos, new Vector3(0, 1, 0), bombBuffer, bombPrefab));
        }
        if (Input.GetKeyDown("t"))
        {
            StartCoroutine(SpawnBombTrailAtOffset(playerpos, new Vector3(0, 1, 0), bombTrailSpacing, bombBuffer, bombPrefab));
        }
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(SpawnBombAtOffset(playerpos + RandomNumConerVector(), new Vector3(0, 1, 0), bombBuffer, bombPrefab));
        }
    }

    IEnumerator SpawnBombAtOffset(Vector3 playerpos, Vector3 inOffset, float waitTime, GameObject bombPrefab)
    {
        yield return new WaitForSeconds(waitTime);
        Vector3 pos = playerpos + inOffset;
        Instantiate(bombPrefab, pos, Quaternion.identity);

    }

    IEnumerator SpawnBombTrailAtOffset(Vector3 playerpos, Vector3 inOffset, float spacing, float waitTime, GameObject bombPrefab)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < AmountOfBombs; i++)
        {
            Vector3 pos = playerpos - inOffset;
            pos.y -= spacing * i;
            Instantiate(bombPrefab, pos, Quaternion.identity);
        }
    }

    static Vector3 RandomNumConerVector()
    {
        int num = Random.RandomRange(1, 5);
        switch (num)
        {
            case 1:
                return new Vector3(1, 0.5f);
            case 2:
                return new Vector3(1, -2);
            case 3:
                return new Vector3(-1, 0.5f);
            case 4:
                return new Vector3(-1, -2);
            default:
                return new Vector3(0, 0);
        }
    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        foreach (Transform tempAsteroidsTransform in inAsteroids)
        {
            float distance = Vector3.Distance(tempAsteroidsTransform.position, transform.position);
            if (distance <= 2.5f)
            {
                Debug.DrawLine(transform.position, tempAsteroidsTransform.position, Color.green);
            }
        }
    }
}
