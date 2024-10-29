using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _231403
{
    public class Banco
    { 
        //criando as variaveis publicas para conexao e consulta serao usadas em todo o projeto
        //connection responsavel pela conexao com mysql
        public static MySqlConnection Conexao;

        //command responsavel pelas instruçoes sql a serem executadas
        public static MySqlCommand Comando;

        //adapter responsavel por inserir dados em um datatable
        public static MySqlDataAdapter Adaptador;

        //datatable responsavel por ligar o banco em controles com a propriedade datasource
        public static DataTable datTabela;

    public static void AbrirConexao()
        {
            try
            {
                //estabelece os parametros para a conexao com o banco
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");

                //abre a conexao com o banco de dados
                Conexao.Open();
            }
            catch (Exception e) 
            { 
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    
        
        }

        public static void FecharConexao()
        {
            try
            {
                //fecha a conexao
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                //chama funçao para abertura de conexao com o banco
                AbrirConexao();

                //informa a instruçao sql
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);
                //executa a query no mysql(raio do workbench)
                Comando.ExecuteNonQuery();

                //chama a funçao para fechar a conexao com o banco
                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Banco.CriarBanco();
        }

        public static void CriarBanco()
        {
            try
            {
                //abre a conexao com o banco
                AbrirConexao();

                //informa a instruçao sql
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);
                //executa a query no mysql
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE DATABSE IF NOT EXISTS Cidades " +
                                           "(id integer auto_increment primary key," +
                                           "nome char(40), " +
                                           "uf char(02))", Conexao);
                Comando.ExecuteNonQuery();

                //fecha conexao com o banco
                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
