using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Avaliação.DTO;

namespace Avaliação.DAO
{
    internal class VeiculoDAO
    {

        public static void Insert()
        {

        }

        public static void Update(VeiculoDTO veiculo, string tipo)
        {
            string tabela = "";
            string tipo_id = "";
            SQLiteDataAdapter da = null;
            MessageBox.Show(veiculo.Id_veiculo.ToString());
            switch (tipo)
            {
                case "Caminhonete":
                    tabela = "caminhonete";
                    tipo_id = "id_caminhonete";
                    break;

                case "Carro Passeio":
                    tabela = "carro";
                    tipo_id = "id_carro";
                    break;
                case "Moto":
                    tabela = "moto";
                    tipo_id = "id_moto";
                    break;
            }
        
            try
            {
                var cmd = Conexao.dbCon().CreateCommand();
                cmd.CommandText = "UPDATE "+tabela+" SET nome = '"+veiculo.Nome.ToString()+"', modelo = '"+veiculo.Modelo.ToString()+"', ano = '"+veiculo.Ano.ToString()+"' WHERE "+tipo_id+" = "+veiculo.Id_veiculo+" ";
                MessageBox.Show(cmd.CommandText);
                da = new SQLiteDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                Conexao.dbCon().Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }

        public static List<VeiculoDAO> GetAll()
        {
            return new List<VeiculoDAO>();
        }
        public static void Delete(Int32 id, string tipo)
        {
            string tabela = "";
            string tipo_id = "";
            SQLiteDataAdapter da = null;
            switch (tipo)
            {
                case "Caminhonete":
                    tabela = "caminhonete";
                    tipo_id = "id_caminhonete";
                    break;

                case "Carro Passeio":
                    tabela = "carro";
                    tipo_id = "id_carro";
                    break;
                case "Moto":
                    tabela = "moto";
                    tipo_id = "id_moto";
                    break;
            }
            try
            {
                var cmd = Conexao.dbCon().CreateCommand();
                cmd.CommandText = "DELETE FROM " + tabela + " WHERE " + tipo_id + " = " + id + " ";
                MessageBox.Show(cmd.CommandText);
                da = new SQLiteDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                Conexao.dbCon().Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }
    }
}
