using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticlesDestroy : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(delayedDestroy());
    }

    IEnumerator delayedDestroy()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
