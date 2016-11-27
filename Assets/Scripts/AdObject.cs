using UnityEngine;
using System.Collections;

public class AdObject : MonoBehaviour {

    private GameObject hololenseData;
    private bool adActive;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

	// Use this for initialization
	void Start () {
        hololenseData = GameObject.Find("hololenseData");
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        hololenseSensorData holoData = hololenseData.GetComponent<hololenseSensorData>();
        float distance = (holoData.pinchHitLocation - transform.position).magnitude;
        if (distance < 0.25f)
        {
            adActive = true;
        }
        
        if(holoData.numberOfHands == 0)
        {
            adActive = false;
        }

        if (adActive)
        {
            if(holoData.handPinched)
            {
                Quaternion targetRotation = Quaternion.Inverse(GameObject.Find("Camera").transform.rotation);
                transform.position = Vector3.Lerp(transform.position, holoData.pinchHitLocation, Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime);
        }
    }
}
