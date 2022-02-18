// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/UserInput/SpacingSnapper/SpacingSnapKeybinds.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace NotReaper.Tools.SpacingSnap
{
    public class @SpacingSnapKeybinds : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @SpacingSnapKeybinds()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""SpacingSnapKeybinds"",
    ""maps"": [
        {
            ""name"": ""SpacingSnap"",
            ""id"": ""a35eea9c-ccc6-4c55-aaaf-50fc4e181a1b"",
            ""actions"": [
                {
                    ""name"": ""ChangeDistance"",
                    ""type"": ""Button"",
                    ""id"": ""8d243a74-6996-426e-a405-cd27f4ad5da5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockDirectional"",
                    ""type"": ""Button"",
                    ""id"": ""57bcaabe-8d38-49e8-83ee-a1dafe17b83f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""b281825d-919d-4a7a-aafe-8d106bf512e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0ad1750a-9f96-4fe2-8700-44fccace1e2c"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeDistance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24ab4df6-629d-4062-8a08-944e4bb97af8"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockDirectional"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbe6f6a6-3d15-44be-bbc6-17c746d6ab6f"",
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
            // SpacingSnap
            m_SpacingSnap = asset.FindActionMap("SpacingSnap", throwIfNotFound: true);
            m_SpacingSnap_ChangeDistance = m_SpacingSnap.FindAction("ChangeDistance", throwIfNotFound: true);
            m_SpacingSnap_LockDirectional = m_SpacingSnap.FindAction("LockDirectional", throwIfNotFound: true);
            m_SpacingSnap_MousePosition = m_SpacingSnap.FindAction("MousePosition", throwIfNotFound: true);
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

        // SpacingSnap
        private readonly InputActionMap m_SpacingSnap;
        private ISpacingSnapActions m_SpacingSnapActionsCallbackInterface;
        private readonly InputAction m_SpacingSnap_ChangeDistance;
        private readonly InputAction m_SpacingSnap_LockDirectional;
        private readonly InputAction m_SpacingSnap_MousePosition;
        public struct SpacingSnapActions
        {
            private @SpacingSnapKeybinds m_Wrapper;
            public SpacingSnapActions(@SpacingSnapKeybinds wrapper) { m_Wrapper = wrapper; }
            public InputAction @ChangeDistance => m_Wrapper.m_SpacingSnap_ChangeDistance;
            public InputAction @LockDirectional => m_Wrapper.m_SpacingSnap_LockDirectional;
            public InputAction @MousePosition => m_Wrapper.m_SpacingSnap_MousePosition;
            public InputActionMap Get() { return m_Wrapper.m_SpacingSnap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SpacingSnapActions set) { return set.Get(); }
            public void SetCallbacks(ISpacingSnapActions instance)
            {
                if (m_Wrapper.m_SpacingSnapActionsCallbackInterface != null)
                {
                    @ChangeDistance.started -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnChangeDistance;
                    @ChangeDistance.performed -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnChangeDistance;
                    @ChangeDistance.canceled -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnChangeDistance;
                    @LockDirectional.started -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnLockDirectional;
                    @LockDirectional.performed -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnLockDirectional;
                    @LockDirectional.canceled -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnLockDirectional;
                    @MousePosition.started -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnMousePosition;
                }
                m_Wrapper.m_SpacingSnapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ChangeDistance.started += instance.OnChangeDistance;
                    @ChangeDistance.performed += instance.OnChangeDistance;
                    @ChangeDistance.canceled += instance.OnChangeDistance;
                    @LockDirectional.started += instance.OnLockDirectional;
                    @LockDirectional.performed += instance.OnLockDirectional;
                    @LockDirectional.canceled += instance.OnLockDirectional;
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                }
            }
        }
        public SpacingSnapActions @SpacingSnap => new SpacingSnapActions(this);
        public interface ISpacingSnapActions
        {
            void OnChangeDistance(InputAction.CallbackContext context);
            void OnLockDirectional(InputAction.CallbackContext context);
            void OnMousePosition(InputAction.CallbackContext context);
        }
    }
}
