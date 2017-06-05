using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Configuration;

namespace WebApp.Helpers
{
    public class Logger
    {
        public static void addEvent(string id, string eventType)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["userdata"].ToString());
            var dbcommand = new SqlCommand("insert into events (user_id, event_date, event_type) values (@user_id, @event_date, @event_type)", dbcon);
            var paramUserId = new SqlParameter();
            var paramEventDate = new SqlParameter();
            var paramEventType = new SqlParameter();

            paramUserId.SqlDbType = SqlDbType.UniqueIdentifier;
            paramEventType.SqlDbType = SqlDbType.DateTime;
            paramEventDate.SqlDbType = SqlDbType.Text;
            paramUserId.Value = new Guid(id);
            var datestring = DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss:fff");
                //DateTime.ParseExact(DateTime.Now.ToString(), "YYYY-MM-DDThh:mm:ss.fff", null);
            paramEventDate.Value = datestring;
            paramEventType.Value = eventType;
            paramUserId.ParameterName = "user_id"; paramEventDate.ParameterName = "event_date"; paramEventType.ParameterName = "event_type";
            dbcommand.Parameters.Add(paramUserId);
            dbcommand.Parameters.Add(paramEventDate);
            dbcommand.Parameters.Add(paramEventType);
            dbcon.Open();
            var result = dbcommand.ExecuteNonQuery();
            dbcon.Close();
            return;
        }

    }
}