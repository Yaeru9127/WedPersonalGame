using UnityEngine;
using UniRx;

public class Player : MonoBehaviour
{
    private InputSystem_Actions action;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InputSystem
        action = InputSystemManager.instance.GetActions();
        InputSystemManager.instance.PlayerOn();

        GameManager.instance.NotifyPause += Shoot;
    }

    private void Shoot(bool isPause)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
