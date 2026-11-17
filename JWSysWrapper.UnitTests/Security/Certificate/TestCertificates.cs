#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace JWWrap.UnitTests.Security.Certificate
{
    // ----------------------------------------------------
    /// <summary>
    ///     Public test certificate (self-signed, CN=JWWrap Unit Test) in three forms:
    ///     a DER certificate, a password protected PFX without a private key,
    ///     and a password protected PFX with a private key.
    /// </summary>

    public static class TestCertificates
    {
        public const string Password = "JWWrapTest!";
        public const string SubjectName = "CN=JWWrap Unit Test";

        private const string CertBase64 =
            "MIICtjCCAZ6gAwIBAgIGGis8TV5vMA0GCSqGSIb3DQEBCwUAMBsxGTAXBgNVBAMMEEpXV3JhcCBVbml0IFRlc3Qw" +
            "IBcNMjAwMTAxMDAwMDAwWhgPMjA5OTEyMzEwMDAwMDBaMBsxGTAXBgNVBAMMEEpXV3JhcCBVbml0IFRlc3QwggEi" +
            "MA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDPpDt1QWXoX07dtm1NOOW1nCPCw2Jjp39NZbgQARPSVw2GTYME" +
            "3V8ynhQ6BjJNG9IdWNFXmRK3QQXuqMskevfyWWcnEyqAsY3/YHZUfKuEMUqmZVUySNI9h+BBuFHujj/qtSNSe12r" +
            "bcohC0FnpSzO3pwF0YG7bHdBqqv7XlFWQlTLa9HDynWIpRxLMm2+T9alSfYjJCE4uEeO8SVTWXJ1YqCV2iIeAOhK" +
            "+aM7iuEdE7/Jz/g9unwlZuPBSfe7C7+FsTo+PawvV9J4Y0vyZk2VvWW5Y93iCAVXytGdcj6pfgLk15vRISsqnzME" +
            "voJoVt2P7TAPlrt3tk9SsOa27XY9AgMBAAEwDQYJKoZIhvcNAQELBQADggEBAIzGPnVUZh4gX717m7aMvXplSJqW" +
            "DB/z1ks08wcu32lsnYJqjbcauaWfpwT+O/3CKLb0skgo+TUJCZGjYhuUdCNPckHCUFZVHGzxBNeeg47ffk7BbFmM" +
            "OpsV2v0hd3gxzA7Q0S1Th/O4e8yN7R0R2akW71U3+6x2wDFUsep8Ir1+q5G8A4GSpa43LfEG7+zON17LUjCkqcKC" +
            "0Yojk3+xF51dMb3quxEJDqoKCXxbdHUAC7sHG4M39IVoPpTtloaDp7EBUktdLYqpebG29+uouz4zyBVYYu9Vktzp" +
            "QCyEz+GBXg0Cj/AdMGDT62r4NeXnMo4Hwxr+YPbXGiuHa2hYTb8=";

        private const string PfxNoKeyBase64 =
            "MIIDpAIBAzCCA2oGCSqGSIb3DQEHAaCCA1sEggNXMIIDUzCCA08GCSqGSIb3DQEHBqCCA0AwggM8AgEAMIIDNQYJ" +
            "KoZIhvcNAQcBMBwGCiqGSIb3DQEMAQMwDgQIsoM93/dkh1ACAggAgIIDCMSHHNpOSN2mdpiryd2JsiKNu/VhrcjL" +
            "B+xOqHX8YUze+0n9da4vKZIQ3j7S3uipazcfX86bsdpImNTGy5L2OXeQq3h2+R5zzdKJ8bOAc9RMhjr++M8In0Sl" +
            "WzQBsSEPEgfmJyxsc0FqJ1hlGs3MoTBUutlWj/po4s/gn/hrr/pLRvLaBGD6PPf0RYkkcZU4G2PUGjfFvfJ58RZr" +
            "NK99j+DFixFp8lo57yXbkEDh7ZOaoBjx9bLCc7lZstGOqGrpDZB7jxsLaMSVncXxLASroUr84kQXZK7mFnbFcQBy" +
            "f2qX+daXIsBK73mmviCI14p2X4dBwHQZRsGtEXODkvcCJhME3QsM9WgowO+b3pydSNmTKZezx07DEscpPoo19SUs" +
            "qbIaschYvo4d1nPQfnnHQI6T8rqtTA5B5vLNeJaA0YyAN1FsRu3Twb2e8/WDMZdIYuHGziW9+lhChB6Z0WFr6bcj" +
            "gtLLk/3JCsZJ933QiXVL5VjFuhX15jEMfjRo3EUS+QZW2BH7Q6CEZV4wM5jBs3+xcI/vZ+yu4nYona+7tClaT7+a" +
            "Wlby7qACrx4l/Q408vSZEoS3Wb4tVTSLGSeQdzHNEgzRUG4M12YzanWRdTXqflR26WHddCdz2HgU5evUdt7uy068" +
            "1LeLyvLiarYbMMIoyvQhBNSdZT9YOhcYmgfLS9biSrr5NRJX4Bx3H2jOb/pSB/4lRPtt33hZKVUhaZUZyXgEI4Zx" +
            "hOcf15hVUvtgtTofEJFqi5PXcjSI9PcbouJQZcUw4soKAwugFQCHtNvd0ziqvDqfyMPHPZ9kh0+7v/DvhC9HYsYb" +
            "dkOgAMzx3lRRnx344T2etQ508wumC8l+nCeoOkTDC/N6WvGdhh7/sEzLsMc7AqKBmjvCYPBKDGGo2rMJSlDLGOTV" +
            "NR2w+ZrkqAEuD0HGsxf7/Yj989kszkh42oWW5KteoRsYevO86Q/WNc/qKaZFI01vtUeBI5VlBit8mO5u4bfbx7ZB" +
            "7asdlg1Fawi6QfoDXN7OLnA6JfYsfEmOAXFIMDEwITAJBgUrDgMCGgUABBQW3k9Fe3e1QD6JcnOvdFs8DOa4LQQI" +
            "nLjezmGwJ4ACAggA";

        private const string PfxWithKeyBase64 =
            "MIIJHAIBAzCCCOIGCSqGSIb3DQEHAaCCCNMEggjPMIIIyzCCA28GCSqGSIb3DQEHBqCCA2AwggNcAgEAMIIDVQYJ" +
            "KoZIhvcNAQcBMBwGCiqGSIb3DQEMAQMwDgQIpOfoi/I4mc8CAggAgIIDKAmiKzyY32OulcDWe8G6MWywXzEqeoc6" +
            "kNFmhx514AL5jZVkx4NM8+jmSfMM3EGhFdWR0125pLX9l02SlRurXtHFNY/TqbiY6SzfD/0tvt2ly/4Xi0mnLaR1" +
            "IHIDjPeyHQLBjPZKP8PfUsfh14ys5LSS4xaMJpaosWIB46hRrjdZ8dgYGApCpPRGo535BkY85KSZYhf7HANH0cOv" +
            "Q6ZV4eEe/nuEiKhj2hlgWVl4HEZfBW9s68OIa+6Z7T9FuJGUgb+YIBwbzrnw5+NZtUHjnV16+XDkZ454tF6TdBQ6" +
            "EwYA+BtWVa3RFwas7rd29VjGcQII0DMbPcs9HiqZ4oX5WOtHnJXaalgu3NgOou9iTECcwCPmprgvDsqTZXzpFJzM" +
            "oIqxLvsMZodrRijFZcsNfvFC+ipdr756LXeuJ+30Z+srIWyFY8UwL4uyT/hUeYGZa8BElwjDdqtLOHWsM4w/ZnF4" +
            "0SNiK+nuDGvPZzyYTX3X0rMsfO4XUms3Jl2Q5elnnwy+JlOM22ttD9QEET+WuqqsZH4X/21qZvXJFJ9WXT4TR3qh" +
            "163zG+7/Uh5KqVTrpLDUzNRAu/Ap5I8robJvDEVZkCnz/sq/ZhtKqXLefyaaltclkby2LHzESSuERoccIuMnJpJj" +
            "Md4KX7hupLuQSKo4S8sGPci7L6nhXJDB2RZp432odHpCrSHU5DWqgsHCP3s6D20lvPQcFmZYpB3ZwrdwYx26Xzik" +
            "atJeJw+VqmbzMzn89CHek5QDVuzqi0ksq8cVNtbMfAZ3a7mwTEvnxlfE/SYfQ99oO6uaKJ00z1WnbwWslWdZ56ol" +
            "IJWr/aC90V5vqOVcju3dc5kQMvCd7uqbfsheF2JqoLJzEyyBpCi9Puv3qq47vwmtH2WQsl0qT5/HZC3NUEMem2sc" +
            "Te5F8JBG3F0/z8Otl3RlfPOCYcEruGNucUs7j6gaqRI+XAO8hYcFaI/MNBqaA7E6O8lslQ0BiMvh6+QbPphCvNTe" +
            "9szsdZ808wbFKWQctgn7BNmJZ59Nwxn5HRFiX0wRK2QOz/xDIU/QpvYDEJFPazhZ1Xvs8IHhePyGQ/0wggVUBgkq" +
            "hkiG9w0BBwGgggVFBIIFQTCCBT0wggU5BgsqhkiG9w0BDAoBAqCCBO4wggTqMBwGCiqGSIb3DQEMAQMwDgQI2zkS" +
            "h7KU0IcCAggABIIEyNupGxghMDwk8G1TckWE0Cj4ny01wA2o5mWsfGXdZNSXBsiqRHMEQBwSGj7k20R1DxcW64Pt" +
            "+/TTaPCHUxcL+RxfH82hqBG7PA/5kWa93pR/pvaBRMlM2j8aah9bsaj3uXkoiI9BqhnitM9/lMBTiP6iQchEZyDi" +
            "D2SrpmXmlDpsLcrqnVKZotQfxUUeL8hsqs6XakwF93LpkpBThQ+ltZimoFI/YlCxlXhhOjFNvPW8WMHojmSMPjh5" +
            "frM3iifSuy9L3Bs+dOMDeH/gVF9d8afQXoONqJjX+DrzCerznTMralYoAy0xpg8guO1kok6Jw8zQlAgpI34Ls1h7" +
            "VNHup25Eku/JkGDGDZJ/wo1wa+7i4WBq6SyAHmNu2IaGVTZm1ktp0NrypXDoYk0oGQWOsxv+cRzpGO4mSfa/pLF0" +
            "dIxVtKUHI+v3ZoZw1M07Nf0MleZnlGm02cDUTdDSZDAV/z1Sfvg6wpOSaqwkpvRQdUvn4bF2rddxd4f51kSD0OGq" +
            "f3Uidf9FHJ7QE7T51citSI3qoDkEZaImXrmbuYIBIVfvWlLVvah68w6PKfZmMpIbPsxDC9t4dKhSknq/SobjSRQQ" +
            "cjQsaXc7pSfTBeeajuR40jW+R8xp6sGFq4GAvBDNuLtpXiNcPsOs9p06MHDgZ0gUv57tNjHgzW5tHdk3L81b6pGi" +
            "Uus1Oa7VOt+s+cNFxCHDEVKa/+tA7WVrFSS4RWxKP/D7KeiEx2e0HDmcL86DycLW6kHTx172Unrt+QYCamkGpSWA" +
            "KT6QYxDdVsj5n9oD2wtth2otgnStb4AE2DpMYwebQUnJ8Dx94UvCbcgbxTGVUMRZR0msjLumepOe35R7oiU/XkPW" +
            "TRjhZVj4PM8ViatMkcpleKke2bKXa3UHk/YNxphJNVaEPJfPYDL9eLWvyCgpr0gwnTvC0O3U+V5jgxu96l9U1oa8" +
            "Gt8Gk4sMjkQ/Bq5Zc/NrA1iGOhPu89U4uDfKJ/LIUSyCEINEE/YjOsf3OllZ/pTC7nwdtLEJy0TB3IcbUqjFGgDi" +
            "+JKct9LAKQRDbqEmNHAYQ40zuRQToCSyqaaoddojAVlqmjVYm0FcOD/oVb/eg4xP9n0RHbjZFNgMHb5rAB4o0JLB" +
            "4ytNM5gYKpmHn9mwURY0KgCT0rjDy/HrjonS+af0I2NW7o1BXLLpM7CoNscqtntiRenCX/McCrFt8x10e2czMAUO" +
            "gjjCzcI1al1Jyc20ueydWIqPBE5XLRGZ+Ypk1cIotQST4e4ENaDtyVPPVEZ4YTd+Xh0G5Js6iQBCXSWxzbv2pAui" +
            "MG57butqT5VXANWGYD67FGxWjqrNcw7bbP9niTa1UtEpxlFs4n1lqpStZRfSiry7owJBevr1+18cOaz+Mh8TDLAz" +
            "seVpDM6qG7wK7qCPNqRo1snanCGaAyLshvt7uIzzYXCzFwTJkU8Zlxi48BF5BYarCAT4OmPkeDL+6lDH4u56D3Cu" +
            "iFlkrpvtOsDdEr1NVqk5Gw6+3D9r/ZYZiV/yDZ8chSn8G6I/1i9GYRNDN+pC/+djlMYls/Ay7YSAmiIBC5/woieR" +
            "jk1waIwG3FAHe95RM2oU8lg7RZhJ50pMfVqSEi+Q3GOt14RTFLFbSBtmGr9xVXFMhzE4MBEGCSqGSIb3DQEJFDEE" +
            "HgIAdDAjBgkqhkiG9w0BCRUxFgQU7HcWnwHVM2wmMrIp648oFl3+BngwMTAhMAkGBSsOAwIaBQAEFGseNhEIV3qR" +
            "voP06d3j9uvAOFZQBAhE8i/KYLI+FQICCAA=";

        // ----------------------------------------------------

        public static byte[] CertBytes() => Convert.FromBase64String(CertBase64);

        // ----------------------------------------------------

        public static byte[] PfxNoKeyBytes() => Convert.FromBase64String(PfxNoKeyBase64);

        // ----------------------------------------------------

        public static byte[] PfxWithKeyBytes() => Convert.FromBase64String(PfxWithKeyBase64);

        // ----------------------------------------------------

        public static X509Certificate2 CreateCertificate() => new X509Certificate2(CertBytes());

        // ----------------------------------------------------

        public static SecureString CreateSecurePassword()
        {
            var result = new SecureString();

            foreach(var ch in Password)
            {
                result.AppendChar(ch);
            }

            result.MakeReadOnly();

            return result;
        }
    }
}
