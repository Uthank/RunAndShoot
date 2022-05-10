// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""fec58f94-72b1-4738-aaf8-5fb675234b00"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""63fc369c-371f-4614-9210-1417319afa7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fb5031ee-5912-4adc-8743-992189276738"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""FinishZone"",
            ""id"": ""28724479-fa23-4004-ac6a-851d9d04a4d0"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""662bfb43-bcda-493b-b1b4-c6469e74cf24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""301cfa7a-5de5-4fae-ae26-4d773a11a32c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Touch = m_Player.FindAction("Touch", throwIfNotFound: true);
        // FinishZone
        m_FinishZone = asset.FindActionMap("FinishZone", throwIfNotFound: true);
        m_FinishZone_Click = m_FinishZone.FindAction("Click", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Touch;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_Player_Touch;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Touch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // FinishZone
    private readonly InputActionMap m_FinishZone;
    private IFinishZoneActions m_FinishZoneActionsCallbackInterface;
    private readonly InputAction m_FinishZone_Click;
    public struct FinishZoneActions
    {
        private @PlayerInput m_Wrapper;
        public FinishZoneActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_FinishZone_Click;
        public InputActionMap Get() { return m_Wrapper.m_FinishZone; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FinishZoneActions set) { return set.Get(); }
        public void SetCallbacks(IFinishZoneActions instance)
        {
            if (m_Wrapper.m_FinishZoneActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_FinishZoneActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_FinishZoneActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_FinishZoneActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_FinishZoneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public FinishZoneActions @FinishZone => new FinishZoneActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnTouch(InputAction.CallbackContext context);
    }
    public interface IFinishZoneActions
    {
        void OnClick(InputAction.CallbackContext context);
    }
}
