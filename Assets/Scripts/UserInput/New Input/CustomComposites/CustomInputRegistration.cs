using UnityEngine;
using static UnityEngine.InputSystem.InputSystem;

namespace NotReaper.CustomComposites
{
    #if UNITY_EDITOR
    using UnityEditor;
    #endif


    #if UNITY_EDITOR
    [InitializeOnLoad]
    #endif
    public static class CustomInputRegistration
    {
        private static bool initialized = false;

    #if UNITY_EDITOR
        static CustomInputRegistration()
        {
            Register();
        }
    #endif
        [RuntimeInitializeOnLoadMethod]
        private static void Register()
        {
            if (!initialized)
            {
                RegisterProcessor<NegateButtonProcessor>();
                RegisterBindingComposite<ButtonWithOneModifierOneExclude>();
                RegisterBindingComposite<ButtonWithOneModifierTwoExcludes>();
                RegisterBindingComposite<ButtonWithTwoModifiersOneExclude>();
                RegisterBindingComposite<ButtonWithThreeModifiers>();
                RegisterBindingComposite<ButtonWithThreeExcludes>();
                initialized = true;
            }
        }
    }
}

