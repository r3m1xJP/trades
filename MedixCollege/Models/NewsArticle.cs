using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedixCollege.Models
{
    public class NewsArticle
    {
        public NewsArticleDTO NewsArticleDTO { get; set; }
        private bool _connectionOpen;
        private MySqlConnection _connection;

        public NewsArticle()
        {

        }

        public NewsArticle(int id)
        {
            GetConnection();
            NewsArticleDTO = new NewsArticleDTO();
            NewsArticleDTO.Id = id;

            try
            {
                var cmd = new MySqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = string.Format("SELECT * FROM NewsArticle WHERE Id = {0}", id);

                var reader = cmd.ExecuteReader();

                try
                {
                    reader.Read();

                    if (reader.IsDBNull(1) == false)
                        NewsArticleDTO.Date = reader.GetDateTime(1);
                    else
                        NewsArticleDTO.Date = DateTime.Now;

                    if (reader.IsDBNull(2) == false)
                        NewsArticleDTO.Title = reader.GetString(2);
                    else
                        NewsArticleDTO.Title = null;

                    if (reader.IsDBNull(3) == false)
                        NewsArticleDTO.Body = reader.GetString(3);
                    else
                        NewsArticleDTO.Body = null;

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
        }

        public IList<NewsArticleDTO> Get()
        {
            GetConnection();
            IList<NewsArticleDTO> newsArticles = new List<NewsArticleDTO>();

            try
            {
                var cmd = new MySqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = string.Format("SELECT * FROM NewsArticle ORDER BY Id DESC");

                var reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        var newsArticle = new NewsArticleDTO();

                        if (reader.IsDBNull(0) == false)
                            newsArticle.Id = reader.GetInt32(0);
                        else
                            newsArticle.Date = DateTime.Now;

                        if (reader.IsDBNull(1) == false)
                            newsArticle.Date = reader.GetDateTime(1);
                        else
                            newsArticle.Date = DateTime.Now;

                        if (reader.IsDBNull(2) == false)
                            newsArticle.Title = reader.GetString(2);
                        else
                            newsArticle.Title = null;

                        if (reader.IsDBNull(3) == false)
                            newsArticle.Body = reader.GetString(3);
                        else
                            newsArticle.Body = null;

                        newsArticles.Add(newsArticle);
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

            return newsArticles;
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

    public class NewsArticleDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
