using adonet_db_videogame;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VideogameManager
{
    private readonly string _connectionString;

    public VideogameManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void InserisciVideogame(Videogame videogame)
    {
        if (string.IsNullOrWhiteSpace(videogame.Name))
        {
            throw new ArgumentException("Il nome del videogioco non può essere vuoto.");
        }

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(
                "INSERT INTO Videogames (Nome, Genere, AnnoDiUscita) " +
                "VALUES (@Nome, @Genere, @AnnoDiUscita); " +
                "SELECT CAST(scope_identity() AS int)",
                conn);
            command.Parameters.AddWithValue("@Nome", videogame.Name);
            command.Parameters.AddWithValue("@Genere", videogame.Genre);
            command.Parameters.AddWithValue("@AnnoDiUscita", videogame.ReleaseYear);
                
            int nuovoId = (int)command.ExecuteScalar();

            videogame.Id = nuovoId;
        }
    }

    public Videogame? GetVideogameById(int id)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(
                "SELECT Id, Nome, Genere, AnnoDiUscita FROM Videogames WHERE Id = @Id",
                conn);
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Videogame videogame = new Videogame();
                videogame.Id = reader.GetInt32(0);
                videogame.Name = reader.GetString(1);
                videogame.Genre = reader.GetString(2);
                videogame.ReleaseYear = reader.GetInt32(3);
                return videogame;
            }
            else
            {
                return null;
            }
        }
    }

    public List<Videogame> CercaVideogiochiPerNome(string nome)
    {
        List<Videogame> videogiochi = new List<Videogame>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(
                "SELECT Id, Nome, Genere, AnnoDiUscita FROM Videogames WHERE Nome LIKE @Nome",
                conn);
            command.Parameters.AddWithValue("@Nome", $"%{nome}%");

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Videogame videogame = new Videogame();
                videogame.Id = reader.GetInt32(0);
                videogame.Name = reader.GetString(1);
                videogame.Genre = reader.GetString(2);
                videogame.ReleaseYear = reader.GetInt32(3);
                videogiochi.Add(videogame);
            }
        }

        return videogiochi;
    }

    public void CancellaVideogame(int id)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(
                "DELETE FROM Videogames WHERE Id = @Id",
                conn);
            command.Parameters.AddWithValue("@Id", id);

            int numDeleted = command.ExecuteNonQuery();
            if (numDeleted == 0)
            {
                throw new ArgumentException($"Il videogioco con id {id} non esiste.");
            }
        }
    }
}