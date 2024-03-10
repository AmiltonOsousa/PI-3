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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            lblVersao.Text = "Versão: " + Jogo.Versao;
        }

        private void btnListaPartida_Click(object sender, EventArgs e)
        {
            ListarPartida form1 = new ListarPartida();
            form1.Show();
        }

        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            CriarPartida criarPartida = new CriarPartida();
            criarPartida.Show();
        }
    }
}
