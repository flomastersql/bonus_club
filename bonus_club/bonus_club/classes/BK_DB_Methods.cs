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


        public static DataTable get_alarm_pds_users()
        {
            // вариант: 
            // Здесь важно для СБ видеть начисления бонусов на одну карту 2 и более раза за одни день по всем ресторанам
            SqlDataAdapter sda = new SqlDataAdapter(
               " select cl.FirstName, cl.LastName, cl.Birthday, o.CardId from( " +
               " select CardId " +
               " from Orders " +
               " where CONVERT(varchar, RkOrderDate, 101) = CONVERT(varchar, GETDATE()- " + Program.datediff + ", 101) " +
               " group by CardId having count(*) > 1 " +
               " ) o join Cards c on o.CardId = c.Id " +
               " join Clients cl on c.ClientId = cl.id "

                , str);

            DataTable DT = new DataTable();
            sda.Fill(DT);
            return DT;
        }


        public static DataTable get_bk_orders_of_users(string cardid)
        {
            SqlDataAdapter sda = new SqlDataAdapter(
            " select id, RkCheckNum, RkRestaurantCode, RkOrderDate, [Sum], PaidBonuses, GotBonuses, ItemCount from Orders where " +
            "  CardId = " + cardid +
            " and CONVERT(varchar, RkOrderDate, 101) = CONVERT(varchar, GETDATE() - " + Program.datediff + ", 101)"
                , str);

            DataTable DT = new DataTable();
            sda.Fill(DT);
            return DT;
        }

        




    }
}
