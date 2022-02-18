// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Tools/ChainBuilder/New Pathbuilder/PathbuilderKeybinds.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace NotReaper.Tools.ChainBuilder
{
    public class @PathbuilderKeybinds : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PathbuilderKeybinds()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PathbuilderKeybinds"",
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
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""fd8b12fb-3334-4527-b63f-46dc093ac20b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AppendSegment"",
                    ""type"": ""Button"",
                    ""id"": ""36f9f8f2-c411-4341-b23f-b7d922e66e21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delete Segment"",
                    ""type"": ""Button"",
                    ""id"": ""324e1fc7-e17c-4f85-8e5c-9fbce19ed4a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SnapToGrid"",
                    ""type"": ""Button"",
                    ""id"": ""ec667bbe-a6ec-427b-9ec5-f27f3ab59278"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToNextSegment"",
                    ""type"": ""Button"",
                    ""id"": ""e6309fad-307d-4e60-b6d9-567f644990ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToPreviousSegment"",
                    ""type"": ""Button"",
                    ""id"": ""448b1291-3d6e-4736-8270-96b43f305e2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseLength"",
                    ""type"": ""Button"",
                    ""id"": ""9865982d-4833-46c3-884f-937bbb15981e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreaseLength"",
                    ""type"": ""Button"",
                    ""id"": ""e64d905a-0bc6-4719-998e-04d588820f0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseInterval"",
                    ""type"": ""Button"",
                    ""id"": ""c849da78-07fc-438c-ba00-c8907b831438"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreaseInterval"",
                    ""type"": ""Button"",
                    ""id"": ""3a52b446-39ff-431b-972d-116b4d00336d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeScope"",
                    ""type"": ""Button"",
                    ""id"": ""c1e24740-a3f4-410d-88e5-0481b94ad600"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AlternateHands"",
                    ""type"": ""Button"",
                    ""id"": ""afe07294-37b4-4884-bc63-d45b49bc012d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeTargetHand"",
                    ""type"": ""Button"",
                    ""id"": ""f14bf3bc-76db-4a48-ad5a-9649ad6e9349"",
                    ""expectedControlType"": ""Button"",
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
                    ""id"": ""c0c13960-7509-45c4-898a-8619a52233f2"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""d9ea3eb1-6dd4-490f-a45a-abf6152ae2db"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AppendSegment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""7bb8cd81-cc1e-40c9-852b-d39a37bd802e"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AppendSegment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""cbe53d93-64ba-4078-ba2c-47cab48d464a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AppendSegment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d6bfe8b7-afb7-4919-82a9-c12428ac1331"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delete Segment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecd55dce-780f-43e1-90fb-1edeaa945ce5"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SnapToGrid"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With Three Excludes"",
                    ""id"": ""bd038075-09b9-47d2-8fed-509b776488cb"",
                    ""path"": ""ButtonWithThreeExcludes"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseInterval"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""b9d4a1c6-3d0e-45bf-87e8-3a81be526d30"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseInterval"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude1"",
                    ""id"": ""21d8b4b3-c717-4b04-8404-a9a51898eb11"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseInterval"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude2"",
                    ""id"": ""237c1a3a-8731-4f67-8a79-cffd305dab2c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseInterval"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude3"",
                    ""id"": ""b90db1d6-4f80-4ec0-a220-acf6245cb73f"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseInterval"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With Three Excludes"",
                    ""id"": ""723d358a-215d-47f7-add0-f83d13f76950"",
                    ""path"": ""ButtonWithThreeExcludes"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseInterval"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""8f48de39-8252-4e4d-9528-7202b3a38f0b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseInterval"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude1"",
                    ""id"": ""b9e65280-4635-4330-b4e0-f58ab43cbaf5"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseInterval"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude2"",
                    ""id"": ""bd594279-9f7e-4428-bdef-101c555af5b0"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseInterval"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude3"",
                    ""id"": ""21ec7117-49f9-4719-a2f0-f28522d1c076"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseInterval"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8a904445-39b8-4544-b479-56743b39ea51"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeScope"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8198a01f-1bb9-4919-8eb6-227f3734530c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AlternateHands"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41724a31-51a2-4a7c-bd8c-999ce092ba7a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeTargetHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07ec969e-5f7c-4613-ba1e-1632f05e6ab5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToPreviousSegment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92cee129-92c2-4522-ba5e-3f60bb14c6b3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToNextSegment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f0c84b7-0af5-4b17-a441-60f1ceb25865"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseLength"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acbe1ae6-5b58-4daf-aa10-02539dcabe6d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseLength"",
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
            m_Pathbuilder_MousePosition = m_Pathbuilder.FindAction("MousePosition", throwIfNotFound: true);
            m_Pathbuilder_AppendSegment = m_Pathbuilder.FindAction("AppendSegment", throwIfNotFound: true);
            m_Pathbuilder_DeleteSegment = m_Pathbuilder.FindAction("Delete Segment", throwIfNotFound: true);
            m_Pathbuilder_SnapToGrid = m_Pathbuilder.FindAction("SnapToGrid", throwIfNotFound: true);
            m_Pathbuilder_ChangeToNextSegment = m_Pathbuilder.FindAction("ChangeToNextSegment", throwIfNotFound: true);
            m_Pathbuilder_ChangeToPreviousSegment = m_Pathbuilder.FindAction("ChangeToPreviousSegment", throwIfNotFound: true);
            m_Pathbuilder_IncreaseLength = m_Pathbuilder.FindAction("IncreaseLength", throwIfNotFound: true);
            m_Pathbuilder_DecreaseLength = m_Pathbuilder.FindAction("DecreaseLength", throwIfNotFound: true);
            m_Pathbuilder_IncreaseInterval = m_Pathbuilder.FindAction("IncreaseInterval", throwIfNotFound: true);
            m_Pathbuilder_DecreaseInterval = m_Pathbuilder.FindAction("DecreaseInterval", throwIfNotFound: true);
            m_Pathbuilder_ChangeScope = m_Pathbuilder.FindAction("ChangeScope", throwIfNotFound: true);
            m_Pathbuilder_AlternateHands = m_Pathbuilder.FindAction("AlternateHands", throwIfNotFound: true);
            m_Pathbuilder_ChangeTargetHand = m_Pathbuilder.FindAction("ChangeTargetHand", throwIfNotFound: true);
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
        private readonly InputAction m_Pathbuilder_MousePosition;
        private readonly InputAction m_Pathbuilder_AppendSegment;
        private readonly InputAction m_Pathbuilder_DeleteSegment;
        private readonly InputAction m_Pathbuilder_SnapToGrid;
        private readonly InputAction m_Pathbuilder_ChangeToNextSegment;
        private readonly InputAction m_Pathbuilder_ChangeToPreviousSegment;
        private readonly InputAction m_Pathbuilder_IncreaseLength;
        private readonly InputAction m_Pathbuilder_DecreaseLength;
        private readonly InputAction m_Pathbuilder_IncreaseInterval;
        private readonly InputAction m_Pathbuilder_DecreaseInterval;
        private readonly InputAction m_Pathbuilder_ChangeScope;
        private readonly InputAction m_Pathbuilder_AlternateHands;
        private readonly InputAction m_Pathbuilder_ChangeTargetHand;
        public struct PathbuilderActions
        {
            private @PathbuilderKeybinds m_Wrapper;
            public PathbuilderActions(@PathbuilderKeybinds wrapper) { m_Wrapper = wrapper; }
            public InputAction @SelectTarget => m_Wrapper.m_Pathbuilder_SelectTarget;
            public InputAction @MousePosition => m_Wrapper.m_Pathbuilder_MousePosition;
            public InputAction @AppendSegment => m_Wrapper.m_Pathbuilder_AppendSegment;
            public InputAction @DeleteSegment => m_Wrapper.m_Pathbuilder_DeleteSegment;
            public InputAction @SnapToGrid => m_Wrapper.m_Pathbuilder_SnapToGrid;
            public InputAction @ChangeToNextSegment => m_Wrapper.m_Pathbuilder_ChangeToNextSegment;
            public InputAction @ChangeToPreviousSegment => m_Wrapper.m_Pathbuilder_ChangeToPreviousSegment;
            public InputAction @IncreaseLength => m_Wrapper.m_Pathbuilder_IncreaseLength;
            public InputAction @DecreaseLength => m_Wrapper.m_Pathbuilder_DecreaseLength;
            public InputAction @IncreaseInterval => m_Wrapper.m_Pathbuilder_IncreaseInterval;
            public InputAction @DecreaseInterval => m_Wrapper.m_Pathbuilder_DecreaseInterval;
            public InputAction @ChangeScope => m_Wrapper.m_Pathbuilder_ChangeScope;
            public InputAction @AlternateHands => m_Wrapper.m_Pathbuilder_AlternateHands;
            public InputAction @ChangeTargetHand => m_Wrapper.m_Pathbuilder_ChangeTargetHand;
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
                    @MousePosition.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnMousePosition;
                    @AppendSegment.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnAppendSegment;
                    @AppendSegment.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnAppendSegment;
                    @AppendSegment.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnAppendSegment;
                    @DeleteSegment.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnDeleteSegment;
                    @DeleteSegment.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnDeleteSegment;
                    @DeleteSegment.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnDeleteSegment;
                    @SnapToGrid.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnSnapToGrid;
                    @SnapToGrid.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnSnapToGrid;
                    @SnapToGrid.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnSnapToGrid;
                    @ChangeToNextSegment.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeToNextSegment;
                    @ChangeToNextSegment.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeToNextSegment;
                    @ChangeToNextSegment.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeToNextSegment;
                    @ChangeToPreviousSegment.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeToPreviousSegment;
                    @ChangeToPreviousSegment.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeToPreviousSegment;
                    @ChangeToPreviousSegment.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeToPreviousSegment;
                    @IncreaseLength.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnIncreaseLength;
                    @IncreaseLength.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnIncreaseLength;
                    @IncreaseLength.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnIncreaseLength;
                    @DecreaseLength.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnDecreaseLength;
                    @DecreaseLength.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnDecreaseLength;
                    @DecreaseLength.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnDecreaseLength;
                    @IncreaseInterval.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnIncreaseInterval;
                    @IncreaseInterval.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnIncreaseInterval;
                    @IncreaseInterval.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnIncreaseInterval;
                    @DecreaseInterval.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnDecreaseInterval;
                    @DecreaseInterval.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnDecreaseInterval;
                    @DecreaseInterval.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnDecreaseInterval;
                    @ChangeScope.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeScope;
                    @ChangeScope.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeScope;
                    @ChangeScope.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeScope;
                    @AlternateHands.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnAlternateHands;
                    @AlternateHands.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnAlternateHands;
                    @AlternateHands.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnAlternateHands;
                    @ChangeTargetHand.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeTargetHand;
                    @ChangeTargetHand.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeTargetHand;
                    @ChangeTargetHand.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnChangeTargetHand;
                }
                m_Wrapper.m_PathbuilderActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @SelectTarget.started += instance.OnSelectTarget;
                    @SelectTarget.performed += instance.OnSelectTarget;
                    @SelectTarget.canceled += instance.OnSelectTarget;
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                    @AppendSegment.started += instance.OnAppendSegment;
                    @AppendSegment.performed += instance.OnAppendSegment;
                    @AppendSegment.canceled += instance.OnAppendSegment;
                    @DeleteSegment.started += instance.OnDeleteSegment;
                    @DeleteSegment.performed += instance.OnDeleteSegment;
                    @DeleteSegment.canceled += instance.OnDeleteSegment;
                    @SnapToGrid.started += instance.OnSnapToGrid;
                    @SnapToGrid.performed += instance.OnSnapToGrid;
                    @SnapToGrid.canceled += instance.OnSnapToGrid;
                    @ChangeToNextSegment.started += instance.OnChangeToNextSegment;
                    @ChangeToNextSegment.performed += instance.OnChangeToNextSegment;
                    @ChangeToNextSegment.canceled += instance.OnChangeToNextSegment;
                    @ChangeToPreviousSegment.started += instance.OnChangeToPreviousSegment;
                    @ChangeToPreviousSegment.performed += instance.OnChangeToPreviousSegment;
                    @ChangeToPreviousSegment.canceled += instance.OnChangeToPreviousSegment;
                    @IncreaseLength.started += instance.OnIncreaseLength;
                    @IncreaseLength.performed += instance.OnIncreaseLength;
                    @IncreaseLength.canceled += instance.OnIncreaseLength;
                    @DecreaseLength.started += instance.OnDecreaseLength;
                    @DecreaseLength.performed += instance.OnDecreaseLength;
                    @DecreaseLength.canceled += instance.OnDecreaseLength;
                    @IncreaseInterval.started += instance.OnIncreaseInterval;
                    @IncreaseInterval.performed += instance.OnIncreaseInterval;
                    @IncreaseInterval.canceled += instance.OnIncreaseInterval;
                    @DecreaseInterval.started += instance.OnDecreaseInterval;
                    @DecreaseInterval.performed += instance.OnDecreaseInterval;
                    @DecreaseInterval.canceled += instance.OnDecreaseInterval;
                    @ChangeScope.started += instance.OnChangeScope;
                    @ChangeScope.performed += instance.OnChangeScope;
                    @ChangeScope.canceled += instance.OnChangeScope;
                    @AlternateHands.started += instance.OnAlternateHands;
                    @AlternateHands.performed += instance.OnAlternateHands;
                    @AlternateHands.canceled += instance.OnAlternateHands;
                    @ChangeTargetHand.started += instance.OnChangeTargetHand;
                    @ChangeTargetHand.performed += instance.OnChangeTargetHand;
                    @ChangeTargetHand.canceled += instance.OnChangeTargetHand;
                }
            }
        }
        public PathbuilderActions @Pathbuilder => new PathbuilderActions(this);
        public interface IPathbuilderActions
        {
            void OnSelectTarget(InputAction.CallbackContext context);
            void OnMousePosition(InputAction.CallbackContext context);
            void OnAppendSegment(InputAction.CallbackContext context);
            void OnDeleteSegment(InputAction.CallbackContext context);
            void OnSnapToGrid(InputAction.CallbackContext context);
            void OnChangeToNextSegment(InputAction.CallbackContext context);
            void OnChangeToPreviousSegment(InputAction.CallbackContext context);
            void OnIncreaseLength(InputAction.CallbackContext context);
            void OnDecreaseLength(InputAction.CallbackContext context);
            void OnIncreaseInterval(InputAction.CallbackContext context);
            void OnDecreaseInterval(InputAction.CallbackContext context);
            void OnChangeScope(InputAction.CallbackContext context);
            void OnAlternateHands(InputAction.CallbackContext context);
            void OnChangeTargetHand(InputAction.CallbackContext context);
        }
    }
}
