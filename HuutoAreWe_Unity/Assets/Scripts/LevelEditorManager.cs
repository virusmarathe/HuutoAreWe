using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditorManager : MonoBehaviour
{
    public TileGrid Grid;
    public Dropdown EntityDropdown;
    public EntityType_Data EntityData;

    // Start is called before the first frame update
    void Start()
    {
        List<Dropdown.OptionData> optionsList = new List<Dropdown.OptionData>();
        foreach(EntityType_Data.EntityTypeStructure ed in EntityData.EntityTypes)
        {
            optionsList.Add(new Dropdown.OptionData(ed.Name, ed.DefaultSprite));
        }

        EntityDropdown.AddOptions(optionsList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
