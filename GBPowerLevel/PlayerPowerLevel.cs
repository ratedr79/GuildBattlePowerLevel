using System;
using System.Collections.Generic;
using System.Text;

namespace GBPowerLevel
{
    public class PlayerPowerLevel
    {
        public string InGameName { get; set; }
        public string Character { get; set; }
        public double PowerLevel { get; set; }
        public string OtherCharacters { get; set; }
        public string CurrentGuild { get; set; }
        public double SummonModifier { get; set; }
        public double EnemySkillModifier { get; set; }
        public double SupportModifier { get; set; }
        public string SupportModifierDetails { get; set; }
        public double SummonMaxLevel { get; set; }
    }
}
