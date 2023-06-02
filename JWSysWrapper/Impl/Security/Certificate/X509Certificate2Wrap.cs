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

using JWWrap.Interface.Security.Certificate;

namespace JWWrap.Impl.Security.Certificate
{
    // ----------------------------------------------------
    /// <summary>
    ///     X509Certificate2Wrap Description
    /// </summary>

    public class X509Certificate2Wrap : IX509Certificate2
    {
        public X509Certificate2 Instance { set; get; }

        // ------------------------------------------------

        public X509Certificate2Wrap() { Instance = new X509Certificate2(); }
        public X509Certificate2Wrap(X509Certificate2 instance) { Instance = instance; }
        public X509Certificate2Wrap(IX509Certificate2 wrap) { Instance = wrap.Instance; }
        public X509Certificate2Wrap(IntPtr handle) { Instance = new X509Certificate2(handle); }
        public X509Certificate2Wrap(byte[] rawData) { Instance = new X509Certificate2(rawData); }
        public X509Certificate2Wrap(string fileName) { Instance = new X509Certificate2(fileName); }
        public X509Certificate2Wrap(X509Certificate certificate) { Instance = new X509Certificate2(certificate); }
        public X509Certificate2Wrap(byte[] rawData, string password) { Instance = new X509Certificate2(rawData, password); }
        public X509Certificate2Wrap(byte[] rawData, SecureString password) { Instance = new X509Certificate2(rawData, password); }
        public X509Certificate2Wrap(string fileName, string password) { Instance = new X509Certificate2(fileName, password); }
        public X509Certificate2Wrap(string fileName, SecureString password) { Instance = new X509Certificate2(fileName, password); }
        public X509Certificate2Wrap(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags) 
        { Instance = new X509Certificate2(rawData, password, keyStorageFlags); }

        public X509Certificate2Wrap(byte[] rawData, SecureString password, X509KeyStorageFlags keyStorageFlags) 
        { Instance = new X509Certificate2(rawData, password, keyStorageFlags); }

        public X509Certificate2Wrap(string fileName, string password, X509KeyStorageFlags keyStorageFlags) 
        { Instance = new X509Certificate2(fileName, password, keyStorageFlags); }

        public X509Certificate2Wrap(string fileName, SecureString password, X509KeyStorageFlags keyStorageFlags) 
        { Instance = new X509Certificate2(fileName, password, keyStorageFlags); }

        // ------------------------------------------------

        public IntPtr Handle => Instance.Handle;

        public string Issuer => Instance.Issuer;

        public string Subject => Instance.Subject;

        public Oid SignatureAlgorithm => Instance.SignatureAlgorithm;

        public X500DistinguishedName SubjectName => Instance.SubjectName;

        public string SerialNumber => Instance.SerialNumber;

        public byte[] RawData => Instance.RawData;

        public PublicKey PublicKey => Instance.PublicKey;

        public AsymmetricAlgorithm PrivateKey { get => Instance.PrivateKey; set => Instance.PrivateKey = value; }

        public bool HasPrivateKey => Instance.HasPrivateKey;

        public DateTime NotBefore => Instance.NotBefore;

        public DateTime NotAfter => Instance.NotAfter;

        public X500DistinguishedName IssuerName => Instance.IssuerName;

        public string FriendlyName { get => Instance.FriendlyName; set => Instance.FriendlyName = value; }

        public X509ExtensionCollection Extensions => Instance.Extensions;

        public bool Archived { get => Instance.Archived; set => Instance.Archived = value; }

        public int Version => Instance.Version;

        public string Thumbprint => Instance.Thumbprint;

        public bool Equals(X509Certificate other) { return Instance.Equals(other); }

        public byte[] Export(X509ContentType contentType, SecureString password) { return Instance.Export(contentType, password); }

        public byte[] Export(X509ContentType contentType, string password) { return Instance.Export(contentType, password); }

        public byte[] Export(X509ContentType contentType) {  return Instance.Export(contentType); }

        public byte[] GetCertHash() { return Instance.GetCertHash(); }

        public string GetCertHashString() { return Instance.GetCertHashString(); }

        public string GetEffectiveDateString() { return Instance.GetEffectiveDateString(); }

        public string GetExpirationDateString() { return Instance.GetExpirationDateString(); }

        public string GetFormat() { return Instance.GetFormat(); }

        [Obsolete("Obsolete: Use the Issuer property instead")]
        public string GetIssuerName() { return Instance.GetIssuerName(); }

        public string GetKeyAlgorithm() { return Instance.GetKeyAlgorithm(); }

        public byte[] GetKeyAlgorithmParameters() { return Instance.GetKeyAlgorithmParameters(); }

        public string GetKeyAlgorithmParametersString() { return Instance.GetKeyAlgorithmParametersString(); }

        [Obsolete("Obsolete: Use the Subject property instead")]
        public string GetName() { return Instance.GetName(); }

        public string GetNameInfo(X509NameType nameType, bool forIssuer) { return Instance.GetNameInfo(nameType, forIssuer); }

        public byte[] GetPublicKey() { return Instance.GetPublicKey(); }

        public string GetPublicKeyString() { return Instance.GetPublicKeyString(); }

        public byte[] GetRawCertData() { return Instance.GetRawCertData(); }

        public string GetRawCertDataString() { return Instance.GetRawCertDataString(); }

        public byte[] GetSerialNumber() { return Instance.GetSerialNumber(); }

        public string GetSerialNumberString() { return Instance.GetSerialNumberString(); }

        public void Import(string fileName, SecureString password, X509KeyStorageFlags keyStorageFlags)
        { Instance.Import(fileName, password, keyStorageFlags); }

        public void Import(string fileName, string password, X509KeyStorageFlags keyStorageFlags)
        { Instance.Import(fileName, password, keyStorageFlags); }

        public void Import(byte[] rawData, SecureString password, X509KeyStorageFlags keyStorageFlags)
        { Instance.Import(rawData, password, keyStorageFlags); }

        public void Import(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags)
        { Instance.Import(rawData, password, keyStorageFlags); }

        public void Import(byte[] rawData) { Instance.Import(rawData); }

        public void Import(string fileName) { Instance.Import(fileName); }

        public void Reset() { Instance.Reset(); }

        public string ToString(bool verbose) { return Instance.ToString(verbose); }

        public bool Verify() { return Instance.Verify(); }

        // ---------------------
        // Static Implementation

        public X509Certificate CreateFromCertFile(string filename) => X509Certificate2.CreateFromCertFile(filename);
        public X509Certificate CreateFromSignedFile(string filename) => X509Certificate2.CreateFromSignedFile(filename);

        public X509ContentType GetCertContentType(byte[] rawData) => X509Certificate2.GetCertContentType(rawData);
        public X509ContentType GetCertContentType(string fileName) => X509Certificate2.GetCertContentType(fileName);
    }
}
