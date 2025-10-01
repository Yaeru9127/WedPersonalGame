using UnityEngine;

public class InputSystemManager : MonoBehaviour
{
    public static InputSystemManager input {  get; private set; }

    private InputSystem_Actions actions;

    private void Awake()
    {
        if (input == null) input = this;
        else if (input != null) Destroy(this.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetActions();
    }

    /// <summary>
    /// InputSystemÇéÊìæÇ∑ÇÈä÷êî
    /// </summary>
    /// <returns></returns>
    public InputSystem_Actions GetActions()
    {
        if (actions == null) actions = new InputSystem_Actions();

        return actions;
    }

    /// <summary>
    /// UI
    /// </summary>
    public void UIOn()
    {
        actions.UI.Enable();
    }
    public void UIOff()
    {
        actions.UI.Disable();
    }

    /// <summary>
    /// Player
    /// </summary>
    public void PlayerOn()
    {
        actions.Player.Enable();
    }

    public void PlayerOff()
    {
        actions.Player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
