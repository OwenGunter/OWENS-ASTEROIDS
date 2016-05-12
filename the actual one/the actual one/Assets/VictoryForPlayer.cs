using UnityEngine;
using System.Collections;

public class VictoryForPlayer : MonoBehaviour {

    private Rigidbody m_Rigidbody;

    public bool m_isGameOver;


    public void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        m_isGameOver = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();

        if(other.tag == "Player")
        {
            m_isGameOver = true;
        }
    }

}
