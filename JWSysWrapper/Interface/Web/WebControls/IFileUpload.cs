#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.IO;
using System.Web;
using System.Collections.Generic;

namespace JWWrap.Web.WebControls
{
    public interface IFileUpload
    {
        bool AllowMultiple { get; set; }
        byte[] FileBytes { get; }
        Stream FileContent { get; }
        string FileName { get; }
        bool HasFile { get; }
        bool HasFiles { get; }
        IHttpPostedFile PostedFile { get; }
        IList<IHttpPostedFile> PostedFiles { get; }

        void SaveAs(string filename);
    }
}
