using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ConsumeEvent : MonoBehaviour 
{
    [SerializeField] private GameObject deathScreen;
    private GameObject mobGameObject = null;
    private Transform playerTransform = null;
    private int consumableValue = 0;
    private int mobType = 0;
    private Vector3 mobScale;

    [SerializeField]
    private ParticleSystem[] death = null;
    private ParticleSystem deathReSized = null;

    [SerializeField] private AudioClip eatClip;

    [SerializeField] private AudioClip awayClip;

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
            //information for deaths
            mobType = collision.GetComponent<ConsumableData>().stats.unitType;
            mobGameObject = collision.gameObject;
            mobScale = collision.gameObject.transform.localScale;


            consumableValue = collision.GetComponent<ConsumableData>().stats.sizeValue;
            m_EatObject.Invoke();


            Destroy(collision.gameObject);
        }
        else if (collision.GetComponent<Transform>().localScale.x > transform.localScale.x)
        {
            PassAway();
        }
    }

    void ConsumeObject() 
    {
        SpawnManager.Instance.currentEnemyCount--;
        playerTransform.localScale += new Vector3(0.1f, 0.1f, 0) * consumableValue / 4;

        //sets deathReSized value to the correct value
        deathReSized = death[mobType];
        //rescale the particles to mathc the size of mob
        deathReSized.transform.localScale = mobScale;

        //trigger noise
        SoundManager.Instance.PlaySound(eatClip);

        Instantiate(death[mobType], mobGameObject.transform.position,Quaternion.identity);


        SizeManager.Instance.Grow(consumableValue / SizeManager.Instance.playerLevel);
    }

    void PassAway() 
    {
        SoundManager.Instance.PlaySound(awayClip);
        deathScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
