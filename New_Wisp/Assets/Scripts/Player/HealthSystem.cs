using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public static HealthSystem instance;

    public int currentPlayerHealth;
    public int maxPlayerHealth;
    public int currentWispHealth;
    public int maxWispHealth;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentWispHealth = maxWispHealth;
        currentPlayerHealth = maxPlayerHealth;

        //currentHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxPlayerHealth;
        UIController.instance.healthSlider.value = currentPlayerHealth;
        UIController.instance.healthText.text = currentPlayerHealth.ToString() + " / " + maxPlayerHealth.ToString();

        currentWispHealth = maxWispHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DamagePlayer()
    {
        currentPlayerHealth--;
        if(currentPlayerHealth <= 0)
        {
            PlayerController.instance.gameObject.SetActive(false);
        }
    }
    public void DamageWisp()
    {
        currentWispHealth--;
        if (currentWispHealth <= 0)
        {
            Wisp_Follow.instance.gameObject.SetActive(false);
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentPlayerHealth += healAmount;
        if (currentPlayerHealth > maxPlayerHealth)
        {
            currentPlayerHealth = maxPlayerHealth;
        }

        UIController.instance.healthSlider.value = currentPlayerHealth;
        UIController.instance.healthText.text = currentPlayerHealth.ToString() + " / " + maxPlayerHealth.ToString();
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxPlayerHealth += amount;
        currentPlayerHealth = maxPlayerHealth;

        UIController.instance.healthSlider.maxValue = maxPlayerHealth;
        UIController.instance.healthSlider.value = currentPlayerHealth;
        UIController.instance.healthText.text = currentPlayerHealth.ToString() + " / " + maxPlayerHealth.ToString();
    }
}