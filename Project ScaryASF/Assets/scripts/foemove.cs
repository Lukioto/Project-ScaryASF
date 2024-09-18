using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class foemove : MonoBehaviour
{

    public Transform _foe;



    void Awake()
    {
        
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(90f, Camera.main.transform.rotation.eulerAngles.y, -90f);
    }
}
