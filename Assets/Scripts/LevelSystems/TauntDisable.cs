﻿using UnityEngine;
using System.Collections;

public class TauntDisable : MonoBehaviour {


    public Transform spikeWall;
    public float raiseSpeed;

    private MeshRenderer _render;
    private bool _spikesUp;

	void Start ()
    {
        _spikesUp = false;

        _render = GetComponent<MeshRenderer>();
        _render.enabled = false;
	}
	
	void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            print("touched taunt disabler");
            StartCoroutine(RaiseSpikes());
        }
    }

    IEnumerator RaiseSpikes()
    {
        if (_spikesUp)
            yield break;

        _spikesUp = true;

        for (float i = 0; i < 4; i += .2f)
        {
            spikeWall.position = Vector3.Lerp(spikeWall.position, spikeWall.position + (Vector3.up * 3), Time.deltaTime * raiseSpeed);
            yield return null;
        }
    }
}
