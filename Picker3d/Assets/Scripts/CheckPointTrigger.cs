using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour
{
    public Transform Platform;
    public int OpenClose = 0;
    public GameObject picker;
    float t=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenClose == 1)
        {
            OpenCeiling();
        }
        if(OpenClose == -1)
        {
            CloseCeiling();
            t += Time.deltaTime;
            if (t > 5)
            {
                picker.GetComponent<PickerMove>().OnTheMove = -5;
                this.enabled = false;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag=="Picker"&&OpenClose==0)
        {            
            other.GetComponentInParent<PickerMove>().OnTheMove = 0;           
            OpenClose = 1;
        }
    }

    private void OpenCeiling()
    {
        Platform.position= Vector3.Lerp(Platform.position, new Vector3(Platform.position.x, -5, Platform.position.z),1*Time.deltaTime);
    }
    private void CloseCeiling()
    {
        Platform.position = Vector3.Lerp(Platform.position, new Vector3(Platform.position.x, 0, Platform.position.z), 1 * Time.deltaTime);

    }
}
