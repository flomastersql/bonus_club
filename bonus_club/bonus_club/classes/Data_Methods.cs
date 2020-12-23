using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace bonus_club
{
    class Data_Methods
    {
        public static DateTime date_time_from_str_sql(string str_date_from_sql, bool ret_date = true)
        {
            if (str_date_from_sql.Length < 3)
            {
                return new DateTime(1900, 1, 1, 10, 10, 10);
            }

            int year = int.Parse(
                str_date_from_sql.ToString()[6].ToString() +
                str_date_from_sql.ToString()[7].ToString() +
                str_date_from_sql.ToString()[8].ToString() +
                str_date_from_sql.ToString()[9].ToString()
                 );

            int month = int.Parse(
                str_date_from_sql.ToString()[3].ToString() +
                str_date_from_sql.ToString()[4].ToString()
                 );

            int day = int.Parse(
                str_date_from_sql.ToString()[0].ToString() +
                str_date_from_sql.ToString()[1].ToString()
                 );

            if (ret_date)
            {
                return new DateTime(
                   year, month, day);
            } else
            {
                string hour = str_date_from_sql.ToString()[11].ToString();
                int min_index = 13;
                if (str_date_from_sql.ToString()[12] != ':')
                {
                    hour += str_date_from_sql.ToString()[12].ToString();
                    min_index++;
                }

                return new DateTime(
                   year, month, day
                   , int.Parse(hour)
                    , int.Parse(
                    str_date_from_sql.ToString()[min_index].ToString() +
                    str_date_from_sql.ToString()[min_index + 1].ToString()
                    )
                    , int.Parse(
                    str_date_from_sql.ToString()[min_index + 3].ToString() +
                    str_date_from_sql.ToString()[min_index + 4].ToString()
                    )
                   );
            }
        }

        public static string DT_to_string_sep_zpt(DataTable DT)
        {
            string ext = "";
            foreach (DataRow ord in DT.Rows)
            {
                ext += "," + ord[0].ToString();
            }
            if (ext.Length > 0)
            {
                return ext.Substring(1, ext.Length-1);
            } else
            {
                return "1";
            }
        }
    }
}
