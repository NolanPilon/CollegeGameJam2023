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

    public ParticleSystem splurg;

    [SerializeField]
    private AudioClip growAudio = null;



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
            SoundManager.Instance.PlaySound(growAudio);
            splurg.Play();
            CameraManager.Instance.CameraShake(3, 0.1f);
            StartCoroutine(ZoomOut());
        }

        if(allowedToGrow)
        {
            playerTransform.localScale = new Vector3(playerStartingSize, playerStartingSize, 0);
            playerStartingSize = Mathf.SmoothDamp(playerStartingSize, playerMultiplier, ref velocity, 4.0f);

            if (Mathf.Round(playerStartingSize +1f) >= playerMultiplier)
            {
                allowedToGrow = false;
            }
        }
    }

    IEnumerator ZoomOut()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        splurg.Pause();
        splurg.Clear();
        CameraManager.Instance.CameraZoom(CameraManager.Instance.cam.orthographicSize * 1.5f);
        StopCoroutine(ZoomOut());

    }
}
