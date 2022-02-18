// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/ReviewSystem/ReviewKeybinds.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace NotReaper.ReviewSystem
{
    public class @ReviewKeybinds : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ReviewKeybinds()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ReviewKeybinds"",
    ""maps"": [
        {
            ""name"": ""Review"",
            ""id"": ""65e39195-28c1-4937-bf11-a76c372a98b4"",
            ""actions"": [
                {
                    ""name"": ""TogglePlayback"",
                    ""type"": ""Button"",
                    ""id"": ""dd69bf90-9cd6-41b6-80a3-39e06e558864"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scrub"",
                    ""type"": ""Value"",
                    ""id"": ""1d72cf29-44b0-4602-a0ec-40f450c94d97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4b9b435b-0db2-4f00-96e9-cfd8871a495b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TogglePlayback"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7dc6c3b-e9e9-4687-b9d4-e022df81572d"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scrub"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Review
            m_Review = asset.FindActionMap("Review", throwIfNotFound: true);
            m_Review_TogglePlayback = m_Review.FindAction("TogglePlayback", throwIfNotFound: true);
            m_Review_Scrub = m_Review.FindAction("Scrub", throwIfNotFound: true);
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

        // Review
        private readonly InputActionMap m_Review;
        private IReviewActions m_ReviewActionsCallbackInterface;
        private readonly InputAction m_Review_TogglePlayback;
        private readonly InputAction m_Review_Scrub;
        public struct ReviewActions
        {
            private @ReviewKeybinds m_Wrapper;
            public ReviewActions(@ReviewKeybinds wrapper) { m_Wrapper = wrapper; }
            public InputAction @TogglePlayback => m_Wrapper.m_Review_TogglePlayback;
            public InputAction @Scrub => m_Wrapper.m_Review_Scrub;
            public InputActionMap Get() { return m_Wrapper.m_Review; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ReviewActions set) { return set.Get(); }
            public void SetCallbacks(IReviewActions instance)
            {
                if (m_Wrapper.m_ReviewActionsCallbackInterface != null)
                {
                    @TogglePlayback.started -= m_Wrapper.m_ReviewActionsCallbackInterface.OnTogglePlayback;
                    @TogglePlayback.performed -= m_Wrapper.m_ReviewActionsCallbackInterface.OnTogglePlayback;
                    @TogglePlayback.canceled -= m_Wrapper.m_ReviewActionsCallbackInterface.OnTogglePlayback;
                    @Scrub.started -= m_Wrapper.m_ReviewActionsCallbackInterface.OnScrub;
                    @Scrub.performed -= m_Wrapper.m_ReviewActionsCallbackInterface.OnScrub;
                    @Scrub.canceled -= m_Wrapper.m_ReviewActionsCallbackInterface.OnScrub;
                }
                m_Wrapper.m_ReviewActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @TogglePlayback.started += instance.OnTogglePlayback;
                    @TogglePlayback.performed += instance.OnTogglePlayback;
                    @TogglePlayback.canceled += instance.OnTogglePlayback;
                    @Scrub.started += instance.OnScrub;
                    @Scrub.performed += instance.OnScrub;
                    @Scrub.canceled += instance.OnScrub;
                }
            }
        }
        public ReviewActions @Review => new ReviewActions(this);
        public interface IReviewActions
        {
            void OnTogglePlayback(InputAction.CallbackContext context);
            void OnScrub(InputAction.CallbackContext context);
        }
    }
}
