using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ScoreRecord
{
    public class ScoreRepository
    {
        MySqlConnection conn;

        public static List<ScoreEntity> Scores = new List<ScoreEntity>();

        public ScoreRepository(MySqlConnection connection)
        {
            conn = connection;
        }
        public bool AddScores(string name, int englishGrade, int mathGrade, int economicGrade)
        {
            try
            {
                conn.Open();
                string addScore = "Insert into studentrecords (name, englishGrade, mathGrade, economicGrade)values ('" + name + "', '" + englishGrade + "', '" + mathGrade + "', '" + economicGrade + "')";
                MySqlCommand command = new MySqlCommand(addScore, conn);
                Console.WriteLine("Score Added Sucessfully!");
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }
        public ScoreEntity FindStudentScore(string name)
        {
            ScoreEntity student = null;
            try
            {
                conn.Open();
                string Query = "Select name, englishGrade, mathGrade, economicGrade from studentrecords where studentName = '" + name + "'";
                MySqlCommand command = new MySqlCommand(Query, conn);
                MySqlDataReader Index = command.ExecuteReader();
                while (Index.Read())
                {
                    {
                        int englishGrade = Index.GetInt32(1);
                        int mathGrade = Index.GetInt32(2);
                        int economicGrade = Index.GetInt32(3);
                        student = new ScoreEntity(name, englishGrade, mathGrade, economicGrade);
                    }
                    Console.WriteLine($"Name: {Index[0]}, English Grade: {Index[1]}, Maths Grade: {Index[2]}, Economics Grade: {Index[3]}");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return student;
        }
        public bool UpdateStudentScore(string name, int englishGrade, int mathGrade, int economicGrade)
        {
            var student = FindStudentScore(name);
            if (student == null)
            {
                Console.WriteLine($"Student with Name: {name} does not exist");
            }
            try
            {
                conn.Open();
                string updateScoreQuery = "update studentrecords set englishGrade ='" + englishGrade + "', mathGrade = '" + mathGrade + "' , economicScore = '" + economicGrade + "' where name = '" + name + "'";
                MySqlCommand command = new MySqlCommand(updateScoreQuery, conn);
                int Count = command.ExecuteNonQuery();
                Console.WriteLine("Student Score Update Sucessful!");
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }
        public bool DeleteStudentRecord(string name)
        {
            if (name == null)
            {
                Console.WriteLine($"Student with Name: {name} does not exist");
            }
            try
            {
                conn.Open();
                string deleteQuery = "delete from studentrecords where name = '" + name + "'";
                MySqlCommand command = new MySqlCommand(deleteQuery, conn);
                Console.WriteLine("Student Record Deleted Sucessfully!");
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }
        public void ListAllRecords()
        {
            List<ScoreEntity> Scores = new List<ScoreEntity>();
            try
            {
                conn.Open();
                string Query = "Select name, englishGrade, mathGrade, economicGrade from studentrecords";
                MySqlCommand command = new MySqlCommand(Query, conn);
                MySqlDataReader Index = command.ExecuteReader();
                while (Index.Read())
                {
                    Console.WriteLine($"Student Name: {Index[0]}, English Score: {Index[1]}, Maths Score: {Index[2]}, Economics Score: {Index[3]}");
                }
                Index.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void NumberOfStudentsAboveAverage()
        {
            List<ScoreEntity> Scores = new List<ScoreEntity>();
            try
            {
                int average =0;
                conn.Open();
                string scoreQuery = "Select name, englishGrade, mathGrade, economicGrade from studentrecords where englishGrade+mathGrade+economicGrade > '" + 150 + "'";
                MySqlCommand command = new MySqlCommand(scoreQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    average++;
                }
                Console.WriteLine($"The number of Students that  their  score is above average is: {average}");
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}