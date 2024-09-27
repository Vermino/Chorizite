using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Sets a new fill complevel for a component
    /// </summary>
    public class Character_SetDesiredComponentLevel : ACGameAction {
        /// <summary>
        /// class id of the component
        /// </summary>
        public uint Wcid;

        public uint Amount;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Wcid = reader.ReadUInt32();
            Amount = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Wcid);
            writer.Write(Amount);
        }

    }

}
