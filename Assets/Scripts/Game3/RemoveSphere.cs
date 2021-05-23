using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSphere : MonoBehaviour
{
    [SerializeField] private GameObject Sphere;
    [SerializeField] private GameObject Generate;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire")
        {
            Destroy(other.gameObject);
            var sp = Instantiate(Sphere);
            sp.transform.position = Generate.transform.position;
        }
    }
}
