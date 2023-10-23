using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConsumableWander : MonoBehaviour
{
    [SerializeField] private float wanderDirectionTime = 1.0f;
    [SerializeField] private float wanderSpeed = 1.0f;

    [SerializeField] private Vector2 target = new Vector2(0, 0);
   


    void Start()
    {
        PickDirection();
    }

    private void FixedUpdate()
    {
        if (transform.localPosition.x >= target.x && transform.localPosition.y <= target.y || 
            transform.localPosition.x <= target.x && transform.localPosition.y >= target.y)
        {
            PickDirection();
        }
        
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, target, wanderSpeed * Time.deltaTime);
    }

    void PickDirection() 
    {
        target = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
    }
}
