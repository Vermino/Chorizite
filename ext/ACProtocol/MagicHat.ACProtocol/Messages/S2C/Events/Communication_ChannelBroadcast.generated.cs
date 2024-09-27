using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// ChannelBroadcast: Group Chat
    /// </summary>
    public class Communication_ChannelBroadcast : ACGameEvent {
        /// <summary>
        /// Channel id
        /// </summary>
        public Channel Channel;

        /// <summary>
        /// Message being sent
        /// </summary>
        public string Message;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Channel = (Channel)reader.ReadUInt32();
            Message = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)Channel);
            writer.Write(Message);
        }

    }

}
