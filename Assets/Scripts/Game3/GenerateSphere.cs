using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateSphere : MonoBehaviour
{
    [SerializeField] private Text Score;
    [SerializeField] private GameObject Sphere;
    public GameObject FstSphere;
    private int counter = 0;
    public void Start()
    {
        GlobalDefines.GameTip3 = true;
    }
    void Update()
    {
        if (GlobalDefines.GameTip3)
        {
            FstSphere.GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            FstSphere.GetComponent<Rigidbody>().useGravity = true; 
        }

        if (int.Parse(Score.text)%5 == 0 && int.Parse(Score.text) != counter )
        {
            counter+=5;
            var sp = Instantiate(Sphere);
            sp.transform.position = gameObject.transform.position;
        }
    }
}
