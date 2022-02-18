// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Modifiers/ModifierKeybinds.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace NotReaper.Modifier
{
    public class @ModifierKeybinds : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ModifierKeybinds()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ModifierKeybinds"",
    ""maps"": [
        {
            ""name"": ""Modifiers"",
            ""id"": ""e2565ca3-bac5-48ac-8919-efeb172a297d"",
            ""actions"": [
                {
                    ""name"": ""DragSelect"",
                    ""type"": ""Button"",
                    ""id"": ""7ab7d592-97b1-413c-be04-0a02d1ca5bb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Copy"",
                    ""type"": ""Button"",
                    ""id"": ""a63bae77-fc8b-4e19-b2b0-6ef093a0a78b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Paste"",
                    ""type"": ""Button"",
                    ""id"": ""0f26395d-2086-4fb1-913f-f5a6eb9dc0d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cut"",
                    ""type"": ""Button"",
                    ""id"": ""c917ee96-5d91-43d8-8f1e-60763c4ace50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DeselectAll"",
                    ""type"": ""Button"",
                    ""id"": ""30870449-07bc-4d90-b2b8-0f4f082f3222"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectAll"",
                    ""type"": ""Button"",
                    ""id"": ""c7850dc0-ad20-4209-9751-4a36fcf5e3ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Undo"",
                    ""type"": ""Button"",
                    ""id"": ""d9bc80da-b2d4-437a-ae2a-e58f92eca548"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Redo"",
                    ""type"": ""Button"",
                    ""id"": ""8d33f850-bee6-4f6a-8d7e-2600af5904d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""e407caf3-1d1b-4e93-a1be-cab2a0451bb7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delete"",
                    ""type"": ""Button"",
                    ""id"": ""54c91322-18b4-46e9-8ba7-93336fe31df4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RemoveModifier"",
                    ""type"": ""Button"",
                    ""id"": ""46b9ae21-d1b3-43e9-8ade-c1984923d895"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6af59d45-eb55-4ddc-a7bc-38960039b7cc"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DragSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""1ba1f82c-8488-4827-9678-f6ef0ff6665b"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Copy"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""c9475c11-6b3d-4b1a-8ca7-b7e772e0b40d"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Copy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""8379d180-2b42-4aea-bd87-526b7210e255"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Copy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""f4a3ceef-2712-4bae-8681-448de5f7387a"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Paste"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""3ab938a2-3a49-4414-a580-d64735778cd9"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Paste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""75f67b9a-59fd-41af-8b08-73273a3c32f7"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Paste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""5ba2680b-6b17-479a-93ec-be77756a5a2d"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cut"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""13931788-c1f7-44c7-a885-7662b74f8733"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""3777c547-a91e-4fab-92f6-752477f6008e"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""c460f6b1-75c8-4214-af2a-0f5036aeb65b"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeselectAll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""48d329ce-fda7-4d71-bebe-3b178f3bc592"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeselectAll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""1a95c29c-fe00-47f9-8108-c5aff1768480"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeselectAll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""124d8fbe-eaff-4d62-9bdf-8ed04ef81e2e"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectAll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""e4235b65-9c23-4caf-982a-24c3fa52a7c3"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectAll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""dd63f3df-b9ca-4b6e-b35a-05435822260b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectAll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""03aed599-2e36-4e24-958a-e47defe19cd2"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Undo"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""f1db2f7b-829b-4a92-b980-28d37905a573"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Undo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""fde01e21-e45d-4254-8aef-98f9c1382d18"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Undo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""766bd2cd-85d5-44a8-9859-bd72b8d02272"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Redo"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""b1f46a01-6875-4120-92be-ed2fa7b52b4f"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Redo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""85186aa9-bdc1-421c-8a74-dcaf6b5d9ff0"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Redo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5a304269-b930-48c6-950b-f5895d556f6d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb4e5780-981f-419b-b75c-0e9673f4eb30"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12f0d5b8-9dcd-4ae9-90f2-b6a86e222022"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RemoveModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Modifiers
            m_Modifiers = asset.FindActionMap("Modifiers", throwIfNotFound: true);
            m_Modifiers_DragSelect = m_Modifiers.FindAction("DragSelect", throwIfNotFound: true);
            m_Modifiers_Copy = m_Modifiers.FindAction("Copy", throwIfNotFound: true);
            m_Modifiers_Paste = m_Modifiers.FindAction("Paste", throwIfNotFound: true);
            m_Modifiers_Cut = m_Modifiers.FindAction("Cut", throwIfNotFound: true);
            m_Modifiers_DeselectAll = m_Modifiers.FindAction("DeselectAll", throwIfNotFound: true);
            m_Modifiers_SelectAll = m_Modifiers.FindAction("SelectAll", throwIfNotFound: true);
            m_Modifiers_Undo = m_Modifiers.FindAction("Undo", throwIfNotFound: true);
            m_Modifiers_Redo = m_Modifiers.FindAction("Redo", throwIfNotFound: true);
            m_Modifiers_LeftMouseClick = m_Modifiers.FindAction("LeftMouseClick", throwIfNotFound: true);
            m_Modifiers_Delete = m_Modifiers.FindAction("Delete", throwIfNotFound: true);
            m_Modifiers_RemoveModifier = m_Modifiers.FindAction("RemoveModifier", throwIfNotFound: true);
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

        // Modifiers
        private readonly InputActionMap m_Modifiers;
        private IModifiersActions m_ModifiersActionsCallbackInterface;
        private readonly InputAction m_Modifiers_DragSelect;
        private readonly InputAction m_Modifiers_Copy;
        private readonly InputAction m_Modifiers_Paste;
        private readonly InputAction m_Modifiers_Cut;
        private readonly InputAction m_Modifiers_DeselectAll;
        private readonly InputAction m_Modifiers_SelectAll;
        private readonly InputAction m_Modifiers_Undo;
        private readonly InputAction m_Modifiers_Redo;
        private readonly InputAction m_Modifiers_LeftMouseClick;
        private readonly InputAction m_Modifiers_Delete;
        private readonly InputAction m_Modifiers_RemoveModifier;
        public struct ModifiersActions
        {
            private @ModifierKeybinds m_Wrapper;
            public ModifiersActions(@ModifierKeybinds wrapper) { m_Wrapper = wrapper; }
            public InputAction @DragSelect => m_Wrapper.m_Modifiers_DragSelect;
            public InputAction @Copy => m_Wrapper.m_Modifiers_Copy;
            public InputAction @Paste => m_Wrapper.m_Modifiers_Paste;
            public InputAction @Cut => m_Wrapper.m_Modifiers_Cut;
            public InputAction @DeselectAll => m_Wrapper.m_Modifiers_DeselectAll;
            public InputAction @SelectAll => m_Wrapper.m_Modifiers_SelectAll;
            public InputAction @Undo => m_Wrapper.m_Modifiers_Undo;
            public InputAction @Redo => m_Wrapper.m_Modifiers_Redo;
            public InputAction @LeftMouseClick => m_Wrapper.m_Modifiers_LeftMouseClick;
            public InputAction @Delete => m_Wrapper.m_Modifiers_Delete;
            public InputAction @RemoveModifier => m_Wrapper.m_Modifiers_RemoveModifier;
            public InputActionMap Get() { return m_Wrapper.m_Modifiers; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ModifiersActions set) { return set.Get(); }
            public void SetCallbacks(IModifiersActions instance)
            {
                if (m_Wrapper.m_ModifiersActionsCallbackInterface != null)
                {
                    @DragSelect.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnDragSelect;
                    @DragSelect.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnDragSelect;
                    @DragSelect.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnDragSelect;
                    @Copy.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnCopy;
                    @Copy.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnCopy;
                    @Copy.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnCopy;
                    @Paste.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnPaste;
                    @Paste.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnPaste;
                    @Paste.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnPaste;
                    @Cut.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnCut;
                    @Cut.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnCut;
                    @Cut.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnCut;
                    @DeselectAll.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnDeselectAll;
                    @DeselectAll.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnDeselectAll;
                    @DeselectAll.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnDeselectAll;
                    @SelectAll.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnSelectAll;
                    @SelectAll.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnSelectAll;
                    @SelectAll.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnSelectAll;
                    @Undo.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnUndo;
                    @Undo.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnUndo;
                    @Undo.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnUndo;
                    @Redo.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnRedo;
                    @Redo.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnRedo;
                    @Redo.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnRedo;
                    @LeftMouseClick.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnLeftMouseClick;
                    @LeftMouseClick.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnLeftMouseClick;
                    @LeftMouseClick.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnLeftMouseClick;
                    @Delete.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnDelete;
                    @Delete.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnDelete;
                    @Delete.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnDelete;
                    @RemoveModifier.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnRemoveModifier;
                    @RemoveModifier.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnRemoveModifier;
                    @RemoveModifier.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnRemoveModifier;
                }
                m_Wrapper.m_ModifiersActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @DragSelect.started += instance.OnDragSelect;
                    @DragSelect.performed += instance.OnDragSelect;
                    @DragSelect.canceled += instance.OnDragSelect;
                    @Copy.started += instance.OnCopy;
                    @Copy.performed += instance.OnCopy;
                    @Copy.canceled += instance.OnCopy;
                    @Paste.started += instance.OnPaste;
                    @Paste.performed += instance.OnPaste;
                    @Paste.canceled += instance.OnPaste;
                    @Cut.started += instance.OnCut;
                    @Cut.performed += instance.OnCut;
                    @Cut.canceled += instance.OnCut;
                    @DeselectAll.started += instance.OnDeselectAll;
                    @DeselectAll.performed += instance.OnDeselectAll;
                    @DeselectAll.canceled += instance.OnDeselectAll;
                    @SelectAll.started += instance.OnSelectAll;
                    @SelectAll.performed += instance.OnSelectAll;
                    @SelectAll.canceled += instance.OnSelectAll;
                    @Undo.started += instance.OnUndo;
                    @Undo.performed += instance.OnUndo;
                    @Undo.canceled += instance.OnUndo;
                    @Redo.started += instance.OnRedo;
                    @Redo.performed += instance.OnRedo;
                    @Redo.canceled += instance.OnRedo;
                    @LeftMouseClick.started += instance.OnLeftMouseClick;
                    @LeftMouseClick.performed += instance.OnLeftMouseClick;
                    @LeftMouseClick.canceled += instance.OnLeftMouseClick;
                    @Delete.started += instance.OnDelete;
                    @Delete.performed += instance.OnDelete;
                    @Delete.canceled += instance.OnDelete;
                    @RemoveModifier.started += instance.OnRemoveModifier;
                    @RemoveModifier.performed += instance.OnRemoveModifier;
                    @RemoveModifier.canceled += instance.OnRemoveModifier;
                }
            }
        }
        public ModifiersActions @Modifiers => new ModifiersActions(this);
        public interface IModifiersActions
        {
            void OnDragSelect(InputAction.CallbackContext context);
            void OnCopy(InputAction.CallbackContext context);
            void OnPaste(InputAction.CallbackContext context);
            void OnCut(InputAction.CallbackContext context);
            void OnDeselectAll(InputAction.CallbackContext context);
            void OnSelectAll(InputAction.CallbackContext context);
            void OnUndo(InputAction.CallbackContext context);
            void OnRedo(InputAction.CallbackContext context);
            void OnLeftMouseClick(InputAction.CallbackContext context);
            void OnDelete(InputAction.CallbackContext context);
            void OnRemoveModifier(InputAction.CallbackContext context);
        }
    }
}
