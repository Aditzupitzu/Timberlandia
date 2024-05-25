using UnityEngine;
using TMPro;

public class BuyMenuScript : MonoBehaviour
{
    public TMP_Text axeUpgradePrice, moneyDisplay;
    public PlayerStats playerStats;
    public GameObject buyMenu;
    public int axeRequiredMoney = 1000;

    private void Start()
    {
        axeUpgradePrice.SetText("Upgrade Axe\n- " + axeRequiredMoney.ToString() + " -");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pleyar"))
        {
            buyMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        buyMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UpgradeAxe()
    {
        if (playerStats.money >= axeRequiredMoney)
        {
            playerStats.money -= axeRequiredMoney;
            playerStats.axeDamage += 10;
            axeRequiredMoney *= 2;
            axeUpgradePrice.SetText("Upgrade Axe\n- " + axeRequiredMoney.ToString() + " -");
            moneyDisplay.text = "$" + playerStats.money.ToString();
        }
    }
}
