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
        static void Main(string[] args)
        {
            foreach (DataRow row in BK_DB_Methods.get_alarm_pds_users().Rows)
            {
               // если пользователь westrest нету в графане
               if (!Grafana_DB_Methods.is_client_in_grafana(row["CardId"].ToString()))
                {
                    //добавляем
                    Console.WriteLine("no");
                } else {
                    
                    Console.WriteLine("yes");
                }
                    

            }

            Console.ReadLine();

        }
    }
}
