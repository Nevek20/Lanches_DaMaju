using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace comida
{
    public partial class cadpro : Form
    {
        public cadpro()
        {
            InitializeComponent();
        }
        string conexaoString = "Server=localhost; Port=3306; Database=bd_lanches; Uid=root; Pwd=;";

        string query = "INSERT INTO tb_produto (nome, valor, descricao, categoria) VALUES (@nome, @valor, @descricao, @categoria)";
        private void button4_Click(object sender, EventArgs e)
        {
            textBoxNome2.Text = "";
            maskedTextBoxValor.Text = "";
            richTextBoxDescricao.Text = "";
            textBoxCategoria.Text = "";
            textBoxNome2.Focus();
        }
        private void richTextBoxDescricao_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conexao = new MySqlConnection(conexaoString))
            {
                try
                {
                    conexao.Open();
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", textBoxNome2.Text);
                        comando.Parameters.AddWithValue("@valor", maskedTextBoxValor.Text);
                        comando.Parameters.AddWithValue("@descricao", richTextBoxDescricao.Text);
                        comando.Parameters.AddWithValue("@categoria", textBoxCategoria.Text);
                        comando.ExecuteNonQuery();

                        MessageBox.Show("Dados inseridos com sucesso!");
                        textBoxNome2.Text = "";
                        maskedTextBoxValor.Text = "";
                        richTextBoxDescricao.Text = "";
                        textBoxCategoria.Text = "";
                        textBoxNome2.Focus();
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
    }
}
