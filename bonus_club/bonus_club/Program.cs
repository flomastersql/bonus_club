using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bonus_club
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BK_DB_Methods.get_alarm_pds_pays().Rows.Count.ToString());
            Console.ReadLine();
        }
    }
}
