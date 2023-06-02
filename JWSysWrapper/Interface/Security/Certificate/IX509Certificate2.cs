#region © 2021 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace JWWrap.Interface.Security.Certificate
{
    public interface IX509Certificate2
    {
        IntPtr Handle { get; }
        string Issuer { get; }
        string Subject { get; }
        X509Certificate2 Instance { set; get; }

        bool Equals(X509Certificate other);
        bool Equals(object obj);
        byte[] Export(X509ContentType contentType, SecureString password);
        byte[] Export(X509ContentType contentType, string password);
        byte[] Export(X509ContentType contentType);
        byte[] GetCertHash();
        string GetCertHashString();
        string GetEffectiveDateString();
        string GetExpirationDateString();
        string GetFormat();
        int GetHashCode();
        string GetIssuerName();
        string GetKeyAlgorithm();
        byte[] GetKeyAlgorithmParameters();
        string GetKeyAlgorithmParametersString();
        string GetName();
        byte[] GetPublicKey();
        string GetPublicKeyString();
        byte[] GetRawCertData();
        string GetRawCertDataString();
        byte[] GetSerialNumber();
        string GetSerialNumberString();

        // ----------

        Oid SignatureAlgorithm { get; }
        X500DistinguishedName SubjectName { get; }
        string SerialNumber { get; }
        byte[] RawData { get; }
        PublicKey PublicKey { get; }
        AsymmetricAlgorithm PrivateKey { get; set; }
        bool HasPrivateKey { get; }
        DateTime NotBefore { get; }
        DateTime NotAfter { get; }
        X500DistinguishedName IssuerName { get; }
        string FriendlyName { get; set; }
        X509ExtensionCollection Extensions { get; }
        bool Archived { get; set; }
        int Version { get; }
        string Thumbprint { get; }

        string GetNameInfo(X509NameType nameType, bool forIssuer);
        void Import(string fileName, SecureString password, X509KeyStorageFlags keyStorageFlags);
        void Import(string fileName, string password, X509KeyStorageFlags keyStorageFlags);
        void Import(byte[] rawData, SecureString password, X509KeyStorageFlags keyStorageFlags);
        void Import(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags);
        void Import(byte[] rawData);
        void Import(string fileName);
        void Reset();
        string ToString(bool verbose);
        string ToString();
        bool Verify();

        // ---------------------
        // Static Implementation

        X509Certificate CreateFromCertFile(string filename);
        X509Certificate CreateFromSignedFile(string filename);

        X509ContentType GetCertContentType(byte[] rawData);
        X509ContentType GetCertContentType(string fileName);
    }
}
