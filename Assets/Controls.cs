//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""b9892b9a-3e25-41ae-aed6-ed857d9c6bfc"",
            ""actions"": [
                {
                    ""name"": ""Movement1"",
                    ""type"": ""Value"",
                    ""id"": ""c30a63b3-5ec2-485b-ad2f-b084ca20d468"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump1"",
                    ""type"": ""Button"",
                    ""id"": ""4013cf6a-0c2a-4d9d-8071-52a2bbc95e1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability0_1"",
                    ""type"": ""Button"",
                    ""id"": ""3faa5091-a9b5-4de6-9bfe-4b4defdf4460"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability1_1"",
                    ""type"": ""Button"",
                    ""id"": ""1ebddc6f-6211-4691-adce-a59827a8ea78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability2_1"",
                    ""type"": ""Button"",
                    ""id"": ""fce4fbb8-a91f-439f-8157-2cc68e72721a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement2"",
                    ""type"": ""Value"",
                    ""id"": ""3734ea4f-bef2-4757-a262-1d78278d5b54"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump2"",
                    ""type"": ""Button"",
                    ""id"": ""e5096631-387d-40b9-8384-afaed184817f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability1_2"",
                    ""type"": ""Button"",
                    ""id"": ""59bfc0ee-3eaf-436f-88c8-4db0e1607937"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""85090b85-9f3a-493c-a2bb-01b6b6a55797"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2DVector1"",
                    ""id"": ""aa6850ee-2f48-404c-b733-67f8ae130390"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement1"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0f36c6c4-81c6-4739-9791-a834ea5454f0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bc09f213-fe90-4bf0-b2c9-dd894348d481"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2DVector2"",
                    ""id"": ""fcea9611-af8b-4693-9871-61605dbd5f40"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement2"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""32ee1cad-b8b6-4c52-9716-a04172f59f34"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""070f681b-27b3-44de-8364-af75a832e892"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1ef9f054-f69a-4b69-8066-fedf09209961"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ability1_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79d2465d-51c9-4f4a-b255-6ff23407a540"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ability0_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87228eb4-0b8a-42d7-9007-da301f39477a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bd7cefc-8000-47b0-8a79-81717b23d8b5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73a40c62-4252-43a9-b2f1-9c78b2581815"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d39b3f4e-be56-4290-acba-4fcc8ad67f96"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ability1_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e33c51b-10ca-4d6f-9509-3cf1a1145810"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ability2_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""e2d69543-6df6-43b0-a3cd-204e87cdd5a5"",
            ""actions"": [
                {
                    ""name"": ""Navigation"",
                    ""type"": ""Button"",
                    ""id"": ""2dbe822b-bcf1-43f1-b7ac-19d0ed46517b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3cc79e94-0dec-46ac-a03b-db6d1c11a01f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a451159-ce82-4d8b-8412-d705ee52fbff"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb8bc101-ea53-46a1-b1ab-7cd3b253a0d6"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53ffdc53-9a05-4999-9b7e-204a0ada8f3f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement1 = m_Gameplay.FindAction("Movement1", throwIfNotFound: true);
        m_Gameplay_Jump1 = m_Gameplay.FindAction("Jump1", throwIfNotFound: true);
        m_Gameplay_Ability0_1 = m_Gameplay.FindAction("Ability0_1", throwIfNotFound: true);
        m_Gameplay_Ability1_1 = m_Gameplay.FindAction("Ability1_1", throwIfNotFound: true);
        m_Gameplay_Ability2_1 = m_Gameplay.FindAction("Ability2_1", throwIfNotFound: true);
        m_Gameplay_Movement2 = m_Gameplay.FindAction("Movement2", throwIfNotFound: true);
        m_Gameplay_Jump2 = m_Gameplay.FindAction("Jump2", throwIfNotFound: true);
        m_Gameplay_Ability1_2 = m_Gameplay.FindAction("Ability1_2", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Navigation = m_Menu.FindAction("Navigation", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement1;
    private readonly InputAction m_Gameplay_Jump1;
    private readonly InputAction m_Gameplay_Ability0_1;
    private readonly InputAction m_Gameplay_Ability1_1;
    private readonly InputAction m_Gameplay_Ability2_1;
    private readonly InputAction m_Gameplay_Movement2;
    private readonly InputAction m_Gameplay_Jump2;
    private readonly InputAction m_Gameplay_Ability1_2;
    private readonly InputAction m_Gameplay_Pause;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement1 => m_Wrapper.m_Gameplay_Movement1;
        public InputAction @Jump1 => m_Wrapper.m_Gameplay_Jump1;
        public InputAction @Ability0_1 => m_Wrapper.m_Gameplay_Ability0_1;
        public InputAction @Ability1_1 => m_Wrapper.m_Gameplay_Ability1_1;
        public InputAction @Ability2_1 => m_Wrapper.m_Gameplay_Ability2_1;
        public InputAction @Movement2 => m_Wrapper.m_Gameplay_Movement2;
        public InputAction @Jump2 => m_Wrapper.m_Gameplay_Jump2;
        public InputAction @Ability1_2 => m_Wrapper.m_Gameplay_Ability1_2;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement1;
                @Movement1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement1;
                @Movement1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement1;
                @Jump1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump1;
                @Jump1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump1;
                @Jump1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump1;
                @Ability0_1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility0_1;
                @Ability0_1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility0_1;
                @Ability0_1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility0_1;
                @Ability1_1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility1_1;
                @Ability1_1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility1_1;
                @Ability1_1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility1_1;
                @Ability2_1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility2_1;
                @Ability2_1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility2_1;
                @Ability2_1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility2_1;
                @Movement2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement2;
                @Movement2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement2;
                @Movement2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement2;
                @Jump2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump2;
                @Jump2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump2;
                @Jump2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump2;
                @Ability1_2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility1_2;
                @Ability1_2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility1_2;
                @Ability1_2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbility1_2;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement1.started += instance.OnMovement1;
                @Movement1.performed += instance.OnMovement1;
                @Movement1.canceled += instance.OnMovement1;
                @Jump1.started += instance.OnJump1;
                @Jump1.performed += instance.OnJump1;
                @Jump1.canceled += instance.OnJump1;
                @Ability0_1.started += instance.OnAbility0_1;
                @Ability0_1.performed += instance.OnAbility0_1;
                @Ability0_1.canceled += instance.OnAbility0_1;
                @Ability1_1.started += instance.OnAbility1_1;
                @Ability1_1.performed += instance.OnAbility1_1;
                @Ability1_1.canceled += instance.OnAbility1_1;
                @Ability2_1.started += instance.OnAbility2_1;
                @Ability2_1.performed += instance.OnAbility2_1;
                @Ability2_1.canceled += instance.OnAbility2_1;
                @Movement2.started += instance.OnMovement2;
                @Movement2.performed += instance.OnMovement2;
                @Movement2.canceled += instance.OnMovement2;
                @Jump2.started += instance.OnJump2;
                @Jump2.performed += instance.OnJump2;
                @Jump2.canceled += instance.OnJump2;
                @Ability1_2.started += instance.OnAbility1_2;
                @Ability1_2.performed += instance.OnAbility1_2;
                @Ability1_2.canceled += instance.OnAbility1_2;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Navigation;
    public struct MenuActions
    {
        private @Controls m_Wrapper;
        public MenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigation => m_Wrapper.m_Menu_Navigation;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Navigation.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigation;
                @Navigation.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigation;
                @Navigation.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNavigation;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigation.started += instance.OnNavigation;
                @Navigation.performed += instance.OnNavigation;
                @Navigation.canceled += instance.OnNavigation;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement1(InputAction.CallbackContext context);
        void OnJump1(InputAction.CallbackContext context);
        void OnAbility0_1(InputAction.CallbackContext context);
        void OnAbility1_1(InputAction.CallbackContext context);
        void OnAbility2_1(InputAction.CallbackContext context);
        void OnMovement2(InputAction.CallbackContext context);
        void OnJump2(InputAction.CallbackContext context);
        void OnAbility1_2(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNavigation(InputAction.CallbackContext context);
    }
}
