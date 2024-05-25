using UnityEngine;
using TMPro;

public class SellPlanks : MonoBehaviour
{
    public PlayerStats playerStats;
    private float plankScale, moneyAmount;
    public TMP_Text moneyDisplay;

    private void Start()
    {
        moneyDisplay.text = "$0";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plank"))
        {
            plankScale = other.transform.localScale.x;
            playerStats.money += Mathf.RoundToInt(plankScale);
            moneyDisplay.text = "$" + playerStats.money.ToString();
            Destroy(other.gameObject);
        }
    }
}