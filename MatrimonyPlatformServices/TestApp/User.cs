using System;
using System.Collections.Generic;
using MPS.Shared.Cryptography;
using MPS.Shared.CustomAttributes;
using System.Text;

namespace TestApp
{
    public class User
    {
        [EncryptAttribute(true)]
        public dynamic Name { set; get; }

        [EncryptAttribute(true)]
        public dynamic DOB { set; get; }

        [EncryptAttribute(false)]
        public string Gender { set; get; }

        [EncryptAttribute(true)]
        public dynamic Married { set; get; }
    }
}
