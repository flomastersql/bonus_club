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


        public static void ins_user_data(string card_id, string fst_name, string scnd_name, string tel,  DateTime birthday)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                //параметр определения строки которую правим
                SqlCommand sp = new SqlCommand(
                   "	INSERT INTO [dbo].[westrest_clients]	 " +
                    "	           ([id]	 " +
                    "	           ,[fst_name]	 " +
                    "	           ,[scnd_name]	 " +
                    "	           ,[tel]	 " +
                    "	           ,[birthday])	 " +
                    "	     VALUES	 " +
                    "	           (@card_id	 " +
                    "	           ,@fst_name	 " +
                    "	           ,@scnd_name	 " +
                    "	           ,@tel     " +
                    "	           ,@birthday)	 "
            , connection);
                sp.Connection.Open();

                SqlParameter spar_card_id = sp.Parameters.Add("@card_id", SqlDbType.Int);
                spar_card_id.Direction = ParameterDirection.Input;
                spar_card_id.Value = card_id;

                SqlParameter spar_fst_name = sp.Parameters.Add("@fst_name", SqlDbType.VarChar, 200);
                spar_fst_name.Direction = ParameterDirection.Input;
                spar_fst_name.Value = fst_name;

                SqlParameter spar_scnd_name = sp.Parameters.Add("@scnd_name", SqlDbType.VarChar, 200);
                spar_scnd_name.Direction = ParameterDirection.Input;
                spar_scnd_name.Value = scnd_name;

                SqlParameter spar_tel = sp.Parameters.Add("@tel", SqlDbType.VarChar, 100);
                spar_tel.Direction = ParameterDirection.Input;
                spar_tel.Value = tel;

                SqlParameter spar_birthday = sp.Parameters.Add("@birthday", SqlDbType.DateTime);
                spar_birthday.Direction = ParameterDirection.Input;
                spar_birthday.Value = birthday;

                sp.ExecuteNonQuery();

            }
        }

        public static List<string> get_ids_orders_observed_early(string card_id)
        {

            SqlDataAdapter sda = new SqlDataAdapter(
               " select id ids from westrest_orders " +
               " where [id_guest_card] = " + card_id + " and CONVERT(varchar, order_date, 101) = CONVERT(varchar, GETDATE() - " + Program.datediff + ", 101) "
                , str);

            DataTable DT = new DataTable();
            sda.Fill(DT);

            List<string> L = new List<string>();

            foreach(DataRow row in DT.Rows)
            {
                L.Add(row[0].ToString());
            }
            return L;
        }

        public static void ins_order_in_grafana(string id_order, string keeper_code, string id_guest_card, string rk_check_num, DateTime order_date
            , object check_sum, object paid_bonuses, object got_bonuses, string check_items_count
            )
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                SqlCommand sp = new SqlCommand(
                "	INSERT INTO [dbo].[westrest_orders]	 " +
                "	           ([id]	 " +
                "	           ,[id_rest]	 " +
                "	           ,[id_guest_card]	 " +
                "	           ,[rk_check_num]	 " +
                "	           ,[order_date]	 " +
                "	           ,[rest_table]	 " +
                "	           ,[check_sum]	 " +
                "	           ,[paid_bonuses]	 " +
                "	           ,[got_bonuses]	 " +
                "	           ,[check_items_count])	 " +
                "	     VALUES	 " +
                "	           (@id_order	 " +
                "	           ,(select id from restaurants where keeper_code = @keeper_code)	 " +
                "	           ,@id_guest_card " +
                "	           ,@rk_check_num " +
                "	           ,@order_date " +
                "	           ,null	 " +
                "	           ,@check_sum " +
                "	           ,@paid_bonuses " +
                "	           ,@got_bonuses " +
                "	           ,@check_items_count)	 "

            , connection);
                sp.Connection.Open();

                SqlParameter spar_id_order = sp.Parameters.Add("@id_order", SqlDbType.Int);
                spar_id_order.Direction = ParameterDirection.Input;
                spar_id_order.Value = int.Parse(id_order);

                SqlParameter spar_keeper_code = sp.Parameters.Add("@keeper_code", SqlDbType.BigInt);
                spar_keeper_code.Direction = ParameterDirection.Input;
                spar_keeper_code.Value = int.Parse(keeper_code);

                SqlParameter spar_id_guest_card = sp.Parameters.Add("@id_guest_card", SqlDbType.Int);
                spar_id_guest_card.Direction = ParameterDirection.Input;
                spar_id_guest_card.Value = int.Parse(id_guest_card);

                SqlParameter spar_rk_check_num = sp.Parameters.Add("@rk_check_num", SqlDbType.Int);
                spar_rk_check_num.Direction = ParameterDirection.Input;
                spar_rk_check_num.Value = int.Parse(rk_check_num);

                SqlParameter spar_order_date = sp.Parameters.Add("@order_date", SqlDbType.DateTime);
                spar_order_date.Direction = ParameterDirection.Input;
                spar_order_date.Value = order_date;

                SqlParameter spar_check_sum  = sp.Parameters.Add("@check_sum", SqlDbType.Decimal);
                spar_check_sum.Direction = ParameterDirection.Input;
                spar_check_sum.Value = check_sum;

                SqlParameter spar_paid_bonuses = sp.Parameters.Add("@paid_bonuses", SqlDbType.Decimal);
                spar_paid_bonuses.Direction = ParameterDirection.Input;
                spar_paid_bonuses.Value = paid_bonuses;

                SqlParameter spar_got_bonuses = sp.Parameters.Add("@got_bonuses", SqlDbType.Decimal);
                spar_got_bonuses.Direction = ParameterDirection.Input;
                spar_got_bonuses.Value = got_bonuses;

                SqlParameter spar_check_items_count = sp.Parameters.Add("@check_items_count", SqlDbType.Int);
                spar_check_items_count.Direction = ParameterDirection.Input;
                spar_check_items_count.Value = int.Parse(check_items_count);

                sp.ExecuteNonQuery();

            }
        }
    }
}
