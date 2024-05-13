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
        public string dadoOriginal, status, dados, senha, naipe;
        public string[] dado, minhasCartas;

        public int idJogador, idPartida;

        //Variável para saber se a carta selecionada é a jogada ou apostada
        public bool cartaJogada = false;
        //Variável para mostrar as cartas graficamente
        public PictureBox[] CartasImagens = new PictureBox[12];
        //Lista que será usada para armazenar os naipes
        public List<string> ListaNaipes = new List<string>();
        //Array para mostrar CartasImagens disponíveis e indisponíveis
        public bool[] Cartas = new bool[12];
        //Matriz com todas as cartas
        public int[,] TodasCartas = new int[3, 8];

        //-----------Variáveis para o jogo----------------
        public int[] valoresMao = new int[12];
        public int vitorias = 0;
        public int numCarta, numRound, posicao;
        public bool apostaEncontrada = false;
        public bool acumularPontos = true;
        public bool apostou = false;
        public bool fimPartida = false;


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

            //Inicialize o array com as CartasImagens gráficas
            for (int i = 0; i < 12; i++)
            {
                Cartas[i] = true;
            }

            CartasImagens[0] = picCarta1;
            CartasImagens[1] = picCarta2;
            CartasImagens[2] = picCarta3;
            CartasImagens[3] = picCarta4;
            CartasImagens[4] = picCarta5;
            CartasImagens[5] = picCarta6;
            CartasImagens[6] = picCarta7;
            CartasImagens[7] = picCarta8;
            CartasImagens[8] = picCarta9;
            CartasImagens[9] = picCarta10;
            CartasImagens[10] = picCarta11;
            CartasImagens[11] = picCarta12;
        }
        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            Jogo.IniciarPartida(idJogador, senha);
            VerMao();
            btnIniciarPartida.Enabled = false;
        }

        public bool VerificarVez()
        {
            string retorno = Jogo.VerificarVez(idPartida);
            string[] dadosPartida = retorno.Split(',');

            string statusPartida = dadosPartida[0];
            string idJogadorVez = dadosPartida[1];
            int numRodadas = Convert.ToInt32(dadosPartida[2]);
            string status = dadosPartida[3];

            //Verificar se é hora de jogar ou não
            if (idJogador == Convert.ToInt32(idJogadorVez))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void VerMao()
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
                        CartasImagens[i].Image = Properties.Resources.Ouros1;
                        break;

                    case "C":
                        CartasImagens[i].Image = Properties.Resources.Copas1;
                        break;

                    case "E":
                        CartasImagens[i].Image = Properties.Resources.Espadas1;
                        break;

                    case "S":
                        CartasImagens[i].Image = Properties.Resources.Estrela1;
                        break;

                    case "P":
                        CartasImagens[i].Image = Properties.Resources.Paus1;
                        break;

                    case "L":
                        CartasImagens[i].Image = Properties.Resources.Lua1;
                        break;

                    case "T":
                        CartasImagens[i].Image = Properties.Resources.Triângulo1;
                        break;
                }
            }
        }

        public void MudarDesignCarta(int posicao)
        {
            switch (ListaNaipes[posicao - 1])
            {
                case "O":
                    CartasImagens[posicao - 1].Image = Properties.Resources.Ouros2;
                    break;

                case "C":
                    CartasImagens[posicao - 1].Image = Properties.Resources.Copas2;
                    break;

                case "E":
                    CartasImagens[posicao - 1].Image = Properties.Resources.Espadas2;
                    break;

                case "S":
                    CartasImagens[posicao - 1].Image = Properties.Resources.Estrela2;
                    break;

                case "P":
                    CartasImagens[posicao - 1].Image = Properties.Resources.Paus2;
                    break;

                case "L":
                    CartasImagens[posicao - 1].Image = Properties.Resources.Lua2;
                    break;

                case "T":
                    CartasImagens[posicao - 1].Image = Properties.Resources.Triângulo2;
                    break;
            }
        }

        public string JogarCarta(int posicao)
        {
            string retorno = Jogo.Jogar(idJogador, senha, posicao);

            /*if (retorno.Substring(0, 1) == "E")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retorno.Substring(5), "Meu PI-3", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "";
            }
            */

            
                lblTitulo.Text = "Carta jogada | Esperando a aposta...";
                lblCartaJogada.Text = "Carta Jogada: " + retorno;

                lblCartaValor.Text = retorno;
                lblCartaValor.BackColor = Color.Transparent;

                picCartaJogada.Image = CartasImagens[posicao - 1].Image;

                //Mudar o design da carta que foi jogada
                MudarDesignCarta(posicao);

                return retorno;
            
        }

        public void ApostarCarta(int posicao)
        {
            string retorno = Jogo.Apostar(idJogador, senha, posicao);

            /*if (retorno.Substring(0, 1) == "E")
            {
                MessageBox.Show("Ocorreu um erro:\n" + retorno.Substring(5), "Meu PI-3", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            */

            
                lblAposta.Text = "Aposta feita: " + retorno;
                lblTitulo.Text = "Carta jogada | Aposta feita";
                lblApostaValor.Text = retorno;

                if (posicao == 0)
                {
                    picCartaApostada.Image = Properties.Resources.istockphoto_878053066_170667a;
                }
                else
                {
                    MudarDesignCarta(posicao);
                    picCartaApostada.Image = CartasImagens[posicao - 1].Image;
                }
                cartaJogada = false;
            
        }

        //----------------------Métodos Auxiliares---------------------\\

        private void AlgAposta(int numCarta, int vitoria, int posicao)
        {
            if (apostou)
            {
                ApostarCarta(0);
                return;
            }

            if(numRound == 10)
            {
                //Apostar a carta mais próxima da quantidade de vitórias
                for (int i = 0; i < Cartas.Length; i++)
                {
                    if (Cartas[i] == true)
                    {
                        ApostarCarta(i + 1);
                        Cartas[i] = false;

                        return;
                    }
                } 
            }

            if(numRound >= 5)
            {
                if(numCarta - vitoria == 0)
                {
                    //remover os extremos, pois a primeira carta -1 ou a última mais 1 não existe
                    if (posicao != 11 && posicao != 0)
                    {
                        if (Cartas[posicao + 1] == true)
                        {
                            ApostarCarta(posicao + 2);
                            apostou = true;

                            Cartas[posicao + 1] = false;
                        }
                        else if (Cartas[posicao + 1] == true)
                        {
                            ApostarCarta(posicao);
                            apostou = true;

                            Cartas[posicao + 1] = false;
                        }
                    }
                }
            }
            ApostarCarta(0);
        }

        public void MaiorCarta(string naipe)
        {
            for (int i = ListaNaipes.Count - 1; i >= 0; i--)
            {
                if (ListaNaipes[i] == naipe && Cartas[i] == true)
                {
                    numCarta = Convert.ToInt32(JogarCarta(i + 1));
                    Cartas[i] = false;

                    return;
                }
            }

            //Caso não tenha nenhuma carta com o naipe
            for (int j = ListaNaipes.Count - 1; j >= 0; j--)
            {
                if (Cartas[j] == true)
                {
                    numCarta = Convert.ToInt32(JogarCarta(j + 1));
                    Cartas[j] = false;

                    return;
                }
            }
        }

        //--------------------------Estratégias---------------------------\\

        private void EstTeste(string retornoJogadas)
        {
            retornoJogadas = retornoJogadas.Replace("\r", "");
            string[] jogadas = retornoJogadas.Split('\n');

            if(retornoJogadas != "")
            {
                //Achar as informações da última jogada
                int size = jogadas.Length - 1;
                string ultimaJogada = jogadas[size - 1];
                    
                string[] infos = ultimaJogada.Split(',');
                numRound = Convert.ToInt32(infos[0]);
                naipe = infos[2];
            }

            //Verificar se é o primeiro a jogar ou não - OBS: Se é o primeiro logo ele ganhou a rodada anterior, com excessão da primeira rodada que é aleatório quem começa
            if (retornoJogadas == "" || (jogadas.Length - 1) % 2 == 0)
            {
                if (numRound > 0)
                    vitorias++;

                for (int i = Cartas.Length - 1; i >= 0; i--)
                {
                    //Confere se a carta está disponível
                    if (Cartas[i] == true)
                    {
                        numCarta = Convert.ToInt32(JogarCarta(i + 1));
                        Cartas[i] = false;
                        posicao = i;

                        AlgAposta(numCarta, vitorias, posicao);

                        break;
                    }
                }
            }
            else
            {
                if (vitorias < 3)
                {
                    MaiorCarta(naipe);
                    AlgAposta(numCarta, vitorias, posicao);

                    return;
                }

                for (int i = 0; i < ListaNaipes.Count; i++)
                {
                    if (ListaNaipes[i] == naipe && Cartas[i] == true)
                    {
                        numCarta = Convert.ToInt32(JogarCarta(i + 1));
                        Cartas[i] = false;

                        AlgAposta(numCarta, vitorias, posicao);

                        return;
                    }
                }

                //Excessão: Não tem a carta com o naipe correspondente
                for (int j = 0; j < ListaNaipes.Count; j++)
                {
                    if (Cartas[j] == true)
                    {
                        int numCarta = Convert.ToInt32(JogarCarta(j + 1));
                        Cartas[j] = false;

                        AlgAposta(numCarta, vitorias, posicao);

                        return;
                    }
                }                      
            }
        }

        //--------------------------------------------------------------\\

        //Automação

        private void btnAutomacao_Click(object sender, EventArgs e)
        
        {
            btnAutomacao.Enabled = false;
            tmrAutomacao.Enabled = true;
        }

        private void tmrAutomacao_Tick(object sender, EventArgs e)
        {
            tmrAutomacao.Enabled = false;

            bool seuTurno = VerificarVez();
            string retornoJogadas = Jogo.ExibirJogadas2(idPartida);

            if (seuTurno)
            {
                EstTeste(retornoJogadas);
            }

            tmrAutomacao.Enabled = true;
        }
    }
}
