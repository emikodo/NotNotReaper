using System.ComponentModel;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Scripting;

namespace NotReaper.CustomComposites
{
    [Preserve]
    [DisplayName("Button with 1 Modifier and 1 Exclude")]
    [DisplayStringFormat("{button}+{modifier}")]
    public class ButtonWithOneModifierOneExclude : InputBindingComposite<float>
    {
        [InputControl(layout = "Button")]
        public int button;

        [InputControl(layout = "Button")]
        public int modifier;

        [InputControl(layout = "Button")]
        public int excludeButton;

        public bool noModifier;
        public bool noExclude;

        public override float ReadValue(ref InputBindingCompositeContext context)
        {
            return context.ReadValue<float>(button);
        }

        public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
        {
            float buttonVal = context.ReadValue<float>(button);
            float modifierVal = noModifier ? 1f : context.ReadValue<float>(modifier);
            float excludeVal = noExclude ? 1f : context.ReadValueAsButton(excludeButton) ? 0f : 1f;
            return buttonVal * modifierVal * excludeVal;
        }
    }
}

