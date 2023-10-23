using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConsumeEvent : MonoBehaviour
{
    private Transform playerTransform = null;


    UnityEvent m_EatObject;
    void Start()
    {
        if (m_EatObject == null) 
        {
            m_EatObject = new UnityEvent();
        }

        m_EatObject.AddListener(ConsumeObject);


        playerTransform = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_EatObject.Invoke();
        Destroy(collision.gameObject);
    }

    //Pass through object info later
    void ConsumeObject() 
    {
        playerTransform.localScale += new Vector3(0.1f, 0.1f, transform.localScale.z);
        
        Debug.Log("YUUUUUM!!!");
    }
}
