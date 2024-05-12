using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hchakraas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0,20,0));
    }
    // it will rotate earth along y axis by 1 degree 60 times in  1 sec
}
