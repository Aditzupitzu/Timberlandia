using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private int damageAmount = 100;
    private float cooldownTime = 1f, lastAttackTime;
    public Image crosshair1, crosshair2;
    public Text healthText;
    public GameObject pickUpPos, woodParticles;

    // Add a variable to track the collision state
    private bool isLookingAtObject;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5))
        {
            if (hit.collider.CompareTag("Tree"))
            {
                // Update health text
                int currentTreeHealth = hit.transform.GetComponent<TreeHealth>().currentHealth;
                int currentTreeMaxHealth = hit.transform.GetComponent<TreeHealth>().maxHealth;
                healthText.text = currentTreeHealth + "/" + currentTreeMaxHealth;

                // Activate crosshair if not already active
                if (!isLookingAtObject)
                {
                    CrosshairActivate();
                    isLookingAtObject = true;
                }

                // Handle attack
                if (Input.GetMouseButton(0))
                {
                    if (Time.time - lastAttackTime >= cooldownTime)
                    {
                        woodParticles.transform.position = hit.point;
                        woodParticles.GetComponent<ParticleSystem>().Play();
                        lastAttackTime = Time.time;
                        hit.transform.GetComponent<TreeHealth>().TakeDamage(damageAmount);
                    }
                }
            }
            else
            {
                // Deactivate crosshair if it was previously active
                if (isLookingAtObject)
                {
                    healthText.text = " ";
                    CrosshairDeactivate();
                    isLookingAtObject = false;
                }
            }
        }
        else
        {
            // Deactivate crosshair if no object is hit
            if (isLookingAtObject)
            {
                healthText.text = " ";
                CrosshairDeactivate();
                isLookingAtObject = false;
            }
        }
    }

    private void CrosshairActivate()
    {
        crosshair1.enabled = false;
        crosshair2.enabled = true;
    }

    private void CrosshairDeactivate()
    {
        crosshair1.enabled = true;
        crosshair2.enabled = false;
    }
}