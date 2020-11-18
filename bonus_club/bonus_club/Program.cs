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
            //Grafana_DB_Methods.ins_user_data("111", "aaaaa", "bbbb", "", new DateTime(2000, 11, 1));

            //Console.ReadLine();
            foreach (DataRow row in BK_DB_Methods.get_alarm_pds_users().Rows)
            {
               // если пользователь westrest нету в графане
               if (!Grafana_DB_Methods.is_client_in_grafana(row["CardId"].ToString()))
                {
                    //добавляем
                    Console.WriteLine("no");

                    Grafana_DB_Methods.ins_user_data(
                        row["CardId"].ToString()
                        , row["FirstName"].ToString()
                        , row["LastName"].ToString()
                        , ""
                        ,
                        new DateTime(
                          int.Parse(
                        row["Birthday"].ToString()[6].ToString() +
                        row["Birthday"].ToString()[7].ToString() +
                        row["Birthday"].ToString()[8].ToString() +
                        row["Birthday"].ToString()[9].ToString()
                        )
                        , int.Parse(
                        row["Birthday"].ToString()[3].ToString() +
                        row["Birthday"].ToString()[4].ToString()
                        )
                        , int.Parse(
                        row["Birthday"].ToString()[0].ToString() +
                        row["Birthday"].ToString()[1].ToString()
                        ))

                        );

                   // cl.FirstName, cl.LastName, cl.Birthday, o.CardId
                } else {
                    
                    Console.WriteLine("yes");
                }
                    

            }

            Console.ReadLine();

        }
    }
}
