using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//destroy a thing after a set amount of time!
public class Lifetime : MonoBehaviour
{
    public float lifetime;

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
