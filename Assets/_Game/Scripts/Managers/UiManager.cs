using Game.Scripts;

public class UiManager : Singleton<UiManager>
{
    private void Start()
    {
        SRResources.Prefabs.UI.Instantiate();
    }
}