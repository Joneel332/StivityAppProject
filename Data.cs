using System;
using Microsoft.Data.SqlClient;
using Stivity.Models;

namespace Stivity.Data
{
    public class StivityRepository
    {
        private static bool _dbInitialized;

        private readonly string _masterConnStr =
            @"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=30;";

        private readonly string _connStr =
            @"Server=(localdb)\MSSQLLocalDB;Database=StivityDB;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=30;";

        private void EnsureDatabaseExists()
        {
            if (_dbInitialized) return;

            using var conn = new SqlConnection(_masterConnStr);
            conn.Open();

            using (var createDbCmd = new SqlCommand("IF DB_ID('StivityDB') IS NULL CREATE DATABASE StivityDB;", conn))
            {
                createDbCmd.ExecuteNonQuery();
            }

            conn.ChangeDatabase("StivityDB");

            const string initSql = @"
                IF OBJECT_ID('Students', 'U') IS NULL
                BEGIN
                    CREATE TABLE Students (
                        StudentID INT IDENTITY(1,1) PRIMARY KEY,
                        StudentNumber NVARCHAR(20) NOT NULL UNIQUE,
                        FullName NVARCHAR(100) NOT NULL,
                        PasswordHash NVARCHAR(255) NOT NULL,
                        WeeklyAllowance DECIMAL(10, 2) NOT NULL DEFAULT 0
                    );
                END

                IF NOT EXISTS (SELECT 1 FROM Students WHERE StudentNumber = '543210')
                BEGIN
                    INSERT INTO Students (StudentNumber, FullName, PasswordHash)
                    VALUES ('543210', 'Jerryme S. Tohoy', 'stivity123');
                END";

            using (var initCmd = new SqlCommand(initSql, conn))
            {
                initCmd.ExecuteNonQuery();
            }

            _dbInitialized = true;
        }

        public Student? Login(string studentNumber, string password)
        {
            EnsureDatabaseExists();

            const string sql = @"
                SELECT StudentID, StudentNumber, FullName
                FROM Students
                WHERE StudentNumber = @Num AND PasswordHash = @Pass";

            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Num", studentNumber.Trim());
            cmd.Parameters.AddWithValue("@Pass", password);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Student
                {
                    StudentID = reader.GetInt32(0),
                    StudentNumber = reader.GetString(1),
                    FullName = reader.GetString(2)
                };
            }
            return null;
        }

        public bool RegisterStudent(string studentNumber, string fullName, string password)
        {
            EnsureDatabaseExists();

            const string checkSql = "SELECT COUNT(1) FROM Students WHERE StudentNumber = @Num";
            const string insertSql = @"
                INSERT INTO Students (StudentNumber, FullName, PasswordHash)
                VALUES (@Num, @Name, @Pass)";

            using var conn = new SqlConnection(_connStr);
            conn.Open();

            using (var checkCmd = new SqlCommand(checkSql, conn))
            {
                checkCmd.Parameters.AddWithValue("@Num", studentNumber.Trim());
                if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                    return false;
            }

            using (var insertCmd = new SqlCommand(insertSql, conn))
            {
                insertCmd.Parameters.AddWithValue("@Num", studentNumber.Trim());
                insertCmd.Parameters.AddWithValue("@Name", fullName.Trim());
                insertCmd.Parameters.AddWithValue("@Pass", password);
                return insertCmd.ExecuteNonQuery() > 0;
            }
        }
    }
}