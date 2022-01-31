//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Common/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""a343bbab-b674-425d-9276-cb350b653045"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""dcf0e38d-aaa0-4679-b567-34373bae7012"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""eb0394d3-f21b-4f83-8723-3c06fabf244d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""11d01e9f-203a-4d27-8fb5-b76c97192dc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""b6122bc2-beb3-40de-8ad0-d8610703ee9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""13389e5a-9c4b-4002-ad01-4650411a8f59"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e30964a7-4d76-489a-a229-26f500992bda"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12947df8-648c-45a5-9d1d-a2e79267fa31"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a4971089-dc0a-47c8-8ea0-bd0e6164d6b4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d1d60b8a-6c12-44c2-a432-5ec5c7bd48a5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""422e12f2-1ec6-4171-8d76-f301fcbc840c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""23df8a96-8a65-43be-8cb7-a56797e28d0f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a368b916-0b00-44dd-a0eb-1cfa0a69b263"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""105eab1c-f60c-4e57-a9f1-adcdbc213e34"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuControls"",
            ""id"": ""7c0134c7-30d9-45e8-a0b6-5437823764b6"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""d747b18c-27e0-42e7-bbef-dc45f1a4cfc8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move Right"",
                    ""type"": ""Button"",
                    ""id"": ""9d302f24-9099-49f8-9bc4-c8bd6ec3164a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeColor Left"",
                    ""type"": ""Button"",
                    ""id"": ""573b2dda-4c06-4daf-a9ff-bfaad244883c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeColor Right"",
                    ""type"": ""Button"",
                    ""id"": ""4e99137a-b52c-4a4a-bf9f-44d37fa87259"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ready"",
                    ""type"": ""Button"",
                    ""id"": ""652c4ef3-8eab-49ce-ba9f-54e22ec95ab1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c41e1b12-5529-47a8-b2b5-13aa5b49be2e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3308287b-656f-4c3c-a5a1-a3d89820ba25"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f3ab85f-f913-4029-93c5-9ace380f3227"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeColor Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41de2baa-57b7-437d-99a4-e9026bfa2546"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeColor Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6044206-7e79-42f9-b2e0-d4193c3215b4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Walk = m_Movement.FindAction("Walk", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_Grab = m_Movement.FindAction("Grab", throwIfNotFound: true);
        m_Movement_Special = m_Movement.FindAction("Special", throwIfNotFound: true);
        // MenuControls
        m_MenuControls = asset.FindActionMap("MenuControls", throwIfNotFound: true);
        m_MenuControls_MoveLeft = m_MenuControls.FindAction("MoveLeft", throwIfNotFound: true);
        m_MenuControls_MoveRight = m_MenuControls.FindAction("Move Right", throwIfNotFound: true);
        m_MenuControls_ChangeColorLeft = m_MenuControls.FindAction("ChangeColor Left", throwIfNotFound: true);
        m_MenuControls_ChangeColorRight = m_MenuControls.FindAction("ChangeColor Right", throwIfNotFound: true);
        m_MenuControls_Ready = m_MenuControls.FindAction("Ready", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Walk;
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_Grab;
    private readonly InputAction m_Movement_Special;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Movement_Walk;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @Grab => m_Wrapper.m_Movement_Grab;
        public InputAction @Special => m_Wrapper.m_Movement_Special;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalk;
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Grab.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnGrab;
                @Special.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnSpecial;
                @Special.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnSpecial;
                @Special.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnSpecial;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // MenuControls
    private readonly InputActionMap m_MenuControls;
    private IMenuControlsActions m_MenuControlsActionsCallbackInterface;
    private readonly InputAction m_MenuControls_MoveLeft;
    private readonly InputAction m_MenuControls_MoveRight;
    private readonly InputAction m_MenuControls_ChangeColorLeft;
    private readonly InputAction m_MenuControls_ChangeColorRight;
    private readonly InputAction m_MenuControls_Ready;
    public struct MenuControlsActions
    {
        private @PlayerControls m_Wrapper;
        public MenuControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeft => m_Wrapper.m_MenuControls_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_MenuControls_MoveRight;
        public InputAction @ChangeColorLeft => m_Wrapper.m_MenuControls_ChangeColorLeft;
        public InputAction @ChangeColorRight => m_Wrapper.m_MenuControls_ChangeColorRight;
        public InputAction @Ready => m_Wrapper.m_MenuControls_Ready;
        public InputActionMap Get() { return m_Wrapper.m_MenuControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuControlsActions instance)
        {
            if (m_Wrapper.m_MenuControlsActionsCallbackInterface != null)
            {
                @MoveLeft.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMoveRight;
                @ChangeColorLeft.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnChangeColorLeft;
                @ChangeColorLeft.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnChangeColorLeft;
                @ChangeColorLeft.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnChangeColorLeft;
                @ChangeColorRight.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnChangeColorRight;
                @ChangeColorRight.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnChangeColorRight;
                @ChangeColorRight.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnChangeColorRight;
                @Ready.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnReady;
                @Ready.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnReady;
                @Ready.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnReady;
            }
            m_Wrapper.m_MenuControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @ChangeColorLeft.started += instance.OnChangeColorLeft;
                @ChangeColorLeft.performed += instance.OnChangeColorLeft;
                @ChangeColorLeft.canceled += instance.OnChangeColorLeft;
                @ChangeColorRight.started += instance.OnChangeColorRight;
                @ChangeColorRight.performed += instance.OnChangeColorRight;
                @ChangeColorRight.canceled += instance.OnChangeColorRight;
                @Ready.started += instance.OnReady;
                @Ready.performed += instance.OnReady;
                @Ready.canceled += instance.OnReady;
            }
        }
    }
    public MenuControlsActions @MenuControls => new MenuControlsActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
    }
    public interface IMenuControlsActions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnChangeColorLeft(InputAction.CallbackContext context);
        void OnChangeColorRight(InputAction.CallbackContext context);
        void OnReady(InputAction.CallbackContext context);
    }
}
