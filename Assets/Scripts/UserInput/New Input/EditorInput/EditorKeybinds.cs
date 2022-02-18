// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/UserInput/New Input/EditorInput/EditorKeybinds.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @EditorKeybinds : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @EditorKeybinds()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EditorKeybinds"",
    ""maps"": [
        {
            ""name"": ""Mapping"",
            ""id"": ""f5825fcb-3355-4fd2-8e1a-208c8ae5a18a"",
            ""actions"": [
                {
                    ""name"": ""PlaceNote"",
                    ""type"": ""Button"",
                    ""id"": ""1135e5c4-23db-4dd3-b2df-dcd6a3ceef5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RemoveNote"",
                    ""type"": ""Button"",
                    ""id"": ""3bedfb04-97ca-444d-a116-397966932d3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchHand"",
                    ""type"": ""Button"",
                    ""id"": ""03c343a5-9aaf-4baf-9278-d280ee733ffd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlipTargetColors"",
                    ""type"": ""Button"",
                    ""id"": ""7088afb3-341b-40b3-b50a-91a92793b91c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DeleteSelectedTargets"",
                    ""type"": ""Button"",
                    ""id"": ""7da3228b-8ca1-43b8-b2e1-e5b990096ab0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5cefc6d7-bc99-4fb3-9f45-79f1168d98cc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceNote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c550dcdd-ef2b-4dfe-acce-754ea9166f07"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SwitchHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""423faaef-f556-4c77-a901-2f5ce603941d"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DeleteSelectedTargets"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With Three Excludes"",
                    ""id"": ""6e6d75e6-8114-40df-a9b7-04b19d54fd13"",
                    ""path"": ""ButtonWithThreeExcludes"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipTargetColors"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""e16377ab-9822-4ed8-ad6d-f76c358ed060"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipTargetColors"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude1"",
                    ""id"": ""49c59510-c478-46f6-b8e1-7e1cc5f9e1fb"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipTargetColors"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude2"",
                    ""id"": ""53c21263-bd28-4339-9688-96b85bdb19fa"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipTargetColors"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude3"",
                    ""id"": ""497f7446-b6b5-47e5-970b-e2822dae94dd"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipTargetColors"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6637a16a-3517-4eed-8632-6c0df64c1d06"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RemoveNote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Utility"",
            ""id"": ""a3fb0b41-0523-44f4-9485-93782b8c9b15"",
            ""actions"": [
                {
                    ""name"": ""SelectAll"",
                    ""type"": ""Button"",
                    ""id"": ""926da7e2-6782-4652-9f64-c199feed2d92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DeselectAll"",
                    ""type"": ""Button"",
                    ""id"": ""a73bf061-84c0-4727-bf84-cd956975612c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Copy"",
                    ""type"": ""Button"",
                    ""id"": ""d2e1c2dc-5896-4fae-9bc1-4713d59e7642"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cut"",
                    ""type"": ""Button"",
                    ""id"": ""9f33cf8c-b1e3-4dc1-a089-ddd36fdd4e76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Paste"",
                    ""type"": ""Button"",
                    ""id"": ""c4bf0a68-8650-498d-8f86-baa2b385c280"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""a3112068-bc68-4d91-9ecd-ea8fae9c4e79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Undo"",
                    ""type"": ""Button"",
                    ""id"": ""d49c3f0e-dbc3-4b79-ad52-f2ff38980b84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Redo"",
                    ""type"": ""Button"",
                    ""id"": ""d6c9684d-ecbd-4da7-a099-305ded2b1e88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""c8c16fad-e3e1-4e13-8a25-bb0dc84ff98b"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectAll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""7e11f58c-91a0-4ff2-8c09-da39e24d57c3"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectAll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""6eb9ecd6-0647-415d-bb03-a83d8a87bb65"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectAll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""6ef3e78a-1ea4-4468-8260-9a94adce6885"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DeselectAll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""3e7325dd-df4c-489c-9156-442cf0ed2421"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DeselectAll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""44a7a4be-15cc-4c62-8c1a-2e5a0adba8a7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DeselectAll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""395f7867-5f1f-42b1-9019-9e3959512d9a"",
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
                    ""id"": ""0045c798-89f0-4ce4-80f2-6938aeb40675"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Copy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""0880bd64-9feb-48f6-9c49-cd36dff36746"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Copy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""c87d9d82-1f04-44b5-875a-0d1af9fec243"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cut"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""7c6a82f8-1553-4918-bf0d-97fc10ac32a2"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""135f11e6-7d86-4734-a710-fb3d9e17e9da"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""c8b53cd3-c9fc-4dc9-9fd0-a74737058c1a"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Paste"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""6f37df67-ebd2-40ef-91db-ed8d1c654c3c"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Paste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""cd1fb8cc-a675-4780-bf60-02be93e8c9db"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Paste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""144a3ff6-5ce6-43f2-965d-8f1f061caa1b"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Save"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""ce21218c-0166-44dc-a9a7-d4e8bc558b34"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""5a1b1c3f-3f05-45d1-9c0a-4428300ceabd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""d10d7df2-deb6-47d9-87d3-2ca72cf1f849"",
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
                    ""id"": ""28a85771-499c-4699-842d-5879efa59464"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Undo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""0ddf8bfc-4cf7-4a7b-ba1d-7aadefa18968"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Undo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""c9194329-0a47-461c-9664-7af30dcd34eb"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Redo"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""649db32c-e794-416e-bad6-fe5753f78ca9"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Redo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""ea0192d8-eb63-4971-97ee-7422cab99dd7"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Redo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Menus"",
            ""id"": ""ac39d824-9aad-4518-a599-97c84335be8b"",
            ""actions"": [
                {
                    ""name"": ""Countin"",
                    ""type"": ""Button"",
                    ""id"": ""39f40699-8482-4e19-9ace-ad424f10361b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ModifyAudio"",
                    ""type"": ""Button"",
                    ""id"": ""b34ef5c3-a351-4efc-b4e3-8002463beb8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TimingPoints"",
                    ""type"": ""Button"",
                    ""id"": ""6626579a-95d0-46a4-8673-1c2e0656b16b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ModifierHelp"",
                    ""type"": ""Button"",
                    ""id"": ""ad899e46-7ff7-4524-aeb4-d509ec314737"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ReviewMenu"",
                    ""type"": ""Button"",
                    ""id"": ""bbff1ef1-671b-4864-8c22-249fea1a9470"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bookmark"",
                    ""type"": ""Button"",
                    ""id"": ""e606b95d-bb86-44f6-89f1-21ed74850692"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""594aaaa7-d608-4c8a-9a96-0d09a371d6a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Help"",
                    ""type"": ""Button"",
                    ""id"": ""62b967ae-bca2-484d-a1cf-35d5e60fcfc8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4c4767a9-8383-4873-b4c0-1b9d0149d4c3"",
                    ""path"": ""<Keyboard>/f3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Countin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cca827e-e9f3-4d57-851d-281dfeb6eb4e"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ModifyAudio"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52a7d1f5-0eb7-4413-927b-4038edb950ef"",
                    ""path"": ""<Keyboard>/f6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""TimingPoints"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae065b33-5101-4d23-9ef4-6262ca84cba6"",
                    ""path"": ""<Keyboard>/f8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ModifierHelp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""382f1c2c-74cb-4a3c-b506-a284237a6045"",
                    ""path"": ""<Keyboard>/f9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ReviewMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c79e9c5-e1e3-499f-890e-b94684f7bcc6"",
                    ""path"": ""<Keyboard>/period"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bookmark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6cc1b90-63d5-4f07-914b-f554aa3898f6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cd6f87f-39c0-4017-8dee-808758c6fd63"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Help"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Timeline"",
            ""id"": ""80010bab-3ac8-46cf-87f3-dc0361406d03"",
            ""actions"": [
                {
                    ""name"": ""TogglePlay"",
                    ""type"": ""Button"",
                    ""id"": ""8b338932-899e-48f5-9521-bb3063f6163c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scrub"",
                    ""type"": ""Value"",
                    ""id"": ""6a636507-01dd-435e-a269-c87811d48911"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrubByTick"",
                    ""type"": ""Value"",
                    ""id"": ""9f4bdf6e-1626-4b53-b740-bb5f544cae1e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeBeatSnap"",
                    ""type"": ""Value"",
                    ""id"": ""78e9dc01-44c4-4952-8001-0978923b0879"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZoomTimeline"",
                    ""type"": ""Value"",
                    ""id"": ""1f3b5269-ee9e-4f8c-943c-1448bbd22ce9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartMetronome"",
                    ""type"": ""Button"",
                    ""id"": ""119a6e75-c67f-45d1-bf63-97f55bc67765"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleWaveform"",
                    ""type"": ""Button"",
                    ""id"": ""fed964c5-0056-42d9-ac60-ac618a9baff5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9ad7378f-3131-4909-a61c-3b32b4b5eeea"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""TogglePlay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""72fdf5b2-4769-4bd1-bd24-6be6a88cb134"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartMetronome"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""fb45c049-6146-4dfb-a332-a80db3570321"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartMetronome"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""e333e77b-efe2-48c4-91ab-4287b2258299"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartMetronome"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With Three Excludes"",
                    ""id"": ""385de0ec-683f-456e-b7b0-6ea0e4276c78"",
                    ""path"": ""ButtonWithThreeExcludes"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scrub"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""cc5af5be-a8ca-419b-9ca7-769c6cea0048"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scrub"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude1"",
                    ""id"": ""3b6eb778-1231-4c4d-801d-1a0b982bf096"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scrub"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude2"",
                    ""id"": ""4de6dd8c-36c0-46fd-bbd8-c137685a3e91"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scrub"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude3"",
                    ""id"": ""37ba834b-e549-4dc3-96fd-463913246683"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scrub"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier Two Excludes"",
                    ""id"": ""ca57d522-fc5e-4221-964b-837b92f73c9a"",
                    ""path"": ""ButtonWithOneModifierTwoExcludes"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrubByTick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""64cbdbb1-fb45-4712-89c5-32944bc5e2ab"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrubByTick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""2360c285-cac0-4fdb-9857-e4ab08a77172"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrubByTick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude1"",
                    ""id"": ""16dd3693-1d0e-495a-9612-4f926a2cee4b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrubByTick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude2"",
                    ""id"": ""6a6b58a1-ff2b-479c-9649-46ab3c67f6a0"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrubByTick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With Two Modifiers One Exclude"",
                    ""id"": ""6db79154-9284-49dc-9cf1-ba45fbb288da"",
                    ""path"": ""ButtonWithTwoModifiersOneExclude"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeBeatSnap"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""b8437e48-b694-4328-b404-ec68566945ba"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeBeatSnap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""894a59f9-1c4a-4db9-bfc4-4c323ce152b3"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeBeatSnap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""c4880b61-fa76-4980-bc75-0bdb458b92cb"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeBeatSnap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""excludeButton"",
                    ""id"": ""81ca2870-f984-4654-bc98-f27fab7c3b3a"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeBeatSnap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier Two Excludes"",
                    ""id"": ""2cf6c81e-2c19-4603-bf6e-75ae74dcfb53"",
                    ""path"": ""ButtonWithOneModifierTwoExcludes"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomTimeline"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""b226774e-8552-4943-9b44-d95a7362a9f9"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomTimeline"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""9a70db5b-a4b0-47c7-9a78-64e927800796"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomTimeline"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude1"",
                    ""id"": ""90100978-74b9-4f89-9ec5-48a7884fd886"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomTimeline"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude2"",
                    ""id"": ""9c9e2749-22c7-4764-bd8c-20f3e0a419b8"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomTimeline"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""502e5563-2475-4381-916e-b7ef36cdd085"",
                    ""path"": ""<Keyboard>/f2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ToggleWaveform"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DragSelect"",
            ""id"": ""a0a3b428-72a0-43ff-9694-90680ad32bde"",
            ""actions"": [
                {
                    ""name"": ""SelectDragTool"",
                    ""type"": ""Button"",
                    ""id"": ""f12b8cd5-0081-4f28-ad34-6185ad51ab06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MoveTargets"",
                    ""type"": ""Button"",
                    ""id"": ""b66a996d-cf66-4f39-8c1b-421097b234df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveTargetsQuarterModifier"",
                    ""type"": ""Button"",
                    ""id"": ""08aff691-55d9-4d00-a782-017b9a836cef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveTargetsHalfModifier"",
                    ""type"": ""Button"",
                    ""id"": ""b8cde323-49e3-435f-9496-1289241180b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlipTargetsVertically"",
                    ""type"": ""Button"",
                    ""id"": ""57478268-8f74-4196-9d1a-41a92a989b13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlipTargetsHorizontally"",
                    ""type"": ""Button"",
                    ""id"": ""a99841c0-d231-478c-9476-1ed6d28a2880"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseScaleVertically"",
                    ""type"": ""Button"",
                    ""id"": ""4a42fb70-766c-41da-802a-10a78f9bce61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreaseScaleVertically"",
                    ""type"": ""Button"",
                    ""id"": ""0089a7ac-a7e4-422b-90ef-55be04d32fbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseScaleHorizontally"",
                    ""type"": ""Button"",
                    ""id"": ""29eb46f8-6153-4ce2-8168-e5e7edf63aaa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreaseScaleHorizontally"",
                    ""type"": ""Button"",
                    ""id"": ""db929702-2851-44a7-9d76-c308fe5269b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ReverseSelectedTargets"",
                    ""type"": ""Button"",
                    ""id"": ""665426aa-257a-4b3c-b998-ac8bb56cf969"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateSelectedTargetsRight"",
                    ""type"": ""Button"",
                    ""id"": ""3b518ffe-52a2-4cce-aaa9-3dd478938ab6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateSelectedTargetsLeft"",
                    ""type"": ""Button"",
                    ""id"": ""75a230d7-631f-4c50-8d9e-2cfdc3bc3202"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""263e4bf8-907e-407d-8127-b67d680186e7"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectDragTool"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b34b9325-2283-4c31-afc3-56b39e7f7bbc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveTargets"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cd66e65a-95fe-4c2a-bb75-488774df435d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveTargets"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""223d887f-1217-4a4d-bf27-6c2f26653aff"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveTargets"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""aec1f3c5-5af5-4b5f-99ad-994656cba896"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveTargets"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6041543f-9ff7-4814-b50c-9ad2406c2f9d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveTargets"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a34d4303-bc34-4935-85df-7aa246def295"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveTargetsQuarterModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e4e5a97-d706-4a67-9603-011a0a3bc791"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveTargetsHalfModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""289a59be-0cb6-4ae5-9bb9-b1dffceca193"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipTargetsVertically"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""6c6c0f07-6a21-475c-aa95-4d497625e4cb"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipTargetsVertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""693afa67-762a-446e-abec-81efb2d40222"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipTargetsVertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""2f7218c9-d008-4166-9142-f5c5f5f1b873"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipTargetsHorizontally"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""186ac87b-906f-4385-9da1-13f456cba556"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipTargetsHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""1ddb7614-6cc9-484a-9add-8ff881578e68"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipTargetsHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier One Exclude"",
                    ""id"": ""495d4d46-4dbe-48d8-811c-864813fa85dc"",
                    ""path"": ""ButtonWithOneModifierOneExclude"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseScaleVertically"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""5b0f15b6-fd1a-4c23-ae5b-8b6e4eb56407"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseScaleVertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""32855d33-0ff9-4739-a2f5-9e0d45e818bf"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseScaleVertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""excludeButton"",
                    ""id"": ""5dbbfd91-78b0-4d1b-b6b4-bc5086923b09"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseScaleVertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier One Exclude"",
                    ""id"": ""e3dd47f0-19fd-440e-b12c-cd7ad8ad285e"",
                    ""path"": ""ButtonWithOneModifierOneExclude"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseScaleVertically"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""778188f6-3d71-4e17-b525-ed581bd94e33"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseScaleVertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""a437cb54-6455-46c4-aaba-bca6bbe8eb23"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseScaleVertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""excludeButton"",
                    ""id"": ""89d189d8-fe28-49f6-ade6-1ddd95ff0ade"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseScaleVertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier One Exclude"",
                    ""id"": ""dac68261-4b81-4690-89ea-cf73249061bc"",
                    ""path"": ""ButtonWithOneModifierOneExclude"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseScaleHorizontally"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""eb9d0649-d446-4afe-b3bb-6986f6b522cb"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseScaleHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""d9670bff-b3ff-4996-bf22-be439860dc6b"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseScaleHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""excludeButton"",
                    ""id"": ""a95b828d-ee61-4b70-bb06-9fabb15b136c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseScaleHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier One Exclude"",
                    ""id"": ""4094895f-451f-4c62-8cae-beedfc8cf5c6"",
                    ""path"": ""ButtonWithOneModifierOneExclude"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseScaleHorizontally"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""75f1f0b3-c50f-4880-830a-80d42e2817be"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseScaleHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""39bafb47-0f2e-42dc-a5f4-fd02bbad71b5"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseScaleHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""excludeButton"",
                    ""id"": ""982f5c9c-4ebd-4af2-ba6b-9f5b66ae921a"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseScaleHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""f80e63c8-0ebc-480e-9a99-5c64dc60ba54"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReverseSelectedTargets"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""e6a84f06-d7c9-4006-8c43-b4a716eb43ff"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReverseSelectedTargets"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""29fa160f-1295-430e-9f8d-a3e3e8806400"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReverseSelectedTargets"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""efa14e0b-673b-4acb-a343-6f86aaa7a0a7"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelectedTargetsRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""dd346aff-70ef-41e3-bbc9-af311ae18156"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelectedTargetsRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""8c3ed938-e958-4821-8af0-4d54f38788de"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelectedTargetsRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""0a0d6cb7-316d-4f76-80a0-f246f0151582"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelectedTargetsLeft"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""8020b78c-8189-49fc-a397-2cffcec1badb"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelectedTargetsLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""d193f6ad-f9b8-409d-8721-022f260dbfc7"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelectedTargetsLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Grid"",
            ""id"": ""b1d25f65-4fe5-4d6e-b790-3536ddfdc36a"",
            ""actions"": [
                {
                    ""name"": ""GridView"",
                    ""type"": ""Button"",
                    ""id"": ""024f5296-4d4c-4f8f-bb7a-91dc1e0bfc40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NoGridView"",
                    ""type"": ""Button"",
                    ""id"": ""49d6463d-2220-4b3c-a1ee-af10699a0332"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MeleeView"",
                    ""type"": ""Button"",
                    ""id"": ""fe3492bf-f264-4924-9b5b-505e2fac749b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""QuickSwitchGrid"",
                    ""type"": ""Button"",
                    ""id"": ""76cefbfd-4d72-49a2-90ad-68fe5c3760f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveGrid"",
                    ""type"": ""Value"",
                    ""id"": ""04567811-2606-4d43-bdeb-104043d279a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bc4fd92e-e36f-442e-bafc-21d8d0e136c5"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""GridView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bbe541d6-a14c-462d-9d9b-e480876b6023"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""NoGridView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a6d0847-5740-4b1f-aa49-8bc66d57dbc7"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MeleeView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1ddafca-82cc-4cc2-b338-3f9b8ec919bf"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSwitchGrid"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""eed0f6b9-6dda-418a-a02d-7780c5bef4c5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveGrid"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""37b30f8e-ef05-4bc9-a9f0-62a878c86fec"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveGrid"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1b2beeab-aaa0-428b-ac55-75483b633603"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveGrid"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b08d3442-9ed2-4311-a47a-150842ae7632"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveGrid"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""eca3786c-7b31-4da6-afdc-9aeb98bf5463"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveGrid"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""BPM"",
            ""id"": ""7442403a-ab4f-4796-87da-29b5c5175b3b"",
            ""actions"": [
                {
                    ""name"": ""DetectBPM"",
                    ""type"": ""Button"",
                    ""id"": ""b0653f7e-fba3-4117-b31f-ab63517e482d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShiftBPMMarker"",
                    ""type"": ""Button"",
                    ""id"": ""48e8170e-d866-4832-a0ff-5bf3874d75bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BPMMarker"",
                    ""type"": ""Button"",
                    ""id"": ""1ed2c344-7702-438d-9a48-a411528f73e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PreviewPoint"",
                    ""type"": ""Button"",
                    ""id"": ""61811c5e-4e76-43d0-8260-f13219801341"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Button With One Modifier Two Excludes"",
                    ""id"": ""01cd2a8a-8dc6-46e8-b0fd-3b7eed9a34d0"",
                    ""path"": ""ButtonWithOneModifierTwoExcludes"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DetectBPM"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""dfb47cac-03ab-493e-9485-4b1595ba8046"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DetectBPM"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""e5e75f02-1e32-4507-b73a-87e856f9a30f"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DetectBPM"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude1"",
                    ""id"": ""29779d0e-52d9-4161-a0d7-83bb09fcb64e"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DetectBPM"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude2"",
                    ""id"": ""96c368f0-669b-4a00-8896-e5d177ac4b8d"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DetectBPM"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier Two Excludes"",
                    ""id"": ""ca8e982f-9dd0-4cfc-b6a6-95dc42dfbf46"",
                    ""path"": ""ButtonWithOneModifierTwoExcludes"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftBPMMarker"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""d848a9ff-a2be-4999-aac3-99ff2d929b09"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftBPMMarker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0926f541-93a3-4b93-8309-898704fc518f"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftBPMMarker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude1"",
                    ""id"": ""45dd7708-ee34-4da4-ad5a-09ec029c5085"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftBPMMarker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude2"",
                    ""id"": ""5d1645b7-5a92-4d76-911c-17d82cbdb26b"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftBPMMarker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With Three Excludes"",
                    ""id"": ""f9f74cc8-8579-4d28-9fde-36913944e180"",
                    ""path"": ""ButtonWithThreeExcludes"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BPMMarker"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""button"",
                    ""id"": ""ded42fd1-009c-4150-919e-6ea29c82f73c"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BPMMarker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude1"",
                    ""id"": ""9f5c7236-7007-4d49-9236-2137092af988"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BPMMarker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude2"",
                    ""id"": ""2b9eef8e-469c-4583-9b83-cb88c3222159"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BPMMarker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""exclude3"",
                    ""id"": ""e12a26c8-c3bd-449a-aa0a-6bc928f4b5ff"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BPMMarker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f29cb16b-7cb9-489a-a137-ebae89e0d0cf"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PreviewPoint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SpacingSnap"",
            ""id"": ""cc8bb546-6c8c-43c5-bdb4-ff702e48ca05"",
            ""actions"": [
                {
                    ""name"": ""EnableSpacingSnap"",
                    ""type"": ""Button"",
                    ""id"": ""376921ba-3d09-41e1-8a1c-aa85ac6b43c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d39382e2-a24d-4a34-a0a9-a2a7f35e7dff"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""EnableSpacingSnap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pathbuilder"",
            ""id"": ""d86f5814-bda2-4c52-81f8-c62bfd211b62"",
            ""actions"": [
                {
                    ""name"": ""EnablePathbuilder"",
                    ""type"": ""Button"",
                    ""id"": ""aa3c3eab-0b91-45fd-85d2-803fa6c74080"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dfe1f0d4-c8e9-444f-9229-3733c2b55ef2"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""EnablePathbuilder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Modifiers"",
            ""id"": ""da2e58ab-0dc4-4dde-bf0f-33c6fffc0bdc"",
            ""actions"": [
                {
                    ""name"": ""OpenModifiers"",
                    ""type"": ""Button"",
                    ""id"": ""f92e3ee6-7bfa-41ef-9bdc-3752e6138c60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ModifierPreview"",
                    ""type"": ""Button"",
                    ""id"": ""abd017a8-6a3d-4721-b25b-a2ee6e3c3b04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2a0396e8-124e-45c1-bf10-151df0b9ae8c"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenModifiers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""20bc0acb-21cd-4ba1-a8c3-31926b65b27d"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifierPreview"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""e0e72910-e7ad-438a-bcee-76638f932e61"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifierPreview"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""5de1c5c9-d9d7-4cd2-9f6f-f83f4711ffa6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifierPreview"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""BehaviorSelect"",
            ""id"": ""b0aa890b-fae2-4cf6-9d93-c85e546b0429"",
            ""actions"": [
                {
                    ""name"": ""SelectBehaviorStandard"",
                    ""type"": ""Button"",
                    ""id"": ""26fc1164-00b6-4fcc-a1e9-d48a52d9471d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectBehaviorSustain"",
                    ""type"": ""Button"",
                    ""id"": ""d28ff1b8-dc5b-4998-967c-9b3d2c1a5cbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectBehaviorMine"",
                    ""type"": ""Button"",
                    ""id"": ""8cf79b51-2c64-4d2b-b6d4-7c798e50cefe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectBehaviorMelee"",
                    ""type"": ""Button"",
                    ""id"": ""2d78bce9-8ff7-40e6-b00e-ac3f2ce4cebf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectBehaviorChain"",
                    ""type"": ""Button"",
                    ""id"": ""47da4255-8ec7-443b-83ec-609ab775dbb9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectBehaviorChainstart"",
                    ""type"": ""Button"",
                    ""id"": ""163391ea-08e5-45cf-8174-fd2dd3d8e8a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectBehaviorVertical"",
                    ""type"": ""Button"",
                    ""id"": ""47fb17aa-2d38-4a37-91c1-1274b2e2877f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectBehaviorHorizontal"",
                    ""type"": ""Button"",
                    ""id"": ""a68e2b3b-2e58-4b3c-b98c-e45778f2ca89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f9c04ddd-61fa-4fae-b385-a1d51e8167d7"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectBehaviorStandard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4be0cc8-c990-45f6-b1dd-e3780126f848"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectBehaviorSustain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19a8589b-2069-4931-9512-26c5443278f3"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectBehaviorMine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e714c295-68fc-4036-9f1f-a509bf3b9708"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectBehaviorMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3cf005b-7c11-4100-a2f8-2bf2b2b4fcef"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectBehaviorChain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c757974c-82e8-4d41-81f8-39bbf1f61efd"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectBehaviorChainstart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64220fab-0c57-4273-810a-d969aa0349ed"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectBehaviorVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01d2270d-85a2-49c4-9eec-8d3084ab25eb"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectBehaviorHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""BehaviorConvert"",
            ""id"": ""c4e86379-cc52-48ae-989d-f10b87f9be88"",
            ""actions"": [
                {
                    ""name"": ""ConvertBehaviorStandard"",
                    ""type"": ""Button"",
                    ""id"": ""ec1d49eb-c37e-4de2-94c4-d0ea25e4da79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertBehaviorSustain"",
                    ""type"": ""Button"",
                    ""id"": ""d7f9e073-9c8d-481b-8287-bbeb17ea7354"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertBehaviorVertical"",
                    ""type"": ""Button"",
                    ""id"": ""c11883ea-ba60-4412-98da-c875e679122c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertBehaviorHorizontal"",
                    ""type"": ""Button"",
                    ""id"": ""8dfeac65-b806-40d3-abd0-7db365d36f13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertBehaviorChainstart"",
                    ""type"": ""Button"",
                    ""id"": ""8e08c3f7-34e6-4ae2-9d31-196a660e8d96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertBehaviorChain"",
                    ""type"": ""Button"",
                    ""id"": ""930079e1-5619-4c60-8373-77c84b320ea2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertBehaviorMelee"",
                    ""type"": ""Button"",
                    ""id"": ""0e6b737a-28b4-4fde-a061-4b17f53cce2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertBehaviorMine"",
                    ""type"": ""Button"",
                    ""id"": ""557b403d-5d3b-4f34-8881-5b664d478d3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""d9f47949-006a-4544-829d-5b0864b9e27d"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertBehaviorStandard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""30b929b1-7314-455d-92a9-eab1ef3c7a38"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorStandard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""4abe9e8e-078c-4e22-81ca-ac242c81c9e1"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorStandard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""b4f82e2c-7bb9-47cd-a926-fb4eb165a7ea"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorSustain"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""1216654f-6289-4b7f-b9f1-4844393e4c5d"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorSustain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""33088c14-808f-49a6-ac0e-872a58e7b811"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorSustain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""c359f53c-53bc-4ae1-ac73-310f1f9c42c5"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""871053ab-8455-420f-aa78-43c1687b8d2a"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""50fb8cb6-5238-4a4a-a091-05d5a6806309"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""a255f470-bbfa-463d-8ef8-01fe8eb32ffa"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""71a006bc-5004-4290-98f7-6e358aea9238"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""65c26e1c-13ae-4da6-b1cd-d2f25fe97dca"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""7483d052-9471-436d-a9ad-844d981d404f"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorChainstart"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""8f15a5df-d15e-45fd-a79d-7540f0c26dc8"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorChainstart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""05ba09a0-0431-431d-9070-00e9a8f934d4"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorChainstart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""88b22353-0b07-4b7c-a844-918b7abd2aba"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorChain"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""b4973b6e-9b30-4edf-b5d3-06a7fc4e3e76"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorChain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""4f6896fe-0f7e-47ef-88f9-87359c9d4cf1"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorChain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""438d10db-ef05-4743-8dec-f1a1e70900cb"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorMelee"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0b0f2050-4272-48da-8757-47ea089693c4"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""804a0a36-13d4-4063-8e20-9d5cc159a6ed"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""6fb894db-182e-47bb-901e-ff1e7b3c16ff"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorMine"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""111c1d6e-da4c-4031-9b68-4b0312e6ac14"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorMine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""14c42aa8-0b43-48bd-a47c-38bca2970938"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ConvertBehaviorMine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""HitsoundSelect"",
            ""id"": ""b4dc7f2f-68e2-4bbd-afb0-186e85f5a40b"",
            ""actions"": [
                {
                    ""name"": ""SelectHitsoundKick"",
                    ""type"": ""Button"",
                    ""id"": ""4fd0747f-c811-46d5-a935-96447368dc8c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectHitsoundSnare"",
                    ""type"": ""Button"",
                    ""id"": ""ef5fb7bb-16f1-463f-a4c3-ddb9c7ac05a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectHitsoundPercussion"",
                    ""type"": ""Button"",
                    ""id"": ""c06c90a0-6b8c-4ff9-91b2-e3a2fbe0e66d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectHitsoundChainstart"",
                    ""type"": ""Button"",
                    ""id"": ""dc76decc-a697-4b1b-9f41-a5386065012d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectHitsoundChain"",
                    ""type"": ""Button"",
                    ""id"": ""6e323c62-a846-4ebd-948f-f742e655c867"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectHitsoundMelee"",
                    ""type"": ""Button"",
                    ""id"": ""95abaac8-3eed-49da-8070-de4cf20803ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectHitsoundSilent"",
                    ""type"": ""Button"",
                    ""id"": ""299ffac3-550c-43cf-86fb-895788829a5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6485c361-aac3-4ba7-bbb0-c45addb5a5b2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectHitsoundKick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccd74f55-0737-4e3b-aabf-2e477e76aa3a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectHitsoundSnare"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd7f1583-0164-4b30-9c8e-3b90bc4589e8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectHitsoundPercussion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""962d0c6f-9872-4b7d-876b-e7ba4928327b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectHitsoundChainstart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2c8a79f-ea28-444d-927b-f80976498a73"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectHitsoundChain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45f2bb26-1042-4f9e-af89-a79f01c008ca"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectHitsoundMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9edfc761-50e5-4dee-9faa-8d94a631a095"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectHitsoundSilent"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""HitsoundConvert"",
            ""id"": ""3220ed51-98f4-41a4-a148-634660e8d38b"",
            ""actions"": [
                {
                    ""name"": ""ConvertHitsoundKick"",
                    ""type"": ""Button"",
                    ""id"": ""875e2bee-7e9b-48e2-bc4b-a771dca64103"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertHitsoundSnare"",
                    ""type"": ""Button"",
                    ""id"": ""23170cd3-9ad3-46aa-ac7b-420a8cba8a8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertHitsoundPercussion"",
                    ""type"": ""Button"",
                    ""id"": ""47a759cc-48c8-4e03-9c4c-41dcc6f777fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertHitsoundChainstart"",
                    ""type"": ""Button"",
                    ""id"": ""4fcc0e55-4f0e-450c-be72-4956140711f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertHitsoundChain"",
                    ""type"": ""Button"",
                    ""id"": ""c9b1bc60-db00-4e98-8e7e-f9e3b7c5f245"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertHitsoundMelee"",
                    ""type"": ""Button"",
                    ""id"": ""b2d71fad-c681-4455-be2c-9c5315493654"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConvertHitsoundSilent"",
                    ""type"": ""Button"",
                    ""id"": ""5becb66b-122d-4c92-ba67-3493449cb17d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""4a78b5fa-2c30-4c98-a59c-f44068e6a505"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundKick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""328a2f3c-8552-4df4-9fab-a7e013237301"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundKick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""9325a1f4-f5a2-48c3-ba56-072bc06aafff"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundKick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""f977ce98-e61b-4241-893e-157db86c2a95"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundSnare"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""4f801ca7-ed25-4d77-a033-5c1f390f6a53"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundSnare"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""df1cb619-1ffa-4b68-9a70-ce73d68e7ea3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundSnare"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""e343cc5f-2921-422d-b066-e9833ceaccd3"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundPercussion"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""ef9b8f81-58c5-4f02-bda4-9e74bae2ca9a"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundPercussion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""c6a5db98-9057-4c54-a390-04fbdc62d9d8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundPercussion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""6165a924-ae4b-4af0-ae68-53a70cefc12f"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundChainstart"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""7736ff76-a4b6-4a49-9b0b-d0d9fd7e9332"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundChainstart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""21a45ebd-15d7-456d-98e4-b898ffe315f6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundChainstart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""b48577e2-cb3a-479b-b1f7-b9a6c4b7386f"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundChain"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""4fda5dc8-9a59-48d7-8c5d-7505c266e532"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundChain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""11598d8a-0f3a-434e-8ba9-6e88ef0d6c5e"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundChain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With Two Modifiers"",
                    ""id"": ""b33737e4-cd02-4cef-a92a-b31713da34be"",
                    ""path"": ""ButtonWithTwoModifiers"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundMelee"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier1"",
                    ""id"": ""4a137895-7191-4fdc-87ea-dfd00dc0d4d6"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""d054dc87-f354-488c-b52c-5c7153f60d08"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""95ce1028-9acc-4390-b487-2c9e73e82a6f"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""25efb5d6-b10e-43c1-8a86-494161a78376"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundSilent"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""a6b74f37-7c08-40f8-a05b-d0476e90a434"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundSilent"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""a9fadb55-7e0d-4882-b5ad-99255b40302a"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConvertHitsoundSilent"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
        // Mapping
        m_Mapping = asset.FindActionMap("Mapping", throwIfNotFound: true);
        m_Mapping_PlaceNote = m_Mapping.FindAction("PlaceNote", throwIfNotFound: true);
        m_Mapping_RemoveNote = m_Mapping.FindAction("RemoveNote", throwIfNotFound: true);
        m_Mapping_SwitchHand = m_Mapping.FindAction("SwitchHand", throwIfNotFound: true);
        m_Mapping_FlipTargetColors = m_Mapping.FindAction("FlipTargetColors", throwIfNotFound: true);
        m_Mapping_DeleteSelectedTargets = m_Mapping.FindAction("DeleteSelectedTargets", throwIfNotFound: true);
        // Utility
        m_Utility = asset.FindActionMap("Utility", throwIfNotFound: true);
        m_Utility_SelectAll = m_Utility.FindAction("SelectAll", throwIfNotFound: true);
        m_Utility_DeselectAll = m_Utility.FindAction("DeselectAll", throwIfNotFound: true);
        m_Utility_Copy = m_Utility.FindAction("Copy", throwIfNotFound: true);
        m_Utility_Cut = m_Utility.FindAction("Cut", throwIfNotFound: true);
        m_Utility_Paste = m_Utility.FindAction("Paste", throwIfNotFound: true);
        m_Utility_Save = m_Utility.FindAction("Save", throwIfNotFound: true);
        m_Utility_Undo = m_Utility.FindAction("Undo", throwIfNotFound: true);
        m_Utility_Redo = m_Utility.FindAction("Redo", throwIfNotFound: true);
        // Menus
        m_Menus = asset.FindActionMap("Menus", throwIfNotFound: true);
        m_Menus_Countin = m_Menus.FindAction("Countin", throwIfNotFound: true);
        m_Menus_ModifyAudio = m_Menus.FindAction("ModifyAudio", throwIfNotFound: true);
        m_Menus_TimingPoints = m_Menus.FindAction("TimingPoints", throwIfNotFound: true);
        m_Menus_ModifierHelp = m_Menus.FindAction("ModifierHelp", throwIfNotFound: true);
        m_Menus_ReviewMenu = m_Menus.FindAction("ReviewMenu", throwIfNotFound: true);
        m_Menus_Bookmark = m_Menus.FindAction("Bookmark", throwIfNotFound: true);
        m_Menus_Pause = m_Menus.FindAction("Pause", throwIfNotFound: true);
        m_Menus_Help = m_Menus.FindAction("Help", throwIfNotFound: true);
        // Timeline
        m_Timeline = asset.FindActionMap("Timeline", throwIfNotFound: true);
        m_Timeline_TogglePlay = m_Timeline.FindAction("TogglePlay", throwIfNotFound: true);
        m_Timeline_Scrub = m_Timeline.FindAction("Scrub", throwIfNotFound: true);
        m_Timeline_ScrubByTick = m_Timeline.FindAction("ScrubByTick", throwIfNotFound: true);
        m_Timeline_ChangeBeatSnap = m_Timeline.FindAction("ChangeBeatSnap", throwIfNotFound: true);
        m_Timeline_ZoomTimeline = m_Timeline.FindAction("ZoomTimeline", throwIfNotFound: true);
        m_Timeline_StartMetronome = m_Timeline.FindAction("StartMetronome", throwIfNotFound: true);
        m_Timeline_ToggleWaveform = m_Timeline.FindAction("ToggleWaveform", throwIfNotFound: true);
        // DragSelect
        m_DragSelect = asset.FindActionMap("DragSelect", throwIfNotFound: true);
        m_DragSelect_SelectDragTool = m_DragSelect.FindAction("SelectDragTool", throwIfNotFound: true);
        m_DragSelect_MoveTargets = m_DragSelect.FindAction("MoveTargets", throwIfNotFound: true);
        m_DragSelect_MoveTargetsQuarterModifier = m_DragSelect.FindAction("MoveTargetsQuarterModifier", throwIfNotFound: true);
        m_DragSelect_MoveTargetsHalfModifier = m_DragSelect.FindAction("MoveTargetsHalfModifier", throwIfNotFound: true);
        m_DragSelect_FlipTargetsVertically = m_DragSelect.FindAction("FlipTargetsVertically", throwIfNotFound: true);
        m_DragSelect_FlipTargetsHorizontally = m_DragSelect.FindAction("FlipTargetsHorizontally", throwIfNotFound: true);
        m_DragSelect_IncreaseScaleVertically = m_DragSelect.FindAction("IncreaseScaleVertically", throwIfNotFound: true);
        m_DragSelect_DecreaseScaleVertically = m_DragSelect.FindAction("DecreaseScaleVertically", throwIfNotFound: true);
        m_DragSelect_IncreaseScaleHorizontally = m_DragSelect.FindAction("IncreaseScaleHorizontally", throwIfNotFound: true);
        m_DragSelect_DecreaseScaleHorizontally = m_DragSelect.FindAction("DecreaseScaleHorizontally", throwIfNotFound: true);
        m_DragSelect_ReverseSelectedTargets = m_DragSelect.FindAction("ReverseSelectedTargets", throwIfNotFound: true);
        m_DragSelect_RotateSelectedTargetsRight = m_DragSelect.FindAction("RotateSelectedTargetsRight", throwIfNotFound: true);
        m_DragSelect_RotateSelectedTargetsLeft = m_DragSelect.FindAction("RotateSelectedTargetsLeft", throwIfNotFound: true);
        // Grid
        m_Grid = asset.FindActionMap("Grid", throwIfNotFound: true);
        m_Grid_GridView = m_Grid.FindAction("GridView", throwIfNotFound: true);
        m_Grid_NoGridView = m_Grid.FindAction("NoGridView", throwIfNotFound: true);
        m_Grid_MeleeView = m_Grid.FindAction("MeleeView", throwIfNotFound: true);
        m_Grid_QuickSwitchGrid = m_Grid.FindAction("QuickSwitchGrid", throwIfNotFound: true);
        m_Grid_MoveGrid = m_Grid.FindAction("MoveGrid", throwIfNotFound: true);
        // BPM
        m_BPM = asset.FindActionMap("BPM", throwIfNotFound: true);
        m_BPM_DetectBPM = m_BPM.FindAction("DetectBPM", throwIfNotFound: true);
        m_BPM_ShiftBPMMarker = m_BPM.FindAction("ShiftBPMMarker", throwIfNotFound: true);
        m_BPM_BPMMarker = m_BPM.FindAction("BPMMarker", throwIfNotFound: true);
        m_BPM_PreviewPoint = m_BPM.FindAction("PreviewPoint", throwIfNotFound: true);
        // SpacingSnap
        m_SpacingSnap = asset.FindActionMap("SpacingSnap", throwIfNotFound: true);
        m_SpacingSnap_EnableSpacingSnap = m_SpacingSnap.FindAction("EnableSpacingSnap", throwIfNotFound: true);
        // Pathbuilder
        m_Pathbuilder = asset.FindActionMap("Pathbuilder", throwIfNotFound: true);
        m_Pathbuilder_EnablePathbuilder = m_Pathbuilder.FindAction("EnablePathbuilder", throwIfNotFound: true);
        // Modifiers
        m_Modifiers = asset.FindActionMap("Modifiers", throwIfNotFound: true);
        m_Modifiers_OpenModifiers = m_Modifiers.FindAction("OpenModifiers", throwIfNotFound: true);
        m_Modifiers_ModifierPreview = m_Modifiers.FindAction("ModifierPreview", throwIfNotFound: true);
        // BehaviorSelect
        m_BehaviorSelect = asset.FindActionMap("BehaviorSelect", throwIfNotFound: true);
        m_BehaviorSelect_SelectBehaviorStandard = m_BehaviorSelect.FindAction("SelectBehaviorStandard", throwIfNotFound: true);
        m_BehaviorSelect_SelectBehaviorSustain = m_BehaviorSelect.FindAction("SelectBehaviorSustain", throwIfNotFound: true);
        m_BehaviorSelect_SelectBehaviorMine = m_BehaviorSelect.FindAction("SelectBehaviorMine", throwIfNotFound: true);
        m_BehaviorSelect_SelectBehaviorMelee = m_BehaviorSelect.FindAction("SelectBehaviorMelee", throwIfNotFound: true);
        m_BehaviorSelect_SelectBehaviorChain = m_BehaviorSelect.FindAction("SelectBehaviorChain", throwIfNotFound: true);
        m_BehaviorSelect_SelectBehaviorChainstart = m_BehaviorSelect.FindAction("SelectBehaviorChainstart", throwIfNotFound: true);
        m_BehaviorSelect_SelectBehaviorVertical = m_BehaviorSelect.FindAction("SelectBehaviorVertical", throwIfNotFound: true);
        m_BehaviorSelect_SelectBehaviorHorizontal = m_BehaviorSelect.FindAction("SelectBehaviorHorizontal", throwIfNotFound: true);
        // BehaviorConvert
        m_BehaviorConvert = asset.FindActionMap("BehaviorConvert", throwIfNotFound: true);
        m_BehaviorConvert_ConvertBehaviorStandard = m_BehaviorConvert.FindAction("ConvertBehaviorStandard", throwIfNotFound: true);
        m_BehaviorConvert_ConvertBehaviorSustain = m_BehaviorConvert.FindAction("ConvertBehaviorSustain", throwIfNotFound: true);
        m_BehaviorConvert_ConvertBehaviorVertical = m_BehaviorConvert.FindAction("ConvertBehaviorVertical", throwIfNotFound: true);
        m_BehaviorConvert_ConvertBehaviorHorizontal = m_BehaviorConvert.FindAction("ConvertBehaviorHorizontal", throwIfNotFound: true);
        m_BehaviorConvert_ConvertBehaviorChainstart = m_BehaviorConvert.FindAction("ConvertBehaviorChainstart", throwIfNotFound: true);
        m_BehaviorConvert_ConvertBehaviorChain = m_BehaviorConvert.FindAction("ConvertBehaviorChain", throwIfNotFound: true);
        m_BehaviorConvert_ConvertBehaviorMelee = m_BehaviorConvert.FindAction("ConvertBehaviorMelee", throwIfNotFound: true);
        m_BehaviorConvert_ConvertBehaviorMine = m_BehaviorConvert.FindAction("ConvertBehaviorMine", throwIfNotFound: true);
        // HitsoundSelect
        m_HitsoundSelect = asset.FindActionMap("HitsoundSelect", throwIfNotFound: true);
        m_HitsoundSelect_SelectHitsoundKick = m_HitsoundSelect.FindAction("SelectHitsoundKick", throwIfNotFound: true);
        m_HitsoundSelect_SelectHitsoundSnare = m_HitsoundSelect.FindAction("SelectHitsoundSnare", throwIfNotFound: true);
        m_HitsoundSelect_SelectHitsoundPercussion = m_HitsoundSelect.FindAction("SelectHitsoundPercussion", throwIfNotFound: true);
        m_HitsoundSelect_SelectHitsoundChainstart = m_HitsoundSelect.FindAction("SelectHitsoundChainstart", throwIfNotFound: true);
        m_HitsoundSelect_SelectHitsoundChain = m_HitsoundSelect.FindAction("SelectHitsoundChain", throwIfNotFound: true);
        m_HitsoundSelect_SelectHitsoundMelee = m_HitsoundSelect.FindAction("SelectHitsoundMelee", throwIfNotFound: true);
        m_HitsoundSelect_SelectHitsoundSilent = m_HitsoundSelect.FindAction("SelectHitsoundSilent", throwIfNotFound: true);
        // HitsoundConvert
        m_HitsoundConvert = asset.FindActionMap("HitsoundConvert", throwIfNotFound: true);
        m_HitsoundConvert_ConvertHitsoundKick = m_HitsoundConvert.FindAction("ConvertHitsoundKick", throwIfNotFound: true);
        m_HitsoundConvert_ConvertHitsoundSnare = m_HitsoundConvert.FindAction("ConvertHitsoundSnare", throwIfNotFound: true);
        m_HitsoundConvert_ConvertHitsoundPercussion = m_HitsoundConvert.FindAction("ConvertHitsoundPercussion", throwIfNotFound: true);
        m_HitsoundConvert_ConvertHitsoundChainstart = m_HitsoundConvert.FindAction("ConvertHitsoundChainstart", throwIfNotFound: true);
        m_HitsoundConvert_ConvertHitsoundChain = m_HitsoundConvert.FindAction("ConvertHitsoundChain", throwIfNotFound: true);
        m_HitsoundConvert_ConvertHitsoundMelee = m_HitsoundConvert.FindAction("ConvertHitsoundMelee", throwIfNotFound: true);
        m_HitsoundConvert_ConvertHitsoundSilent = m_HitsoundConvert.FindAction("ConvertHitsoundSilent", throwIfNotFound: true);
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

    // Mapping
    private readonly InputActionMap m_Mapping;
    private IMappingActions m_MappingActionsCallbackInterface;
    private readonly InputAction m_Mapping_PlaceNote;
    private readonly InputAction m_Mapping_RemoveNote;
    private readonly InputAction m_Mapping_SwitchHand;
    private readonly InputAction m_Mapping_FlipTargetColors;
    private readonly InputAction m_Mapping_DeleteSelectedTargets;
    public struct MappingActions
    {
        private @EditorKeybinds m_Wrapper;
        public MappingActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlaceNote => m_Wrapper.m_Mapping_PlaceNote;
        public InputAction @RemoveNote => m_Wrapper.m_Mapping_RemoveNote;
        public InputAction @SwitchHand => m_Wrapper.m_Mapping_SwitchHand;
        public InputAction @FlipTargetColors => m_Wrapper.m_Mapping_FlipTargetColors;
        public InputAction @DeleteSelectedTargets => m_Wrapper.m_Mapping_DeleteSelectedTargets;
        public InputActionMap Get() { return m_Wrapper.m_Mapping; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MappingActions set) { return set.Get(); }
        public void SetCallbacks(IMappingActions instance)
        {
            if (m_Wrapper.m_MappingActionsCallbackInterface != null)
            {
                @PlaceNote.started -= m_Wrapper.m_MappingActionsCallbackInterface.OnPlaceNote;
                @PlaceNote.performed -= m_Wrapper.m_MappingActionsCallbackInterface.OnPlaceNote;
                @PlaceNote.canceled -= m_Wrapper.m_MappingActionsCallbackInterface.OnPlaceNote;
                @RemoveNote.started -= m_Wrapper.m_MappingActionsCallbackInterface.OnRemoveNote;
                @RemoveNote.performed -= m_Wrapper.m_MappingActionsCallbackInterface.OnRemoveNote;
                @RemoveNote.canceled -= m_Wrapper.m_MappingActionsCallbackInterface.OnRemoveNote;
                @SwitchHand.started -= m_Wrapper.m_MappingActionsCallbackInterface.OnSwitchHand;
                @SwitchHand.performed -= m_Wrapper.m_MappingActionsCallbackInterface.OnSwitchHand;
                @SwitchHand.canceled -= m_Wrapper.m_MappingActionsCallbackInterface.OnSwitchHand;
                @FlipTargetColors.started -= m_Wrapper.m_MappingActionsCallbackInterface.OnFlipTargetColors;
                @FlipTargetColors.performed -= m_Wrapper.m_MappingActionsCallbackInterface.OnFlipTargetColors;
                @FlipTargetColors.canceled -= m_Wrapper.m_MappingActionsCallbackInterface.OnFlipTargetColors;
                @DeleteSelectedTargets.started -= m_Wrapper.m_MappingActionsCallbackInterface.OnDeleteSelectedTargets;
                @DeleteSelectedTargets.performed -= m_Wrapper.m_MappingActionsCallbackInterface.OnDeleteSelectedTargets;
                @DeleteSelectedTargets.canceled -= m_Wrapper.m_MappingActionsCallbackInterface.OnDeleteSelectedTargets;
            }
            m_Wrapper.m_MappingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlaceNote.started += instance.OnPlaceNote;
                @PlaceNote.performed += instance.OnPlaceNote;
                @PlaceNote.canceled += instance.OnPlaceNote;
                @RemoveNote.started += instance.OnRemoveNote;
                @RemoveNote.performed += instance.OnRemoveNote;
                @RemoveNote.canceled += instance.OnRemoveNote;
                @SwitchHand.started += instance.OnSwitchHand;
                @SwitchHand.performed += instance.OnSwitchHand;
                @SwitchHand.canceled += instance.OnSwitchHand;
                @FlipTargetColors.started += instance.OnFlipTargetColors;
                @FlipTargetColors.performed += instance.OnFlipTargetColors;
                @FlipTargetColors.canceled += instance.OnFlipTargetColors;
                @DeleteSelectedTargets.started += instance.OnDeleteSelectedTargets;
                @DeleteSelectedTargets.performed += instance.OnDeleteSelectedTargets;
                @DeleteSelectedTargets.canceled += instance.OnDeleteSelectedTargets;
            }
        }
    }
    public MappingActions @Mapping => new MappingActions(this);

    // Utility
    private readonly InputActionMap m_Utility;
    private IUtilityActions m_UtilityActionsCallbackInterface;
    private readonly InputAction m_Utility_SelectAll;
    private readonly InputAction m_Utility_DeselectAll;
    private readonly InputAction m_Utility_Copy;
    private readonly InputAction m_Utility_Cut;
    private readonly InputAction m_Utility_Paste;
    private readonly InputAction m_Utility_Save;
    private readonly InputAction m_Utility_Undo;
    private readonly InputAction m_Utility_Redo;
    public struct UtilityActions
    {
        private @EditorKeybinds m_Wrapper;
        public UtilityActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectAll => m_Wrapper.m_Utility_SelectAll;
        public InputAction @DeselectAll => m_Wrapper.m_Utility_DeselectAll;
        public InputAction @Copy => m_Wrapper.m_Utility_Copy;
        public InputAction @Cut => m_Wrapper.m_Utility_Cut;
        public InputAction @Paste => m_Wrapper.m_Utility_Paste;
        public InputAction @Save => m_Wrapper.m_Utility_Save;
        public InputAction @Undo => m_Wrapper.m_Utility_Undo;
        public InputAction @Redo => m_Wrapper.m_Utility_Redo;
        public InputActionMap Get() { return m_Wrapper.m_Utility; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UtilityActions set) { return set.Get(); }
        public void SetCallbacks(IUtilityActions instance)
        {
            if (m_Wrapper.m_UtilityActionsCallbackInterface != null)
            {
                @SelectAll.started -= m_Wrapper.m_UtilityActionsCallbackInterface.OnSelectAll;
                @SelectAll.performed -= m_Wrapper.m_UtilityActionsCallbackInterface.OnSelectAll;
                @SelectAll.canceled -= m_Wrapper.m_UtilityActionsCallbackInterface.OnSelectAll;
                @DeselectAll.started -= m_Wrapper.m_UtilityActionsCallbackInterface.OnDeselectAll;
                @DeselectAll.performed -= m_Wrapper.m_UtilityActionsCallbackInterface.OnDeselectAll;
                @DeselectAll.canceled -= m_Wrapper.m_UtilityActionsCallbackInterface.OnDeselectAll;
                @Copy.started -= m_Wrapper.m_UtilityActionsCallbackInterface.OnCopy;
                @Copy.performed -= m_Wrapper.m_UtilityActionsCallbackInterface.OnCopy;
                @Copy.canceled -= m_Wrapper.m_UtilityActionsCallbackInterface.OnCopy;
                @Cut.started -= m_Wrapper.m_UtilityActionsCallbackInterface.OnCut;
                @Cut.performed -= m_Wrapper.m_UtilityActionsCallbackInterface.OnCut;
                @Cut.canceled -= m_Wrapper.m_UtilityActionsCallbackInterface.OnCut;
                @Paste.started -= m_Wrapper.m_UtilityActionsCallbackInterface.OnPaste;
                @Paste.performed -= m_Wrapper.m_UtilityActionsCallbackInterface.OnPaste;
                @Paste.canceled -= m_Wrapper.m_UtilityActionsCallbackInterface.OnPaste;
                @Save.started -= m_Wrapper.m_UtilityActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_UtilityActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_UtilityActionsCallbackInterface.OnSave;
                @Undo.started -= m_Wrapper.m_UtilityActionsCallbackInterface.OnUndo;
                @Undo.performed -= m_Wrapper.m_UtilityActionsCallbackInterface.OnUndo;
                @Undo.canceled -= m_Wrapper.m_UtilityActionsCallbackInterface.OnUndo;
                @Redo.started -= m_Wrapper.m_UtilityActionsCallbackInterface.OnRedo;
                @Redo.performed -= m_Wrapper.m_UtilityActionsCallbackInterface.OnRedo;
                @Redo.canceled -= m_Wrapper.m_UtilityActionsCallbackInterface.OnRedo;
            }
            m_Wrapper.m_UtilityActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectAll.started += instance.OnSelectAll;
                @SelectAll.performed += instance.OnSelectAll;
                @SelectAll.canceled += instance.OnSelectAll;
                @DeselectAll.started += instance.OnDeselectAll;
                @DeselectAll.performed += instance.OnDeselectAll;
                @DeselectAll.canceled += instance.OnDeselectAll;
                @Copy.started += instance.OnCopy;
                @Copy.performed += instance.OnCopy;
                @Copy.canceled += instance.OnCopy;
                @Cut.started += instance.OnCut;
                @Cut.performed += instance.OnCut;
                @Cut.canceled += instance.OnCut;
                @Paste.started += instance.OnPaste;
                @Paste.performed += instance.OnPaste;
                @Paste.canceled += instance.OnPaste;
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
                @Undo.started += instance.OnUndo;
                @Undo.performed += instance.OnUndo;
                @Undo.canceled += instance.OnUndo;
                @Redo.started += instance.OnRedo;
                @Redo.performed += instance.OnRedo;
                @Redo.canceled += instance.OnRedo;
            }
        }
    }
    public UtilityActions @Utility => new UtilityActions(this);

    // Menus
    private readonly InputActionMap m_Menus;
    private IMenusActions m_MenusActionsCallbackInterface;
    private readonly InputAction m_Menus_Countin;
    private readonly InputAction m_Menus_ModifyAudio;
    private readonly InputAction m_Menus_TimingPoints;
    private readonly InputAction m_Menus_ModifierHelp;
    private readonly InputAction m_Menus_ReviewMenu;
    private readonly InputAction m_Menus_Bookmark;
    private readonly InputAction m_Menus_Pause;
    private readonly InputAction m_Menus_Help;
    public struct MenusActions
    {
        private @EditorKeybinds m_Wrapper;
        public MenusActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @Countin => m_Wrapper.m_Menus_Countin;
        public InputAction @ModifyAudio => m_Wrapper.m_Menus_ModifyAudio;
        public InputAction @TimingPoints => m_Wrapper.m_Menus_TimingPoints;
        public InputAction @ModifierHelp => m_Wrapper.m_Menus_ModifierHelp;
        public InputAction @ReviewMenu => m_Wrapper.m_Menus_ReviewMenu;
        public InputAction @Bookmark => m_Wrapper.m_Menus_Bookmark;
        public InputAction @Pause => m_Wrapper.m_Menus_Pause;
        public InputAction @Help => m_Wrapper.m_Menus_Help;
        public InputActionMap Get() { return m_Wrapper.m_Menus; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenusActions set) { return set.Get(); }
        public void SetCallbacks(IMenusActions instance)
        {
            if (m_Wrapper.m_MenusActionsCallbackInterface != null)
            {
                @Countin.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnCountin;
                @Countin.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnCountin;
                @Countin.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnCountin;
                @ModifyAudio.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnModifyAudio;
                @ModifyAudio.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnModifyAudio;
                @ModifyAudio.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnModifyAudio;
                @TimingPoints.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnTimingPoints;
                @TimingPoints.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnTimingPoints;
                @TimingPoints.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnTimingPoints;
                @ModifierHelp.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnModifierHelp;
                @ModifierHelp.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnModifierHelp;
                @ModifierHelp.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnModifierHelp;
                @ReviewMenu.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnReviewMenu;
                @ReviewMenu.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnReviewMenu;
                @ReviewMenu.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnReviewMenu;
                @Bookmark.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnBookmark;
                @Bookmark.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnBookmark;
                @Bookmark.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnBookmark;
                @Pause.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnPause;
                @Help.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnHelp;
                @Help.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnHelp;
                @Help.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnHelp;
            }
            m_Wrapper.m_MenusActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Countin.started += instance.OnCountin;
                @Countin.performed += instance.OnCountin;
                @Countin.canceled += instance.OnCountin;
                @ModifyAudio.started += instance.OnModifyAudio;
                @ModifyAudio.performed += instance.OnModifyAudio;
                @ModifyAudio.canceled += instance.OnModifyAudio;
                @TimingPoints.started += instance.OnTimingPoints;
                @TimingPoints.performed += instance.OnTimingPoints;
                @TimingPoints.canceled += instance.OnTimingPoints;
                @ModifierHelp.started += instance.OnModifierHelp;
                @ModifierHelp.performed += instance.OnModifierHelp;
                @ModifierHelp.canceled += instance.OnModifierHelp;
                @ReviewMenu.started += instance.OnReviewMenu;
                @ReviewMenu.performed += instance.OnReviewMenu;
                @ReviewMenu.canceled += instance.OnReviewMenu;
                @Bookmark.started += instance.OnBookmark;
                @Bookmark.performed += instance.OnBookmark;
                @Bookmark.canceled += instance.OnBookmark;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Help.started += instance.OnHelp;
                @Help.performed += instance.OnHelp;
                @Help.canceled += instance.OnHelp;
            }
        }
    }
    public MenusActions @Menus => new MenusActions(this);

    // Timeline
    private readonly InputActionMap m_Timeline;
    private ITimelineActions m_TimelineActionsCallbackInterface;
    private readonly InputAction m_Timeline_TogglePlay;
    private readonly InputAction m_Timeline_Scrub;
    private readonly InputAction m_Timeline_ScrubByTick;
    private readonly InputAction m_Timeline_ChangeBeatSnap;
    private readonly InputAction m_Timeline_ZoomTimeline;
    private readonly InputAction m_Timeline_StartMetronome;
    private readonly InputAction m_Timeline_ToggleWaveform;
    public struct TimelineActions
    {
        private @EditorKeybinds m_Wrapper;
        public TimelineActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @TogglePlay => m_Wrapper.m_Timeline_TogglePlay;
        public InputAction @Scrub => m_Wrapper.m_Timeline_Scrub;
        public InputAction @ScrubByTick => m_Wrapper.m_Timeline_ScrubByTick;
        public InputAction @ChangeBeatSnap => m_Wrapper.m_Timeline_ChangeBeatSnap;
        public InputAction @ZoomTimeline => m_Wrapper.m_Timeline_ZoomTimeline;
        public InputAction @StartMetronome => m_Wrapper.m_Timeline_StartMetronome;
        public InputAction @ToggleWaveform => m_Wrapper.m_Timeline_ToggleWaveform;
        public InputActionMap Get() { return m_Wrapper.m_Timeline; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TimelineActions set) { return set.Get(); }
        public void SetCallbacks(ITimelineActions instance)
        {
            if (m_Wrapper.m_TimelineActionsCallbackInterface != null)
            {
                @TogglePlay.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnTogglePlay;
                @TogglePlay.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnTogglePlay;
                @TogglePlay.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnTogglePlay;
                @Scrub.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnScrub;
                @Scrub.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnScrub;
                @Scrub.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnScrub;
                @ScrubByTick.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnScrubByTick;
                @ScrubByTick.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnScrubByTick;
                @ScrubByTick.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnScrubByTick;
                @ChangeBeatSnap.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnChangeBeatSnap;
                @ChangeBeatSnap.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnChangeBeatSnap;
                @ChangeBeatSnap.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnChangeBeatSnap;
                @ZoomTimeline.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnZoomTimeline;
                @ZoomTimeline.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnZoomTimeline;
                @ZoomTimeline.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnZoomTimeline;
                @StartMetronome.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnStartMetronome;
                @StartMetronome.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnStartMetronome;
                @StartMetronome.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnStartMetronome;
                @ToggleWaveform.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnToggleWaveform;
                @ToggleWaveform.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnToggleWaveform;
                @ToggleWaveform.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnToggleWaveform;
            }
            m_Wrapper.m_TimelineActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TogglePlay.started += instance.OnTogglePlay;
                @TogglePlay.performed += instance.OnTogglePlay;
                @TogglePlay.canceled += instance.OnTogglePlay;
                @Scrub.started += instance.OnScrub;
                @Scrub.performed += instance.OnScrub;
                @Scrub.canceled += instance.OnScrub;
                @ScrubByTick.started += instance.OnScrubByTick;
                @ScrubByTick.performed += instance.OnScrubByTick;
                @ScrubByTick.canceled += instance.OnScrubByTick;
                @ChangeBeatSnap.started += instance.OnChangeBeatSnap;
                @ChangeBeatSnap.performed += instance.OnChangeBeatSnap;
                @ChangeBeatSnap.canceled += instance.OnChangeBeatSnap;
                @ZoomTimeline.started += instance.OnZoomTimeline;
                @ZoomTimeline.performed += instance.OnZoomTimeline;
                @ZoomTimeline.canceled += instance.OnZoomTimeline;
                @StartMetronome.started += instance.OnStartMetronome;
                @StartMetronome.performed += instance.OnStartMetronome;
                @StartMetronome.canceled += instance.OnStartMetronome;
                @ToggleWaveform.started += instance.OnToggleWaveform;
                @ToggleWaveform.performed += instance.OnToggleWaveform;
                @ToggleWaveform.canceled += instance.OnToggleWaveform;
            }
        }
    }
    public TimelineActions @Timeline => new TimelineActions(this);

    // DragSelect
    private readonly InputActionMap m_DragSelect;
    private IDragSelectActions m_DragSelectActionsCallbackInterface;
    private readonly InputAction m_DragSelect_SelectDragTool;
    private readonly InputAction m_DragSelect_MoveTargets;
    private readonly InputAction m_DragSelect_MoveTargetsQuarterModifier;
    private readonly InputAction m_DragSelect_MoveTargetsHalfModifier;
    private readonly InputAction m_DragSelect_FlipTargetsVertically;
    private readonly InputAction m_DragSelect_FlipTargetsHorizontally;
    private readonly InputAction m_DragSelect_IncreaseScaleVertically;
    private readonly InputAction m_DragSelect_DecreaseScaleVertically;
    private readonly InputAction m_DragSelect_IncreaseScaleHorizontally;
    private readonly InputAction m_DragSelect_DecreaseScaleHorizontally;
    private readonly InputAction m_DragSelect_ReverseSelectedTargets;
    private readonly InputAction m_DragSelect_RotateSelectedTargetsRight;
    private readonly InputAction m_DragSelect_RotateSelectedTargetsLeft;
    public struct DragSelectActions
    {
        private @EditorKeybinds m_Wrapper;
        public DragSelectActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectDragTool => m_Wrapper.m_DragSelect_SelectDragTool;
        public InputAction @MoveTargets => m_Wrapper.m_DragSelect_MoveTargets;
        public InputAction @MoveTargetsQuarterModifier => m_Wrapper.m_DragSelect_MoveTargetsQuarterModifier;
        public InputAction @MoveTargetsHalfModifier => m_Wrapper.m_DragSelect_MoveTargetsHalfModifier;
        public InputAction @FlipTargetsVertically => m_Wrapper.m_DragSelect_FlipTargetsVertically;
        public InputAction @FlipTargetsHorizontally => m_Wrapper.m_DragSelect_FlipTargetsHorizontally;
        public InputAction @IncreaseScaleVertically => m_Wrapper.m_DragSelect_IncreaseScaleVertically;
        public InputAction @DecreaseScaleVertically => m_Wrapper.m_DragSelect_DecreaseScaleVertically;
        public InputAction @IncreaseScaleHorizontally => m_Wrapper.m_DragSelect_IncreaseScaleHorizontally;
        public InputAction @DecreaseScaleHorizontally => m_Wrapper.m_DragSelect_DecreaseScaleHorizontally;
        public InputAction @ReverseSelectedTargets => m_Wrapper.m_DragSelect_ReverseSelectedTargets;
        public InputAction @RotateSelectedTargetsRight => m_Wrapper.m_DragSelect_RotateSelectedTargetsRight;
        public InputAction @RotateSelectedTargetsLeft => m_Wrapper.m_DragSelect_RotateSelectedTargetsLeft;
        public InputActionMap Get() { return m_Wrapper.m_DragSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DragSelectActions set) { return set.Get(); }
        public void SetCallbacks(IDragSelectActions instance)
        {
            if (m_Wrapper.m_DragSelectActionsCallbackInterface != null)
            {
                @SelectDragTool.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnSelectDragTool;
                @SelectDragTool.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnSelectDragTool;
                @SelectDragTool.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnSelectDragTool;
                @MoveTargets.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMoveTargets;
                @MoveTargets.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMoveTargets;
                @MoveTargets.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMoveTargets;
                @MoveTargetsQuarterModifier.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMoveTargetsQuarterModifier;
                @MoveTargetsQuarterModifier.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMoveTargetsQuarterModifier;
                @MoveTargetsQuarterModifier.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMoveTargetsQuarterModifier;
                @MoveTargetsHalfModifier.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMoveTargetsHalfModifier;
                @MoveTargetsHalfModifier.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMoveTargetsHalfModifier;
                @MoveTargetsHalfModifier.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnMoveTargetsHalfModifier;
                @FlipTargetsVertically.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnFlipTargetsVertically;
                @FlipTargetsVertically.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnFlipTargetsVertically;
                @FlipTargetsVertically.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnFlipTargetsVertically;
                @FlipTargetsHorizontally.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnFlipTargetsHorizontally;
                @FlipTargetsHorizontally.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnFlipTargetsHorizontally;
                @FlipTargetsHorizontally.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnFlipTargetsHorizontally;
                @IncreaseScaleVertically.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnIncreaseScaleVertically;
                @IncreaseScaleVertically.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnIncreaseScaleVertically;
                @IncreaseScaleVertically.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnIncreaseScaleVertically;
                @DecreaseScaleVertically.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnDecreaseScaleVertically;
                @DecreaseScaleVertically.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnDecreaseScaleVertically;
                @DecreaseScaleVertically.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnDecreaseScaleVertically;
                @IncreaseScaleHorizontally.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnIncreaseScaleHorizontally;
                @IncreaseScaleHorizontally.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnIncreaseScaleHorizontally;
                @IncreaseScaleHorizontally.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnIncreaseScaleHorizontally;
                @DecreaseScaleHorizontally.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnDecreaseScaleHorizontally;
                @DecreaseScaleHorizontally.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnDecreaseScaleHorizontally;
                @DecreaseScaleHorizontally.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnDecreaseScaleHorizontally;
                @ReverseSelectedTargets.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnReverseSelectedTargets;
                @ReverseSelectedTargets.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnReverseSelectedTargets;
                @ReverseSelectedTargets.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnReverseSelectedTargets;
                @RotateSelectedTargetsRight.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnRotateSelectedTargetsRight;
                @RotateSelectedTargetsRight.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnRotateSelectedTargetsRight;
                @RotateSelectedTargetsRight.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnRotateSelectedTargetsRight;
                @RotateSelectedTargetsLeft.started -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnRotateSelectedTargetsLeft;
                @RotateSelectedTargetsLeft.performed -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnRotateSelectedTargetsLeft;
                @RotateSelectedTargetsLeft.canceled -= m_Wrapper.m_DragSelectActionsCallbackInterface.OnRotateSelectedTargetsLeft;
            }
            m_Wrapper.m_DragSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectDragTool.started += instance.OnSelectDragTool;
                @SelectDragTool.performed += instance.OnSelectDragTool;
                @SelectDragTool.canceled += instance.OnSelectDragTool;
                @MoveTargets.started += instance.OnMoveTargets;
                @MoveTargets.performed += instance.OnMoveTargets;
                @MoveTargets.canceled += instance.OnMoveTargets;
                @MoveTargetsQuarterModifier.started += instance.OnMoveTargetsQuarterModifier;
                @MoveTargetsQuarterModifier.performed += instance.OnMoveTargetsQuarterModifier;
                @MoveTargetsQuarterModifier.canceled += instance.OnMoveTargetsQuarterModifier;
                @MoveTargetsHalfModifier.started += instance.OnMoveTargetsHalfModifier;
                @MoveTargetsHalfModifier.performed += instance.OnMoveTargetsHalfModifier;
                @MoveTargetsHalfModifier.canceled += instance.OnMoveTargetsHalfModifier;
                @FlipTargetsVertically.started += instance.OnFlipTargetsVertically;
                @FlipTargetsVertically.performed += instance.OnFlipTargetsVertically;
                @FlipTargetsVertically.canceled += instance.OnFlipTargetsVertically;
                @FlipTargetsHorizontally.started += instance.OnFlipTargetsHorizontally;
                @FlipTargetsHorizontally.performed += instance.OnFlipTargetsHorizontally;
                @FlipTargetsHorizontally.canceled += instance.OnFlipTargetsHorizontally;
                @IncreaseScaleVertically.started += instance.OnIncreaseScaleVertically;
                @IncreaseScaleVertically.performed += instance.OnIncreaseScaleVertically;
                @IncreaseScaleVertically.canceled += instance.OnIncreaseScaleVertically;
                @DecreaseScaleVertically.started += instance.OnDecreaseScaleVertically;
                @DecreaseScaleVertically.performed += instance.OnDecreaseScaleVertically;
                @DecreaseScaleVertically.canceled += instance.OnDecreaseScaleVertically;
                @IncreaseScaleHorizontally.started += instance.OnIncreaseScaleHorizontally;
                @IncreaseScaleHorizontally.performed += instance.OnIncreaseScaleHorizontally;
                @IncreaseScaleHorizontally.canceled += instance.OnIncreaseScaleHorizontally;
                @DecreaseScaleHorizontally.started += instance.OnDecreaseScaleHorizontally;
                @DecreaseScaleHorizontally.performed += instance.OnDecreaseScaleHorizontally;
                @DecreaseScaleHorizontally.canceled += instance.OnDecreaseScaleHorizontally;
                @ReverseSelectedTargets.started += instance.OnReverseSelectedTargets;
                @ReverseSelectedTargets.performed += instance.OnReverseSelectedTargets;
                @ReverseSelectedTargets.canceled += instance.OnReverseSelectedTargets;
                @RotateSelectedTargetsRight.started += instance.OnRotateSelectedTargetsRight;
                @RotateSelectedTargetsRight.performed += instance.OnRotateSelectedTargetsRight;
                @RotateSelectedTargetsRight.canceled += instance.OnRotateSelectedTargetsRight;
                @RotateSelectedTargetsLeft.started += instance.OnRotateSelectedTargetsLeft;
                @RotateSelectedTargetsLeft.performed += instance.OnRotateSelectedTargetsLeft;
                @RotateSelectedTargetsLeft.canceled += instance.OnRotateSelectedTargetsLeft;
            }
        }
    }
    public DragSelectActions @DragSelect => new DragSelectActions(this);

    // Grid
    private readonly InputActionMap m_Grid;
    private IGridActions m_GridActionsCallbackInterface;
    private readonly InputAction m_Grid_GridView;
    private readonly InputAction m_Grid_NoGridView;
    private readonly InputAction m_Grid_MeleeView;
    private readonly InputAction m_Grid_QuickSwitchGrid;
    private readonly InputAction m_Grid_MoveGrid;
    public struct GridActions
    {
        private @EditorKeybinds m_Wrapper;
        public GridActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @GridView => m_Wrapper.m_Grid_GridView;
        public InputAction @NoGridView => m_Wrapper.m_Grid_NoGridView;
        public InputAction @MeleeView => m_Wrapper.m_Grid_MeleeView;
        public InputAction @QuickSwitchGrid => m_Wrapper.m_Grid_QuickSwitchGrid;
        public InputAction @MoveGrid => m_Wrapper.m_Grid_MoveGrid;
        public InputActionMap Get() { return m_Wrapper.m_Grid; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GridActions set) { return set.Get(); }
        public void SetCallbacks(IGridActions instance)
        {
            if (m_Wrapper.m_GridActionsCallbackInterface != null)
            {
                @GridView.started -= m_Wrapper.m_GridActionsCallbackInterface.OnGridView;
                @GridView.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnGridView;
                @GridView.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnGridView;
                @NoGridView.started -= m_Wrapper.m_GridActionsCallbackInterface.OnNoGridView;
                @NoGridView.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnNoGridView;
                @NoGridView.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnNoGridView;
                @MeleeView.started -= m_Wrapper.m_GridActionsCallbackInterface.OnMeleeView;
                @MeleeView.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnMeleeView;
                @MeleeView.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnMeleeView;
                @QuickSwitchGrid.started -= m_Wrapper.m_GridActionsCallbackInterface.OnQuickSwitchGrid;
                @QuickSwitchGrid.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnQuickSwitchGrid;
                @QuickSwitchGrid.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnQuickSwitchGrid;
                @MoveGrid.started -= m_Wrapper.m_GridActionsCallbackInterface.OnMoveGrid;
                @MoveGrid.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnMoveGrid;
                @MoveGrid.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnMoveGrid;
            }
            m_Wrapper.m_GridActionsCallbackInterface = instance;
            if (instance != null)
            {
                @GridView.started += instance.OnGridView;
                @GridView.performed += instance.OnGridView;
                @GridView.canceled += instance.OnGridView;
                @NoGridView.started += instance.OnNoGridView;
                @NoGridView.performed += instance.OnNoGridView;
                @NoGridView.canceled += instance.OnNoGridView;
                @MeleeView.started += instance.OnMeleeView;
                @MeleeView.performed += instance.OnMeleeView;
                @MeleeView.canceled += instance.OnMeleeView;
                @QuickSwitchGrid.started += instance.OnQuickSwitchGrid;
                @QuickSwitchGrid.performed += instance.OnQuickSwitchGrid;
                @QuickSwitchGrid.canceled += instance.OnQuickSwitchGrid;
                @MoveGrid.started += instance.OnMoveGrid;
                @MoveGrid.performed += instance.OnMoveGrid;
                @MoveGrid.canceled += instance.OnMoveGrid;
            }
        }
    }
    public GridActions @Grid => new GridActions(this);

    // BPM
    private readonly InputActionMap m_BPM;
    private IBPMActions m_BPMActionsCallbackInterface;
    private readonly InputAction m_BPM_DetectBPM;
    private readonly InputAction m_BPM_ShiftBPMMarker;
    private readonly InputAction m_BPM_BPMMarker;
    private readonly InputAction m_BPM_PreviewPoint;
    public struct BPMActions
    {
        private @EditorKeybinds m_Wrapper;
        public BPMActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @DetectBPM => m_Wrapper.m_BPM_DetectBPM;
        public InputAction @ShiftBPMMarker => m_Wrapper.m_BPM_ShiftBPMMarker;
        public InputAction @BPMMarker => m_Wrapper.m_BPM_BPMMarker;
        public InputAction @PreviewPoint => m_Wrapper.m_BPM_PreviewPoint;
        public InputActionMap Get() { return m_Wrapper.m_BPM; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BPMActions set) { return set.Get(); }
        public void SetCallbacks(IBPMActions instance)
        {
            if (m_Wrapper.m_BPMActionsCallbackInterface != null)
            {
                @DetectBPM.started -= m_Wrapper.m_BPMActionsCallbackInterface.OnDetectBPM;
                @DetectBPM.performed -= m_Wrapper.m_BPMActionsCallbackInterface.OnDetectBPM;
                @DetectBPM.canceled -= m_Wrapper.m_BPMActionsCallbackInterface.OnDetectBPM;
                @ShiftBPMMarker.started -= m_Wrapper.m_BPMActionsCallbackInterface.OnShiftBPMMarker;
                @ShiftBPMMarker.performed -= m_Wrapper.m_BPMActionsCallbackInterface.OnShiftBPMMarker;
                @ShiftBPMMarker.canceled -= m_Wrapper.m_BPMActionsCallbackInterface.OnShiftBPMMarker;
                @BPMMarker.started -= m_Wrapper.m_BPMActionsCallbackInterface.OnBPMMarker;
                @BPMMarker.performed -= m_Wrapper.m_BPMActionsCallbackInterface.OnBPMMarker;
                @BPMMarker.canceled -= m_Wrapper.m_BPMActionsCallbackInterface.OnBPMMarker;
                @PreviewPoint.started -= m_Wrapper.m_BPMActionsCallbackInterface.OnPreviewPoint;
                @PreviewPoint.performed -= m_Wrapper.m_BPMActionsCallbackInterface.OnPreviewPoint;
                @PreviewPoint.canceled -= m_Wrapper.m_BPMActionsCallbackInterface.OnPreviewPoint;
            }
            m_Wrapper.m_BPMActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DetectBPM.started += instance.OnDetectBPM;
                @DetectBPM.performed += instance.OnDetectBPM;
                @DetectBPM.canceled += instance.OnDetectBPM;
                @ShiftBPMMarker.started += instance.OnShiftBPMMarker;
                @ShiftBPMMarker.performed += instance.OnShiftBPMMarker;
                @ShiftBPMMarker.canceled += instance.OnShiftBPMMarker;
                @BPMMarker.started += instance.OnBPMMarker;
                @BPMMarker.performed += instance.OnBPMMarker;
                @BPMMarker.canceled += instance.OnBPMMarker;
                @PreviewPoint.started += instance.OnPreviewPoint;
                @PreviewPoint.performed += instance.OnPreviewPoint;
                @PreviewPoint.canceled += instance.OnPreviewPoint;
            }
        }
    }
    public BPMActions @BPM => new BPMActions(this);

    // SpacingSnap
    private readonly InputActionMap m_SpacingSnap;
    private ISpacingSnapActions m_SpacingSnapActionsCallbackInterface;
    private readonly InputAction m_SpacingSnap_EnableSpacingSnap;
    public struct SpacingSnapActions
    {
        private @EditorKeybinds m_Wrapper;
        public SpacingSnapActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @EnableSpacingSnap => m_Wrapper.m_SpacingSnap_EnableSpacingSnap;
        public InputActionMap Get() { return m_Wrapper.m_SpacingSnap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpacingSnapActions set) { return set.Get(); }
        public void SetCallbacks(ISpacingSnapActions instance)
        {
            if (m_Wrapper.m_SpacingSnapActionsCallbackInterface != null)
            {
                @EnableSpacingSnap.started -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnEnableSpacingSnap;
                @EnableSpacingSnap.performed -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnEnableSpacingSnap;
                @EnableSpacingSnap.canceled -= m_Wrapper.m_SpacingSnapActionsCallbackInterface.OnEnableSpacingSnap;
            }
            m_Wrapper.m_SpacingSnapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @EnableSpacingSnap.started += instance.OnEnableSpacingSnap;
                @EnableSpacingSnap.performed += instance.OnEnableSpacingSnap;
                @EnableSpacingSnap.canceled += instance.OnEnableSpacingSnap;
            }
        }
    }
    public SpacingSnapActions @SpacingSnap => new SpacingSnapActions(this);

    // Pathbuilder
    private readonly InputActionMap m_Pathbuilder;
    private IPathbuilderActions m_PathbuilderActionsCallbackInterface;
    private readonly InputAction m_Pathbuilder_EnablePathbuilder;
    public struct PathbuilderActions
    {
        private @EditorKeybinds m_Wrapper;
        public PathbuilderActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @EnablePathbuilder => m_Wrapper.m_Pathbuilder_EnablePathbuilder;
        public InputActionMap Get() { return m_Wrapper.m_Pathbuilder; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PathbuilderActions set) { return set.Get(); }
        public void SetCallbacks(IPathbuilderActions instance)
        {
            if (m_Wrapper.m_PathbuilderActionsCallbackInterface != null)
            {
                @EnablePathbuilder.started -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnEnablePathbuilder;
                @EnablePathbuilder.performed -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnEnablePathbuilder;
                @EnablePathbuilder.canceled -= m_Wrapper.m_PathbuilderActionsCallbackInterface.OnEnablePathbuilder;
            }
            m_Wrapper.m_PathbuilderActionsCallbackInterface = instance;
            if (instance != null)
            {
                @EnablePathbuilder.started += instance.OnEnablePathbuilder;
                @EnablePathbuilder.performed += instance.OnEnablePathbuilder;
                @EnablePathbuilder.canceled += instance.OnEnablePathbuilder;
            }
        }
    }
    public PathbuilderActions @Pathbuilder => new PathbuilderActions(this);

    // Modifiers
    private readonly InputActionMap m_Modifiers;
    private IModifiersActions m_ModifiersActionsCallbackInterface;
    private readonly InputAction m_Modifiers_OpenModifiers;
    private readonly InputAction m_Modifiers_ModifierPreview;
    public struct ModifiersActions
    {
        private @EditorKeybinds m_Wrapper;
        public ModifiersActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @OpenModifiers => m_Wrapper.m_Modifiers_OpenModifiers;
        public InputAction @ModifierPreview => m_Wrapper.m_Modifiers_ModifierPreview;
        public InputActionMap Get() { return m_Wrapper.m_Modifiers; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ModifiersActions set) { return set.Get(); }
        public void SetCallbacks(IModifiersActions instance)
        {
            if (m_Wrapper.m_ModifiersActionsCallbackInterface != null)
            {
                @OpenModifiers.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnOpenModifiers;
                @OpenModifiers.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnOpenModifiers;
                @OpenModifiers.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnOpenModifiers;
                @ModifierPreview.started -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnModifierPreview;
                @ModifierPreview.performed -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnModifierPreview;
                @ModifierPreview.canceled -= m_Wrapper.m_ModifiersActionsCallbackInterface.OnModifierPreview;
            }
            m_Wrapper.m_ModifiersActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OpenModifiers.started += instance.OnOpenModifiers;
                @OpenModifiers.performed += instance.OnOpenModifiers;
                @OpenModifiers.canceled += instance.OnOpenModifiers;
                @ModifierPreview.started += instance.OnModifierPreview;
                @ModifierPreview.performed += instance.OnModifierPreview;
                @ModifierPreview.canceled += instance.OnModifierPreview;
            }
        }
    }
    public ModifiersActions @Modifiers => new ModifiersActions(this);

    // BehaviorSelect
    private readonly InputActionMap m_BehaviorSelect;
    private IBehaviorSelectActions m_BehaviorSelectActionsCallbackInterface;
    private readonly InputAction m_BehaviorSelect_SelectBehaviorStandard;
    private readonly InputAction m_BehaviorSelect_SelectBehaviorSustain;
    private readonly InputAction m_BehaviorSelect_SelectBehaviorMine;
    private readonly InputAction m_BehaviorSelect_SelectBehaviorMelee;
    private readonly InputAction m_BehaviorSelect_SelectBehaviorChain;
    private readonly InputAction m_BehaviorSelect_SelectBehaviorChainstart;
    private readonly InputAction m_BehaviorSelect_SelectBehaviorVertical;
    private readonly InputAction m_BehaviorSelect_SelectBehaviorHorizontal;
    public struct BehaviorSelectActions
    {
        private @EditorKeybinds m_Wrapper;
        public BehaviorSelectActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectBehaviorStandard => m_Wrapper.m_BehaviorSelect_SelectBehaviorStandard;
        public InputAction @SelectBehaviorSustain => m_Wrapper.m_BehaviorSelect_SelectBehaviorSustain;
        public InputAction @SelectBehaviorMine => m_Wrapper.m_BehaviorSelect_SelectBehaviorMine;
        public InputAction @SelectBehaviorMelee => m_Wrapper.m_BehaviorSelect_SelectBehaviorMelee;
        public InputAction @SelectBehaviorChain => m_Wrapper.m_BehaviorSelect_SelectBehaviorChain;
        public InputAction @SelectBehaviorChainstart => m_Wrapper.m_BehaviorSelect_SelectBehaviorChainstart;
        public InputAction @SelectBehaviorVertical => m_Wrapper.m_BehaviorSelect_SelectBehaviorVertical;
        public InputAction @SelectBehaviorHorizontal => m_Wrapper.m_BehaviorSelect_SelectBehaviorHorizontal;
        public InputActionMap Get() { return m_Wrapper.m_BehaviorSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BehaviorSelectActions set) { return set.Get(); }
        public void SetCallbacks(IBehaviorSelectActions instance)
        {
            if (m_Wrapper.m_BehaviorSelectActionsCallbackInterface != null)
            {
                @SelectBehaviorStandard.started -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorStandard;
                @SelectBehaviorStandard.performed -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorStandard;
                @SelectBehaviorStandard.canceled -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorStandard;
                @SelectBehaviorSustain.started -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorSustain;
                @SelectBehaviorSustain.performed -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorSustain;
                @SelectBehaviorSustain.canceled -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorSustain;
                @SelectBehaviorMine.started -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorMine;
                @SelectBehaviorMine.performed -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorMine;
                @SelectBehaviorMine.canceled -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorMine;
                @SelectBehaviorMelee.started -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorMelee;
                @SelectBehaviorMelee.performed -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorMelee;
                @SelectBehaviorMelee.canceled -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorMelee;
                @SelectBehaviorChain.started -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorChain;
                @SelectBehaviorChain.performed -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorChain;
                @SelectBehaviorChain.canceled -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorChain;
                @SelectBehaviorChainstart.started -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorChainstart;
                @SelectBehaviorChainstart.performed -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorChainstart;
                @SelectBehaviorChainstart.canceled -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorChainstart;
                @SelectBehaviorVertical.started -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorVertical;
                @SelectBehaviorVertical.performed -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorVertical;
                @SelectBehaviorVertical.canceled -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorVertical;
                @SelectBehaviorHorizontal.started -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorHorizontal;
                @SelectBehaviorHorizontal.performed -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorHorizontal;
                @SelectBehaviorHorizontal.canceled -= m_Wrapper.m_BehaviorSelectActionsCallbackInterface.OnSelectBehaviorHorizontal;
            }
            m_Wrapper.m_BehaviorSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectBehaviorStandard.started += instance.OnSelectBehaviorStandard;
                @SelectBehaviorStandard.performed += instance.OnSelectBehaviorStandard;
                @SelectBehaviorStandard.canceled += instance.OnSelectBehaviorStandard;
                @SelectBehaviorSustain.started += instance.OnSelectBehaviorSustain;
                @SelectBehaviorSustain.performed += instance.OnSelectBehaviorSustain;
                @SelectBehaviorSustain.canceled += instance.OnSelectBehaviorSustain;
                @SelectBehaviorMine.started += instance.OnSelectBehaviorMine;
                @SelectBehaviorMine.performed += instance.OnSelectBehaviorMine;
                @SelectBehaviorMine.canceled += instance.OnSelectBehaviorMine;
                @SelectBehaviorMelee.started += instance.OnSelectBehaviorMelee;
                @SelectBehaviorMelee.performed += instance.OnSelectBehaviorMelee;
                @SelectBehaviorMelee.canceled += instance.OnSelectBehaviorMelee;
                @SelectBehaviorChain.started += instance.OnSelectBehaviorChain;
                @SelectBehaviorChain.performed += instance.OnSelectBehaviorChain;
                @SelectBehaviorChain.canceled += instance.OnSelectBehaviorChain;
                @SelectBehaviorChainstart.started += instance.OnSelectBehaviorChainstart;
                @SelectBehaviorChainstart.performed += instance.OnSelectBehaviorChainstart;
                @SelectBehaviorChainstart.canceled += instance.OnSelectBehaviorChainstart;
                @SelectBehaviorVertical.started += instance.OnSelectBehaviorVertical;
                @SelectBehaviorVertical.performed += instance.OnSelectBehaviorVertical;
                @SelectBehaviorVertical.canceled += instance.OnSelectBehaviorVertical;
                @SelectBehaviorHorizontal.started += instance.OnSelectBehaviorHorizontal;
                @SelectBehaviorHorizontal.performed += instance.OnSelectBehaviorHorizontal;
                @SelectBehaviorHorizontal.canceled += instance.OnSelectBehaviorHorizontal;
            }
        }
    }
    public BehaviorSelectActions @BehaviorSelect => new BehaviorSelectActions(this);

    // BehaviorConvert
    private readonly InputActionMap m_BehaviorConvert;
    private IBehaviorConvertActions m_BehaviorConvertActionsCallbackInterface;
    private readonly InputAction m_BehaviorConvert_ConvertBehaviorStandard;
    private readonly InputAction m_BehaviorConvert_ConvertBehaviorSustain;
    private readonly InputAction m_BehaviorConvert_ConvertBehaviorVertical;
    private readonly InputAction m_BehaviorConvert_ConvertBehaviorHorizontal;
    private readonly InputAction m_BehaviorConvert_ConvertBehaviorChainstart;
    private readonly InputAction m_BehaviorConvert_ConvertBehaviorChain;
    private readonly InputAction m_BehaviorConvert_ConvertBehaviorMelee;
    private readonly InputAction m_BehaviorConvert_ConvertBehaviorMine;
    public struct BehaviorConvertActions
    {
        private @EditorKeybinds m_Wrapper;
        public BehaviorConvertActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @ConvertBehaviorStandard => m_Wrapper.m_BehaviorConvert_ConvertBehaviorStandard;
        public InputAction @ConvertBehaviorSustain => m_Wrapper.m_BehaviorConvert_ConvertBehaviorSustain;
        public InputAction @ConvertBehaviorVertical => m_Wrapper.m_BehaviorConvert_ConvertBehaviorVertical;
        public InputAction @ConvertBehaviorHorizontal => m_Wrapper.m_BehaviorConvert_ConvertBehaviorHorizontal;
        public InputAction @ConvertBehaviorChainstart => m_Wrapper.m_BehaviorConvert_ConvertBehaviorChainstart;
        public InputAction @ConvertBehaviorChain => m_Wrapper.m_BehaviorConvert_ConvertBehaviorChain;
        public InputAction @ConvertBehaviorMelee => m_Wrapper.m_BehaviorConvert_ConvertBehaviorMelee;
        public InputAction @ConvertBehaviorMine => m_Wrapper.m_BehaviorConvert_ConvertBehaviorMine;
        public InputActionMap Get() { return m_Wrapper.m_BehaviorConvert; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BehaviorConvertActions set) { return set.Get(); }
        public void SetCallbacks(IBehaviorConvertActions instance)
        {
            if (m_Wrapper.m_BehaviorConvertActionsCallbackInterface != null)
            {
                @ConvertBehaviorStandard.started -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorStandard;
                @ConvertBehaviorStandard.performed -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorStandard;
                @ConvertBehaviorStandard.canceled -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorStandard;
                @ConvertBehaviorSustain.started -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorSustain;
                @ConvertBehaviorSustain.performed -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorSustain;
                @ConvertBehaviorSustain.canceled -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorSustain;
                @ConvertBehaviorVertical.started -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorVertical;
                @ConvertBehaviorVertical.performed -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorVertical;
                @ConvertBehaviorVertical.canceled -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorVertical;
                @ConvertBehaviorHorizontal.started -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorHorizontal;
                @ConvertBehaviorHorizontal.performed -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorHorizontal;
                @ConvertBehaviorHorizontal.canceled -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorHorizontal;
                @ConvertBehaviorChainstart.started -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorChainstart;
                @ConvertBehaviorChainstart.performed -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorChainstart;
                @ConvertBehaviorChainstart.canceled -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorChainstart;
                @ConvertBehaviorChain.started -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorChain;
                @ConvertBehaviorChain.performed -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorChain;
                @ConvertBehaviorChain.canceled -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorChain;
                @ConvertBehaviorMelee.started -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorMelee;
                @ConvertBehaviorMelee.performed -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorMelee;
                @ConvertBehaviorMelee.canceled -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorMelee;
                @ConvertBehaviorMine.started -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorMine;
                @ConvertBehaviorMine.performed -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorMine;
                @ConvertBehaviorMine.canceled -= m_Wrapper.m_BehaviorConvertActionsCallbackInterface.OnConvertBehaviorMine;
            }
            m_Wrapper.m_BehaviorConvertActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ConvertBehaviorStandard.started += instance.OnConvertBehaviorStandard;
                @ConvertBehaviorStandard.performed += instance.OnConvertBehaviorStandard;
                @ConvertBehaviorStandard.canceled += instance.OnConvertBehaviorStandard;
                @ConvertBehaviorSustain.started += instance.OnConvertBehaviorSustain;
                @ConvertBehaviorSustain.performed += instance.OnConvertBehaviorSustain;
                @ConvertBehaviorSustain.canceled += instance.OnConvertBehaviorSustain;
                @ConvertBehaviorVertical.started += instance.OnConvertBehaviorVertical;
                @ConvertBehaviorVertical.performed += instance.OnConvertBehaviorVertical;
                @ConvertBehaviorVertical.canceled += instance.OnConvertBehaviorVertical;
                @ConvertBehaviorHorizontal.started += instance.OnConvertBehaviorHorizontal;
                @ConvertBehaviorHorizontal.performed += instance.OnConvertBehaviorHorizontal;
                @ConvertBehaviorHorizontal.canceled += instance.OnConvertBehaviorHorizontal;
                @ConvertBehaviorChainstart.started += instance.OnConvertBehaviorChainstart;
                @ConvertBehaviorChainstart.performed += instance.OnConvertBehaviorChainstart;
                @ConvertBehaviorChainstart.canceled += instance.OnConvertBehaviorChainstart;
                @ConvertBehaviorChain.started += instance.OnConvertBehaviorChain;
                @ConvertBehaviorChain.performed += instance.OnConvertBehaviorChain;
                @ConvertBehaviorChain.canceled += instance.OnConvertBehaviorChain;
                @ConvertBehaviorMelee.started += instance.OnConvertBehaviorMelee;
                @ConvertBehaviorMelee.performed += instance.OnConvertBehaviorMelee;
                @ConvertBehaviorMelee.canceled += instance.OnConvertBehaviorMelee;
                @ConvertBehaviorMine.started += instance.OnConvertBehaviorMine;
                @ConvertBehaviorMine.performed += instance.OnConvertBehaviorMine;
                @ConvertBehaviorMine.canceled += instance.OnConvertBehaviorMine;
            }
        }
    }
    public BehaviorConvertActions @BehaviorConvert => new BehaviorConvertActions(this);

    // HitsoundSelect
    private readonly InputActionMap m_HitsoundSelect;
    private IHitsoundSelectActions m_HitsoundSelectActionsCallbackInterface;
    private readonly InputAction m_HitsoundSelect_SelectHitsoundKick;
    private readonly InputAction m_HitsoundSelect_SelectHitsoundSnare;
    private readonly InputAction m_HitsoundSelect_SelectHitsoundPercussion;
    private readonly InputAction m_HitsoundSelect_SelectHitsoundChainstart;
    private readonly InputAction m_HitsoundSelect_SelectHitsoundChain;
    private readonly InputAction m_HitsoundSelect_SelectHitsoundMelee;
    private readonly InputAction m_HitsoundSelect_SelectHitsoundSilent;
    public struct HitsoundSelectActions
    {
        private @EditorKeybinds m_Wrapper;
        public HitsoundSelectActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectHitsoundKick => m_Wrapper.m_HitsoundSelect_SelectHitsoundKick;
        public InputAction @SelectHitsoundSnare => m_Wrapper.m_HitsoundSelect_SelectHitsoundSnare;
        public InputAction @SelectHitsoundPercussion => m_Wrapper.m_HitsoundSelect_SelectHitsoundPercussion;
        public InputAction @SelectHitsoundChainstart => m_Wrapper.m_HitsoundSelect_SelectHitsoundChainstart;
        public InputAction @SelectHitsoundChain => m_Wrapper.m_HitsoundSelect_SelectHitsoundChain;
        public InputAction @SelectHitsoundMelee => m_Wrapper.m_HitsoundSelect_SelectHitsoundMelee;
        public InputAction @SelectHitsoundSilent => m_Wrapper.m_HitsoundSelect_SelectHitsoundSilent;
        public InputActionMap Get() { return m_Wrapper.m_HitsoundSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HitsoundSelectActions set) { return set.Get(); }
        public void SetCallbacks(IHitsoundSelectActions instance)
        {
            if (m_Wrapper.m_HitsoundSelectActionsCallbackInterface != null)
            {
                @SelectHitsoundKick.started -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundKick;
                @SelectHitsoundKick.performed -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundKick;
                @SelectHitsoundKick.canceled -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundKick;
                @SelectHitsoundSnare.started -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundSnare;
                @SelectHitsoundSnare.performed -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundSnare;
                @SelectHitsoundSnare.canceled -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundSnare;
                @SelectHitsoundPercussion.started -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundPercussion;
                @SelectHitsoundPercussion.performed -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundPercussion;
                @SelectHitsoundPercussion.canceled -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundPercussion;
                @SelectHitsoundChainstart.started -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundChainstart;
                @SelectHitsoundChainstart.performed -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundChainstart;
                @SelectHitsoundChainstart.canceled -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundChainstart;
                @SelectHitsoundChain.started -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundChain;
                @SelectHitsoundChain.performed -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundChain;
                @SelectHitsoundChain.canceled -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundChain;
                @SelectHitsoundMelee.started -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundMelee;
                @SelectHitsoundMelee.performed -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundMelee;
                @SelectHitsoundMelee.canceled -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundMelee;
                @SelectHitsoundSilent.started -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundSilent;
                @SelectHitsoundSilent.performed -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundSilent;
                @SelectHitsoundSilent.canceled -= m_Wrapper.m_HitsoundSelectActionsCallbackInterface.OnSelectHitsoundSilent;
            }
            m_Wrapper.m_HitsoundSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectHitsoundKick.started += instance.OnSelectHitsoundKick;
                @SelectHitsoundKick.performed += instance.OnSelectHitsoundKick;
                @SelectHitsoundKick.canceled += instance.OnSelectHitsoundKick;
                @SelectHitsoundSnare.started += instance.OnSelectHitsoundSnare;
                @SelectHitsoundSnare.performed += instance.OnSelectHitsoundSnare;
                @SelectHitsoundSnare.canceled += instance.OnSelectHitsoundSnare;
                @SelectHitsoundPercussion.started += instance.OnSelectHitsoundPercussion;
                @SelectHitsoundPercussion.performed += instance.OnSelectHitsoundPercussion;
                @SelectHitsoundPercussion.canceled += instance.OnSelectHitsoundPercussion;
                @SelectHitsoundChainstart.started += instance.OnSelectHitsoundChainstart;
                @SelectHitsoundChainstart.performed += instance.OnSelectHitsoundChainstart;
                @SelectHitsoundChainstart.canceled += instance.OnSelectHitsoundChainstart;
                @SelectHitsoundChain.started += instance.OnSelectHitsoundChain;
                @SelectHitsoundChain.performed += instance.OnSelectHitsoundChain;
                @SelectHitsoundChain.canceled += instance.OnSelectHitsoundChain;
                @SelectHitsoundMelee.started += instance.OnSelectHitsoundMelee;
                @SelectHitsoundMelee.performed += instance.OnSelectHitsoundMelee;
                @SelectHitsoundMelee.canceled += instance.OnSelectHitsoundMelee;
                @SelectHitsoundSilent.started += instance.OnSelectHitsoundSilent;
                @SelectHitsoundSilent.performed += instance.OnSelectHitsoundSilent;
                @SelectHitsoundSilent.canceled += instance.OnSelectHitsoundSilent;
            }
        }
    }
    public HitsoundSelectActions @HitsoundSelect => new HitsoundSelectActions(this);

    // HitsoundConvert
    private readonly InputActionMap m_HitsoundConvert;
    private IHitsoundConvertActions m_HitsoundConvertActionsCallbackInterface;
    private readonly InputAction m_HitsoundConvert_ConvertHitsoundKick;
    private readonly InputAction m_HitsoundConvert_ConvertHitsoundSnare;
    private readonly InputAction m_HitsoundConvert_ConvertHitsoundPercussion;
    private readonly InputAction m_HitsoundConvert_ConvertHitsoundChainstart;
    private readonly InputAction m_HitsoundConvert_ConvertHitsoundChain;
    private readonly InputAction m_HitsoundConvert_ConvertHitsoundMelee;
    private readonly InputAction m_HitsoundConvert_ConvertHitsoundSilent;
    public struct HitsoundConvertActions
    {
        private @EditorKeybinds m_Wrapper;
        public HitsoundConvertActions(@EditorKeybinds wrapper) { m_Wrapper = wrapper; }
        public InputAction @ConvertHitsoundKick => m_Wrapper.m_HitsoundConvert_ConvertHitsoundKick;
        public InputAction @ConvertHitsoundSnare => m_Wrapper.m_HitsoundConvert_ConvertHitsoundSnare;
        public InputAction @ConvertHitsoundPercussion => m_Wrapper.m_HitsoundConvert_ConvertHitsoundPercussion;
        public InputAction @ConvertHitsoundChainstart => m_Wrapper.m_HitsoundConvert_ConvertHitsoundChainstart;
        public InputAction @ConvertHitsoundChain => m_Wrapper.m_HitsoundConvert_ConvertHitsoundChain;
        public InputAction @ConvertHitsoundMelee => m_Wrapper.m_HitsoundConvert_ConvertHitsoundMelee;
        public InputAction @ConvertHitsoundSilent => m_Wrapper.m_HitsoundConvert_ConvertHitsoundSilent;
        public InputActionMap Get() { return m_Wrapper.m_HitsoundConvert; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HitsoundConvertActions set) { return set.Get(); }
        public void SetCallbacks(IHitsoundConvertActions instance)
        {
            if (m_Wrapper.m_HitsoundConvertActionsCallbackInterface != null)
            {
                @ConvertHitsoundKick.started -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundKick;
                @ConvertHitsoundKick.performed -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundKick;
                @ConvertHitsoundKick.canceled -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundKick;
                @ConvertHitsoundSnare.started -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundSnare;
                @ConvertHitsoundSnare.performed -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundSnare;
                @ConvertHitsoundSnare.canceled -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundSnare;
                @ConvertHitsoundPercussion.started -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundPercussion;
                @ConvertHitsoundPercussion.performed -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundPercussion;
                @ConvertHitsoundPercussion.canceled -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundPercussion;
                @ConvertHitsoundChainstart.started -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundChainstart;
                @ConvertHitsoundChainstart.performed -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundChainstart;
                @ConvertHitsoundChainstart.canceled -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundChainstart;
                @ConvertHitsoundChain.started -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundChain;
                @ConvertHitsoundChain.performed -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundChain;
                @ConvertHitsoundChain.canceled -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundChain;
                @ConvertHitsoundMelee.started -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundMelee;
                @ConvertHitsoundMelee.performed -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundMelee;
                @ConvertHitsoundMelee.canceled -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundMelee;
                @ConvertHitsoundSilent.started -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundSilent;
                @ConvertHitsoundSilent.performed -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundSilent;
                @ConvertHitsoundSilent.canceled -= m_Wrapper.m_HitsoundConvertActionsCallbackInterface.OnConvertHitsoundSilent;
            }
            m_Wrapper.m_HitsoundConvertActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ConvertHitsoundKick.started += instance.OnConvertHitsoundKick;
                @ConvertHitsoundKick.performed += instance.OnConvertHitsoundKick;
                @ConvertHitsoundKick.canceled += instance.OnConvertHitsoundKick;
                @ConvertHitsoundSnare.started += instance.OnConvertHitsoundSnare;
                @ConvertHitsoundSnare.performed += instance.OnConvertHitsoundSnare;
                @ConvertHitsoundSnare.canceled += instance.OnConvertHitsoundSnare;
                @ConvertHitsoundPercussion.started += instance.OnConvertHitsoundPercussion;
                @ConvertHitsoundPercussion.performed += instance.OnConvertHitsoundPercussion;
                @ConvertHitsoundPercussion.canceled += instance.OnConvertHitsoundPercussion;
                @ConvertHitsoundChainstart.started += instance.OnConvertHitsoundChainstart;
                @ConvertHitsoundChainstart.performed += instance.OnConvertHitsoundChainstart;
                @ConvertHitsoundChainstart.canceled += instance.OnConvertHitsoundChainstart;
                @ConvertHitsoundChain.started += instance.OnConvertHitsoundChain;
                @ConvertHitsoundChain.performed += instance.OnConvertHitsoundChain;
                @ConvertHitsoundChain.canceled += instance.OnConvertHitsoundChain;
                @ConvertHitsoundMelee.started += instance.OnConvertHitsoundMelee;
                @ConvertHitsoundMelee.performed += instance.OnConvertHitsoundMelee;
                @ConvertHitsoundMelee.canceled += instance.OnConvertHitsoundMelee;
                @ConvertHitsoundSilent.started += instance.OnConvertHitsoundSilent;
                @ConvertHitsoundSilent.performed += instance.OnConvertHitsoundSilent;
                @ConvertHitsoundSilent.canceled += instance.OnConvertHitsoundSilent;
            }
        }
    }
    public HitsoundConvertActions @HitsoundConvert => new HitsoundConvertActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IMappingActions
    {
        void OnPlaceNote(InputAction.CallbackContext context);
        void OnRemoveNote(InputAction.CallbackContext context);
        void OnSwitchHand(InputAction.CallbackContext context);
        void OnFlipTargetColors(InputAction.CallbackContext context);
        void OnDeleteSelectedTargets(InputAction.CallbackContext context);
    }
    public interface IUtilityActions
    {
        void OnSelectAll(InputAction.CallbackContext context);
        void OnDeselectAll(InputAction.CallbackContext context);
        void OnCopy(InputAction.CallbackContext context);
        void OnCut(InputAction.CallbackContext context);
        void OnPaste(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnUndo(InputAction.CallbackContext context);
        void OnRedo(InputAction.CallbackContext context);
    }
    public interface IMenusActions
    {
        void OnCountin(InputAction.CallbackContext context);
        void OnModifyAudio(InputAction.CallbackContext context);
        void OnTimingPoints(InputAction.CallbackContext context);
        void OnModifierHelp(InputAction.CallbackContext context);
        void OnReviewMenu(InputAction.CallbackContext context);
        void OnBookmark(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnHelp(InputAction.CallbackContext context);
    }
    public interface ITimelineActions
    {
        void OnTogglePlay(InputAction.CallbackContext context);
        void OnScrub(InputAction.CallbackContext context);
        void OnScrubByTick(InputAction.CallbackContext context);
        void OnChangeBeatSnap(InputAction.CallbackContext context);
        void OnZoomTimeline(InputAction.CallbackContext context);
        void OnStartMetronome(InputAction.CallbackContext context);
        void OnToggleWaveform(InputAction.CallbackContext context);
    }
    public interface IDragSelectActions
    {
        void OnSelectDragTool(InputAction.CallbackContext context);
        void OnMoveTargets(InputAction.CallbackContext context);
        void OnMoveTargetsQuarterModifier(InputAction.CallbackContext context);
        void OnMoveTargetsHalfModifier(InputAction.CallbackContext context);
        void OnFlipTargetsVertically(InputAction.CallbackContext context);
        void OnFlipTargetsHorizontally(InputAction.CallbackContext context);
        void OnIncreaseScaleVertically(InputAction.CallbackContext context);
        void OnDecreaseScaleVertically(InputAction.CallbackContext context);
        void OnIncreaseScaleHorizontally(InputAction.CallbackContext context);
        void OnDecreaseScaleHorizontally(InputAction.CallbackContext context);
        void OnReverseSelectedTargets(InputAction.CallbackContext context);
        void OnRotateSelectedTargetsRight(InputAction.CallbackContext context);
        void OnRotateSelectedTargetsLeft(InputAction.CallbackContext context);
    }
    public interface IGridActions
    {
        void OnGridView(InputAction.CallbackContext context);
        void OnNoGridView(InputAction.CallbackContext context);
        void OnMeleeView(InputAction.CallbackContext context);
        void OnQuickSwitchGrid(InputAction.CallbackContext context);
        void OnMoveGrid(InputAction.CallbackContext context);
    }
    public interface IBPMActions
    {
        void OnDetectBPM(InputAction.CallbackContext context);
        void OnShiftBPMMarker(InputAction.CallbackContext context);
        void OnBPMMarker(InputAction.CallbackContext context);
        void OnPreviewPoint(InputAction.CallbackContext context);
    }
    public interface ISpacingSnapActions
    {
        void OnEnableSpacingSnap(InputAction.CallbackContext context);
    }
    public interface IPathbuilderActions
    {
        void OnEnablePathbuilder(InputAction.CallbackContext context);
    }
    public interface IModifiersActions
    {
        void OnOpenModifiers(InputAction.CallbackContext context);
        void OnModifierPreview(InputAction.CallbackContext context);
    }
    public interface IBehaviorSelectActions
    {
        void OnSelectBehaviorStandard(InputAction.CallbackContext context);
        void OnSelectBehaviorSustain(InputAction.CallbackContext context);
        void OnSelectBehaviorMine(InputAction.CallbackContext context);
        void OnSelectBehaviorMelee(InputAction.CallbackContext context);
        void OnSelectBehaviorChain(InputAction.CallbackContext context);
        void OnSelectBehaviorChainstart(InputAction.CallbackContext context);
        void OnSelectBehaviorVertical(InputAction.CallbackContext context);
        void OnSelectBehaviorHorizontal(InputAction.CallbackContext context);
    }
    public interface IBehaviorConvertActions
    {
        void OnConvertBehaviorStandard(InputAction.CallbackContext context);
        void OnConvertBehaviorSustain(InputAction.CallbackContext context);
        void OnConvertBehaviorVertical(InputAction.CallbackContext context);
        void OnConvertBehaviorHorizontal(InputAction.CallbackContext context);
        void OnConvertBehaviorChainstart(InputAction.CallbackContext context);
        void OnConvertBehaviorChain(InputAction.CallbackContext context);
        void OnConvertBehaviorMelee(InputAction.CallbackContext context);
        void OnConvertBehaviorMine(InputAction.CallbackContext context);
    }
    public interface IHitsoundSelectActions
    {
        void OnSelectHitsoundKick(InputAction.CallbackContext context);
        void OnSelectHitsoundSnare(InputAction.CallbackContext context);
        void OnSelectHitsoundPercussion(InputAction.CallbackContext context);
        void OnSelectHitsoundChainstart(InputAction.CallbackContext context);
        void OnSelectHitsoundChain(InputAction.CallbackContext context);
        void OnSelectHitsoundMelee(InputAction.CallbackContext context);
        void OnSelectHitsoundSilent(InputAction.CallbackContext context);
    }
    public interface IHitsoundConvertActions
    {
        void OnConvertHitsoundKick(InputAction.CallbackContext context);
        void OnConvertHitsoundSnare(InputAction.CallbackContext context);
        void OnConvertHitsoundPercussion(InputAction.CallbackContext context);
        void OnConvertHitsoundChainstart(InputAction.CallbackContext context);
        void OnConvertHitsoundChain(InputAction.CallbackContext context);
        void OnConvertHitsoundMelee(InputAction.CallbackContext context);
        void OnConvertHitsoundSilent(InputAction.CallbackContext context);
    }
}
