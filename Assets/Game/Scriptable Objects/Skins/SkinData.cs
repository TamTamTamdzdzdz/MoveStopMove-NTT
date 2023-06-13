using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SkinData", order = 1)]
public class SkinData : ScriptableObject
{
    public List<Material> listMaterial;
    public Material GetSkinMat(int colorId)
    {
        return listMaterial[(int)colorId];
    }
}
