using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class boxScaler : MonoBehaviour
{
    public Material material;
    [Range(1, 500)]
    public int cubescale;
    private int scalefactor = 4;
    private int iscale = -1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (iscale != cubescale)
        {
            iscale = cubescale;
            transform.localScale = new Vector3(cubescale * 0.1f, cubescale * 0.1f, cubescale * 0.1f);
            material.mainTextureScale = new Vector2(cubescale * scalefactor, cubescale * scalefactor);
            if ((cubescale%2)==0)
            {
                material.mainTextureOffset = new Vector2(0f, 0f);
            }
            else
            {
                material.mainTextureOffset = new Vector2(0.5f, 0f);
            }
        }
    }
}
