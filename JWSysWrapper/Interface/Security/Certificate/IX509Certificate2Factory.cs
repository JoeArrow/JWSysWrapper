using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JWWrap.Interface.Security.Certificate
{
    public interface IX509Certificate2Factory
    {
        IX509Certificate2 Create();
        IX509Certificate2 Create(IntPtr handle);
        IX509Certificate2 Create(byte[] rawData);
        IX509Certificate2 Create(string fileName);
        IX509Certificate2 Create(X509Certificate certificate);
        IX509Certificate2 Create(byte[] rawData, string password);
        IX509Certificate2 Create(string fileName, string password);
        IX509Certificate2 Create(byte[] rawData, SecureString password);
        IX509Certificate2 Create(string fileName, SecureString password);
        IX509Certificate2 Create(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags);
        IX509Certificate2 Create(string fileName, string password, X509KeyStorageFlags keyStorageFlags);
        IX509Certificate2 Create(byte[] rawData, SecureString password, X509KeyStorageFlags keyStorageFlags);
        IX509Certificate2 Create(string fileName, SecureString password, X509KeyStorageFlags keyStorageFlags);
    }
}
