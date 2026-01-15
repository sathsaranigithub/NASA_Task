using NasaApodGallery.Models;
using Microsoft.Data.SqlClient;


namespace NasaApodGallery.Data
{
    public class ApodRepository
    {
        private readonly string _connectionString;

        public ApodRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public void SaveApod(ApodDto apod)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = @"IF NOT EXISTS (SELECT 1 FROM Apod WHERE Date = @Date)
                     INSERT INTO Apod (Date, Title, Explanation, Url, MediaType, ServiceVersion)
                     VALUES (@Date, @Title, @Explanation, @Url, @MediaType, @ServiceVersion)";

            using SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date)
                .Value = DateTime.Parse(apod.date);   

            cmd.Parameters.Add("@Title", System.Data.SqlDbType.NVarChar).Value = apod.title;
            cmd.Parameters.Add("@Explanation", System.Data.SqlDbType.NVarChar).Value = apod.explanation;
            cmd.Parameters.Add("@Url", System.Data.SqlDbType.NVarChar).Value = apod.url;
            cmd.Parameters.Add("@MediaType", System.Data.SqlDbType.NVarChar).Value = apod.media_type;
            cmd.Parameters.Add("@ServiceVersion", System.Data.SqlDbType.NVarChar).Value = apod.service_version;

            cmd.ExecuteNonQuery();
        }
        public List<ApodDto> GetAll()
        {
            List<ApodDto> list = new();

            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT Date, Title, Explanation, Url, MediaType, ServiceVersion FROM Apod ORDER BY Date DESC";

            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ApodDto
                {
                    date = reader["Date"].ToString(),
                    title = reader["Title"].ToString(),
                    explanation = reader["Explanation"].ToString(),
                    url = reader["Url"].ToString(),
                    media_type = reader["MediaType"].ToString(),
                    service_version = reader["ServiceVersion"].ToString()
                });
            }

            return list;
        }

    }
}
