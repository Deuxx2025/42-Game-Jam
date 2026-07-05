using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class Weapon : MonoBehaviour
{
    public List<GameObject>bulletPool;
    public Transform gunMuzzle;
    public GameObject bulletPrefab;
    public float bulletVelocity = 30;
    public float delay = 3;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        print(bulletPool.Count);
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (bulletPool[i].activeSelf == false)
            {
                bulletPool[i].transform.position = gunMuzzle.position;
                bulletPool[i].SetActive(true);
                bulletPool[i].GetComponent<Rigidbody>().AddForce(gunMuzzle.forward.normalized * bulletVelocity, ForceMode.Impulse);
                StartCoroutine(DeactivateBulletAfterTime(delay, bulletPool[i]));
                break ;
            }
        }
    }

    public IEnumerator DeactivateBulletAfterTime(float seconds, GameObject bullet)
    {
        yield return new WaitForSeconds(seconds);
        bullet.SetActive(false);
    }
}
