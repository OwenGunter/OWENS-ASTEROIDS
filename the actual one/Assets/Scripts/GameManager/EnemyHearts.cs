using UnityEngine;
using System.Collections;


public class EnemyHearts : MonoBehaviour
{

    //amount of hearts the player starts with
    public float m_StartingHearts = 1f;

    public float amount = 1f;

    private float m_CurrentHearts;

    private bool m_Dead;

    private void OnEnable()
    {
        // reset ship health to starting health and it is not dead
        m_CurrentHearts = m_StartingHearts;
        m_Dead = false;
       
        //Debug.Log(m_CurrentHearts);
    }

    
    public void TakeDamage(float amount)
    {
        // Reduce current health by one 
        m_CurrentHearts -= amount;
        
        // if the current health is at or below zero and it has not yet
        // been registered, call OnDeath
        if (m_CurrentHearts <= 0f && !m_Dead)
        {
            OnDeath();
            Debug.Log(m_CurrentHearts);
        }
    }

    private void OnDeath()
    {
        // Set the flag so that this function is only called once
        m_Dead = true;

        Debug.Log(m_Dead);

        gameObject.SetActive(false);

    }
}
