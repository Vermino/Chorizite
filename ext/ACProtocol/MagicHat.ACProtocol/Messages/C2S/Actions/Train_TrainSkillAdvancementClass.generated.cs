using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Spend skill credits to train a skill.
    /// </summary>
    public class Train_TrainSkillAdvancementClass : ACGameAction {
        /// <summary>
        /// The Id of the skill
        /// </summary>
        public SkillId Skill;

        /// <summary>
        /// The number of skill credits being spent
        /// </summary>
        public uint Credits;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Skill = (SkillId)reader.ReadInt32();
            Credits = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((int)Skill);
            writer.Write(Credits);
        }

    }

}
