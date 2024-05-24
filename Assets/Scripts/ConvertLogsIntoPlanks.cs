using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertLogsIntoPlanks : MonoBehaviour
{
    public GameObject[] planks;
    Vector3 logPosition, logScale;
    Quaternion logRotation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Log"))
        {
            int randomPlank = Random.Range(0, planks.Length);
            logPosition = other.transform.position;
            logRotation = Quaternion.Euler(Vector3.one * other.transform.rotation.y);
            logScale = other.transform.localScale;
            Destroy(other.gameObject);
            GameObject plankToSpawn = planks[randomPlank];
            Instantiate(plankToSpawn, logPosition, Quaternion.identity);
            plankToSpawn.transform.localScale = logScale;
        }

    }
}
