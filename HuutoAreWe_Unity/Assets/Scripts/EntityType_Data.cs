using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityTypes", menuName = "ScriptableObjects/EntityTypes", order = 1)]
public class EntityType_Data : ScriptableObject
{
    [System.Serializable]
    public class EntityTypeStructure
    {
        public string Name;
        public int ID;
        public Sprite DefaultSprite;
    }

    public List<EntityTypeStructure> EntityTypes = new List<EntityTypeStructure>();
}
