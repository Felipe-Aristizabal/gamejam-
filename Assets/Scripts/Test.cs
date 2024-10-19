using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public  Texture aTexture;
    
    public GameObject aObject;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = aObject.GetComponent<Renderer>();

        if (renderer == null || renderer.materials.Length == 0)
        {
            Debug.LogError("Renderer or materials are missing.");
            return;
        }

        Material[] mat = renderer.materials;

        foreach (Material material in mat)
        {
            if (material.mainTexture != null) 
            {
                Debug.Log(material.mainTexture.name);
                if (material.mainTexture.name == "color-palette-2")
                {
                    material.SetTexture("_BaseMap", aTexture);
                }
            }
            else
            {
                Debug.LogWarning("Material found with no main texture.");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
