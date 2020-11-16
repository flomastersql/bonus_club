using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace bonus_club
{
    class BK_DB_Methods
    {
        static string str = "uid=crm_usr;pwd=zTQrW4HTPA;Initial Catalog=Vlad.CRM;Data Source=192.168.100.5";


        public static DataTable get_alarm_pds_pays()
        {
            SqlDataAdapter sda = new SqlDataAdapter(
                "	select CardId, count(*) from Orders where RkOrderDate > GETDATE() - 2 group by CardId having count(*) > 1	 "

                , str);

            DataTable DT = new DataTable();
            sda.Fill(DT);
            return DT;
        }

    }
}
