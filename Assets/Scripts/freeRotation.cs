using UnityEngine;
using System.Collections;

public class freeRotation : MonoBehaviour
{

    public float rotateSpeed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * new Quaternion(0.3f, 0.5f, 0.6f, 0.1f), Time.deltaTime * rotateSpeed);
    }
}
