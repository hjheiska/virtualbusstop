using UnityEngine;
using System.Collections;

public class AdObject : MonoBehaviour {

    private GameObject hololenseData;
    private bool adActive;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;

	// Use this for initialization
	void Start () {
        hololenseData = GameObject.Find("hololenseData");
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        hololenseSensorData holoData = hololenseData.GetComponent<hololenseSensorData>();
        float distance = (holoData.pinchHitLocation - transform.position).magnitude;
        if (distance < 0.15f)
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
                Vector3 cameraPosition = GameObject.Find("Camera").transform.position;
                Vector3 lookVector = cameraPosition - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(lookVector, Vector3.up);
                Vector3 targetScale = originalScale * 0.2f;
                transform.position = Vector3.Lerp(transform.position, holoData.handPosition, Time.deltaTime);
                transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime);
        }
    }
}
