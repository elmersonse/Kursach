﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Kursach
{
    class Repository
    {
        private const string _connectionString = "Server=ALEXTRAZA\\SQLEXPRESS;Database=SummerCamp;Trusted_Connection=True;";
        private static SqlConnection _connection;
        private static SqlCommand _command;
        private static SqlDataReader _reader;
        private static DataTable _table;

        public static void OpenConnection()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public static DataTable LoadVojatiy()
        {
            _command = new SqlCommand("select * from Вожатый order by 2, 3, 4", _connection);
            _reader = _command.ExecuteReader();
            _table = new DataTable();
            _table.Load(_reader);
            return _table;
        }

        public static DataTable LoadZapis()
        {
            _command = new SqlCommand("select * from Запись_в_кружок_П order by 2, 3, 4", _connection);
            _reader = _command.ExecuteReader();
            _table = new DataTable();
            _table.Load(_reader);
            return _table;
        }

        public static DataTable LoadKomnata()
        {
            _command = new SqlCommand("select * from Комната_П order by 3, 2", _connection);
            _reader = _command.ExecuteReader();
            _table = new DataTable();
            _table.Load(_reader);
            return _table;
        }

        public static DataTable LoadKorpus()
        {
            _command = new SqlCommand("select * from Корпус order by 2", _connection);
            _reader = _command.ExecuteReader();
            _table = new DataTable();
            _table.Load(_reader);
            return _table;
        }

        public static DataTable LoadKruzhok()
        {
            _command = new SqlCommand("select * from Кружок_П order by 2", _connection);
            _reader = _command.ExecuteReader();
            _table = new DataTable();
            _table.Load(_reader);
            return _table;
        }

        public static DataTable LoadMeropriyatie()
        {
            _command = new SqlCommand("select * from Мероприятие order by 2", _connection);
            _reader = _command.ExecuteReader();
            _table = new DataTable();
            _table.Load(_reader);
            return _table;
        }

        public static DataTable LoadOtryad()
        {
            _command = new SqlCommand("select * from Отряд_П order by 2", _connection);
            _reader = _command.ExecuteReader();
            _table = new DataTable();
            _table.Load(_reader);
            return _table;
        }

        public static DataTable LoadRebenok()
        {
            _command = new SqlCommand("select * from Ребёнок_П order by 2, 3, 4", _connection);
            _reader = _command.ExecuteReader();
            _table = new DataTable();
            _table.Load(_reader);
            return _table;
        }

        public static DataTable LoadSmena()
        {
            _command = new SqlCommand("select * from Смена order by 2", _connection);
            _reader = _command.ExecuteReader();
            _table = new DataTable();
            _table.Load(_reader);
            return _table;
        }

        public static DataTable LoadUchastie()
        {
            _command = new SqlCommand("select * from Участие_в_мероприятии_П order by 2, 3", _connection);
            _reader = _command.ExecuteReader();
            _table = new DataTable();
            _table.Load(_reader);
            return _table;
        }

        public static void DeleteVojatiy(DataGrid grid)
        {
            for (int i = 0; i < grid.SelectedItems.Count; i++)
            {
                DataRowView rw = grid.SelectedItems[i] as DataRowView;
                _command = new SqlCommand("delete from Вожатый where Код = @code", _connection);
                _command.Parameters.Add("@code", SqlDbType.Int).Value = int.Parse(rw[0].ToString());
                try
                {
                    _command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Невозможно удалить, есть связанные записи");
                }
            }
        }

        public static void DeleteZapis(DataGrid grid)
        {
            for (int i = 0; i < grid.SelectedItems.Count; i++)
            {
                DataRowView rw = grid.SelectedItems[i] as DataRowView;
                _command = new SqlCommand("delete from Запись_в_кружок where Код = @code", _connection);
                _command.Parameters.Add("@code", SqlDbType.Int).Value = int.Parse(rw[0].ToString());
                _command.ExecuteNonQuery();
            }
        }

        public static void DeleteKomnata(DataGrid grid)
        {
            for (int i = 0; i < grid.SelectedItems.Count; i++)
            {
                DataRowView rw = grid.SelectedItems[i] as DataRowView;
                _command = new SqlCommand("delete from Комната where Код = @code", _connection);
                _command.Parameters.Add("@code", SqlDbType.Int).Value = int.Parse(rw[0].ToString());
                try
                {
                    _command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Невозможно удалить, есть связанные записи");
                }
            }
        }

        public static void DeleteKorpus(DataGrid grid)
        {
            for (int i = 0; i < grid.SelectedItems.Count; i++)
            {
                DataRowView rw = grid.SelectedItems[i] as DataRowView;
                _command = new SqlCommand("delete from Корпус where Код = @code", _connection);
                _command.Parameters.Add("@code", SqlDbType.Int).Value = int.Parse(rw[0].ToString());
                try
                {
                    _command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Невозможно удалить, есть связанные записи");
                }
            }
        }

        public static void DeleteKruzhok(DataGrid grid)
        {
            for (int i = 0; i < grid.SelectedItems.Count; i++)
            {
                DataRowView rw = grid.SelectedItems[i] as DataRowView;
                _command = new SqlCommand("delete from Кружок where Код = @code", _connection);
                _command.Parameters.Add("@code", SqlDbType.Int).Value = int.Parse(rw[0].ToString());
                try
                {
                    _command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Невозможно удалить, есть связанные записи");
                }
            }
        }

        public static void DeleteMeropriyatie(DataGrid grid)
        {
            for (int i = 0; i < grid.SelectedItems.Count; i++)
            {
                DataRowView rw = grid.SelectedItems[i] as DataRowView;
                _command = new SqlCommand("delete from Мероприятие where Код = @code", _connection);
                _command.Parameters.Add("@code", SqlDbType.Int).Value = int.Parse(rw[0].ToString());
                try
                {
                    _command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Невозможно удалить, есть связанные записи");
                }
            }
        }

        public static void DeleteOtryad(DataGrid grid)
        {
            for (int i = 0; i < grid.SelectedItems.Count; i++)
            {
                DataRowView rw = grid.SelectedItems[i] as DataRowView;
                _command = new SqlCommand("delete from Отряд where Код = @code", _connection);
                _command.Parameters.Add("@code", SqlDbType.Int).Value = int.Parse(rw[0].ToString());
                try
                {
                    _command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Невозможно удалить, есть связанные записи");
                }
            }
        }

        public static void DeleteRebenok(DataGrid grid)
        {
            for (int i = 0; i < grid.SelectedItems.Count; i++)
            {
                DataRowView rw = grid.SelectedItems[i] as DataRowView;
                _command = new SqlCommand("delete from Ребёнок where Код = @code", _connection);
                _command.Parameters.Add("@code", SqlDbType.Int).Value = int.Parse(rw[0].ToString());
                try
                {
                    _command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Невозможно удалить, есть связанные записи");
                }
            }
        }

        public static void DeleteSmena(DataGrid grid)
        {
            for (int i = 0; i < grid.SelectedItems.Count; i++)
            {
                DataRowView rw = grid.SelectedItems[i] as DataRowView;
                _command = new SqlCommand("delete from Смена where Код = @code", _connection);
                _command.Parameters.Add("@code", SqlDbType.Int).Value = int.Parse(rw[0].ToString());
                try
                {
                    _command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Невозможно удалить, есть связанные записи");
                }
            }
        }

        public static void DeleteUchastie(DataGrid grid)
        {
            for (int i = 0; i < grid.SelectedItems.Count; i++)
            {
                DataRowView rw = grid.SelectedItems[i] as DataRowView;
                _command = new SqlCommand("delete from Участие_в_мероприятии where Код = @code", _connection);
                _command.Parameters.Add("@code", SqlDbType.Int).Value = int.Parse(rw[0].ToString());
                _command.ExecuteNonQuery();
            }
        }

        public static Dictionary<int, string> KorpusCB()
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();
            _command = new SqlCommand("select * from Корпус", _connection);
            SqlDataReader reader = _command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    ret.Add(reader.GetInt32(0), $"№{reader.GetInt32(1)} ({reader.GetString(2)})");
                }
            }
            reader.Close();
            return ret;
        }

        public static Dictionary<int, string> KomnataCB()
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();
            _command = new SqlCommand("select Комната.Код, Номер_комнаты, Тип_комнаты, Номер_корпуса from Комната, Корпус where Корпус.Код=Код_корпуса", _connection);
            SqlDataReader reader = _command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    ret.Add(reader.GetInt32(0), $"№{reader.GetInt32(1)} (Корпус №{reader.GetInt32(3)}, {reader.GetString(2)})");
                }
            }
            reader.Close();
            return ret;
        }

        public static Dictionary<int, string> VozhatiyCB()
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();
            _command = new SqlCommand("select Код, Фамилия from Вожатый", _connection);
            SqlDataReader reader = _command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    ret.Add(reader.GetInt32(0), reader.GetString(1));
                }
            }
            reader.Close();
            return ret;
        }

        public static Dictionary<int, string> SmenaCB()
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();
            _command = new SqlCommand("select * from Смена", _connection);
            SqlDataReader reader = _command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    ret.Add(reader.GetInt32(0), $"{reader.GetDateTime(1).ToString("dd/MM/yyyy")} - {reader.GetDateTime(2).ToString("dd/MM/yyyy")}");
                }
            }
            reader.Close();
            return ret;
        }
        
        public static Dictionary<int, string> OtryadCB()
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();
            _command = new SqlCommand("select Код, Название from Отряд", _connection);
            SqlDataReader reader = _command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    ret.Add(reader.GetInt32(0), reader.GetString(1));
                }
            }
            reader.Close();
            return ret;
        }
        
        public static Dictionary<int, string> MeropriyatieCB()
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();
            _command = new SqlCommand("select Код, Название from Мероприятие", _connection);
            SqlDataReader reader = _command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    ret.Add(reader.GetInt32(0), reader.GetString(1));
                }
            }
            reader.Close();
            return ret;
        }
        
        public static Dictionary<int, string> RebenokCB()
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();
            _command = new SqlCommand("select Код, Фамилия, Имя from Ребёнок", _connection);
            SqlDataReader reader = _command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    ret.Add(reader.GetInt32(0), $"{reader.GetString(1)} {reader.GetString(2)}");
                }
            }
            reader.Close();
            return ret;
        }
        
        public static Dictionary<int, string> KruzhokCB()
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();
            _command = new SqlCommand("select Код, Название from Кружок", _connection);
            SqlDataReader reader = _command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    ret.Add(reader.GetInt32(0), reader.GetString(1));
                }
            }
            reader.Close();
            return ret;
        }







        public static void AddVojatiy(string s1, string s2, string s3, string s4, string s5)
        {
            _command = new SqlCommand("insert into Вожатый values (@surname, @name, @fathername, @birthdate, @phone)", _connection);
            _command.Parameters.Add("@surname", SqlDbType.VarChar).Value = s1;
            _command.Parameters.Add("@name", SqlDbType.VarChar).Value = s2;
            _command.Parameters.Add("@fathername", SqlDbType.VarChar).Value = s3;
            _command.Parameters.Add("@birthdate", SqlDbType.Date).Value = s4;
            _command.Parameters.Add("@phone", SqlDbType.VarChar).Value = s5;
            _command.ExecuteNonQuery();
        }
        
        public static void AddKomnata(string s1, string s2, string s3, string s4)
        {
            _command = new SqlCommand("insert into Комната values (@v1, @v2, @v3, @v4)", _connection);
            _command.Parameters.Add("@v1", SqlDbType.Int).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Int).Value = s2;
            _command.Parameters.Add("@v3", SqlDbType.VarChar).Value = s3;
            _command.Parameters.Add("@v4", SqlDbType.Int).Value = s4;
            _command.ExecuteNonQuery();
        }
        
        public static void AddKorpus(string s1, string s2)
        {
            _command = new SqlCommand("insert into Корпус values (@v1, @v2)", _connection);
            _command.Parameters.Add("@v1", SqlDbType.Int).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.VarChar).Value = s2;
            _command.ExecuteNonQuery();
        }

        public static void AddKruzhok(string s1, string s2)
        {
            _command = new SqlCommand("insert into Кружок values (@v1, @v2)", _connection);
            _command.Parameters.Add("@v1", SqlDbType.VarChar).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Int).Value = s2;
            _command.ExecuteNonQuery();
        }

        public static void AddMeropriyatie(string s1, string s2)
        {
            _command = new SqlCommand("insert into Мероприятие values (@v1, @v2)", _connection);
            _command.Parameters.Add("@v1", SqlDbType.VarChar).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.VarChar).Value = s2;
            _command.ExecuteNonQuery();
        }

        public static void AddOtryad(string s1, string s2, string s3)
        {
            _command = new SqlCommand("insert into Отряд values (@v1, @v2, @v3)", _connection);
            _command.Parameters.Add("@v1", SqlDbType.VarChar).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Int).Value = s2;
            _command.Parameters.Add("@v3", SqlDbType.Int).Value = s3;
            _command.ExecuteNonQuery();
        }

        public static void AddRebenok(string s1, string s2, string s3, string s4, string s5, string s6, string s7)
        {
            _command = new SqlCommand("insert into Ребёнок values (@v1, @v2, @v3, @v4, @v5, @v6, @v7)", _connection);
            _command.Parameters.Add("@v1", SqlDbType.VarChar).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.VarChar).Value = s2;
            _command.Parameters.Add("@v3", SqlDbType.VarChar).Value = s3;
            _command.Parameters.Add("@v4", SqlDbType.VarChar).Value = s4;
            _command.Parameters.Add("@v5", SqlDbType.Date).Value = s5;
            _command.Parameters.Add("@v6", SqlDbType.Int).Value = s6;
            _command.Parameters.Add("@v7", SqlDbType.Int).Value = s7;
            _command.ExecuteNonQuery();
        }

        public static void AddSmena(string s1, string s2)
        {
            _command = new SqlCommand("insert into Смена values (@v1, @v2)", _connection);
            _command.Parameters.Add("@v1", SqlDbType.Date).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Date).Value = s2;
            _command.ExecuteNonQuery();
        }

        public static void AddUchastie(string s1, string s2, string s3)
        {
            _command = new SqlCommand("insert into Участие_в_мероприятии values (@v1, @v2, @v3)", _connection);
            _command.Parameters.Add("@v1", SqlDbType.Int).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Int).Value = s2;
            _command.Parameters.Add("@v3", SqlDbType.Date).Value = s3;
            _command.ExecuteNonQuery();
        }

        public static void AddZapis(string s1, string s2, string s3)
        {
            _command = new SqlCommand("insert into Запись_в_кружок values (@v1, @v2, @v3)", _connection);
            _command.Parameters.Add("@v1", SqlDbType.Int).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Int).Value = s2;
            _command.Parameters.Add("@v3", SqlDbType.Date).Value = s3;
            _command.ExecuteNonQuery();
        }


        
        public static void EditVojatiy(string s1, string s2, string s3, string s4, string s5, string code)
        {
            _command = new SqlCommand("update Вожатый set Фамилия=@v1, Имя=@v2, Отчество=@v3, Дата_рождения=@v4, Телефон=@v5 where Код=@code", _connection);
            _command.Parameters.Add("@v1", SqlDbType.VarChar).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.VarChar).Value = s2;
            _command.Parameters.Add("@v3", SqlDbType.VarChar).Value = s3;
            _command.Parameters.Add("@v4", SqlDbType.Date).Value = s4;
            _command.Parameters.Add("@v5", SqlDbType.VarChar).Value = s5;
            _command.Parameters.Add("@code", SqlDbType.Int).Value = code;
            _command.ExecuteNonQuery();
        }
        
        public static void EditKomnata(string s1, string s2, string s3, string s4, string code)
        {
            _command = new SqlCommand("update Комната set Номер_комнаты=@v1, Код_корпуса=@v2, Тип_комнаты=@v3, Количество_мест=@v4 where Код=@code", _connection);
            _command.Parameters.Add("@v1", SqlDbType.Int).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Int).Value = s2;
            _command.Parameters.Add("@v3", SqlDbType.VarChar).Value = s3;
            _command.Parameters.Add("@v4", SqlDbType.Int).Value = s4;
            _command.Parameters.Add("@code", SqlDbType.Int).Value = code;
            _command.ExecuteNonQuery();
        }
        
        public static void EditKorpus(string s1, string s2, string code)
        {
            _command = new SqlCommand("update Корпус set Номер_корпуса=@v1, Тип_корпуса=@v2 where Код=@code", _connection);
            _command.Parameters.Add("@v1", SqlDbType.Int).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.VarChar).Value = s2;
            _command.Parameters.Add("@code", SqlDbType.Int).Value = code;
            _command.ExecuteNonQuery();
        }

        public static void EditKruzhok(string s1, string s2, string code)
        {
            _command = new SqlCommand("update Кружок set Название=@v1, Код_комнаты=@v2 where Код=@code", _connection);
            _command.Parameters.Add("@v1", SqlDbType.VarChar).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Int).Value = s2;
            _command.Parameters.Add("@code", SqlDbType.Int).Value = code;
            _command.ExecuteNonQuery();
        }

        public static void EditMeropriyatie(string s1, string s2, string code)
        {
            _command = new SqlCommand("update Мероприятие set Название=@v1, Тип_мероприятия=@v2 where Код=@code", _connection);
            _command.Parameters.Add("@v1", SqlDbType.VarChar).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.VarChar).Value = s2;
            _command.Parameters.Add("@code", SqlDbType.Int).Value = code;
            _command.ExecuteNonQuery();
        }

        public static void EditOtryad(string s1, string s2, string s3, string code)
        {
            _command = new SqlCommand("update Отряд set Название=@v1, Код_вожатого=@v2, Код_смены=@v3 where Код=@code", _connection);
            _command.Parameters.Add("@v1", SqlDbType.VarChar).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Int).Value = s2;
            _command.Parameters.Add("@v3", SqlDbType.Int).Value = s3;
            _command.Parameters.Add("@code", SqlDbType.Int).Value = code;
            _command.ExecuteNonQuery();
        }

        public static void EditRebenok(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string code)
        {
            _command = new SqlCommand("update Ребёнок set Фамилия=@v1, Имя=@v2, Отчество=@v3, Пол=@v4, Дата_рождения=@v5, Код_отряда=@v6, Код_комнаты=@v7 where Код=@code", _connection);
            _command.Parameters.Add("@v1", SqlDbType.VarChar).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.VarChar).Value = s2;
            _command.Parameters.Add("@v3", SqlDbType.VarChar).Value = s3;
            _command.Parameters.Add("@v4", SqlDbType.VarChar).Value = s4;
            _command.Parameters.Add("@v5", SqlDbType.Date).Value = s5;
            _command.Parameters.Add("@v6", SqlDbType.Int).Value = s6;
            _command.Parameters.Add("@v7", SqlDbType.Int).Value = s7;
            _command.Parameters.Add("@code", SqlDbType.Int).Value = code;
            _command.ExecuteNonQuery();
        }

        public static void EditSmena(string s1, string s2, string code)
        {
            _command = new SqlCommand("update Смена set Дата_начала=@v1, Дата_окончания=@v2 where Код=@code", _connection);
            _command.Parameters.Add("@v1", SqlDbType.Date).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Date).Value = s2;
            _command.Parameters.Add("@code", SqlDbType.Int).Value = code;
            _command.ExecuteNonQuery();
        }

        public static void EditUchastie(string s1, string s2, string s3, string code)
        {
            _command = new SqlCommand("update Участие_в_мероприятии set Код_мероприятия=@v1, Код_отряда=@v2, Дата_проведения=@v3 where Код=@code", _connection);
            _command.Parameters.Add("@v1", SqlDbType.Int).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Int).Value = s2;
            _command.Parameters.Add("@v3", SqlDbType.Date).Value = s3;
            _command.Parameters.Add("@code", SqlDbType.Int).Value = code;
            _command.ExecuteNonQuery();
        }

        public static void EditZapis(string s1, string s2, string s3, string code)
        {
            _command = new SqlCommand("update Запись_в_кружок set Код_ребёнка=@v1, Код_кружка=@v2, Дата_записи=@v3 where Код=@code", _connection);
            _command.Parameters.Add("@v1", SqlDbType.Int).Value = s1;
            _command.Parameters.Add("@v2", SqlDbType.Int).Value = s2;
            _command.Parameters.Add("@v3", SqlDbType.Date).Value = s3;
            _command.Parameters.Add("@code", SqlDbType.Int).Value = code;
            _command.ExecuteNonQuery();
        }




    }
}