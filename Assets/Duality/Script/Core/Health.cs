using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float _currentHealth = 100f;
    [SerializeField] private float _maxHealth = 100f;
    public Action painEvent;

    public void AddHealth(float amount)
    {
        Debug.Log("Add hp");
        if (_currentHealth < _maxHealth || (_currentHealth + amount) <= _maxHealth)
        {
            _currentHealth += amount;
        }
    }

    public void DecreaseHealth(float amount)
    {
        Debug.Log("Decrease hp");
        if (_currentHealth - amount <= 0)
        {
            _currentHealth = 0;
        }
        else
        {
            _currentHealth -= amount;
        }
        painEvent.Invoke();
    }
}