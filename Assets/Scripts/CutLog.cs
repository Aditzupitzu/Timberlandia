using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutLog : MonoBehaviour
{
    Vector3 logPosition, logScale;
    Quaternion logRotation;
    public GameObject plankToSpawn;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 5))
        {
            if (hit.collider.CompareTag("Log"))
            {
                if (Input.GetMouseButton(1))
                {
                    logPosition = hit.transform.position;
                    logRotation = hit.transform.rotation;
                    logScale = hit.transform.localScale;
                    Destroy(hit.collider.gameObject);
                    plankToSpawn.transform.localScale = logScale;
                    for (int i = 0; i < Random.Range(4, 8); i++)
                    {
                        Instantiate(plankToSpawn, logPosition, logRotation);
                    }

                }
            }
        }
    }
}
