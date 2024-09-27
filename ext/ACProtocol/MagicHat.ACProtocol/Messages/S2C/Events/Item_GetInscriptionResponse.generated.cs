using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Get Inscription Response, doesn&#39;t seem to be really used by client
    /// </summary>
    public class Item_GetInscriptionResponse : ACGameEvent {
        /// <summary>
        /// The inscription comment
        /// </summary>
        public string Inscription;

        /// <summary>
        /// The name of the inscription author.
        /// </summary>
        public string ScribeName;

        public string ScribeAccount;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Inscription = reader.ReadString16L();
            ScribeName = reader.ReadString16L();
            ScribeAccount = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Inscription);
            writer.Write(ScribeName);
            writer.Write(ScribeAccount);
        }

    }

}
