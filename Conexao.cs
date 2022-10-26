using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Drawing;

namespace Avaliacao
{
    internal class Conexao
    {
        private static SQLiteConnection conn;

        public static SQLiteConnection dbCon()
        {
            conn = new SQLiteConnection("Data Source=C:\\Users\\Altbit\\Avaliacao\\bin\\Debug\\db_teste.sdb");
            conn.Open();
            return conn;
        }

        public void conectar()
        {
            conn.Open();
        }
        public void desconectar()
        {
            conn.Close();
        }

        
    }
}
