using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health Bar Image")]
    [Space]
    [SerializeField] private Image healthBarImage;
    [Header("Bar Values")]
    [Space]
    [SerializeField] private float updateSpeed = 5f; 

    private float currentValue = 0f;

    private void Start()
    {
        healthBarImage.fillAmount = 1f;
    }

    public void UpdateHealthBar(float value)
    {
        currentValue = value;
        StartCoroutine(ChangeBarValueCoroutine());
    }

    private IEnumerator ChangeBarValueCoroutine()
    {
        while(healthBarImage.fillAmount != currentValue)
        {
            yield return null;

            float tempValue = Mathf.Lerp(healthBarImage.fillAmount, currentValue, updateSpeed * Time.deltaTime);
            healthBarImage.fillAmount = tempValue;
        }
    }
}
