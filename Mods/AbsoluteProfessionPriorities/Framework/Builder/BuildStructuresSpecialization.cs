﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitchyMods.AbsoluteProfessionPriorities.Framework {
    public class BuildStructuresSpecialization : Specialization {
        public BuildStructuresSpecialization(int priority, bool active, SubSpecialization[] subs)
            : base(ProfessionType.Builder, "buildStructures", priority, active, subs) {
        }

        public override IEnumerable<InteractionRestricted> GetInteractionRestricted(HumanAI human) {
            yield return new InteractionRestricted(Interaction.Construct,
                    new InteractionRestrictionConstructableType(ConstructableType.Structures));
            yield return new InteractionRestricted(Interaction.Deconstruct, 50);
        }
    }
}
