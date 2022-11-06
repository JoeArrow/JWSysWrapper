#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data.SqlClient;

namespace JWSysWrap.Interface.Data.SqlClient
{
    public interface ISqlCommandFactory : IDisposable
    {
        ISqlCommand Create();
        ISqlCommand Create(string cmdText);
        ISqlCommand Create(SqlCommand command);
        ISqlCommand Create(string cmdText, ISqlConnection connection);
    }
}
