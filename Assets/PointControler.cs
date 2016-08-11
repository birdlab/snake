using UnityEngine;
using System.Collections;

public class PointControler : MonoBehaviour
{

    public Material speedup;
    public Material longer;
    public Material brake;
    public void setRandomState()
    {
        float x = Mathf.Floor(Random.Range(-(25f / 2), 25f / 2));
        float y = Mathf.Floor(Random.Range(-(25f / 2), 25f / 2));
        float z = Mathf.Floor(Random.Range(-(25f / 2), 25f / 2));
        transform.position = new Vector3(x, y, z);
        setType(Mathf.RoundToInt(Random.Range(0f, 2f)));
    }
    public void setType(int type)
    {
        if (type == 0)
        {
            gameObject.GetComponent<Renderer>().sharedMaterial = speedup;
            gameObject.name = "speedup";
        }
        if (type == 1)
        {
            gameObject.GetComponent<Renderer>().sharedMaterial = longer;
            gameObject.name = "longer";
        }
        if (type == 2)
        {
            gameObject.GetComponent<Renderer>().sharedMaterial = brake;
            gameObject.name = "brake";
        }

    }
}
