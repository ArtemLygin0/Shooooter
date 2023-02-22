using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCam : MonoBehaviour
{
    [SerializeField] private float force = 20f;
    [SerializeField] private float damage = 50f;
    [SerializeField] private float spreadConfig = 10f;
    [SerializeField] private GameObject impactPrefab;
    private void Update()
    {
        // Притягивание
        if (Input.GetMouseButtonDown(1) || (Input.GetKey(KeyCode.E)))
        {
            // Разброс пуль
            var randomX = Random.Range(-spreadConfig / 2, spreadConfig / 2);
            var randomY = Random.Range(-spreadConfig / 2, spreadConfig / 2);
            var spread = new Vector3(randomX, randomY, 0f);
            Vector3 direction = transform.forward + spread;

            if (Physics.Raycast(transform.position, direction, out var hit))
            {
                //print(hit.transform.gameObject.name);

                var impactEffect = Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
                Destroy(impactEffect, 1.5f);
                // Нанесение урона
                var destructible = hit.transform.GetComponent<DestructibleObject>();
                if (destructible != null)
                {
                    destructible.ReceiveDamage(damage);
                }
                // Есть ли объект на линии
                var rigidbody = hit.transform.GetComponent<Rigidbody>();
                if (rigidbody == null)
                {
                    return;
                }
                rigidbody.AddForce(transform.forward * -force, ForceMode.Impulse);
            }
        }

        //Отталкивание
        if (Input.GetMouseButtonDown(0) || (Input.GetKey(KeyCode.Q)))
        {
            var randomX = Random.Range(-spreadConfig / 2, spreadConfig / 2);
            var randomY = Random.Range(-spreadConfig / 2, spreadConfig / 2);
            var spread = new Vector3(randomX, randomY, 0f);
            Vector3 direction = transform.forward + spread;

            if (Physics.Raycast(transform.position, direction, out var hit))
            {
                //print(hit.transform.gameObject.name);

                var impactEffect = Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
                Destroy(impactEffect, 1.5f);
                var destructible = hit.transform.GetComponent<DestructibleObject>();
                if (destructible != null)
                {
                    destructible.ReceiveDamage(damage);
                }

                var rigidbody = hit.transform.GetComponent<Rigidbody>();
                if (rigidbody == null)
                {
                    return;
                }
                rigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
            }
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit))
            {
                //print(hit.transform.gameObject.name);

                var rigidbody = hit.transform.GetComponent<Rigidbody>();
                if (rigidbody == null)
                {
                    if (rigidbody == null)
                    {
                        hit.transform.gameObject.SetActive(false);
                    }
                    //else
                    //{
                    //    hit.transform.gameObject.SetActive(true);
                    //}
                    
                    //Как вернуть обратно скрытый объект?
                    //Вернуть через время

                    return;
                    
                }
            }
        }
     
    }
}
