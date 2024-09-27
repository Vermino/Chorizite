using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Move to state data
    /// </summary>
    public class Movement_MoveToState : ACGameAction {
        /// <summary>
        /// set of move to data, currently not in client, may not be used?
        /// </summary>
        public MoveToStatePack MoveToState;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            MoveToState = new MoveToStatePack();
            MoveToState.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            MoveToState.Write(writer);
        }

    }

}
