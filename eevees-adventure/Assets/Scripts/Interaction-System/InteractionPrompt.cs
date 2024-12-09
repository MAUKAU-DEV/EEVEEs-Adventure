using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InteractionPrompt
    : MonoBehaviour
{
    [SerializeField] private GameObject _keyboardPrompt;
    [SerializeField] private GameObject _gamepadPrompt;

    private InputController _inputController;

    private void Awake()
    {
        this._inputController = new InputController();

        InputUser.onChange += deviceChange;
    }

    private void OnDisable()
    {
        InputUser.onChange -= deviceChange;
    }

    private void deviceChange(InputUser user, InputUserChange change, InputDevice device)
    {
        if(user.controlScheme == this._inputController.KeyboardScheme)
        {
            this._keyboardPrompt.SetActive(true);
            this._gamepadPrompt.SetActive(false);
        } else
        {
            this._gamepadPrompt.SetActive(true);
            this._keyboardPrompt.SetActive(false);
        }
    }

}
