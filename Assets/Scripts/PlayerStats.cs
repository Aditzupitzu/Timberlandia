using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public int cutTrees;
    public int axeDamage = 10;
    public int money = 0;
    public int health;
    void Start()
    {
        cutTrees = 0;
        axeDamage = 10;
        money = 0;
        health = 100;
    }
}
