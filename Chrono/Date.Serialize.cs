using System;
using System.Runtime.Serialization;

namespace Motormoth.Chrono
{
    [Serializable]
    partial struct Date : ISerializable
    {
        /// <inheritdoc/>
        /// <remarks>Not implemented.</remarks>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}