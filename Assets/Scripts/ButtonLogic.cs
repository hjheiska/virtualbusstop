using UnityEngine;
using System.Collections;


public class ButtonLogic : MonoBehaviour {

    private GameObject hololenseData;
    public GameObject timeObject;
    private bool pinActive;
    
    // Use this for initialization
    void Start () {
        hololenseData = GameObject.Find("hololenseData");
    }

    // Update is called once per frame
    void Update () {
        
        //float distance = (transform.position - hololenseData.GetComponent<hololenseSensorData>().handPosition).magnitude;
        float distance = (transform.position - hololenseData.GetComponent<hololenseSensorData>().pinchHitLocation).magnitude;

        if (distance < 0.25f)
        {
            pinActive = true;
        }
        else if(hololenseData.GetComponent<hololenseSensorData>().handPinched)
        {
            pinActive = false;
        }

        timeObject.SetActive(pinActive);

    }
    
}
