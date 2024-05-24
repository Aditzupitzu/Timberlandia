using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CACA");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("CACA");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("CACA");
    }
    
}
