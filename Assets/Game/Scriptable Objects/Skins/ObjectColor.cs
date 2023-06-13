using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColor : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] SkinData skinData;
    
    // Start is called before the first frame update
   
    public void ChangeColor(int colorId)
    {
        
        skinnedMeshRenderer.material=skinData.GetSkinMat(colorId);
    }
}
