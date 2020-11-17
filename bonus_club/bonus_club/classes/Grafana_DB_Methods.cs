using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace bonus_club
{
    class Grafana_DB_Methods
    {
        static string str = "uid=Grafana;pwd=8emQ5NsG;Initial Catalog=Grafana_Monitoring;Data Source=10.0.20.8";
        public static bool is_client_in_grafana(string cardid)
        {
            SqlDataAdapter sda = new SqlDataAdapter(
              "select id from westrest_clients where id = " + cardid
               , str);

            DataTable DT = new DataTable();
            sda.Fill(DT);
            if (DT.Rows.Count == 0)
            {
                return false;
            } else
            {
                return true;
            }

        }
    }
}
