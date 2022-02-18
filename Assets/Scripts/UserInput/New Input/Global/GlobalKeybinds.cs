// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/UserInput/New Input/Global/GlobalKeybinds.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GlobalKeybinds : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GlobalKeybinds()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GlobalKeybinds"",
    ""maps"": [
        {
            ""name"": ""Global"",
            ""id"": ""96924341-dd47-4ff2-9489-5c06d3da3d23"",
            ""actions"": [
                {
                    ""name"": ""Close"",
                    ""type"": ""Button"",
                    ""id"": ""f2d016b4-19a7-432c-a2b9-d914bb360f05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Control"",
                    ""type"": ""Button"",
                    ""id"": ""e2ca1043-a690-41c3-a34f-b063728dd118"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Alt"",
                    ""type"": ""Button"",
                    ""id"": ""38f95fe9-6c04-4ef6-b036-5cce48eb7bed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shift"",
                    ""type"": ""Button"",
                    ""id"": ""e1837546-dfe1-42cc-a963-47d7618f438f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""375d9496-2fa3-4f72-a70c-421b0cd88153"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f0abe151-4c52-4bfa-b923-5ced156adb51"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8976019b-bf92-42ff-84d7-98ce8b3abf9a"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef54dde4-65b2-44bc-8630-d40e26dfc521"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d32d33e2-3e79-4b26-8eee-87fc7f660db7"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Alt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75b5c566-ac7f-4e95-9dcb-fc5b717289c1"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ac7b0d4-bce5-4367-8ad2-8a6f8d5d95e1"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Global
        m_Global = asset.FindActionMap("Global", throwIfNotFound: true);
        m_Global_Close = m_Global.FindAction("Close", throwIfNotFound: true);
        m_Global_Control = m_Global.FindAction("Control", throwIfNotFound: true);
        m_Global_Alt = m_Global.FindAction("Alt", throwIfNotFound: true);
        m_Global_Shift = m_Global.FindAction("Shift", throwIfNotFound: true);
        m_Global_MousePosition = m_Global.FindAction("MousePosition", throwIfNotFound: true);
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

    // Global
    private readonly InputActionMap m_Global;
    private IGlobalActions m_GlobalActionsCallbackInterface;
    private readonly InputAction m_Global_Close;
    private readonly InputAction m_Global_Control;
    private readonly InputAction m_Global_Alt;
    private readonly InputAction m_Global_Shift;
    private readonly InputAction m_Global_MousePosition;
    public struct GlobalActions
    {
        private @GlobalKeybinds m_Wrapper;
        public GlobalActions(@GlobalKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @Close => m_Wrapper.m_Global_Close;
        public InputAction @Control => m_Wrapper.m_Global_Control;
        public InputAction @Alt => m_Wrapper.m_Global_Alt;
        public InputAction @Shift => m_Wrapper.m_Global_Shift;
        public InputAction @MousePosition => m_Wrapper.m_Global_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Global; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalActions set) { return set.Get(); }
        public void SetCallbacks(IGlobalActions instance)
        {
            if (m_Wrapper.m_GlobalActionsCallbackInterface != null)
            {
                @Close.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnClose;
                @Close.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnClose;
                @Close.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnClose;
                @Control.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnControl;
                @Control.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnControl;
                @Control.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnControl;
                @Alt.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnAlt;
                @Alt.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnAlt;
                @Alt.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnAlt;
                @Shift.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnShift;
                @Shift.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnShift;
                @Shift.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnShift;
                @MousePosition.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_GlobalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Close.started += instance.OnClose;
                @Close.performed += instance.OnClose;
                @Close.canceled += instance.OnClose;
                @Control.started += instance.OnControl;
                @Control.performed += instance.OnControl;
                @Control.canceled += instance.OnControl;
                @Alt.started += instance.OnAlt;
                @Alt.performed += instance.OnAlt;
                @Alt.canceled += instance.OnAlt;
                @Shift.started += instance.OnShift;
                @Shift.performed += instance.OnShift;
                @Shift.canceled += instance.OnShift;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public GlobalActions @Global => new GlobalActions(this);
    public interface IGlobalActions
    {
        void OnClose(InputAction.CallbackContext context);
        void OnControl(InputAction.CallbackContext context);
        void OnAlt(InputAction.CallbackContext context);
        void OnShift(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
