using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConsumableWander : MonoBehaviour
{
    enum AI_BEHAVIOUR 
    {
        WANDER = 0,
        CHASE,

        BOTTOM_TEXT
    }

    [SerializeField] private float wanderSpeed = 1.0f;
    [SerializeField] private Vector2 target = new Vector2(0, 0);

    [SerializeField] private int state = (int)AI_BEHAVIOUR.WANDER;

    private GameObject playerRef = null;

    void Start()
    { 
        playerRef = GameObject.FindGameObjectWithTag("Player");
        PickRandomDirection();
    }

    private void FixedUpdate()
    {
        if (SizeManager.Instance == null) 
        {
            return;
        }

        if (SizeManager.Instance.playerLevel >= 2)
        {
            state = (int)AI_BEHAVIOUR.WANDER;
        }

        if (state == (int)AI_BEHAVIOUR.WANDER) 
        {
            if (transform.localPosition.x >= target.x && transform.localPosition.y <= target.y ||
                transform.localPosition.x <= target.x && transform.localPosition.y >= target.y)
            {
                PickRandomDirection();
            }

            transform.localPosition = Vector2.MoveTowards(transform.localPosition, target, wanderSpeed * Time.deltaTime);
        }

        if (state == (int)AI_BEHAVIOUR.CHASE) 
        {
            transform.position = Vector2.MoveTowards(transform.position, playerRef.transform.position, wanderSpeed * Time.deltaTime);
        }
    }

    void PickRandomDirection() 
    {
        target = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
    }
}
