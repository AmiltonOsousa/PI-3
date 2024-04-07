using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_PI_3
{
    public partial class CriarPartida : Form
    {
        public CriarPartida()
        {

            InitializeComponent();
            lblVersao.Text = "Versão: " + Jogo.Versao;

            //Criar partida: nome, senha, grupo
        }

        public void Erro(Label label)
        {
            label.ForeColor = Color.Red;
        }

        private void btnCriarPartida_Click(object sender, EventArgs e)
        {

            if (txtNomePartida.Text == "")
            {
                Erro(lblNomePartida);
                MessageBox.Show("Erro: Partida sem nome", "Erro na criação da partida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtNomePartida.Text.Contains(','))
            {
                Erro(lblNomePartida);
                MessageBox.Show("Erro: Partida contém \",\" no nome", "Erro na criação da partida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtSenhaPartida.Text == "")
            {
                Erro(lblSenhaPartida);
                MessageBox.Show("Erro: Partida sem senha", "Erro na criação da partida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else
            {

                string nomePartida = txtNomePartida.Text;
                string senhaPartida = txtSenhaPartida.Text;

                Jogo.CriarPartida(nomePartida, senhaPartida, "Andorra");

                ListarPartida listarPartida = new ListarPartida();
                listarPartida.Show();

                this.Close();
            }

        }

        private void lstNavegacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNavegacao.SelectedIndex == 0)
            {
                this.Close();
            }

            if (lstNavegacao.SelectedIndex == 1)
            {
                ListarPartida listarPartida = new ListarPartida();
                listarPartida.Show();

                this.Close();
            }
        }
    }
}
