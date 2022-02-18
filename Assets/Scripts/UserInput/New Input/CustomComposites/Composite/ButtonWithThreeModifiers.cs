using System.ComponentModel;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.Scripting;

namespace NotReaper.CustomComposites
{
    [Preserve]
    [DisplayName("Button with 3 Modifiers")]
    public class ButtonWithThreeModifiers : InputBindingComposite<float>
    {
        [InputControl(layout = "Button")]
        public int button;

        [InputControl(layout = "Button")]
        public int modifier1;

        [InputControl(layout = "Button")]
        public int modifier2;

        [InputControl(layout = "Button")]
        public int modifier3;

        public override float ReadValue(ref InputBindingCompositeContext context)
        {
            return context.ReadValue<float>(button);
        }

        public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
        {
            float buttonVal = context.ReadValue<float>(button);
            float modifierVal1 = context.ReadValue<float>(modifier1);
            float modifierVal2 = context.ReadValue<float>(modifier2);
            float modifierVal3 = context.ReadValue<float>(modifier3);
            return buttonVal * modifierVal1 * modifierVal2 * modifierVal3;
        }
    }
}

