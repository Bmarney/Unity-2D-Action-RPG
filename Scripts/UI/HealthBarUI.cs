using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image healthBarFill;
    
    private void OnEnable()
    {
        character.onTakeDamage += UpdateHealthBar;
        character.onHeal += UpdateHealthBar;
    }

    private void OnDisable()
    {
        character.onTakeDamage -= UpdateHealthBar;
        character.onHeal -= UpdateHealthBar;
    }

    void SetNameText(string text)
    {
        nameText.text = text;
    }

    private void UpdateHealthBar()
    {
        float healthPercent = (float)character.curHP / (float)character.maxHP;
        healthBarFill.fillAmount = healthPercent;
    }

    private void Start()
    {
        SetNameText(character.displayName);
    }

    private void Update()
    {
        
        
        
    }
}
