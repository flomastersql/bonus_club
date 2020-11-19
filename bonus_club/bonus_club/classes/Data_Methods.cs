using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bonus_club
{
    class Data_Methods
    {
        public static DateTime date_time_from_str_sql(string str_date_from_sql)
        {
            return new DateTime(
               int.Parse(
            str_date_from_sql.ToString()[6].ToString() +
            str_date_from_sql.ToString()[7].ToString() +
            str_date_from_sql.ToString()[8].ToString() +
            str_date_from_sql.ToString()[9].ToString()
             )
             , int.Parse(
            str_date_from_sql.ToString()[3].ToString() +
            str_date_from_sql.ToString()[4].ToString()
             )
             , int.Parse(
            str_date_from_sql.ToString()[0].ToString() +
            str_date_from_sql.ToString()[1].ToString()
             ));
        }
    }
}
