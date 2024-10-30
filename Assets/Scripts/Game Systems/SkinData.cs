using UnityEngine;

[CreateAssetMenu(fileName = "SkinData", menuName = "Game/SkinData")]
public class SkinData : ScriptableObject
{
    public string skinName;
    public int rarity;
    public int id;
    public bool unlocked;
    public Material[] materials;
}
