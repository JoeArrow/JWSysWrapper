#region © 2021 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using JWWrap.Interface.Security.Certificate;

namespace JWWrap.Impl.Security.Certificate
{
    // ----------------------------------------------------
    /// <summary>
    ///     X509Certificate2Factory Description
    /// </summary>

    public class X509Certificate2Factory : IX509Certificate2Factory
    {
        public IX509Certificate2 Create()
        {
            return new X509Certificate2Wrap();
        }

        public IX509Certificate2 Create(IntPtr handle)
        {
            return new X509Certificate2Wrap(handle);
        }

        public IX509Certificate2 Create(byte[] rawData)
        {
            return new X509Certificate2Wrap(rawData);
        }

        public IX509Certificate2 Create(string fileName)
        {
            return new X509Certificate2Wrap(fileName);
        }

        public IX509Certificate2 Create(X509Certificate certificate)
        {
            return new X509Certificate2Wrap(certificate);
        }

        public IX509Certificate2 Create(byte[] rawData, string password)
        {
            return new X509Certificate2Wrap(rawData, password);
        }

        public IX509Certificate2 Create(string fileName, string password)
        {
            return new X509Certificate2Wrap(fileName, password);
        }

        public IX509Certificate2 Create(byte[] rawData, SecureString password)
        {
            return new X509Certificate2Wrap(rawData, password);
        }

        public IX509Certificate2 Create(string fileName, SecureString password)
        {
            return new X509Certificate2Wrap(fileName, password);
        }

        public IX509Certificate2 Create(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags)
        {
            return new X509Certificate2Wrap(rawData, password, keyStorageFlags);
        }

        public IX509Certificate2 Create(string fileName, string password, X509KeyStorageFlags keyStorageFlags)
        {
            return new X509Certificate2Wrap(fileName, password, keyStorageFlags);
        }

        public IX509Certificate2 Create(byte[] rawData, SecureString password, X509KeyStorageFlags keyStorageFlags)
        {
            return new X509Certificate2Wrap(rawData, password, keyStorageFlags);
        }

        public IX509Certificate2 Create(string fileName, SecureString password, X509KeyStorageFlags keyStorageFlags)
        {
            return new X509Certificate2Wrap(fileName, password, keyStorageFlags);
        }
    }
}
