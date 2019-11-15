using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS
{
    class global
    {
        // DIRI KAMO SET SNG GLOBAL VARIABLES NGA PWEDE NINYO MA GAMIT SA SYSTEM...
        // MAG CALL LNG DAYUN SNG VARIABLE MUNI : global.variablename


        // CHANGE ACCORDING TO YOUR SETTINGS
        public static string connectionString = string.Format("datasource=localhost;username=root;password=yourpassword");






        public static string[] sales_product_id = new string[1000];
        public static string[] sales_procudt_code = new string[1000];
        public static string[] sales_product_description = new string[1000];
        public static string[] sales_product_quantity = new string[1000];
        public static string[] sales_product_discount = new string[1000];
        public static string[] sales_product_base_price = new string[1000];
        public static string[] sales_product_price = new string[1000];
        public static string[] sales_total = new string[1000];
        public static string[] sales_product_old_quantity = new string[1000];


        public static string user;

        public static string customer_name = "_______________________________________________________";

        public static string customer_address = "_______________________________________________________";
    }
}
