using System.ComponentModel;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.Scripting;

namespace NotReaper.CustomComposites
{
    [Preserve]
    [DisplayName("Button with 1 Modifier and 2 Excludes")]
    public class ButtonWithOneModifierTwoExcludes : InputBindingComposite<float>
    {
        [InputControl(layout = "Button")]
        public int button;

        [InputControl(layout = "Button")]
        public int modifier;

        [InputControl(layout = "Button")]
        public int exclude1;

        [InputControl(layout = "Button")]
        public int exclude2;

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
            float excludeVal1 = noExclude ? 1f : context.ReadValueAsButton(exclude1) ? 0f : 1f;
            float excludeVal2 = noExclude ? 1f : context.ReadValueAsButton(exclude2) ? 0f : 1f;
            return buttonVal * modifierVal * excludeVal1 * excludeVal2;
        }
    }
}

