using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConsumeEvent : MonoBehaviour
{
    private Transform playerTransform = null;
    private int consumableValue = 0;


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
        if (collision.GetComponent<Transform>().localScale.x <= transform.localScale.x)
        {
            consumableValue = collision.GetComponent<ConsumableData>().stats.sizeValue;
            m_EatObject.Invoke();
            Destroy(collision.gameObject);
        }
        else if (collision.GetComponent<Transform>().localScale.x > transform.localScale.x)
        {
            SizeManager.Instance.TakeDamage(collision.GetComponent<ConsumableData>().stats.damage);

            if (playerTransform.localScale.x > 1) 
            {
                playerTransform.localScale += new Vector3(-0.1f, -0.1f, 0) * consumableValue / 2;
            }   
        }
    }

    void ConsumeObject() 
    {
        playerTransform.localScale += new Vector3(0.1f, 0.1f, 0) * consumableValue / 2;

        SizeManager.Instance.Grow(consumableValue);
    }
}
