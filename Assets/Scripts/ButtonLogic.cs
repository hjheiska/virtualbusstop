using UnityEngine;
using System.Collections;


public class ButtonLogic : MonoBehaviour {

    private GameObject hololenseData;

	// Use this for initialization
	void Start () {
        hololenseData = GameObject.Find("hololenseData");
    }

    // Update is called once per frame
    void Update () {
        
        //float distance = (transform.position - hololenseData.GetComponent<hololenseSensorData>().handPosition).magnitude;
        float distance = (transform.position - hololenseData.GetComponent<hololenseSensorData>().pinchHitLocation).magnitude;

        if (distance > 0.5f)
            GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 0.5f));
        else if (distance > 0.1f)
            GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0.5f, 0));
        else
            GetComponent<Renderer>().material.SetColor("_Color", new Color(0.5f, 0, 0));
    }
    
}
