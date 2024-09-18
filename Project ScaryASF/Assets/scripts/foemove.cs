using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class foemove : MonoBehaviour
{

    public Transform _foe;

    private GameObject _player;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        
    }

    void Update()
    {
        Vector3 targetPostition = new Vector3(_player.transform.position.x,
                                       _player.transform.position.y,
                                       _player.transform.position.z);
        this.transform.LookAt(targetPostition);
    }
}
