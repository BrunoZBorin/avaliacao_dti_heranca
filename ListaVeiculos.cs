using Avaliação.DAO;
using Avaliação.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Avaliação
{
    public partial class ListaVeiculos : Form
    {
        int IdRowSelected = 0;
        string TipoRowSelected = "";
        public ListaVeiculos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroVeiculos cv = new CadastroVeiculos();
            
            this.Hide();
            
            cv.Show();
            
        }

        private void ListaVeiculos_Load_1(object sender, EventArgs e)
        {
            carregaGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            CadastroVeiculos cv = new CadastroVeiculos();
            cv.GetValuesFromListaVeiculos(row);
            cv.Show();

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            CadastroVeiculos cv = new CadastroVeiculos();
            cv.GetValuesFromListaVeiculos(row);
            this.Hide();
            cv.Show();

        }

        public void carregaGrid()
        {
            List<VeiculoDTO> veiculoList = new List<VeiculoDTO>();
            List<VeiculoDTO> list = new List<VeiculoDTO>();
            list = CarroPasseioDAO.GetAll();
            foreach (VeiculoDTO veiculo in list)
            {
                veiculoList.Add(veiculo);
            }

            list = CaminhoneteDAO.GetAll();
            foreach (VeiculoDTO veiculo in list)
            {
                veiculoList.Add(veiculo);
            }

            list = MotoDAO.GetAll();
            foreach (VeiculoDTO veiculo in list)
            {
                veiculoList.Add(veiculo);
            }

            dataGridView1.DataSource = veiculoList;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IdRowSelected = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TipoRowSelected = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IdRowSelected != 0)
            {
                VeiculoDAO.Delete(IdRowSelected, TipoRowSelected);
                carregaGrid();
            }
            else
            {
                MessageBox.Show("Por favor selecione um veículo para exclusão");
            }
        }
    }
}
