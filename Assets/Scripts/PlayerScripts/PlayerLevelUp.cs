using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUp : MonoBehaviour
{
    private Transform playerTransform = null;

    private float playerMultiplier = 4f;
    private float playerStartingSize = 1f;
    private float velocity = 0.0f;
    private bool allowedToGrow = false;



    private void Start()
    {
        playerTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (SizeManager.Instance.isFull())
        {
          allowedToGrow = true;
          playerStartingSize = playerTransform.localScale.y;
          playerMultiplier = playerStartingSize * 2;
          CameraManager.Instance.CameraShake(3, 0.1f);
        }

        if(allowedToGrow)
        {

            playerTransform.localScale = new Vector3(playerStartingSize, playerStartingSize, 0);
            playerStartingSize = Mathf.SmoothDamp(playerStartingSize, playerMultiplier, ref velocity, 4.0f);

            if (Mathf.Round(playerStartingSize +1f) >= playerMultiplier)
            {
                CameraManager.Instance.CameraZoom(CameraManager.Instance.cam.orthographicSize * 1.5f);
                allowedToGrow = false;
            }
        }
    }
}
