using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Sends all contract data
    /// </summary>
    public class Social_SendClientContractTrackerTable : ACGameEvent {
        public ContractTrackerTable ContractTracker;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ContractTracker = new ContractTrackerTable();
            ContractTracker.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            ContractTracker.Write(writer);
        }

    }

}
