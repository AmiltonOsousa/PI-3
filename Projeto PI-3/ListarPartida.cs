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
            if(lstNavegacao.SelectedIndex == 0) 
            {
                this.Close();
            }

            if(lstNavegacao.SelectedIndex == 1)
            {
                CriarPartida criarPartida = new CriarPartida();
                criarPartida.Show();

                this.Close();
            }
        }
    }
}
