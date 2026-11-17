#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.IO;
using System.Web;
using JWWrap.Interface.Web;

namespace JWWrap.Impl.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpPostedFilewRAP Description
    /// </summary>

    public class HttpPostedFileWrap : IHttpPostedFile
    {
        private readonly HttpPostedFile Instance;

        // ------------------------------------------------

        public HttpPostedFileWrap(HttpPostedFile instance)
        {
            Instance = instance;
        }

        // ------------------------------------------------

        public string FileName => Instance.FileName;

        // ------------------------------------------------

        public string ContentType => Instance.ContentType;

        // ------------------------------------------------

        public int ContentLength => Instance.ContentLength;

        // ------------------------------------------------

        public Stream InputStream => Instance.InputStream;

        // ------------------------------------------------

        public void SaveAs(string filename)
        {
            Instance.SaveAs(filename);
        }
    }
}
