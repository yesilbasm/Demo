using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    private Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    private void OnEnable() 
    {
        EventManager.OnPathNewCreated.AddListener(SetMaterialColor);       
    }

    private void OnDisable() 
    {
        EventManager.OnPathNewCreated.RemoveListener(SetMaterialColor);
    }

    private void SetMaterialColor()
    {
        material.color = new Color( material.color.r, material.color.g , material.color.b
        ,255);
        
        ToOpaqueMode(material);
    }
     public  void ToOpaqueMode( Material material)
    {
        material.SetOverrideTag("RenderType", "");
        material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.One);
        material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.Zero);
        material.SetInt("_ZWrite", 1);
        material.DisableKeyword("_ALPHATEST_ON");
        material.DisableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = -1;
    }
}
