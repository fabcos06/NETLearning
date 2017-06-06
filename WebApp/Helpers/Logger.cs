using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Configuration;
using WebApp.Models;


namespace WebApp.Helpers
{
    public class Logger
    {
        public void addEvent(string user_id, string eventType)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["userdata"].ToString());
            var dbcommand = new SqlCommand("insert into app_events (user_id, event_date, event_type) values (@user_id, @event_date, @event_type)", dbcon);
            dbcommand.Parameters.AddWithValue("@user_id", SqlDbType.UniqueIdentifier).Value = user_id;
            dbcommand.Parameters.AddWithValue("@event_date", SqlDbType.DateTime).Value = DateTime.Now;
            dbcommand.Parameters.AddWithValue("@event_type", SqlDbType.VarChar).Value = eventType;
            dbcon.Open();
            var result = dbcommand.ExecuteNonQuery();
            dbcon.Close();
            return;
        }

        public List<AppEvent> getEvents(string user_id)
        {
            var dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["userdata"].ToString());
            var dbcommand = new SqlCommand("select * from app_events where user_id = @user_id", dbcon);
            dbcommand.Parameters.AddWithValue("@user_id", SqlDbType.UniqueIdentifier).Value = user_id;
            dbcon.Open();
            var reader = dbcommand.ExecuteReader();
            var model = new List<AppEvent>();
            while (reader.Read())
            {
                var appEvent = new AppEvent();
                appEvent.user_id = reader["user_id"].ToString();
                appEvent.event_date = reader["event_date"].ToString();
                appEvent.event_type = reader["event_type"].ToString();
                model.Add(appEvent);
            }
            dbcon.Close();
            return model;
        }



    }
}