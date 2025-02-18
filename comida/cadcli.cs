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

namespace comida
{
    public partial class cadcli : Form
    {
        public cadcli()
        {
            InitializeComponent();
        }

        string conexaoString = "Server=localhost; Port=3306; Database=bd_lanches; Uid=root; Pwd=;";

        string query = "INSERT INTO tb_cliente (nome, senha, email, cpf, numero, telefone) VALUES (@nome, @senha, @email, @cpf, @numero, @telefone)";

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conexao = new MySqlConnection(conexaoString))
            {
                try
                {
                    conexao.Open();
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", textBoxNome.Text);
                        comando.Parameters.AddWithValue("@senha", textBoxSenha.Text);
                        comando.Parameters.AddWithValue("@email", textBoxEmail.Text);
                        comando.Parameters.AddWithValue("@categoria", maskedTextBoxCep.Text);
                        comando.Parameters.AddWithValue("@cpf", maskedTextBoxCpf.Text);
                        comando.Parameters.AddWithValue("@numero", maskedTextBoxNumero.Text);
                        comando.Parameters.AddWithValue("@telefone", maskedTextBoxTelefone.Text);
                        comando.ExecuteNonQuery();

                        MessageBox.Show("Dados inseridos com sucesso!");
                        textBoxNome.Text = "";
                        textBoxSenha.Text = "";
                        textBoxEmail.Text = "";
                        maskedTextBoxCep.Text = "";
                        maskedTextBoxCpf.Text = "";
                        maskedTextBoxNumero.Text = "";
                        maskedTextBoxTelefone.Text = "";
                        textBoxNome.Focus();
                    }
                }
                catch (Exception ex)
                {
                    // em caso de erro, exiba menssagem do erro
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxNome.Text = "";
            textBoxSenha.Text = "";
            textBoxEmail.Text = "";
            maskedTextBoxCpf.Text = "";
            maskedTextBoxNumero.Text = "";
            maskedTextBoxTelefone.Text = "";
            textBoxNome.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxSenha.PasswordChar = '*';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Se a senha está oculta, mostramos
            if (textBoxSenha.PasswordChar == '*')
            {
                textBoxSenha.PasswordChar = '\0';  // Exibe a senha (nada é substituído, mostrando os caracteres reais)
                button5.Text = "Ocultar Senha"; // Alterar o texto do botão para "Ocultar Senha"
            }
            else
            {
                textBoxSenha.PasswordChar = '*';  // Oculta a senha novamente
                button5.Text = "Mostrar Senha"; // Alterar o texto do botão para "Mostrar Senha"
            }
        }
    }
}
