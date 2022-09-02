using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_LoginMySql
{
    public partial class Form1 : Form
    {
        // variaveis do mysql
        // Tipo         nome
        MySqlConnection con;
        MySqlCommand    cmd;
        MySqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
            // con recebe uma nova conexão
            con = new MySqlConnection("Server=localhost;Database=dblogin;user=root;Pwd=;SslMode=none");
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;

            string senha = txtSenha.Text;
            // criando um comando mysql
            cmd = new MySqlCommand();
            // abrindo a conexao com o banco
            con.Open();
            // atribuindo a conexão do comando
            cmd.Connection = con;
            // determinando o SQL do comando
            cmd.CommandText = "SELECT * FROM tbluser";
            // executa o comando no banco e retorna um resultado
            dr = cmd.ExecuteReader();

            // se dr retornou true
            if (dr.Read())
            {
                MessageBox.Show("Usuário encontrado");
            }
            else
            {
                MessageBox.Show("Usuário não encontrado");
            }
            con.Close();
            

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
