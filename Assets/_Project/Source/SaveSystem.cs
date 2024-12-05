using _Project.Source;
using Newtonsoft.Json;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class SaveSystem
{
    const string SlotId = "saveslot";

    private static JsonSerializerSettings _settings;

    static SaveSystem()
    {
        _settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        _settings.Converters.Add(new CMSEntityConverter());
        _settings.Converters.Add(new Vector2Converter());
        _settings.Converters.Add(new ColorConverter());
    }

    public static GameState Load()
    {
#if UNITY_EDITOR
        if (!LoadExistingSave)
            return new GameState();
#endif
        if (PlayerPrefs.HasKey(SlotId))
        {
            var deserializeObject =
                JsonConvert.DeserializeObject<GameState>(PlayerPrefs.GetString(SlotId, "{}"), _settings);
            return deserializeObject;
        }

        return new GameState();
    }

    public static void Save(GameState state)
    {
        var serializeObject = JsonConvert.SerializeObject(state, _settings);
        PlayerPrefs.SetString(SlotId, serializeObject);
    }

#if UNITY_EDITOR
    [MenuItem("Tools/[Save] Clear Save File")]
    public static void ClearSaveFile()
    {
        PlayerPrefs.DeleteKey(SlotId);
    }
    
    [MenuItem("Tools/[Save] Copy save to clipboard")]
    public static void CopyFile()
    {
        GUIUtility.systemCopyBuffer = PlayerPrefs.GetString(SlotId, "{}");
    }

    private const string MenuName = "Tools/[Save] Load Existing Save";
    private const string SettingName = "CleanSave";

    public static bool LoadExistingSave
    {
        get => EditorPrefs.GetBool(SettingName, true);
        set => EditorPrefs.SetBool(SettingName, value);
    }

    [MenuItem(MenuName)]
    private static void ToggleLoadExistingSave()
    {
        LoadExistingSave = !LoadExistingSave;
    }

    [MenuItem(MenuName, true)]
    private static bool ToggleLoadExistingSaveValidate()
    {
        Menu.SetChecked(MenuName, LoadExistingSave);
        return true;
    }
#endif
}