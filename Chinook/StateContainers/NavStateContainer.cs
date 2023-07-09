namespace Chinook.StateContainers;

public class NavStateContainer
{
    public event Action? OnChange;
    public void UpdateNavbar()
    {
        OnChange?.Invoke();
    }
}