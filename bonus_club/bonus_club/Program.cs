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
        public static string datediff = "16";
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

                

                //список заказов которые уже были записаны по пользователю за сегодня
                List<string> ids_orders_observed_early = Grafana_DB_Methods.get_ids_orders_observed_early(row["CardId"].ToString());
                //общий список заказов пользователя за день
                DataTable DT_bk_orders_of_users = BK_DB_Methods.get_bk_orders_of_users(row["CardId"].ToString());

                Console.WriteLine(row["CardId"].ToString() + " " + DT_bk_orders_of_users.Rows.Count.ToString());


                //если было замечено меньше заказов чем сейчас
                if (ids_orders_observed_early.Count < DT_bk_orders_of_users.Rows.Count)
                {                    
                    //идем по общему списку заказов пользователя за сегодня
                    foreach(DataRow order in DT_bk_orders_of_users.Rows)
                    {
                        //и если текущего заказа в списке ранее замеченных - нет, то записываем его
                        if (!ids_orders_observed_early.Contains(order["id"].ToString()))
                        {
                            Grafana_DB_Methods.ins_order_in_grafana(
                                order["id"].ToString()
                                , order["RkRestaurantCode"].ToString()
                                , row["CardId"].ToString()
                                , order["RkCheckNum"].ToString()
                                , Data_Methods.date_time_from_str_sql("18.11.2020 16:59:10", false)
                                , order["Sum"].ToString()
                                , order["PaidBonuses"].ToString()
                                , order["GotBonuses"].ToString()
                                , order["ItemCount"].ToString()
                                );
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
