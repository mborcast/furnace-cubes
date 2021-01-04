using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float waitTime;
    public GameObject spawnable;

    public void Start() 
    {
        StartCoroutine(this.spawn());
    }

    IEnumerator spawn() 
    {
        while (true) {
            yield return new WaitForSeconds(this.waitTime);
            GameObject spawned = Instantiate(this.spawnable, this.transform.position, Quaternion.identity);
            spawned.transform.parent = this.transform;
        }
    }
}
