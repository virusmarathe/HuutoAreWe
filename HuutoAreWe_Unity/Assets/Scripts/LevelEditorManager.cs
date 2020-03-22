using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditorManager : MonoBehaviour
{
    public TileGrid Grid;
    public Dropdown EntityDropdown;
    public EntityType_Data EntityData;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

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
        if (Input.GetMouseButton(0))
        {
            Vector2 screenPos = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

            if (hit.collider != null)
            {
                EditorTile tile = hit.collider.GetComponent<EditorTile>();
                if (tile)
                {
                    HandleHit(tile);
                }
            }
        }
    }

    void HandleHit(EditorTile tile)
    {
        tile.SetSprite(EntityDropdown.options[EntityDropdown.value].image);
    }
}
