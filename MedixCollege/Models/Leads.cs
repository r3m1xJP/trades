using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradesCollege.Models
{
    public class Leads
    {
        public LeadsDTO LeadsDTO { get; set; }
        private bool _connectionOpen;
        private MySqlConnection _connection;

        public Leads()
        {

        }

        public IList<LeadsDTO> Get(int count = 10)
        {
            GetConnection();
            IList<LeadsDTO> leads = new List<LeadsDTO>();

            try
            {
                var cmd = new MySqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = string.Format("SELECT * FROM Leads ORDER BY Id DESC LIMIT {0}", count);

                var reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        var lead = new LeadsDTO();

                        if (reader.IsDBNull(0) == false)
                            lead.Id = reader.GetInt32(0);
                        else
                            lead.Id = 0;

                        if (reader.IsDBNull(1) == false)
                            lead.Date = reader.GetDateTime(1);
                        else
                            lead.Date = DateTime.Now;

                        if (reader.IsDBNull(2) == false)
                            lead.FirstName = reader.GetString(2);
                        else
                            lead.FirstName = "";

                        if (reader.IsDBNull(3) == false)
                            lead.LastName = reader.GetString(3);
                        else
                            lead.LastName = "";

                        if (reader.IsDBNull(4) == false)
                            lead.Telephone = reader.GetInt64(4);
                        else
                            lead.Telephone = 0;

                        if (reader.IsDBNull(5) == false)
                            lead.Email = reader.GetString(5);
                        else
                            lead.Email = "";

                        if (reader.IsDBNull(6) == false)
                            lead.Location = reader.GetString(6);
                        else
                            lead.Location = "";

                        if (reader.IsDBNull(7) == false)
                            lead.Program = reader.GetString(7);
                        else
                            lead.Program = "";

                        if (reader.IsDBNull(8) == false)
                            lead.HearAbout = reader.GetString(8);
                        else
                            lead.HearAbout = "";

                        if (reader.IsDBNull(9) == false)
                            lead.Comments = reader.GetString(9);
                        else
                            lead.Comments = "";

                        leads.Add(lead);
                    }

                    reader.Close();
                }
                catch (MySqlException e)
                {
                    //TODO: log error
                    reader.Close();
                }
            }
            catch (MySqlException e)
            {
                //TODO: log error
            }

            _connection.Close();

            return leads;
        }

        public bool Insert(LeadsDTO lead)
        {
            GetConnection();

            try
            {
                var cmd = new MySqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = string.Format("INSERT INTO Leads VALUES (" +
                "{0},'{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}')", 
                0, lead.Date.ToString("yyyy-MM-dd HH:mm:ss"), lead.FirstName, lead.LastName, lead.Telephone, lead.Email, 
                lead.Location, lead.Program, lead.HearAbout, lead.Comments);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException e)
            {
                //TODO: log error
            }

            _connection.Close();

            return false;
        }

        private void GetConnection()
        {
            _connectionOpen = false;

            _connection = new MySqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            if (OpenLocalConnection())
            {
                _connectionOpen = true;
            }
        }

        private bool OpenLocalConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

    public class LeadsDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Int64 Telephone { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public string Program { get; set; }

        public string HearAbout { get; set; }

        public string Comments { get; set; }
    }
}
