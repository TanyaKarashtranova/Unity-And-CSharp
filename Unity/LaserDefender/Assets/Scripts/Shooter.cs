using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileMoveSpeed = 7f;
    [SerializeField] private float projectileLifetime = 2f;
    [SerializeField] private bool isPlayer;
    [SerializeField] private float timeBetweenShootProjectiles = 1f;

    public void Start()
    {
        if (!isPlayer)
        {
            StartCoroutine(ShootContinuously());
        }
    }

    private IEnumerator ShootContinuously()
    {
        while (true)
        {
            AudioPlayer.GetInstance().PlayEnemyShootClip();
            Shoot();
            yield return new WaitForSeconds(timeBetweenShootProjectiles);
        }
    }

    public void ShootOneProjectile()
    {
        AudioPlayer.GetInstance().PlayPlayerShootClip();
        Shoot();
    }

    private void Shoot()
    {
        GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRigidBody = instance.GetComponent<Rigidbody2D>();
        projectileRigidBody.velocity = transform.up * projectileMoveSpeed;
        Destroy(instance, projectileLifetime);
    }
}
