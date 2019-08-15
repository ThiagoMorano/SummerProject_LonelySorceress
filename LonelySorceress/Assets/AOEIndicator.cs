using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AOEIndicator : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }



    public void AOE(RaycastHit hit)
    {
        transform.position = hit.point;

    }

}
