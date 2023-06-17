using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POVHijau : MonoBehaviour
{
    public GameObject Shadow;

    public void red()
    {
        Shadow.SetActive(false);
    }
    public void green()
    {
        Shadow.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
