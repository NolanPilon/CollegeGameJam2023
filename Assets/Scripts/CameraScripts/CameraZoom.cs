using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    private float zoom;
    private float minZoom = 2f;
    private float maxZoom = 16f;
    private float velocity = 0;
    private float smoothTime = 0.25f;

    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        zoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {

       if(Input.GetKeyDown(KeyCode.H))
        {
            zoom = 8f;
        }

        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize,zoom, ref velocity, smoothTime);
    }


}
