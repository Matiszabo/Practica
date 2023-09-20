using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace Practica.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=localhost;Database=GestionAlumnos;Trusted_Connection=True;";
        
        public static List<Alumno> SeleccionarAlumnos()
        {
            List<Alumno> ListaAlumnos;
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Alumno";
                ListaAlumnos = db.Query<Alumno>(sql).ToList();
            }
            return ListaAlumnos;
        }
    
        public static Alumno AlumnoElegido(int id)
        {
            Alumno Elegido = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string SQL = "SELECT * FROM Alumno WHERE id = @Alumno";
                Elegido = db.QueryFirstOrDefault<Alumno>(SQL, new { Alumno= id });
            }
            return Elegido;
        }
    }
}