using System.Configuration;

namespace FormUI
{
    public class Helper
    {
        public static string CnnVal(string name)
        {
           return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
