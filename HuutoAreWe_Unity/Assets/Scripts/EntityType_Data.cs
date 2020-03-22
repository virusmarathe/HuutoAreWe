using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityTypes", menuName = "ScriptableObjects/EntityTypes", order = 1)]
public class EntityType_Data : ScriptableObject
{
    public enum EntityObjectType
    {
        NO_TEXT,
        INCLUDE_TEXT,
        TEXT_ONLY
    }

    [System.Serializable]
    public class EntityTypeStructure
    {
        public string Name;
        public int ID;
        public Sprite DefaultSprite;
        public EntityObjectType ObjectType;
    }

    public List<EntityTypeStructure> EntityTypes = new List<EntityTypeStructure>();
}
