using System;

namespace Tsp.Database
{
    public class MbGet
    {
        public static string Str(object obj1)
        {
            if (obj1 == System.DBNull.Value)
            {
                return null;
            }
            else
            {
                return obj1.ToString();
            }
        }

        public static decimal Dec(object obj1)
        {
            decimal num = 0;
            try
            {
                num = Decimal.Parse(obj1.ToString());
            }
            catch { }
            return num;
        }

        public static int Int(object obj1)
        {
            int num = 0;
            try
            {
                num = Int32.Parse(obj1.ToString());
            }
            catch { }
            return num;
        }

        public static DateTime? Date(object obj1)
        {
            DateTime? num = null;
            try
            {
                num = DateTime.Parse(obj1.ToString());
            }
            catch { }
            return num;
        }
    }
}
