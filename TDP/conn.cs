using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDP
{
    public static class conn
    {
        public static Database.Entities DBConnection;
        public static Database.Forging DBF;
        public static Database.Entities GetModel()
        {
            if (DBConnection == null)
            {
                DBConnection = new Database.Entities();
            }
            return DBConnection;
        }
        public static Database.Forging GetForging()
        {
            if (DBF == null)
            {
                DBF = new Database.Forging();
            }
            return DBF;
        }
    }
}
