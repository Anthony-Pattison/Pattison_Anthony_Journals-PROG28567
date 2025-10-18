using UnityEngine;

public class MIssileScript : MonoBehaviour
{
    public GameObject missleParent;
    void Update()
    {
        Vector2 misslePos = transform.position;
        Vector2 MissleInScreenSpace = Camera.main.WorldToScreenPoint(misslePos);
        transform.position += transform.up* 3 * Time.deltaTime;

        if (MissleInScreenSpace.x > Screen.width || MissleInScreenSpace.y > Screen.height
            || MissleInScreenSpace.x < 0 || MissleInScreenSpace.y < 0)
        {
            missleParent.GetComponent<TurretThatShoots>().MissleFired = true;
            Destroy(this.gameObject);
        }
    }
}
