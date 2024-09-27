using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Admin Receive Player Data
    /// </summary>
    public class Admin_ReceivePlayerData : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7CB;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Admin_ReceivePlayerData;

        public int Unknown;

        /// <summary>
        /// Set of player data
        /// </summary>
        public List<AdminPlayerData> AdminPlayerData = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Unknown = reader.ReadInt32();
            AdminPlayerData = reader.ReadPackableList<AdminPlayerData>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Unknown);
            writer.WritePackableList(AdminPlayerData);
        }

    }

}
