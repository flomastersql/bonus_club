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
    }
}
