using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// End of Chess game
    /// </summary>
    public class Game_GameOver : ACGameEvent {
        public uint GameId;

        /// <summary>
        /// Which team was the winner for this game
        /// </summary>
        public int TeamWinner;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            GameId = reader.ReadUInt32();
            TeamWinner = reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(GameId);
            writer.Write(TeamWinner);
        }

    }

}
