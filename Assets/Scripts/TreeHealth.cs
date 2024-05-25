using System.Collections;
using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    public int maxHealth, currentHealth;
    float treeScale;
    public GameObject log, player, treeSpawner, effects;
    public Vector3 originalLogScale, logScale;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
            player.GetComponent<PlayerStats>().cutTrees++;
        }
    }
    public void Die()
    {
        logScale = log.transform.localScale;
        originalLogScale = new Vector3(50, 50, 50);
        treeScale = gameObject.transform.parent.localScale.x;
        Instantiate(effects, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(transform.parent.gameObject);
        
        for (int i = 0; i < 4; i++)
        {
            logScale = originalLogScale * treeScale;
            log.transform.localScale = logScale;
            Instantiate(log, transform.position + new Vector3(0, i + 2, 0), Quaternion.Euler(Random.Range(0f, 45f), Random.Range(0f, 45f), Random.Range(0f, 45f)));
        }
    }
}