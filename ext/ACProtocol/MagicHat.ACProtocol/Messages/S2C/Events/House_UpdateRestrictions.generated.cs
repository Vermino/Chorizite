using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Update Restrictions
    /// </summary>
    public class House_UpdateRestrictions : ACGameEvent {
        /// <summary>
        /// Sequence value for restrictions list for this house
        /// </summary>
        public byte Sequence;

        /// <summary>
        /// Object having restrictions updated
        /// </summary>
        public uint SenderId;

        /// <summary>
        /// Restrictions database
        /// </summary>
        public RestrictionDB Restrictions;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Sequence = reader.ReadByte();
            SenderId = reader.ReadUInt32();
            Restrictions = new RestrictionDB();
            Restrictions.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Sequence);
            writer.Write(SenderId);
            Restrictions.Write(writer);
        }

    }

}
