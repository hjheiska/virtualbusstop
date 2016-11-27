using UnityEngine;
using System.Collections;

public class CloudObject : MonoBehaviour {

    private bool cloudActive;
    private GameObject hololenseData;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    public Camera mainCamera;



    // Use this for initialization
    void Start()
    {
        hololenseData = GameObject.Find("hololenseData");
        mainCamera = GameObject.Find("Camera").GetComponent<Camera>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hololenseSensorData holoData = hololenseData.GetComponent<hololenseSensorData>();

        bool audioPlaying = GetComponent<AudioSource>().isPlaying;

        if (!audioPlaying && cloudActive)
            GetComponent<AudioSource>().Play();

        if (audioPlaying && !cloudActive)
            GetComponent<AudioSource>().Stop();

        float distance = (holoData.pinchHitLocation - transform.position).magnitude;
        //GetComponent<AudioSource>().volume = (Mathf.Min(1, distance / 3));

        if (holoData.handPinched)
        {
            
            if (distance < 0.2f)
            {
                cloudActive = true;
            }
        }
        else
        {
            cloudActive = false;
            targetPosition = originalPosition;
        }

        if (cloudActive)
        {
            Vector3 handPosition = holoData.handPosition;
            targetPosition = handPosition + (mainCamera.transform.forward * 0.3f);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }
}
