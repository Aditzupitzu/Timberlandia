using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private int damageAmount = 100;
    private float cooldownTime = 1f, lastAttackTime;
    public Image crosshair1, crosshair2;
    public Text healthText;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 5))
        {
            if (hit.collider.CompareTag("Tree"))
            {
                int currentTreeHealth = hit.transform.GetComponent<TreeHealth>().currentHealth;
                int currentTreeMaxHealth = hit.transform.GetComponent<TreeHealth>().maxHealth;
                healthText.text = currentTreeHealth + "/" + currentTreeMaxHealth;
                CrosshairActivate();
                if (Input.GetMouseButton(0))
                {
                    if (Time.time - lastAttackTime >= cooldownTime)
                    {
                        lastAttackTime = Time.time;
                        hit.transform.GetComponent<TreeHealth>().TakeDamage(damageAmount);
                    }
                }
            }
        }
        else
        {
            healthText.text = " ";
            CrosshairDeactivate();
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