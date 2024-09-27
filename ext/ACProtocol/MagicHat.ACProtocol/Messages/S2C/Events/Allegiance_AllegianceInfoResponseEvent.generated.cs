using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Returns data for a player&#39;s allegiance information
    /// </summary>
    public class Allegiance_AllegianceInfoResponseEvent : ACGameEvent {
        /// <summary>
        /// Target of the request
        /// </summary>
        public uint TargetId;

        /// <summary>
        /// Allegiance Profile Data
        /// </summary>
        public AllegianceProfile Profile;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            TargetId = reader.ReadUInt32();
            Profile = new AllegianceProfile();
            Profile.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(TargetId);
            Profile.Write(writer);
        }

    }

}
