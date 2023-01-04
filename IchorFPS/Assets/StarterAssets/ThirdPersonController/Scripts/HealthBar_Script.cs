using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Script : MonoBehaviour
{
    public PlayerBehaviour playerBehaviour;
    private Image HealthBar;
    public float currentHealth;
    private float maxHealth = 200f;

    private void Start()
    {
        HealthBar= GetComponent<Image>();

    }
    private void Update() {
        currentHealth = GameManager.gameManager._playerHealth.Health;
        HealthBar.fillAmount= currentHealth/maxHealth;
    }
}
