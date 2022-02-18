// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/UserInput/New Input/DragSelect/DragSelectKeybinds.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DragSelectKeybinds : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DragSelectKeybinds()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DragSelectKeybinds"",
    ""maps"": [
        {
            ""name"": ""DragSelect"",
            ""id"": ""64dafe96-c872-45e2-90fb-0385bfd9c080"",
            ""actions"": [
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""f22d9320-5c98-42b9-b334-b580282ecdf5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Group Select"",
                    ""type"": ""Button"",
                    ""id"": ""4c13b94b-5b82-4cf6-a5eb-199f801d8473"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Position"",
                    ""type"": ""Value"",
                    ""id"": ""efa11db2-eaa7-4a38-adc8-6ea45fde6e6d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d6cc2977-1d33-4149-9933-063d6f00ccfe"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41451452-9131-4df3-ac7b-b54c01b658da"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Group Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53dd964a-c66f-475e-b150-73de9ddcdeaa"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // DragSelect
        m_DragSelect = asset.FindActionMap("DragSelect", throwIfNotFound: true);
        m_DragSelect_Drag = m_DragSelect.FindAction("Drag", throwIfNotFound: true);
        m_DragSelect_GroupSelect = m_DragSelect.FindAction("Group Select", throwIfNotFound: true);
        m_DragSelect_MousePosition = m_DragSelect.FindAction("Mouse Position", throwIfNotFound: true);
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

    // DragSelect
    private readonly InputActionMap m_DragSelect;
    private IDragSelectActions m_DragSelectActionsCallbackInterface;
    private readonly InputAction m_DragSelect_Drag;
    private readonly InputAction m_DragSelect_GroupSelect;
    private readonly InputAction m_DragSelect_MousePosition;
    public struct DragSelectActions
    {
        private @DragSelectKeybinds m_Wrapper;
        public DragSelectActions(@DragSelectKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @Drag => m_Wrapper.m_DragSelect_Drag;
        public InputAction @GroupSelect => m_Wrapper.m_DragSelect_GroupSelect;
        public InputAction @MousePosition => m_Wrapper.m_DragSelect_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_DragSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DragSelectActions set) { return set.Get(); }
        public void SetCallbacks(IDragSelectActions instance)
        {
            if (m_Wrapper.m_DragSelectActionsCallbackInterface != null)
            {
                @Drag.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnDrag;
                @GroupSelect.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnGroupSelect;
                @GroupSelect.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnGroupSelect;
                @GroupSelect.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnGroupSelect;
                @MousePosition.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_DragSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
                @GroupSelect.started += instance.OnGroupSelect;
                @GroupSelect.performed += instance.OnGroupSelect;
                @GroupSelect.canceled += instance.OnGroupSelect;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public DragSelectActions @DragSelect => new DragSelectActions(this);
    public interface IDragSelectActions
    {
        void OnDrag(InputAction.CallbackContext context);
        void OnGroupSelect(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
