using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character")]
public class Character : ScriptableObject
{
    [Header("Character")] public GameObject player;

    [Header("Name")] public string Name;

    [Header("Specifications")]
    public int Strength;
    public int Agility;
    public int Intelligence;
}
