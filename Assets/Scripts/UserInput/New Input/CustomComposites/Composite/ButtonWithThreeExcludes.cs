using System.ComponentModel;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.Scripting;

namespace NotReaper.CustomComposites
{
    [Preserve]
    [DisplayName("Button with 3 Excludes")]
    public class ButtonWithThreeExcludes : InputBindingComposite<float>
    {
        [InputControl(layout = "Button")]
        public int button;

        [InputControl(layout = "Button")]
        public int exclude1;

        [InputControl(layout = "Button")]
        public int exclude2;

        [InputControl(layout = "Button")]
        public int exclude3;

        public override float ReadValue(ref InputBindingCompositeContext context)
        {
            return context.ReadValue<float>(button);
        }

        public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
        {
            float buttonVal = context.ReadValue<float>(button);
            float excludeVal1 = context.ReadValueAsButton(exclude1) ? 0f : 1f;
            float excludeVal2 = context.ReadValueAsButton(exclude2) ? 0f : 1f;
            float excludeVal3 = context.ReadValueAsButton(exclude3) ? 0f : 1f;
            return buttonVal * excludeVal1 * excludeVal2 * excludeVal3;
        }
    }
}

