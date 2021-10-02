﻿using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using UnityEngine;


namespace ChampionFeats.Components
{
    
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [TypeId("be0495e1ab3a4f0ab50cede89bd1b087")]
    class AddScalingSpellDC : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAbilityParams>, IRulebookHandler<RuleCalculateAbilityParams>, ISubscriber, IInitiatorRulebookSubscriber
    {

        public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
        {

            if(evt.Spell == null)
            {
                return; // not a spell at all
            }
            else if (!evt.Spell.IsSpell)
            {
                return; // not an ACTUAL spell (or spell-like, anyway)
            }

            //we're here, so we know we're a spell. 

            int bonus = Value.Calculate(Context);
            evt.AddBonusDC(Math.Max(1, bonus), ModifierDescriptor.UntypedStackable);

        }

        public void OnEventDidTrigger(RuleCalculateAbilityParams evt)
        {
        }

        public ContextValue Value;
    }
}
