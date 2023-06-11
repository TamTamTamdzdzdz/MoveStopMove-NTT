using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PantsData", order = 1)]
public class PantsData : ScriptableObject

{
    public List<Material> listMaterial;
    public Material GetPantsMat(int ColorId)
    {
        return listMaterial[ColorId];
    }
    //public Material GetPantsMat(ColorType colorType)
    //{
    //    return listMaterial[(int)colorType];
    //}
}
