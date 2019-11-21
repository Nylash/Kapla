// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""de805c6a-00c1-4275-9721-0bbac9b5d1ba"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a6312910-d4b4-461e-b80f-1a41a0f985ec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMovementPad"",
                    ""type"": ""Value"",
                    ""id"": ""d8ce4c66-2662-4552-9f77-7bd5b84c1601"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraCanMove"",
                    ""type"": ""Value"",
                    ""id"": ""83767779-fdad-453f-ad79-254da2a6c21b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotX"",
                    ""type"": ""Button"",
                    ""id"": ""1f813ec3-10a1-403b-9ef4-c2fce2f10ce7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RotY"",
                    ""type"": ""Button"",
                    ""id"": ""ef542ef2-d91a-4e92-9d21-f099f636960d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RotZ"",
                    ""type"": ""Button"",
                    ""id"": ""e8994ac9-c8b3-4a5a-80f6-92f1531030e4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""b953f9d9-2c0d-4932-be40-4f876bfb1c82"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""8f4fe5ce-046c-4f35-b548-bd248a794ef5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""CameraMovementMouse"",
                    ""type"": ""Button"",
                    ""id"": ""21b49e9d-2bb1-4407-837c-4f5cccc8fea2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""ae8cbdfe-7f72-4aed-a120-616c2077f1fc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Value"",
                    ""id"": ""5bed0e87-5bb6-459c-82f2-77d0db03c083"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchMovementSystem"",
                    ""type"": ""Button"",
                    ""id"": ""e1db491a-9358-457d-84bc-7e1d8af7b350"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b6795b9c-0ff8-4c6a-8b92-af3ab7aaea4b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""29a9089c-c418-4d53-a090-502f8ace3d13"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""72ebc69a-946a-4667-a7e4-f3b532cdd1ca"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c5849451-6732-4096-9eef-cbf63ad63a46"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d7e4226e-e130-4955-8599-fe5f3457e19d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""569fde83-2122-4869-8f8b-f4da07b3c922"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5d384244-5625-413d-852b-b40dedf6feef"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52cc8b3b-73aa-4b44-ba99-5ed900449f6f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraMovementPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93bff233-909b-4bce-bb06-3bc870a28971"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""CameraCanMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e19731b5-1890-4a00-be26-29097a02794a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a69a28d-a0be-4b0a-96ce-d46d77d7a9a4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""RotX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d87aeb3e-920e-46c7-94fc-74f731858875"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7113bc5c-87ad-4fb7-93ff-18c37249f9d8"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""RotY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56b1deee-2726-44c8-ab2c-21dbd0c6de27"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""810e1998-897f-44da-84d3-8d843cf2751e"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""RotZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f4df845-4369-45de-a077-95f12f925ed0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee3f21e6-4c55-4646-92e9-06a479bc20b6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02218a44-7aff-4dbd-b621-bf744d6cede8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""023f7141-f62c-4b3a-ba57-d35ec9cb155f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0223342-9fe8-4089-ae1f-377196c665cb"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""CameraMovementMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f119806-150d-4d18-935e-9d304677bce1"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0ece020-81bb-4c85-8d29-d8eb3dfdcc2f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18b6903b-e0fb-4f3d-be20-20885810bf17"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6480dd4e-e281-4d9e-8cad-2504e1a070d5"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""034cabed-fd1c-4e7c-afb0-8a3540b04ef6"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SwitchMovementSystem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
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
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_CameraMovementPad = m_Gameplay.FindAction("CameraMovementPad", throwIfNotFound: true);
        m_Gameplay_CameraCanMove = m_Gameplay.FindAction("CameraCanMove", throwIfNotFound: true);
        m_Gameplay_RotX = m_Gameplay.FindAction("RotX", throwIfNotFound: true);
        m_Gameplay_RotY = m_Gameplay.FindAction("RotY", throwIfNotFound: true);
        m_Gameplay_RotZ = m_Gameplay.FindAction("RotZ", throwIfNotFound: true);
        m_Gameplay_Drop = m_Gameplay.FindAction("Drop", throwIfNotFound: true);
        m_Gameplay_Restart = m_Gameplay.FindAction("Restart", throwIfNotFound: true);
        m_Gameplay_CameraMovementMouse = m_Gameplay.FindAction("CameraMovementMouse", throwIfNotFound: true);
        m_Gameplay_Down = m_Gameplay.FindAction("Down", throwIfNotFound: true);
        m_Gameplay_Up = m_Gameplay.FindAction("Up", throwIfNotFound: true);
        m_Gameplay_SwitchMovementSystem = m_Gameplay.FindAction("SwitchMovementSystem", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_CameraMovementPad;
    private readonly InputAction m_Gameplay_CameraCanMove;
    private readonly InputAction m_Gameplay_RotX;
    private readonly InputAction m_Gameplay_RotY;
    private readonly InputAction m_Gameplay_RotZ;
    private readonly InputAction m_Gameplay_Drop;
    private readonly InputAction m_Gameplay_Restart;
    private readonly InputAction m_Gameplay_CameraMovementMouse;
    private readonly InputAction m_Gameplay_Down;
    private readonly InputAction m_Gameplay_Up;
    private readonly InputAction m_Gameplay_SwitchMovementSystem;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @CameraMovementPad => m_Wrapper.m_Gameplay_CameraMovementPad;
        public InputAction @CameraCanMove => m_Wrapper.m_Gameplay_CameraCanMove;
        public InputAction @RotX => m_Wrapper.m_Gameplay_RotX;
        public InputAction @RotY => m_Wrapper.m_Gameplay_RotY;
        public InputAction @RotZ => m_Wrapper.m_Gameplay_RotZ;
        public InputAction @Drop => m_Wrapper.m_Gameplay_Drop;
        public InputAction @Restart => m_Wrapper.m_Gameplay_Restart;
        public InputAction @CameraMovementMouse => m_Wrapper.m_Gameplay_CameraMovementMouse;
        public InputAction @Down => m_Wrapper.m_Gameplay_Down;
        public InputAction @Up => m_Wrapper.m_Gameplay_Up;
        public InputAction @SwitchMovementSystem => m_Wrapper.m_Gameplay_SwitchMovementSystem;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @CameraMovementPad.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMovementPad;
                @CameraMovementPad.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMovementPad;
                @CameraMovementPad.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMovementPad;
                @CameraCanMove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraCanMove;
                @CameraCanMove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraCanMove;
                @CameraCanMove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraCanMove;
                @RotX.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotX;
                @RotX.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotX;
                @RotX.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotX;
                @RotY.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotY;
                @RotY.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotY;
                @RotY.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotY;
                @RotZ.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotZ;
                @RotZ.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotZ;
                @RotZ.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotZ;
                @Drop.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Restart.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestart;
                @CameraMovementMouse.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMovementMouse;
                @CameraMovementMouse.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMovementMouse;
                @CameraMovementMouse.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMovementMouse;
                @Down.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Up.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @SwitchMovementSystem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchMovementSystem;
                @SwitchMovementSystem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchMovementSystem;
                @SwitchMovementSystem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchMovementSystem;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @CameraMovementPad.started += instance.OnCameraMovementPad;
                @CameraMovementPad.performed += instance.OnCameraMovementPad;
                @CameraMovementPad.canceled += instance.OnCameraMovementPad;
                @CameraCanMove.started += instance.OnCameraCanMove;
                @CameraCanMove.performed += instance.OnCameraCanMove;
                @CameraCanMove.canceled += instance.OnCameraCanMove;
                @RotX.started += instance.OnRotX;
                @RotX.performed += instance.OnRotX;
                @RotX.canceled += instance.OnRotX;
                @RotY.started += instance.OnRotY;
                @RotY.performed += instance.OnRotY;
                @RotY.canceled += instance.OnRotY;
                @RotZ.started += instance.OnRotZ;
                @RotZ.performed += instance.OnRotZ;
                @RotZ.canceled += instance.OnRotZ;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @CameraMovementMouse.started += instance.OnCameraMovementMouse;
                @CameraMovementMouse.performed += instance.OnCameraMovementMouse;
                @CameraMovementMouse.canceled += instance.OnCameraMovementMouse;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @SwitchMovementSystem.started += instance.OnSwitchMovementSystem;
                @SwitchMovementSystem.performed += instance.OnSwitchMovementSystem;
                @SwitchMovementSystem.canceled += instance.OnSwitchMovementSystem;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCameraMovementPad(InputAction.CallbackContext context);
        void OnCameraCanMove(InputAction.CallbackContext context);
        void OnRotX(InputAction.CallbackContext context);
        void OnRotY(InputAction.CallbackContext context);
        void OnRotZ(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnCameraMovementMouse(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnSwitchMovementSystem(InputAction.CallbackContext context);
    }
}
