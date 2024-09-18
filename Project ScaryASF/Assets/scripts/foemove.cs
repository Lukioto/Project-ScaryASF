using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foemove : MonoBehaviour
{

    public Transform _foe;

    private GameObject _player;

    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _foe.LookAt(_player.transform);
    }
}
