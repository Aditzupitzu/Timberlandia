using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    public Transform pickUpPos;
    private Vector3 initialVelocity;
    private GameObject pickedObject;
    private bool interactable;
    private bool pickedUp;
    private Vector3 lastCameraPosition;
    private Vector3 cameraVelocity;

    void Start()
    {
        lastCameraPosition = Camera.main.transform.position;
    }

    void Update()
    {
        // Calculate camera velocity
        Vector3 currentCameraPosition = Camera.main.transform.position;
        cameraVelocity = (currentCameraPosition - lastCameraPosition) / Time.deltaTime;
        lastCameraPosition = currentCameraPosition;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5))
        {
            if (hit.collider.CompareTag("Log"))
            {
                interactable = true;
            }
            else
            {
                interactable = false;
            }

            if (interactable && !pickedUp && Input.GetMouseButton(0))
            {
                pickedObject = hit.transform.gameObject;
                Rigidbody pickedObjectRigidbody = pickedObject.GetComponent<Rigidbody>();
                initialVelocity = pickedObjectRigidbody.velocity;
                pickUpPos.position = hit.point;  // Set pickUpPos to hit.point
                pickUpPos.rotation = pickedObject.transform.rotation;
                pickedObjectRigidbody.isKinematic = true;
                pickedUp = true;
            }
        }
        else
        {
            interactable = false;
        }

        if (pickedUp && pickedObject != null)
        {
            // Continuously update the position to follow pickUpPos
            pickedObject.transform.position = pickUpPos.position;
            pickedObject.transform.rotation = pickUpPos.rotation;

            if (Input.GetMouseButtonUp(0))
            {
                Rigidbody pickedObjectRigidbody = pickedObject.GetComponent<Rigidbody>();
                pickedObject.transform.parent = null;
                pickedObjectRigidbody.isKinematic = false;  // Make non-kinematic first

                // Apply the combined velocity
                pickedObjectRigidbody.velocity = initialVelocity + cameraVelocity;

                pickedUp = false;
                pickedObject = null;
            }
        }
    }
}
