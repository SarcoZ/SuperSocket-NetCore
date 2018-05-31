namespace SuperSocket.ProtoBase
{
    /// <summary>
    /// The object protocol encoder
    /// </summary>
    public interface IProtoObjectEncoder
    {
        /// <summary>
        /// Encode object
        /// </summary>
        /// <param name="output">the output buffer</param>
        /// <param name="target">the object to be encoded</param>
        void EncodeObject(IOutputBuffer output, object target);
    }
}
