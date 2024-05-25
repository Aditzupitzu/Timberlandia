using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Transform pickUpPos;
    private GameObject pickedObject;
    private bool pickedUp;


    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5))
        {
            if (hit.collider.CompareTag("Log") || hit.collider.CompareTag("Plank"))
            {
                if (!pickedUp && Input.GetKeyDown(KeyCode.E))
                {
                    PickUpObject(hit);
                }
            }
        }

        if (pickedUp && pickedObject != null)
        {
            HandlePickedObject();
        }
    }

    void PickUpObject(RaycastHit hit)
    {
        pickedObject = hit.transform.gameObject;
        Rigidbody pickedObjectRigidbody = pickedObject.GetComponent<Rigidbody>();
        Collider pickedObjectCollider = pickedObject.GetComponent<Collider>();

        pickUpPos.position = hit.point;
        pickUpPos.rotation = pickedObject.transform.rotation;

        pickedObjectRigidbody.isKinematic = true;
        pickedObjectCollider.enabled = false;
        pickedUp = true;
    }

    void HandlePickedObject()
    {
        pickedObject.transform.position = pickUpPos.position;
        pickedObject.transform.rotation = pickUpPos.rotation;

        if (Input.GetKeyUp(KeyCode.E))
        {
            Rigidbody pickedObjectRigidbody = pickedObject.GetComponent<Rigidbody>();
            Collider pickedObjectCollider = pickedObject.GetComponent<Collider>();

            pickedObjectRigidbody.isKinematic = false;
            pickedObjectCollider.enabled = true;

            pickedUp = false;
            pickedObject = null;
        }
    }
}