using UnityEngine;
using TMPro;

public class BuildingProgress : MonoBehaviour
{
    public GameObject finishedHouse;
    public TMP_Text logProgress, plankProgress;
    public int logValue, plankValue, requiredLogValue, requiredPlankValue;
    private void Start()
    {
        plankValue = 0;
        logValue = 0;
        plankProgress.SetText(plankValue + "/" + requiredPlankValue);
        logProgress.SetText(logValue + "/" + requiredLogValue);
    }
    private void Update()
    {
        if(plankValue >= requiredPlankValue && logValue >= requiredLogValue)
        {
            Vector3 previewPosition = transform.position;
            Quaternion previewRotation = transform.rotation;
            Instantiate(finishedHouse, previewPosition, previewRotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plank"))
        {
            Destroy(other.gameObject);
            plankValue++;
            plankProgress.SetText(plankValue + "/" + requiredPlankValue);
        }
        if (other.CompareTag("Log"))
        {
            Destroy(other.gameObject);
            logValue++;
            logProgress.SetText(logValue + "/" + requiredLogValue);
        }
    }
}
