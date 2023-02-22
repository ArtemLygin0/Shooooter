using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 10f;
    public float force = 700f;
    [SerializeField] private float damage = 100f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    void Start()
    {
        countdown = delay;    
    }
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        var explosion = Instantiate(explosionEffect, transform.position, transform.rotation);

        //Массив объектов попадающих в радиус действия
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            var destructible = nearbyObject.transform.GetComponent<DestructibleObject>();
            if (destructible != null)
            {
                destructible.ReceiveDamage(damage);
            }
        }
        Destroy(explosion, 1.5f);
        Destroy(gameObject);
    }
}
