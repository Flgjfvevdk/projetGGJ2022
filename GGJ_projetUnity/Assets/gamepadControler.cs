//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/gamepadControler.inputactions
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

public partial class @GamepadControler : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GamepadControler()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""gamepadControler"",
    ""maps"": [
        {
            ""name"": ""gamecontroler"",
            ""id"": ""2899e82f-18b9-41df-818f-48ac85a989a3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d38a9421-9906-431c-af34-ab39ce3f82e3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9c032f41-9227-4281-9b99-8bc0ccbd35ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShootRight"",
                    ""type"": ""Button"",
                    ""id"": ""b07dd39e-7210-4266-b310-e83d18519ef8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShootLeft"",
                    ""type"": ""Button"",
                    ""id"": ""c53c95f4-7555-478f-be16-24095d23734f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Grappin"",
                    ""type"": ""Button"",
                    ""id"": ""980cceae-1fc2-40a4-b972-d18a89b8178f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Bombe"",
                    ""type"": ""Button"",
                    ""id"": ""b6a8984d-44e3-4848-94c0-8ccd2390792b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Blink"",
                    ""type"": ""Button"",
                    ""id"": ""5ae08a9d-1abd-419a-ab09-fcdfd62671bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BlinkStick"",
                    ""type"": ""Value"",
                    ""id"": ""5d127f50-8a49-46fe-b4fc-f7060b7db868"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""54a1c2a2-0a8d-4a6d-9394-76996f8dc684"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""675ab9e7-2358-448a-989c-8e46cdc26217"",
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
                    ""id"": ""9e8b2163-d0cb-450a-999c-44b6f1dd6437"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a6c819f-024d-462c-81a9-eb78933e39b3"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9bd805a-6306-4f05-946f-1386ab239479"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grappin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16babeb3-f3bc-4d5f-b249-8fa42704edea"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bombe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ea7f77e-07b8-4831-80ae-c6ae5221161b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Blink"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""168c6beb-1fbb-4fd9-8ffb-2ab9eed9287f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BlinkStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ClavierSouris"",
            ""id"": ""5a2b26ca-04fa-4b02-96ef-f4ab1a32ec3a"",
            ""actions"": [
                {
                    ""name"": ""q"",
                    ""type"": ""Button"",
                    ""id"": ""9beaf169-0040-4aa9-a070-916d6eae5f34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""d"",
                    ""type"": ""Button"",
                    ""id"": ""de82e57a-f28c-4901-b9a3-aa7115ec5f5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""s"",
                    ""type"": ""Button"",
                    ""id"": ""66f75ab3-7c7f-4474-a794-121271cc794e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c9cae774-90d4-4851-b97f-cf6d9c56178f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FoudrePouvoir"",
                    ""type"": ""Button"",
                    ""id"": ""b1207483-db62-48cc-8208-c574ac31d61a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BdFPouvoir"",
                    ""type"": ""Button"",
                    ""id"": ""08268951-9453-4ec2-a3f2-7d234e8febcf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CacPouvoir"",
                    ""type"": ""Button"",
                    ""id"": ""36e4aec0-1b98-4288-9ad0-7e5f5e5b8365"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c69832f1-f30d-42be-93c8-98cdd1212ccb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""q"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db4fac65-5f54-4531-a514-7a571cb58541"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""q"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5046d0d-9c40-4060-a924-72b5d515c44a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""d"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d8366ca-19fe-4ddf-b578-b0e4ff9bf487"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""d"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02ceed59-14e9-4fd2-98c2-35946bbf122e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4683e131-f527-46f0-8f0b-a8eb2f72c405"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BdFPouvoir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb3e7be4-1ff3-4ae4-86f3-ccec740a868e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""s"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ba5976e-1c7a-414d-8b8d-edb223dd4117"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""s"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10dff2dd-50fd-4f3a-9b58-e155a6d98714"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FoudrePouvoir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c1f4595-999b-4bb7-b417-6ee7dc392bce"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CacPouvoir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // gamecontroler
        m_gamecontroler = asset.FindActionMap("gamecontroler", throwIfNotFound: true);
        m_gamecontroler_Move = m_gamecontroler.FindAction("Move", throwIfNotFound: true);
        m_gamecontroler_Jump = m_gamecontroler.FindAction("Jump", throwIfNotFound: true);
        m_gamecontroler_ShootRight = m_gamecontroler.FindAction("ShootRight", throwIfNotFound: true);
        m_gamecontroler_ShootLeft = m_gamecontroler.FindAction("ShootLeft", throwIfNotFound: true);
        m_gamecontroler_Grappin = m_gamecontroler.FindAction("Grappin", throwIfNotFound: true);
        m_gamecontroler_Bombe = m_gamecontroler.FindAction("Bombe", throwIfNotFound: true);
        m_gamecontroler_Blink = m_gamecontroler.FindAction("Blink", throwIfNotFound: true);
        m_gamecontroler_BlinkStick = m_gamecontroler.FindAction("BlinkStick", throwIfNotFound: true);
        // ClavierSouris
        m_ClavierSouris = asset.FindActionMap("ClavierSouris", throwIfNotFound: true);
        m_ClavierSouris_q = m_ClavierSouris.FindAction("q", throwIfNotFound: true);
        m_ClavierSouris_d = m_ClavierSouris.FindAction("d", throwIfNotFound: true);
        m_ClavierSouris_s = m_ClavierSouris.FindAction("s", throwIfNotFound: true);
        m_ClavierSouris_Jump = m_ClavierSouris.FindAction("Jump", throwIfNotFound: true);
        m_ClavierSouris_FoudrePouvoir = m_ClavierSouris.FindAction("FoudrePouvoir", throwIfNotFound: true);
        m_ClavierSouris_BdFPouvoir = m_ClavierSouris.FindAction("BdFPouvoir", throwIfNotFound: true);
        m_ClavierSouris_CacPouvoir = m_ClavierSouris.FindAction("CacPouvoir", throwIfNotFound: true);
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

    // gamecontroler
    private readonly InputActionMap m_gamecontroler;
    private IGamecontrolerActions m_GamecontrolerActionsCallbackInterface;
    private readonly InputAction m_gamecontroler_Move;
    private readonly InputAction m_gamecontroler_Jump;
    private readonly InputAction m_gamecontroler_ShootRight;
    private readonly InputAction m_gamecontroler_ShootLeft;
    private readonly InputAction m_gamecontroler_Grappin;
    private readonly InputAction m_gamecontroler_Bombe;
    private readonly InputAction m_gamecontroler_Blink;
    private readonly InputAction m_gamecontroler_BlinkStick;
    public struct GamecontrolerActions
    {
        private @GamepadControler m_Wrapper;
        public GamecontrolerActions(@GamepadControler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_gamecontroler_Move;
        public InputAction @Jump => m_Wrapper.m_gamecontroler_Jump;
        public InputAction @ShootRight => m_Wrapper.m_gamecontroler_ShootRight;
        public InputAction @ShootLeft => m_Wrapper.m_gamecontroler_ShootLeft;
        public InputAction @Grappin => m_Wrapper.m_gamecontroler_Grappin;
        public InputAction @Bombe => m_Wrapper.m_gamecontroler_Bombe;
        public InputAction @Blink => m_Wrapper.m_gamecontroler_Blink;
        public InputAction @BlinkStick => m_Wrapper.m_gamecontroler_BlinkStick;
        public InputActionMap Get() { return m_Wrapper.m_gamecontroler; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamecontrolerActions set) { return set.Get(); }
        public void SetCallbacks(IGamecontrolerActions instance)
        {
            if (m_Wrapper.m_GamecontrolerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnJump;
                @ShootRight.started -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnShootRight;
                @ShootRight.performed -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnShootRight;
                @ShootRight.canceled -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnShootRight;
                @ShootLeft.started -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnShootLeft;
                @ShootLeft.performed -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnShootLeft;
                @ShootLeft.canceled -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnShootLeft;
                @Grappin.started -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnGrappin;
                @Grappin.performed -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnGrappin;
                @Grappin.canceled -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnGrappin;
                @Bombe.started -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnBombe;
                @Bombe.performed -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnBombe;
                @Bombe.canceled -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnBombe;
                @Blink.started -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnBlink;
                @Blink.performed -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnBlink;
                @Blink.canceled -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnBlink;
                @BlinkStick.started -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnBlinkStick;
                @BlinkStick.performed -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnBlinkStick;
                @BlinkStick.canceled -= m_Wrapper.m_GamecontrolerActionsCallbackInterface.OnBlinkStick;
            }
            m_Wrapper.m_GamecontrolerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ShootRight.started += instance.OnShootRight;
                @ShootRight.performed += instance.OnShootRight;
                @ShootRight.canceled += instance.OnShootRight;
                @ShootLeft.started += instance.OnShootLeft;
                @ShootLeft.performed += instance.OnShootLeft;
                @ShootLeft.canceled += instance.OnShootLeft;
                @Grappin.started += instance.OnGrappin;
                @Grappin.performed += instance.OnGrappin;
                @Grappin.canceled += instance.OnGrappin;
                @Bombe.started += instance.OnBombe;
                @Bombe.performed += instance.OnBombe;
                @Bombe.canceled += instance.OnBombe;
                @Blink.started += instance.OnBlink;
                @Blink.performed += instance.OnBlink;
                @Blink.canceled += instance.OnBlink;
                @BlinkStick.started += instance.OnBlinkStick;
                @BlinkStick.performed += instance.OnBlinkStick;
                @BlinkStick.canceled += instance.OnBlinkStick;
            }
        }
    }
    public GamecontrolerActions @gamecontroler => new GamecontrolerActions(this);

    // ClavierSouris
    private readonly InputActionMap m_ClavierSouris;
    private IClavierSourisActions m_ClavierSourisActionsCallbackInterface;
    private readonly InputAction m_ClavierSouris_q;
    private readonly InputAction m_ClavierSouris_d;
    private readonly InputAction m_ClavierSouris_s;
    private readonly InputAction m_ClavierSouris_Jump;
    private readonly InputAction m_ClavierSouris_FoudrePouvoir;
    private readonly InputAction m_ClavierSouris_BdFPouvoir;
    private readonly InputAction m_ClavierSouris_CacPouvoir;
    public struct ClavierSourisActions
    {
        private @GamepadControler m_Wrapper;
        public ClavierSourisActions(@GamepadControler wrapper) { m_Wrapper = wrapper; }
        public InputAction @q => m_Wrapper.m_ClavierSouris_q;
        public InputAction @d => m_Wrapper.m_ClavierSouris_d;
        public InputAction @s => m_Wrapper.m_ClavierSouris_s;
        public InputAction @Jump => m_Wrapper.m_ClavierSouris_Jump;
        public InputAction @FoudrePouvoir => m_Wrapper.m_ClavierSouris_FoudrePouvoir;
        public InputAction @BdFPouvoir => m_Wrapper.m_ClavierSouris_BdFPouvoir;
        public InputAction @CacPouvoir => m_Wrapper.m_ClavierSouris_CacPouvoir;
        public InputActionMap Get() { return m_Wrapper.m_ClavierSouris; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ClavierSourisActions set) { return set.Get(); }
        public void SetCallbacks(IClavierSourisActions instance)
        {
            if (m_Wrapper.m_ClavierSourisActionsCallbackInterface != null)
            {
                @q.started -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnQ;
                @q.performed -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnQ;
                @q.canceled -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnQ;
                @d.started -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnD;
                @d.performed -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnD;
                @d.canceled -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnD;
                @s.started -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnS;
                @s.performed -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnS;
                @s.canceled -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnS;
                @Jump.started -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnJump;
                @FoudrePouvoir.started -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnFoudrePouvoir;
                @FoudrePouvoir.performed -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnFoudrePouvoir;
                @FoudrePouvoir.canceled -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnFoudrePouvoir;
                @BdFPouvoir.started -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnBdFPouvoir;
                @BdFPouvoir.performed -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnBdFPouvoir;
                @BdFPouvoir.canceled -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnBdFPouvoir;
                @CacPouvoir.started -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnCacPouvoir;
                @CacPouvoir.performed -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnCacPouvoir;
                @CacPouvoir.canceled -= m_Wrapper.m_ClavierSourisActionsCallbackInterface.OnCacPouvoir;
            }
            m_Wrapper.m_ClavierSourisActionsCallbackInterface = instance;
            if (instance != null)
            {
                @q.started += instance.OnQ;
                @q.performed += instance.OnQ;
                @q.canceled += instance.OnQ;
                @d.started += instance.OnD;
                @d.performed += instance.OnD;
                @d.canceled += instance.OnD;
                @s.started += instance.OnS;
                @s.performed += instance.OnS;
                @s.canceled += instance.OnS;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @FoudrePouvoir.started += instance.OnFoudrePouvoir;
                @FoudrePouvoir.performed += instance.OnFoudrePouvoir;
                @FoudrePouvoir.canceled += instance.OnFoudrePouvoir;
                @BdFPouvoir.started += instance.OnBdFPouvoir;
                @BdFPouvoir.performed += instance.OnBdFPouvoir;
                @BdFPouvoir.canceled += instance.OnBdFPouvoir;
                @CacPouvoir.started += instance.OnCacPouvoir;
                @CacPouvoir.performed += instance.OnCacPouvoir;
                @CacPouvoir.canceled += instance.OnCacPouvoir;
            }
        }
    }
    public ClavierSourisActions @ClavierSouris => new ClavierSourisActions(this);
    public interface IGamecontrolerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShootRight(InputAction.CallbackContext context);
        void OnShootLeft(InputAction.CallbackContext context);
        void OnGrappin(InputAction.CallbackContext context);
        void OnBombe(InputAction.CallbackContext context);
        void OnBlink(InputAction.CallbackContext context);
        void OnBlinkStick(InputAction.CallbackContext context);
    }
    public interface IClavierSourisActions
    {
        void OnQ(InputAction.CallbackContext context);
        void OnD(InputAction.CallbackContext context);
        void OnS(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFoudrePouvoir(InputAction.CallbackContext context);
        void OnBdFPouvoir(InputAction.CallbackContext context);
        void OnCacPouvoir(InputAction.CallbackContext context);
    }
}
