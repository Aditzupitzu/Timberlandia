using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public int damageAmount;
    private float cooldownTime = 1f, lastAttackTime;
    public GameObject playerStats, woodParticles, axe;
    public Image crosshair1, crosshair2;
    public Text healthText;
    public bool hitting;
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
                        StartCoroutine(AxeSwing());
                        gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
                        gameObject.GetComponent<AudioSource>().Play();
                        woodParticles.transform.position = hit.point;
                        woodParticles.GetComponent<ParticleSystem>().Play();
                        lastAttackTime = Time.time;
                        damageAmount = playerStats.GetComponent<PlayerStats>().axeDamage;
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

        if (Input.GetKeyDown(KeyCode.H)) playerStats.GetComponent<PlayerStats>().axeDamage *= 2;
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
    IEnumerator AxeSwing()
    {
        axe.GetComponent<Animator>().Play("AxeSwing");
        yield return new WaitForSeconds(0.5f);
        axe.GetComponent<Animator>().Play("Idle");
    }

}