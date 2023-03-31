#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data.SqlClient;

namespace JWWrap.Interface.Data.SqlClient
{
    public interface ISqlConnectionFactory : IDisposable
    {
        ISqlConnection Create();
        ISqlConnection Create(SqlConnection connection);
        ISqlConnection Create(string connectionString);
    }
}
