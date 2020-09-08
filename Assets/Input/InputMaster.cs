// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""24d94eea-6c98-4e60-94c2-5fdfc656ffec"",
            ""actions"": [
                {
                    ""name"": ""ShootPrimary"",
                    ""type"": ""Button"",
                    ""id"": ""a84bee7e-cd9e-4955-9174-678bed94a258"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6bfdcea6-caf3-47b3-b1c7-563ed0b03495"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""15b67a43-d345-4a08-841b-2c9d0022bcf4"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootSecondary"",
                    ""type"": ""Button"",
                    ""id"": ""af45b7bd-b69f-40e4-afa3-c40a0f9d5ace"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""9bb8c2b0-36f3-4a7c-a2a4-2c61ccae937e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PickUpTurret"",
                    ""type"": ""Button"",
                    ""id"": ""b060fd87-716e-4558-b050-e4f2688509b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""764b7f5d-04c6-4c89-a005-b56f7a7da8cf"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShootPrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""699e9e5e-5042-4a11-bb3d-b95b88bb7d41"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0053f1dc-7aa1-4e40-9787-8274c0e2a191"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8eb37e7a-c4ad-41c3-9b2f-2af911d801e2"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShootSecondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b567332-cb91-40e0-86fb-2699b1a8d107"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e54ece3-150f-4656-a2f2-49c84ec7a2d5"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUpTurret"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<SwitchProControllerHID>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_ShootPrimary = m_Player.FindAction("ShootPrimary", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        m_Player_ShootSecondary = m_Player.FindAction("ShootSecondary", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_PickUpTurret = m_Player.FindAction("PickUpTurret", throwIfNotFound: true);
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
    private readonly InputAction m_Player_ShootPrimary;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Aim;
    private readonly InputAction m_Player_ShootSecondary;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_PickUpTurret;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ShootPrimary => m_Wrapper.m_Player_ShootPrimary;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputAction @ShootSecondary => m_Wrapper.m_Player_ShootSecondary;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @PickUpTurret => m_Wrapper.m_Player_PickUpTurret;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @ShootPrimary.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootPrimary;
                @ShootPrimary.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootPrimary;
                @ShootPrimary.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootPrimary;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @ShootSecondary.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootSecondary;
                @ShootSecondary.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootSecondary;
                @ShootSecondary.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootSecondary;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @PickUpTurret.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUpTurret;
                @PickUpTurret.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUpTurret;
                @PickUpTurret.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUpTurret;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ShootPrimary.started += instance.OnShootPrimary;
                @ShootPrimary.performed += instance.OnShootPrimary;
                @ShootPrimary.canceled += instance.OnShootPrimary;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @ShootSecondary.started += instance.OnShootSecondary;
                @ShootSecondary.performed += instance.OnShootSecondary;
                @ShootSecondary.canceled += instance.OnShootSecondary;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @PickUpTurret.started += instance.OnPickUpTurret;
                @PickUpTurret.performed += instance.OnPickUpTurret;
                @PickUpTurret.canceled += instance.OnPickUpTurret;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnShootPrimary(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShootSecondary(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnPickUpTurret(InputAction.CallbackContext context);
    }
}
