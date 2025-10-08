using UnityEngine;

public class InputSystemManager : MonoBehaviour
{
    private static InputSystemManager inputSystemManager;
    public static InputSystemManager instance => inputSystemManager;
    private InputSystem_Actions actions;

    private void Awake()
    {
        //ƒVƒ“ƒOƒ‹ƒgƒ“
        if (inputSystemManager != null && inputSystemManager != this)
        {
            Destroy(this.gameObject);
            return;
        }
        inputSystemManager = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetActions();
    }

    /// <summary>
    /// InputSystem‚ğæ“¾‚·‚éŠÖ”
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
