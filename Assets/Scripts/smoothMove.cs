using UnityEngine;
using System.Collections;

public class smoothMove : MonoBehaviour
{

    // Use this for initialization
    public Transform target;

    public float moveSpeed;
    public float rotateSpeed;

    void Start()
    {
        StartCoroutine(SmoothMove(transform, target, 0.2f));
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SmoothMove(Transform startpos, Transform endpos, float seconds)
    {
        while (true)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, target.position, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * rotateSpeed);
            yield return new WaitForFixedUpdate();
        }
    }
}
