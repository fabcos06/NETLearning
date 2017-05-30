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
            paramUserId.DbType = DbType.Guid;
            paramEventType.DbType = DbType.DateTime;
            paramEventDate.DbType = DbType.String;
            paramUserId.Value = id;
            paramEventDate.Value = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            paramEventType.Value = eventType;
            paramUserId.ParameterName = "user_id"; paramEventDate.ParameterName = "event_date"; paramEventType.ParameterName = "event_type";
            dbcommand.Parameters.Add(paramUserId);
            dbcommand.Parameters.Add(paramEventType);
            dbcommand.Parameters.Add(paramEventDate);
            dbcon.Open();
            var result = dbcommand.ExecuteNonQuery();
            dbcon.Close();
            return;
        }

    }
}