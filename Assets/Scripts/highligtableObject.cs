using UnityEngine;
using System.Collections;

public class highligtableObject : MonoBehaviour {
    private GameObject hololenseData;


    // Use this for initialization
    void Start () {
        hololenseData = GameObject.Find("hololenseData");
    }
	
	// Update is called once per frame
	void Update () {
        hololenseSensorData holoData = hololenseData.GetComponent<hololenseSensorData>();
        float distance = (holoData.pinchHitLocation - transform.position).magnitude;
        if(distance < 0.5f)
        {
            hololenseData.GetComponent<hololenseSensorData>().gazeDebugObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, Mathf.Min(1, distance / 0.5f), 0));
        }
    }
}
