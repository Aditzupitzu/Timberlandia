using UnityEngine;
using TMPro;

public class BuildScript : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject[] housePrefab;
    public GameObject currentItem;
    private bool isBuilding = false;
    public TMP_Text moneyDisplay;

    void Update()
    {
        if (isBuilding)
        {
            BuildMode();
        }
    }

    private void BuildMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 20))
        {
            currentItem.transform.position = hit.point;
            if (Input.GetKey(KeyCode.R))
            {
                currentItem.transform.Rotate(0, 90 * Time.deltaTime, 0);
            }
            if (Input.GetMouseButtonDown(0))
            {
                isBuilding = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                Destroy(currentItem);
                isBuilding = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void Cabin1()
    {
        if(playerStats.money >= 10)
        {
            currentItem = Instantiate(housePrefab[0]);
            isBuilding = true;
            playerStats.money -= 10;
            moneyDisplay.text = "$" + playerStats.money.ToString();
        }
    }
    public void Cabin2()
    {
        if(playerStats.money >= 100)
        {
            currentItem = Instantiate(housePrefab[1]);
            isBuilding = true;
            playerStats.money -= 100;
            moneyDisplay.text = "$" + playerStats.money.ToString();
        }
    }
}
