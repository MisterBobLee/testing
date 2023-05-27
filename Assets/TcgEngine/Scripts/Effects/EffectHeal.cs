using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TcgEngine.Gameplay;

namespace TcgEngine
{
    /// <summary>
    /// Effects that heals a card or player (hp)
    /// It cannot restore more than the original hp, use AddStats to go beyond original
    /// </summary>

    [CreateAssetMenu(fileName = "effect", menuName = "TcgEngine/Effect/Heal", order = 10)]
    public class EffectHeal : EffectData
    {
        public override void DoEffect(GameLogic logic, AbilityData ability, Card caster, Player target)
        {
            target.hp += ability.value;
            target.hp = Mathf.Clamp(target.hp, 0, target.hp_max);
        }

        public override void DoEffect(GameLogic logic, AbilityData ability, Card caster, Card target)
        {
            logic.HealCard(target, ability.value);
        }

        public override int GetAiValue(AbilityData ability)
        {
            return 1;
        }
    }
}