// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Tools/ChainBuilder/New Pathbuilder/ChainbuilderKeybinds.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace NotReaper.Tools.ChainBuilder
{
    public class @ChainbuilderKeybinds : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ChainbuilderKeybinds()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ChainbuilderKeybinds"",
    ""maps"": [
        {
            ""name"": ""Pathbuilder"",
            ""id"": ""cd62ed56-df6b-4ac8-b3ba-7ba9f73fc720"",
            ""actions"": [
                {
                    ""name"": ""SelectTarget"",
                    ""type"": ""Button"",
                    ""id"": ""c5089688-2c93-454f-963d-a8392d6a6786"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SnapAngle"",
                    ""type"": ""Button"",
                    ""id"": ""de60ffa4-a290-4398-98ed-53038df98fed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""fd8b12fb-3334-4527-b63f-46dc093ac20b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""54fa8ae1-6f2b-48d3-a586-a044bc83605c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10fd6f9e-eead-48b2-8cc2-750d77ea1d55"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SnapAngle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0c13960-7509-45c4-898a-8619a52233f2"",
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
            // Pathbuilder
            m_Pathbuilder = asset.FindActionMap("Pathbuilder", throwIfNotFound: true);
            m_Pathbuilder_SelectTarget = m_Pathbuilder.FindAction("SelectTarget", throwIfNotFound: true);
            m_Pathbuilder_SnapAngle = m_Pathbuilder.FindAction("SnapAngle", throwIfNotFound: true);
            m_Pathbuilder_MousePosition = m_Pathbuilder.FindAction("MousePosition", throwIfNotFound: true);
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

        // Pathbuilder
        private readonly InputActionMap m_Pathbuilder;
        private IPathbuilderActions m_PathbuilderActionsCallbackInterface;
        private readonly InputAction m_Pathbuilder_SelectTarget;
        private readonly InputAction m_Pathbuilder_SnapAngle;
        private readonly InputAction m_Pathbuilder_MousePosition;
        public struct PathbuilderActions
        {
            private @ChainbuilderKeybinds m_Wrapper;
            public PathbuilderActions(@ChainbuilderKeybinds wrapper) { m_Wrapper = wrapper; }
            public InputAction @SelectTarget => m_Wrapper.m_Pathbuilder_SelectTarget;
            public InputAction @SnapAngle => m_Wrapper.m_Pathbuilder_SnapAngle;
            public InputAction @MousePosition => m_Wrapper.m_Pathbuilder_MousePosition;
            public InputActionMap Get() { return m_Wrapper.m_Pathbuilder; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PathbuilderActions set) { return set.Get(); }
            public void SetCallbacks(IPathbuilderActions instance)
            {
                if (m_Wrapper.m_PathbuilderActionsCallbackInterface != null)
                {
                    @SelectTarget.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnSelectTarget;
                    @SelectTarget.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnSelectTarget;
                    @SelectTarget.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnSelectTarget;
                    @SnapAngle.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnSnapAngle;
                    @SnapAngle.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnSnapAngle;
                    @SnapAngle.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnSnapAngle;
                    @MousePosition.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnMousePosition;
                }
                m_Wrapper.m_PathbuilderActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @SelectTarget.started += instance.OnSelectTarget;
                    @SelectTarget.performed += instance.OnSelectTarget;
                    @SelectTarget.canceled += instance.OnSelectTarget;
                    @SnapAngle.started += instance.OnSnapAngle;
                    @SnapAngle.performed += instance.OnSnapAngle;
                    @SnapAngle.canceled += instance.OnSnapAngle;
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                }
            }
        }
        public PathbuilderActions @Pathbuilder => new PathbuilderActions(this);
        public interface IPathbuilderActions
        {
            void OnSelectTarget(InputAction.CallbackContext context);
            void OnSnapAngle(InputAction.CallbackContext context);
            void OnMousePosition(InputAction.CallbackContext context);
        }
    }
}
