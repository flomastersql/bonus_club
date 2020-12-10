using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace bonus_club
{
    class Rkeeper_RPC_DB_Methods
    {
        public static string get_table_by_check(string rk_check_num, string rk_rest_code)
        {
            SqlDataAdapter sda = new SqlDataAdapter(
                "	select ORDERS.TABLENAME from ORDERS join PRINTCHECKS on ORDERS.VISIT = PRINTCHECKS.VISIT where  PRINTCHECKS.CHECKNUM = " + rk_check_num
                     , Grafana_DB_Methods.get_rkeeper_constr(rk_rest_code));

            DataTable DT = new DataTable();
            sda.Fill(DT);

            return DT.Rows[0][0].ToString();
        }
    }
}
