using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DesafioGoDev.Control
{
    public class DBController
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public DBController()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DesafioTreinamento.mdf;Integrated Security=True");
        }

        public bool CadastroPessoa(string nome, string sobrenome)
        {
            // DETERMINA AS SALAS QUE A PESSOA IRÁ FICAR NAS DUAS ETAPAS
            
            try
            {
                string selectOcupa;
                string nomeOcupa1 = "";
                string nomeOcupa2 = "";
                string nomeEspaco1 = "";
                string nomeEspaco2 = "";

                // Verifica se o valor do último IdPessoa registrado é par ou ímpar, fazendo uma inversão no cadastro das salas entre as etapas caso o valor for ímpar (garantindo a troca de salas entre etapas)
                string selectIdPessoa = "SELECT MAX(IdPessoa) from Pessoas";
                int lastId = 0;
                cmd = new SqlCommand(selectIdPessoa, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr[0] != DBNull.Value)
                    {
                        lastId = Convert.ToInt32(dr[0]);
                    }
                }
                dr.Close();
                conn.Close();
                //    

                if (lastId % 2 == 0 || lastId == 0) // determinação das salas por etapa caso o último IdPessoa for par
                {
                   
                    nomeOcupa1 = "";

                    // Sala Etapa 1
                    //seleciona a sala com o menor número de pessoas inscritas
                    selectOcupa = $"SELECT TOP 1 Nome FROM Salas ORDER BY Etapa1 ASC";
                    cmd = new SqlCommand(selectOcupa, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomeOcupa1 = dr[0].ToString();
                    }
                    dr.Close();
                    conn.Close();


                    // Sala Etapa 2
                    //seleciona a sala com o menor número de pessoas inscritas
                    selectOcupa = $"SELECT TOP 1 Nome FROM Salas WHERE NOT Nome = '{nomeOcupa1}' ORDER BY Etapa2 ASC";
                    nomeOcupa2 = "";
                    cmd = new SqlCommand(selectOcupa, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomeOcupa2 = dr[0].ToString();
                        //MessageBox.Show(nomeOcupa2);
                    }
                    dr.Close();
                    conn.Close();


                    // Espaço Café Etapa 1
                    //seleciona o espaço com o menor número de pessoas inscritas
                    selectOcupa = $"SELECT TOP 1 Nome FROM Espacos ORDER BY Etapa1 ASC";
                    nomeEspaco1 = "";
                    cmd = new SqlCommand(selectOcupa, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomeEspaco1 = dr[0].ToString();
                    }
                    dr.Close();
                    conn.Close();

                    // Espaço Café Etapa 2
                    //seleciona o espaço com o menor número de pessoas inscritas
                    selectOcupa = $"SELECT TOP 1 Nome FROM Espacos WHERE NOT Nome = '{nomeEspaco1}' ORDER BY Etapa2 ASC";
                    nomeEspaco2 = "";
                    cmd = new SqlCommand(selectOcupa, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomeEspaco2 = dr[0].ToString();
                    }
                    dr.Close();
                    conn.Close();

                    ////
                    // Cadastra a pessoa na tabela "Pessoas" com as salas e espaços selecionados acima e nome e sobrenome de input
                    string cadPessoa = $"INSERT INTO Pessoas (Nome, Sobrenome, SalaEtapa1, SalaEtapa2, EspacoEtapa1, EspacoEtapa2) VALUES ('{nome}', '{sobrenome}', '{nomeOcupa1}', '{nomeOcupa2}', '{nomeEspaco1}', '{nomeEspaco2}')";

                    cmd = new SqlCommand(cadPessoa, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    /////

                    // Incrementa em 1 a ocupação das salas que a pessoa cadastrada ficará
                    string ocupaSala1 = $"UPDATE Salas SET Etapa1 = Etapa1 + 1 WHERE Nome = '{nomeOcupa1}'";

                    cmd = new SqlCommand(ocupaSala1, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    string ocupaSala2 = $"UPDATE Salas SET Etapa2 = Etapa2 + 1 WHERE Nome = '{nomeOcupa2}'";

                    cmd = new SqlCommand(ocupaSala2, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Incrementa em 1 a ocupação dos espaços que a pessoa cadastrada ficará
                    string ocupaEspaco1 = $"UPDATE Espacos SET Etapa1 = Etapa1 + 1 WHERE Nome = '{nomeEspaco1}'";

                    cmd = new SqlCommand(ocupaEspaco1, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    string ocupaEspaco2 = $"UPDATE Espacos SET Etapa2 = Etapa2 + 1 WHERE Nome = '{nomeEspaco2}'";

                    cmd = new SqlCommand(ocupaSala2, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    return true;

                }

                else // determinação das salas por etapa caso o último IdPessoa for ímpar
                {
                    // Sala Etapa 2
                    //seleciona a sala com o menor número de pessoas inscritas
                    selectOcupa = $"SELECT TOP 1 Nome FROM Salas ORDER BY Etapa2 ASC";
                    nomeOcupa2 = "";
                    cmd = new SqlCommand(selectOcupa, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomeOcupa2 = dr[0].ToString();
                    }
                    dr.Close();
                    conn.Close();


                    // Sala Etapa 1
                    //seleciona a sala com o menor número de pessoas inscritas
                    selectOcupa = $"SELECT TOP 1 Nome FROM Salas WHERE NOT Nome = '{nomeOcupa2}' ORDER BY Etapa1 ASC";
                    nomeOcupa1 = "";
                    cmd = new SqlCommand(selectOcupa, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomeOcupa1 = dr[0].ToString();
                        //MessageBox.Show(nomeOcupa1);
                    }
                    dr.Close();
                    conn.Close();

                    // Espaço Café Etapa 2
                    //seleciona o espaço com o menor número de pessoas inscritas
                    selectOcupa = $"SELECT TOP 1 Nome FROM Espacos ORDER BY Etapa2 ASC";
                    nomeEspaco2 = "";
                    cmd = new SqlCommand(selectOcupa, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomeEspaco2 = dr[0].ToString();
                    }
                    dr.Close();
                    conn.Close();

                    // Espaço Café Etapa 1
                    //seleciona o espaço com o menor número de pessoas inscritas
                    selectOcupa = $"SELECT TOP 1 Nome FROM Espacos WHERE NOT Nome = '{nomeEspaco2}' ORDER BY Etapa1 ASC";
                    nomeEspaco1 = "";
                    cmd = new SqlCommand(selectOcupa, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomeEspaco1 = dr[0].ToString();
                    }
                    dr.Close();
                    conn.Close();

                    ////
                    // Cadastra a pessoa na tabela "Pessoas" com as salas e os espaços selecionados acima e nome e sobrenome de input
                    string cadPessoa = $"INSERT INTO Pessoas (Nome, Sobrenome, SalaEtapa1, SalaEtapa2, EspacoEtapa1, EspacoEtapa2) VALUES ('{nome}', '{sobrenome}', '{nomeOcupa1}', '{nomeOcupa2}', '{nomeEspaco1}', '{nomeEspaco2}')";

                    cmd = new SqlCommand(cadPessoa, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ////

                    // Incrementa em 1 a ocupação das salas que a pessoa cadastrada ficará
                    string ocupaSala1 = $"UPDATE Salas SET Etapa1 = Etapa1 + 1 WHERE Nome = '{nomeOcupa1}'";

                    cmd = new SqlCommand(ocupaSala1, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    string ocupaSala2 = $"UPDATE Salas SET Etapa2 = Etapa2 + 1 WHERE Nome = '{nomeOcupa2}'";

                    cmd = new SqlCommand(ocupaSala2, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Incrementa em 1 a ocupação dos espaços que a pessoa cadastrada ficará
                    string ocupaEspaco1 = $"UPDATE Espacos SET Etapa1 = Etapa1 + 1 WHERE Nome = '{nomeEspaco1}'";

                    cmd = new SqlCommand(ocupaEspaco1, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    string ocupaEspaco2 = $"UPDATE Espacos SET Etapa2 = Etapa2 + 1 WHERE Nome = '{nomeEspaco2}'";

                    cmd = new SqlCommand(ocupaSala2, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado encontrado:\n\n" + ex.Message);
                return true;
            }
        }

        public bool CadastroSala(string nome, int lotacao)
        {
            try
            {
                string cadSala = $"INSERT INTO Salas (Nome, Lotação, Etapa1, Etapa2) VALUES ('{nome}', {lotacao}, 0, 0)";
                cmd = new SqlCommand(cadSala, conn);

                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado encontrado:\n\n" + ex.Message);
                return true;
            }
        }

        public bool CadastroEspaco(string nome, int lotacao)
        {
            try
            {
                //Verifica se já existem espaços de café cadastrados
                int countEspaco = 0;
                string verificaEspaco = "SELECT COUNT(Nome) FROM Espacos";
                cmd = new SqlCommand(verificaEspaco, conn);

                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    countEspaco = Convert.ToInt32(dr[0]);
                }
                dr.Close();
                conn.Close();

                if (countEspaco < 2) // impede o cadastro de mais de 2 espaços de café
                {
                    string cadEspaco = $"INSERT INTO Espacos (Nome, Lotação) VALUES ('{nome}', {lotacao})";
                    cmd = new SqlCommand(cadEspaco, conn);

                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        conn.Close();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("ATENÇÃO!\nNão foi possível completar o cadastro. O número máximo de espaços de café cadastrados foi atingido (2 espaços).");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado encontrado:\n\n" + ex.Message);
                return true;
            }
        }
       
        public bool DeletarSalas()
        {
            try
            {
                string deleteSalas = "DELETE FROM Salas";
                cmd = new SqlCommand(deleteSalas, conn);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado encontrado:\n\n" + ex.Message);
                return false;
            }
        }

        public bool DeletarPessoas()
        {
            try
            {
                string deletePessoas = "DELETE FROM Pessoas";
                cmd = new SqlCommand(deletePessoas, conn);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado encontrado:\n\n" + ex.Message);
                return false;
            }
        }

        public bool DeletarEspacos()
        {
            try
            {
                string deletePessoas = "DELETE FROM Espacos";
                cmd = new SqlCommand(deletePessoas, conn);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado encontrado:\n\n" + ex.Message);
                return false;
            }
        }
    }
}
