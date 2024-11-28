using _Project.Data;
using JamBootstrap.jam_bootstrap.Runtime;
using UnityEngine;

public class ServicedMain : AbstractServicedMain
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InstantiateAutoSaveSystem()
    {
        InstantiateAutoSaveSystem<ServicedMain>();
    }

    protected override void Awake()
    {
        base.Awake();

        G.state = SaveSystem.Load();
        G.fader = gameObject.AddComponent<ScreenFader>();

        new ProgressionImporter().ImportLevelProgressionData();
    }
}