#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using JWWrap.Interface.Web.WebControls;
using JWWrap.Interface.Web;

namespace JWWrap.Impl.Web.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     FileUploadWrap Description
    /// </summary>

    public class FileUploadWrap : IFileUpload
    {
        private readonly FileUpload Instance;
        private readonly IList<IHttpPostedFile> _postedFiles;

        // ------------------------------------------------

        public FileUploadWrap(FileUpload instance)
        {
            Instance = instance;
            _postedFiles = new List<IHttpPostedFile>();

            if(Instance != null)
            {
                foreach(var postedFile in Instance.PostedFiles)
                {
                    _postedFiles.Add(new HttpPostedFileWrap(postedFile));
                }
            }
        }

        // ------------------------------------------------

        public bool AllowMultiple { get => Instance.AllowMultiple; set => Instance.AllowMultiple = value; }

        // ------------------------------------------------

        public byte[] FileBytes => Instance.FileBytes;

        // ------------------------------------------------

        public Stream FileContent => Instance.FileContent;

        // ------------------------------------------------

        public string FileName => Instance.FileName;

        // ------------------------------------------------

        public bool HasFile => Instance.HasFile;

        // ------------------------------------------------

        public bool HasFiles => Instance.HasFiles;

        // ------------------------------------------------

        public IHttpPostedFile PostedFile => new HttpPostedFileWrap(Instance.PostedFile);

        // ------------------------------------------------

        public IList<IHttpPostedFile> PostedFiles => _postedFiles;

        // ------------------------------------------------

        public void SaveAs(string filename)
        {
            Instance.SaveAs(filename);
        }
    }
}
