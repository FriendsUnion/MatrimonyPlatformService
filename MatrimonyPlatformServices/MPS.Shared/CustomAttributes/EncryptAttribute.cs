using System;

namespace MPS.Shared.CustomAttributes
{
    /// <summary>
    /// Custom attribute to define a datamember requires encryption
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    public class EncryptAttribute : Attribute
    {
        public bool NeedsEncryption { get; }
        public EncryptAttribute(bool needEncryption)
        {
            NeedsEncryption = needEncryption;
        }
    }
}
