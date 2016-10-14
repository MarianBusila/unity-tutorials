using UnityEngine;
using System.Collections;

public class WebcamFeed : MonoBehaviour {

    WebCamTexture webcamTexture;

    void Start ()
    {
        webcamTexture = new WebCamTexture();
        webcamTexture.deviceName = WebCamTexture.devices[0].name;
        GetComponent<MeshRenderer>().material.mainTexture = webcamTexture;
        webcamTexture.Play();
       	
	}
    
    public void SwitchCamera()
    {
        if(WebCamTexture.devices.Length > 1)
        {
            webcamTexture.Stop();
            webcamTexture.deviceName = (webcamTexture.deviceName == WebCamTexture.devices[0].name) ? WebCamTexture.devices[1].name : WebCamTexture.devices[0].name;
            webcamTexture.Play();
        }

    }	
	
}
