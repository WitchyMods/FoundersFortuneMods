﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NoMoreBedTime {
    [Serializable]
    public class NoMoreBedTimeMod : Mod {
        public override void Load() {
            Harmony harmony = new Harmony("NoMoreBedTime");
            harmony.PatchAll();
        }

        public override void Start() {
        }

        public override void Update() {
        }
    }

    [HarmonyPatch(typeof(NeedsInteractionController), "GetInteractionProposal")]
    public static class NeedsInteractionControllerPatch {
        public static void Postfix(NeedsInteractionController __instance, HumanAI human, ref InteractionInfo __result) {
            if (__result != null && (
                (__result.interaction == Interaction.Sleep && human.energy >= 0.15f) ||
                (__result.interaction == Interaction.SleepOnGround && human.energy > 0)))

                __result = null;
        }
    }
}
