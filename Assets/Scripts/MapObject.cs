using UnityEngine;
using System.Collections;

public class MapObject : MonoBehaviour {

    private GameObject hololenseData;
    private Quaternion targetRotation;
    private Vector3 targetPosition;
    private Quaternion originalRotation;
    private Vector3 originalPosition;
    private bool mapActive;
    public GameObject pinsRoot;

    // Use this for initialization
    void Start()
    {
        hololenseData = GameObject.Find("hololenseData");
        originalRotation = transform.rotation;
        originalPosition = transform.position;

        targetPosition = originalPosition - Vector3.forward * 0.75f + Vector3.down * 0.5f;
        targetRotation = Quaternion.Euler(60, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        hololenseSensorData holoData = hololenseData.GetComponent<hololenseSensorData>();
        float distance = (holoData.pinchHitLocation - transform.position).magnitude;
        if (distance < 0.25f)
        {
            mapActive = true;
        }
        else if (hololenseData.GetComponent<hololenseSensorData>().handPinched && distance > 1.0f)
        {
            mapActive = false;
        }

        if (mapActive) {
            pinsRoot.SetActive(true);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
         }
         else {
            pinsRoot.SetActive(false);
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime);
        }
    }
}
