using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DesafioGoDev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DesafioTreinamento.mdf;Integrated Security=True");
        SqlCommand cmd;
        DesafioGoDev.Control.DBController dBController = new Control.DBController();

        private void button1_Click(object sender, EventArgs e)
        {
            // cadastro salas
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false)
            {
                string nomeSala = textBox1.Text;
                int lotacaoSala = Convert.ToInt32(textBox2.Text);

                if (dBController.CadastroSala(nomeSala, lotacaoSala))
                {
                    MessageBox.Show("Sala de evento cadastrada com sucesso.");
                }
            }
            else
            {
                MessageBox.Show("Você precisa preencher todos os campos para cadastrar uma sala de evento.\nTente novamente.");
            }    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // cadastro pessoa
            if (String.IsNullOrEmpty(textBox3.Text) == false && String.IsNullOrEmpty(textBox4.Text) == false)
            {
                string nomePessoa = textBox3.Text;
                string sobrenome = textBox4.Text;

                if (dBController.CadastroPessoa(nomePessoa, sobrenome))
                {
                    MessageBox.Show("Pessoa cadastrada com sucesso.");
                }
            }
            else
            {
                MessageBox.Show("Você precisa preencher todos os campos para cadastrar uma pessoa.\nTente novamente.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // deletar salas
            if (DialogResult.Yes == MessageBox.Show("Todos as salas cadastradas serão excluídas.\nVocê deseja continuar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                if (dBController.DeletarSalas())
                {
                    MessageBox.Show("Salas de evento excluídas com sucesso.");
                }
                else
                {
                    MessageBox.Show("Não foi possível excluir as salas de evento.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // deletar pessoas
            if (DialogResult.Yes == MessageBox.Show("Todos as pessoas cadastradas serão excluídas.\nVocê deseja continuar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                if (dBController.DeletarPessoas())
                {
                    MessageBox.Show("Pessoas excluídas com sucesso.");
                }
                else
                {
                    MessageBox.Show("Não foi possível excluir as pessoas cadastradas.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // deletar espaços
            if (DialogResult.Yes == MessageBox.Show("Todos espaços cadastrados serão excluídas.\nVocê deseja continuar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                if (dBController.DeletarEspacos())
                {
                    MessageBox.Show("Espaços de café excluídos com sucesso.");
                }
                else
                {
                    MessageBox.Show("Não foi possível excluir os espaços de café.");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // consultar salas
            try
            {
                SqlDataAdapter da;
                BindingSource bsource = new BindingSource();
                DataSet ds = null;
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    string nome = textBox1.Text;

                    string consultaSala;
                    consultaSala = $"SELECT Nome, Sobrenome, SalaEtapa1, SalaEtapa2 FROM Pessoas WHERE SalaEtapa1 = '{nome}' OR SalaEtapa2 = '{nome}' GROUP BY SalaEtapa1, SalaEtapa2, Nome, Sobrenome ORDER BY Nome";
                    da = new SqlDataAdapter(consultaSala, conn);
                    conn.Open();
                    ds = new DataSet();
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(ds, "Pessoas");
                    bsource.DataSource = ds.Tables["Pessoas"];
                    dataGridView1.DataSource = bsource;
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Preencha o campo 'Nome (sala)' para consultar uma sala.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado encontrado:\n\n" + ex.Message);                
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // consultar pessoas
            try
            {
                SqlDataAdapter da;
                BindingSource bsource = new BindingSource();
                DataSet ds = null;
                if (String.IsNullOrEmpty(textBox3.Text) == false || String.IsNullOrEmpty(textBox4.Text) == false)
                {
                    string nome = textBox3.Text;
                    string sobrenome = textBox4.Text;

                    string consultaPessoa;
                    consultaPessoa = $"SELECT Nome, Sobrenome, SalaEtapa1, SalaEtapa2, EspacoEtapa1, EspacoEtapa2 FROM Pessoas WHERE Nome = '{nome}' AND Sobrenome = '{sobrenome}'";
                    da = new SqlDataAdapter(consultaPessoa, conn);
                    conn.Open();
                    ds = new DataSet();
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(ds, "Pessoas");
                    bsource.DataSource = ds.Tables["Pessoas"];
                    dataGridView1.DataSource = bsource;
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Preencha o campo 'Nome (sala)' para consultar uma sala.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado encontrado:\n\n" + ex.Message);                
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // consultar espaços
            try
            {
                SqlDataAdapter da;
                BindingSource bsource = new BindingSource();
                DataSet ds = null;
                if (String.IsNullOrEmpty(textBox5.Text) == false)
                {
                    string nome = textBox5.Text;

                    string consultaEspaco;
                    consultaEspaco = $"SELECT Nome, Sobrenome, EspacoEtapa1, EspacoEtapa2 FROM Pessoas WHERE EspacoEtapa1 = '{nome}' OR EspacoEtapa2 = '{nome}' GROUP BY EspacoEtapa1, EspacoEtapa2, Nome, Sobrenome ORDER BY Nome";
                    da = new SqlDataAdapter(consultaEspaco, conn);
                    conn.Open();
                    ds = new DataSet();
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                    da.Fill(ds, "Pessoas");
                    bsource.DataSource = ds.Tables["Pessoas"];
                    dataGridView1.DataSource = bsource;
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Preencha o campo 'Nome (sala)' para consultar uma sala.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado encontrado:\n\n" + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // cadastro espaços de café
            try
            {
                if (String.IsNullOrEmpty(textBox5.Text) == false && String.IsNullOrEmpty(textBox6.Text) == false)
                {
                    string nomeEspaco = textBox5.Text;
                    int lotacaoEspaco = Convert.ToInt32(textBox6.Text);

                    if (dBController.CadastroEspaco(nomeEspaco, lotacaoEspaco))
                    {
                        MessageBox.Show("Espaço de café cadastrado com sucesso.");
                    }
                }
                else
                {
                    MessageBox.Show("Você precisa preencher todos os campos para cadastrar um espaço.\nTente novamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado encontrado:\n\n" + ex.Message);
            }
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

