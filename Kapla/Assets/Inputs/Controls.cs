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
                    ""expectedControlType"": ""Button"",
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
                    ""name"": ""ValidateChoice"",
                    ""type"": ""Button"",
                    ""id"": ""8f4fe5ce-046c-4f35-b548-bd248a794ef5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
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
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""e1db491a-9358-457d-84bc-7e1d8af7b350"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""UpTrigger"",
                    ""type"": ""Value"",
                    ""id"": ""fb6082d0-fe0c-47c3-95f5-36babffd07cb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpTriggerRelease"",
                    ""type"": ""Value"",
                    ""id"": ""4a34a6d7-9a85-46ea-8bf9-3b38ada32ec5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""DownTrigger"",
                    ""type"": ""Value"",
                    ""id"": ""9e7b68c5-ccf4-4e21-8a54-7284d637a1d9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DownTriggerRelease"",
                    ""type"": ""Value"",
                    ""id"": ""85541e23-4c86-4743-9bbd-3cfa3df1b627"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""c0ad1aae-f32e-4b10-bd48-8150410108f1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Controls"",
                    ""type"": ""Button"",
                    ""id"": ""03346d33-1609-40bb-88f3-b60994ee7cfc"",
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
                    ""path"": ""<Keyboard>/r"",
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
                    ""path"": ""<Keyboard>/f"",
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
                    ""path"": ""<Keyboard>/c"",
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
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ValidateChoice"",
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
                    ""action"": ""ValidateChoice"",
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
                    ""id"": ""034cabed-fd1c-4e7c-afb0-8a3540b04ef6"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a45820bf-315a-478d-831d-cfaa7e3510dd"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5557813c-652c-49fb-ad2b-5704d8b50d3b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UpTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87fed09c-7036-4c87-8afa-50518116075a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""UpTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a68d9b27-8f5b-4db0-9e7b-1be7a3f92135"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpTriggerRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbc4e219-a28b-47ec-b9d7-251c739a9207"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpTriggerRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d288fe1b-ba9a-4ac9-8874-a0c110e422c2"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DownTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49bfddd9-2f43-411c-9b6d-02fee6c84bd9"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abc06a74-4220-4607-acd5-420be1fc62ef"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownTriggerRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d97c5639-e738-44b8-b39a-e085a3b32208"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownTriggerRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ba2069b-00eb-4dbe-b0eb-aeddc59125e0"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cf437bb-c66d-46b1-bc48-ba31367688cd"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a5e71e7-c860-4ea2-becb-a35b680a2f5c"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Controls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""036820f6-c8a9-463a-8991-52b7be34c512"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Controls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""2292cabb-eaf2-47b7-aae3-2e24e44ee921"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""a9b14026-d089-4bd5-bd7d-73e02d0a3f83"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""395b7287-06af-4e7a-b922-5b92326b7afa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""df6a4127-223e-4668-8bb6-246555f61e9c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c13442ea-5916-4e59-83b0-7e0d571b6811"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0b4deeb9-6cc0-48b5-837a-9135e331e329"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""719f4a4e-e6a1-4516-b33f-aa641ae86e1e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""192aa43d-19e0-4d83-ba82-8d1db18c14a1"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""99ea4df8-fef1-4575-971c-ba5ca9ecbc9f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a2ed3acd-f88b-40da-ab97-87b7acf5cb2b"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""81ff3fcd-8d56-4e6a-b162-84f6022a8d26"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5dae42c4-7905-440e-b466-64f5f1eacac5"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1bb4de61-957a-458a-beec-7f1d50312376"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""b4c0d68e-6712-4c78-9a4b-18efca2630f3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""083ade24-d049-4b01-8b41-13951f3e51e6"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick;Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""213ed2a3-671f-451b-9c20-99ffae1b3f06"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick;Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""412884f7-66d1-4f34-a775-7af3b87329dd"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick;Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a8998e9c-9501-4bb1-bb4d-e7722911f1eb"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick;Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""646ce649-3565-438f-afe4-10e38e59c8ac"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""87ede09e-3d3b-4839-ba5b-3e506846a6df"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d7711864-671d-45a6-a65b-14b4b6257b63"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""557faf09-95af-42b1-8af9-beb89954e9ed"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2f98a6d3-a0d5-4966-921a-518c75532d9b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""72e15c26-63bc-4108-8a01-2a96b1e7fcd8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d6fd904c-0d8d-4438-abbd-1e9d72e01488"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4177baa8-3136-496c-8e43-c8cf99260160"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""28d03c5e-e924-4d1d-a92f-c6fc9ce862e5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b962bc6a-41e5-41f7-80c8-64c10220d905"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3905b5d-4147-4d81-aea9-420ab7f02864"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Submit"",
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
        m_Gameplay_ValidateChoice = m_Gameplay.FindAction("ValidateChoice", throwIfNotFound: true);
        m_Gameplay_CameraMovementMouse = m_Gameplay.FindAction("CameraMovementMouse", throwIfNotFound: true);
        m_Gameplay_Restart = m_Gameplay.FindAction("Restart", throwIfNotFound: true);
        m_Gameplay_UpTrigger = m_Gameplay.FindAction("UpTrigger", throwIfNotFound: true);
        m_Gameplay_UpTriggerRelease = m_Gameplay.FindAction("UpTriggerRelease", throwIfNotFound: true);
        m_Gameplay_DownTrigger = m_Gameplay.FindAction("DownTrigger", throwIfNotFound: true);
        m_Gameplay_DownTriggerRelease = m_Gameplay.FindAction("DownTriggerRelease", throwIfNotFound: true);
        m_Gameplay_Back = m_Gameplay.FindAction("Back", throwIfNotFound: true);
        m_Gameplay_Controls = m_Gameplay.FindAction("Controls", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_ValidateChoice;
    private readonly InputAction m_Gameplay_CameraMovementMouse;
    private readonly InputAction m_Gameplay_Restart;
    private readonly InputAction m_Gameplay_UpTrigger;
    private readonly InputAction m_Gameplay_UpTriggerRelease;
    private readonly InputAction m_Gameplay_DownTrigger;
    private readonly InputAction m_Gameplay_DownTriggerRelease;
    private readonly InputAction m_Gameplay_Back;
    private readonly InputAction m_Gameplay_Controls;
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
        public InputAction @ValidateChoice => m_Wrapper.m_Gameplay_ValidateChoice;
        public InputAction @CameraMovementMouse => m_Wrapper.m_Gameplay_CameraMovementMouse;
        public InputAction @Restart => m_Wrapper.m_Gameplay_Restart;
        public InputAction @UpTrigger => m_Wrapper.m_Gameplay_UpTrigger;
        public InputAction @UpTriggerRelease => m_Wrapper.m_Gameplay_UpTriggerRelease;
        public InputAction @DownTrigger => m_Wrapper.m_Gameplay_DownTrigger;
        public InputAction @DownTriggerRelease => m_Wrapper.m_Gameplay_DownTriggerRelease;
        public InputAction @Back => m_Wrapper.m_Gameplay_Back;
        public InputAction @Controls => m_Wrapper.m_Gameplay_Controls;
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
                @ValidateChoice.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnValidateChoice;
                @ValidateChoice.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnValidateChoice;
                @ValidateChoice.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnValidateChoice;
                @CameraMovementMouse.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMovementMouse;
                @CameraMovementMouse.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMovementMouse;
                @CameraMovementMouse.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraMovementMouse;
                @Restart.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestart;
                @UpTrigger.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUpTrigger;
                @UpTrigger.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUpTrigger;
                @UpTrigger.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUpTrigger;
                @UpTriggerRelease.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUpTriggerRelease;
                @UpTriggerRelease.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUpTriggerRelease;
                @UpTriggerRelease.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUpTriggerRelease;
                @DownTrigger.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDownTrigger;
                @DownTrigger.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDownTrigger;
                @DownTrigger.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDownTrigger;
                @DownTriggerRelease.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDownTriggerRelease;
                @DownTriggerRelease.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDownTriggerRelease;
                @DownTriggerRelease.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDownTriggerRelease;
                @Back.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBack;
                @Controls.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnControls;
                @Controls.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnControls;
                @Controls.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnControls;
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
                @ValidateChoice.started += instance.OnValidateChoice;
                @ValidateChoice.performed += instance.OnValidateChoice;
                @ValidateChoice.canceled += instance.OnValidateChoice;
                @CameraMovementMouse.started += instance.OnCameraMovementMouse;
                @CameraMovementMouse.performed += instance.OnCameraMovementMouse;
                @CameraMovementMouse.canceled += instance.OnCameraMovementMouse;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @UpTrigger.started += instance.OnUpTrigger;
                @UpTrigger.performed += instance.OnUpTrigger;
                @UpTrigger.canceled += instance.OnUpTrigger;
                @UpTriggerRelease.started += instance.OnUpTriggerRelease;
                @UpTriggerRelease.performed += instance.OnUpTriggerRelease;
                @UpTriggerRelease.canceled += instance.OnUpTriggerRelease;
                @DownTrigger.started += instance.OnDownTrigger;
                @DownTrigger.performed += instance.OnDownTrigger;
                @DownTrigger.canceled += instance.OnDownTrigger;
                @DownTriggerRelease.started += instance.OnDownTriggerRelease;
                @DownTriggerRelease.performed += instance.OnDownTriggerRelease;
                @DownTriggerRelease.canceled += instance.OnDownTriggerRelease;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Controls.started += instance.OnControls;
                @Controls.performed += instance.OnControls;
                @Controls.canceled += instance.OnControls;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
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
        void OnValidateChoice(InputAction.CallbackContext context);
        void OnCameraMovementMouse(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnUpTrigger(InputAction.CallbackContext context);
        void OnUpTriggerRelease(InputAction.CallbackContext context);
        void OnDownTrigger(InputAction.CallbackContext context);
        void OnDownTriggerRelease(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnControls(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
    }
}
