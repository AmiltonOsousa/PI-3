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
    public partial class ListarPartida : Form
    {
        public string InfoJogadores;

        public ListarPartida()
        {
            InitializeComponent();

            //Configurações Iniciais
            lblVersao.Text = "Versão: " + Jogo.Versao;
            cmbStatusPartida.SelectedIndex = 0;
        }


        private void cmbStatusPartida_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = cmbStatusPartida.SelectedItem.ToString().Substring(0, 1);
            string listaPartidas = Jogo.ListarPartidas(status);

            //Tratamento para separar cada partida
            listaPartidas = listaPartidas.Replace("\r", "");

            if (listaPartidas.Length != 0)
            {
                listaPartidas = listaPartidas.Substring(0, listaPartidas.Length - 1);

                string[] partidas = listaPartidas.Split('\n');

                //Colocar cada partida como um item da listbox
                lstPartidas.Items.Clear();

                foreach (string partida in partidas)
                {
                    lstPartidas.Items.Add(partida);
                }
            }

            else
                lstPartidas.Items.Clear();
        }

        private void lstPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string partida = lstPartidas.SelectedItem.ToString();
            string[] infoPartida = partida.Split(',');

            int idInfo = Convert.ToInt32(infoPartida[0]);
            string nomeInfo = infoPartida[1];
            string data = infoPartida[2];

            lblId.Text = "ID: " + idInfo.ToString();
            lblNomePartida.Text = "Nome da Partida: " + nomeInfo;
            lblData.Text = "Data: " + data;

            //Fazer a lista de jogadores
            string partidaJogador = Jogo.ListarJogadores(idInfo);
            partidaJogador = partidaJogador.Replace("\r", "");
            string[] jogadores = partidaJogador.Split('\n');

            lstListaJogadores.Items.Clear();
            foreach (string jogador in jogadores)
            {
                lstListaJogadores.Items.Add(jogador);
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
                CriarPartida criarPartida = new CriarPartida();
                criarPartida.Show();

                this.Close();
            }
        }
        

        private void btnEntrarPartida_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja entrar na partida: ", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Text;

                if (lblId.Text == "")
                {
                    MessageBox.Show("Nenhuma partida foi selecionada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(lblId.Text.Length > 4)
                {
                    int idPartida = Convert.ToInt32(lblId.Text.Substring(4));

                    string retorno = Jogo.EntrarPartida(idPartida, usuario, senha);
                    if (retorno.Substring(0, 4) == "ERROR")
                    {
                        MessageBox.Show("Ocorreu um erro:\n" + retorno.Substring(5), "Meu PI-3", MessageBoxButtons.OK);
                    }

                    else
                    {
                        EmJogo emJogo = new EmJogo();
                        emJogo.dadosRetorno = retorno + "," + idPartida;
                        emJogo.AtualizarTela();

                        emJogo.Show();
                        this.Close();                  
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            string nomePadrao = "Andorra";

            for (int i = 0; i < 4; i++)
            {
                nomePadrao += random.Next(1, 10);
            }

            Jogo.CriarPartida(nomePadrao, "123", "Andorra");
        }
    }
}
