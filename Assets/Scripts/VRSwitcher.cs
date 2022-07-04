using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class VRSwitcher : MonoBehaviour
{
    public static VRSwitcher Instance;
    //public bool vrEnabled;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance= this;
    }
    
    public IEnumerator DisableVRView()
    {
        print("VR disabled");
        XRSettings.LoadDeviceByName("None");  
        yield return null;      
        XRSettings.enabled = false;
    }
    public void EnableVR()
    {
        StartCoroutine(EnableVRView());
    }
    private IEnumerator  EnableVRView()
    {
        print("VR enabled");
        XRSettings.LoadDeviceByName("Cardboard");  
        yield return null;      
        XRSettings.enabled = true;
    }
}
