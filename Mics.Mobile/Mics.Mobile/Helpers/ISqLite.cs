using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mics.Mobile.Helpers
{
    interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
