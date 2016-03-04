﻿using UnityEngine;
using System.Collections;

public class RangedEnemy : AIBaseClass {

 
    [Header("Ranged Enemy")]
    public Rigidbody bulletPrefab;
    public Transform firePoint;
    public float fireRate;
    public float accuracyOffset;


	protected override void Awake ()
    {
        base.Awake();
        _actionAvailable = true;
	}

    public void ShootAtPlayer()
    {
        Vector3 direction = new Vector3(_playerTransform.position.x + Random.Range(-accuracyOffset, accuracyOffset), transform.position.y, _playerTransform.position.z + Random.Range(-accuracyOffset, accuracyOffset));

        transform.LookAt(direction);

        if (_actionAvailable)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            _enemyAudio.clip = enemySounds[0];
            _enemyAudio.Play();

            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        _actionAvailable = false;

        yield return new WaitForSeconds(Random.Range(fireRate + .1f, fireRate + .75f));

        _actionAvailable = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Bullet"))
            StartCoroutine(Stun());
    }
}
