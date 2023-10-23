using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [Header("Follow Variables")]
    private Vector3 offset = new Vector3(0.0f, 0.0f, -10f);
    private float followSmoothTime = 0.25f;
    private Vector3 followVelocity = Vector3.zero;
    [SerializeField] private Transform target;


    //Shake Variables
    [Header("Shake Variables")]
    public bool start = false;
    public float duration = 1f;
    public float strenght;

    //Zoom Variables
    [Header("Zoom Variables")]
    private float zoom;
    private float minZoom = 2f;
    private float maxZoom = 16f;
    private float zoomVelocity = 0;
    private float zoomSmoothTime = 1f;
    [SerializeField] private Camera cam;



    //singleton
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //Following the player
    void FixedUpdate()
    {
 
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref followVelocity, followSmoothTime);
    }


    public void CameraZoom(float zoomAmount)
    {
        StartCoroutine(Zoom(zoomAmount));
    }

    IEnumerator Zoom(float zoomAmount)
    {
        zoom = zoomAmount;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);

        while (Mathf.Round(cam.orthographicSize) != zoom )
        {
            Debug.Log(zoom - 2.0f);
            Debug.Log(zoom);
            Debug.Log(cam.orthographicSize);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref zoomVelocity, zoomSmoothTime);
            yield return null;
        }
   
    }


    public void CameraShake(float shakeDuration, float shakeStrenght)
    {
        StartCoroutine(Shaking(shakeDuration, shakeStrenght));
    }

    IEnumerator Shaking(float shakeDuration, float shakeStrenght)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere * shakeStrenght;
            yield return null;
        }

        transform.position = startPosition;
    }

}
