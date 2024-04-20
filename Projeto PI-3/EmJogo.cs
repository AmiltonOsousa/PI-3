using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_PI_3
{

    public partial class EmJogo : Form
    {
        //Variáveis para pegar dado de outro form
        public string dadosRetorno { get; set; }
        public string dadoOriginal, status;

        public string dados, senha;
        public string[] dado;

        public int idJogador, idPartida;

        //Variável para mostrar as cartas graficamente
        public PictureBox[] Cartas = new PictureBox[12];

        //Variável para saber se a carta selecionada é a jogada ou apostada
        public bool cartaJogada = false;

        //Lista que será usada para armazenar os naipes
        public List<string> ListaNaipes = new List<string>();

        public void AtualizarTela()
        {
            dadoOriginal = dadosRetorno;

            dados = dadoOriginal;
            dados = dados.Replace("\r", "");
            dados = dados.Replace("\n", "");

            dado = dados.Split(',');

            idJogador = Convert.ToInt32(dado[0]);
            senha = dado[1];
            idPartida = Convert.ToInt32(dado[2]);
        }

        public EmJogo()
        {
            InitializeComponent();

            //Inicialize o array com as cartas gráficas
            Cartas[0] = picCarta1;
            Cartas[1] = picCarta2;
            Cartas[2] = picCarta3;
            Cartas[3] = picCarta4;
            Cartas[4] = picCarta5;
            Cartas[5] = picCarta6;
            Cartas[6] = picCarta7;
            Cartas[7] = picCarta8;
            Cartas[8] = picCarta9;
            Cartas[9] = picCarta10;
            Cartas[10] = picCarta11;
            Cartas[11] = picCarta12;
        }

        public void JogarApostar(int posicao)
        { 
            dados = dados.Replace("\r", "");
            dados = dados.Replace("\n", "");

            if(!cartaJogada)
            {
                string retorno = Jogo.Jogar(idJogador, senha, posicao);

                if (retorno.Substring(0, 1) == "E")
                {
                    MessageBox.Show("Ocorreu um erro:\n" + retorno.Substring(5), "Meu PI-3", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    lblTitulo.Text = "Carta jogada | Esperando a aposta...";
                    lblCartaJogada.Text = "Carta Jogada: " + retorno;
                    lblCartaValor.Text = retorno;

                    picCartaJogada.Image = Cartas[posicao - 1].Image;

                    switch (ListaNaipes[posicao - 1])
                    {
                        case "O":
                            Cartas[posicao - 1].Image = Properties.Resources.Ouros2;
                            break;

                        case "C":
                            Cartas[posicao - 1].Image = Properties.Resources.Copas2;
                            break;

                        case "E":
                            Cartas[posicao - 1].Image = Properties.Resources.Espadas2;
                            break;

                        case "S":
                            Cartas[posicao - 1].Image = Properties.Resources.Estrela2;
                            break;

                        case "P":
                            Cartas[posicao - 1].Image = Properties.Resources.Paus2;
                            break;

                        case "L":
                            Cartas[posicao - 1].Image = Properties.Resources.Lua2;
                            break;

                        case "T":
                            Cartas[posicao - 1].Image = Properties.Resources.Triângulo2;
                            break;
                    }

                    cartaJogada = true;
                }
            }

            else
            {
                string retorno = Jogo.Apostar(idJogador, senha, posicao);

                if (retorno.Substring(0, 1) == "E")
                {
                    MessageBox.Show("Ocorreu um erro:\n" + retorno.Substring(5), "Meu PI-3", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    lblAposta.Text = "Aposta feita: " + retorno;
                    lblTitulo.Text = "Carta jogada | Aposta feita";
                    lblApostaValor.Text = retorno;

                    picCartaApostada.Image = Cartas[posicao - 1].Image;

                    //Mudar o design da carta que foi jogada
                    switch (ListaNaipes[posicao - 1])
                    {
                        case "O":
                            Cartas[posicao - 1].Image = Properties.Resources.Ouros2;
                            break;

                        case "C":
                            Cartas[posicao - 1].Image = Properties.Resources.Copas2;
                            break;

                        case "E":
                            Cartas[posicao - 1].Image = Properties.Resources.Espadas2;
                            break;

                        case "S":
                            Cartas[posicao - 1].Image = Properties.Resources.Estrela2;
                            break;

                        case "P":
                            Cartas[posicao - 1].Image = Properties.Resources.Paus2;
                            break;

                        case "L":
                            Cartas[posicao - 1].Image = Properties.Resources.Lua2;
                            break;

                        case "T":
                            Cartas[posicao - 1].Image = Properties.Resources.Triângulo2;
                            break;
                    }

                    cartaJogada = false;
                }
            }
        }
        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            string JogadorSorteado = Jogo.IniciarPartida(idJogador, senha);

            jogadorVez(idPartida, Convert.ToInt32(JogadorSorteado));

            btnIniciarPartida.Enabled = false;
            btnIniciarPartida.Visible = false;
        }

        public void jogadorVez(int idPartida, int idSorteado)
        {
            string jogadores = Jogo.ListarJogadores(idPartida);

            jogadores = jogadores.Replace("\r", "");
            jogadores = jogadores.Substring(0, jogadores.Length - 1);

            string[] jogador = jogadores.Split('\n');

            for(int i = 0; i < jogador.Length; i++)
            {
                string[] dadosJogador = jogador[i].Split(',');

                string JogadorSorteado = idSorteado.ToString();
                string idJogadorLista = dadosJogador[0];
                string nomeJogadorLista = dadosJogador[1];

                
                if(idJogadorLista == JogadorSorteado)
                    lblNomeIdSorteado.Text = "Nome: " + nomeJogadorLista + "\nID: " + idJogadorLista;
            }
        }

        public void btnVerificarVez_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.VerificarVez(idPartida);
            string[] dadosPartida = retorno.Split(',');

            string statusPartida = dadosPartida[0];
            string idJogadorVez = dadosPartida[1];
            int numeroRodada = Convert.ToInt32(dadosPartida[2]);
            string status = dadosPartida[3];

            jogadorVez(idPartida, Convert.ToInt32(idJogadorVez));
        }

        private void btnVerificarMao_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.ConsultarMao(idPartida);

            retorno = retorno.Replace("\r", "");

            //Separar as cartas do retorno por linha e colocar na lista
            string[] ConsultarMao = retorno.Split('\n');   

            for (int i = 0; i < ConsultarMao.Length - 1; i++)
            {
                //Adiciona todo o retorno em uma lista
                lstCartas.Items.Add(ConsultarMao[i]);

                //Código para mostrar as imagens das cartas
                string[] dadosMao = ConsultarMao[i].Split(',');
                int cartasIdJogador = Convert.ToInt32(dadosMao[0]);

                //Ver qual é o ID do jogador para mostrar somente as cartas dele
                if (idJogador == cartasIdJogador)
                {
                    string naipe = dadosMao[2];
                    ListaNaipes.Add(naipe);
                }
            }
              
            //MOSTRAR AS IMAGENS DAS CARTAS DO JOGADOR
            for (int i = 0; i < ListaNaipes.Count; i++)
            {
                switch (ListaNaipes[i])
                {
                    case "O":
                        Cartas[i].Image = Properties.Resources.Ouros1;
                        break;
                    
                    case "C":
                        Cartas[i].Image = Properties.Resources.Copas1;
                        break;

                    case "E":
                        Cartas[i].Image = Properties.Resources.Espadas1;
                        break;

                    case "S":
                        Cartas[i].Image = Properties.Resources.Estrela1;
                        break;

                    case "P":
                        Cartas[i].Image = Properties.Resources.Paus1;
                        break;

                    case "L":
                        Cartas[i].Image = Properties.Resources.Lua1;
                        break;

                    case "T":
                        Cartas[i].Image = Properties.Resources.Triângulo1;
                        break;                 
                }
            }     
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.Jogar(idJogador, senha, 1);

            if (retorno.Substring(0, 1) == "E")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retorno.Substring(5), "Meu PI-3", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                lblTitulo.Text = "Carta jogada | Esperando aposta...";
                lblCartaJogada.Text = "Carta Jogada: " + retorno;
            }
        }

        private void btnApostar_Click(object sender, EventArgs e)
        {
            string retorno = Jogo.Apostar(idJogador, senha, 0);

            if (retorno.Substring(0, 1) == "E")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retorno.Substring(5), "Meu PI-3", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                lblTitulo.Text = "Carta jogada | Aposta feita";
                lblAposta.Text = "Carta apostada: " + retorno;
            }
        }
        private void picCarta1_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(1);
        }


        private void picCarta2_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(2);
        }

        private void picCarta3_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(3);
        }


        private void picCarta4_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(4);
        }


        private void picCarta5_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(5);
        }


        private void picCarta6_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(6);
        }


        private void picCarta7_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(7);
        }


        private void picCarta8_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(8);
        }
        private void picCarta9_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(9);
        }

        private void picCarta10_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(10);
        }

        private void picCarta11_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(11);
        }

        private void picCarta12_DoubleClick(object sender, EventArgs e)
        {
            JogarApostar(12);
        }

        private void picCoringa_DoubleClick(object sender, EventArgs e)
        {
            Jogo.Apostar(idJogador, senha, 0);
            picCartaApostada.Image = Properties.Resources.istockphoto_878053066_170667a;

            lblApostaValor.Text = "0";
        }
    }
}
