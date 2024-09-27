using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Direct message by name
    /// </summary>
    public class Communication_TalkDirectByName : ACGameAction {
        /// <summary>
        /// The message text
        /// </summary>
        public string Message;

        /// <summary>
        /// Name of person you are sending a message to
        /// </summary>
        public string TargetName;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Message = reader.ReadString16L();
            TargetName = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Message);
            writer.Write(TargetName);
        }

    }

}
