using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditorManager : MonoBehaviour
{
    public LevelEditorTileGrid Grid;
    public Dropdown EntityDropdown;
    public Toggle UseTextToggle;
    public Image SelectionImage;
    public InputField FileNameInput;
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
        EntityDropdown.onValueChanged.AddListener(OnDropDownChanged);
        OnDropDownChanged(0);
    }

    private void OnDestroy()
    {
        EntityDropdown.onValueChanged.RemoveListener(OnDropDownChanged);
    }

    void OnDropDownChanged(int value)
    {
        EntityType_Data.EntityTypeStructure dataChosen = null;

        foreach(EntityType_Data.EntityTypeStructure data in EntityData.EntityTypes)
        {
            if (data.ID == value)
            {
                dataChosen = data;
            }
        }

        if (dataChosen != null)
        {
            switch (dataChosen.ObjectType)
            {
                case EntityType_Data.EntityObjectType.INCLUDE_TEXT:
                    UseTextToggle.enabled = true;
                    break;
                case EntityType_Data.EntityObjectType.NO_TEXT:
                    UseTextToggle.enabled = false;
                    UseTextToggle.isOn = false;
                    break;
                case EntityType_Data.EntityObjectType.TEXT_ONLY:
                    UseTextToggle.enabled = false;
                    UseTextToggle.isOn = true;
                    break;
            }
        }
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
                LevelEditorTile tile = hit.collider.GetComponent<LevelEditorTile>();
                if (tile)
                {
                    HandleHit(tile);
                }
            }
        }
    }

    void HandleHit(LevelEditorTile tile)
    {
        if (UseTextToggle.isOn)
        {
            tile.SetText(EntityDropdown.options[EntityDropdown.value].text, EntityDropdown.value);
        }
        else
        {
            tile.SetSprite(EntityDropdown.options[EntityDropdown.value].image, EntityDropdown.value);
        }
    }

    public void ExportLevel()
    {
        string filename = FileNameInput.text;
        string path = Application.persistentDataPath + "/Levels/";
        Directory.CreateDirectory(path);

        path += filename + ".level";

        List<string> levelData = new List<string>();

        foreach(LevelEditorTile tile in Grid.TileGridList)
        {
            levelData.Add(tile.GetExportString());
        }

        File.WriteAllLines(path, levelData);
        Debug.Log("exported " + path);
    }
}
