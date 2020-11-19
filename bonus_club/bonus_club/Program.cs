using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace bonus_club
{
    class Program
    {
        // кол-во дней отступить от сегодняшнего (использовать для дебага когда в текущем дне нет примеров)
        public static string datediff = "1";
        static void Main(string[] args)
        {
            foreach (DataRow row in BK_DB_Methods.get_alarm_pds_users().Rows)
            {
               // если пользователь westrest нету в графане
               if (!Grafana_DB_Methods.is_client_in_grafana(row["CardId"].ToString()))
                {
                    //добавляем
                    Console.WriteLine("add user");

                    Grafana_DB_Methods.ins_user_data(
                        row["CardId"].ToString()
                        , row["FirstName"].ToString()
                        , row["LastName"].ToString()
                        , ""
                        , Data_Methods.date_time_from_str_sql(row["Birthday"].ToString())
                        );
                }

                Console.WriteLine(
                BK_DB_Methods.get_bk_orders_of_users(row["CardId"].ToString()).Rows.Count.ToString());



            }
            //Console.ReadLine();
        }
    }
}
