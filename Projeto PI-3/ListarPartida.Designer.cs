namespace Projeto_PI_3
{
    partial class ListarPartida
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblVersao = new System.Windows.Forms.Label();
            this.lstPartidas = new System.Windows.Forms.ListBox();
            this.cmbStatusPartida = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstListaJogadores = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlNavegacao = new System.Windows.Forms.Panel();
            this.lstNavegacao = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblNomePartida = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNavegacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(146, 541);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(40, 13);
            this.lblVersao.TabIndex = 0;
            this.lblVersao.Text = "Versão";
            // 
            // lstPartidas
            // 
            this.lstPartidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPartidas.FormattingEnabled = true;
            this.lstPartidas.ItemHeight = 20;
            this.lstPartidas.Location = new System.Drawing.Point(62, 217);
            this.lstPartidas.Name = "lstPartidas";
            this.lstPartidas.Size = new System.Drawing.Size(336, 224);
            this.lstPartidas.TabIndex = 3;
            this.lstPartidas.SelectedIndexChanged += new System.EventHandler(this.lstPartidas_SelectedIndexChanged);
            // 
            // cmbStatusPartida
            // 
            this.cmbStatusPartida.FormattingEnabled = true;
            this.cmbStatusPartida.Items.AddRange(new object[] {
            "Todas",
            "Abertas",
            "Jogando",
            "Finalizadas",
            "Empate"});
            this.cmbStatusPartida.Location = new System.Drawing.Point(62, 173);
            this.cmbStatusPartida.Name = "cmbStatusPartida";
            this.cmbStatusPartida.Size = new System.Drawing.Size(175, 21);
            this.cmbStatusPartida.TabIndex = 4;
            this.cmbStatusPartida.SelectedIndexChanged += new System.EventHandler(this.cmbStatusPartida_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Status da Partida";
            // 
            // lstListaJogadores
            // 
            this.lstListaJogadores.FormattingEnabled = true;
            this.lstListaJogadores.Location = new System.Drawing.Point(480, 333);
            this.lstListaJogadores.Name = "lstListaJogadores";
            this.lstListaJogadores.Size = new System.Drawing.Size(228, 108);
            this.lstListaJogadores.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 73);
            this.label2.TabIndex = 8;
            this.label2.Text = "Magic Trick";
            // 
            // pnlNavegacao
            // 
            this.pnlNavegacao.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlNavegacao.Controls.Add(this.lstNavegacao);
            this.pnlNavegacao.Controls.Add(this.label5);
            this.pnlNavegacao.Controls.Add(this.lblVersao);
            this.pnlNavegacao.Location = new System.Drawing.Point(729, -2);
            this.pnlNavegacao.Name = "pnlNavegacao";
            this.pnlNavegacao.Size = new System.Drawing.Size(221, 564);
            this.pnlNavegacao.TabIndex = 9;
            // 
            // lstNavegacao
            // 
            this.lstNavegacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstNavegacao.FormattingEnabled = true;
            this.lstNavegacao.ItemHeight = 24;
            this.lstNavegacao.Items.AddRange(new object[] {
            "Home",
            "Criar Partida"});
            this.lstNavegacao.Location = new System.Drawing.Point(24, 92);
            this.lstNavegacao.Name = "lstNavegacao";
            this.lstNavegacao.Size = new System.Drawing.Size(175, 388);
            this.lstNavegacao.TabIndex = 2;
            this.lstNavegacao.SelectedIndexChanged += new System.EventHandler(this.lstNavegacao_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Menu de Navegação";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(475, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Informações da Partida";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(477, 197);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "ID";
            // 
            // lblNomePartida
            // 
            this.lblNomePartida.AutoSize = true;
            this.lblNomePartida.Location = new System.Drawing.Point(477, 227);
            this.lblNomePartida.Name = "lblNomePartida";
            this.lblNomePartida.Size = new System.Drawing.Size(86, 13);
            this.lblNomePartida.TabIndex = 4;
            this.lblNomePartida.Text = "Nome da Partida";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(477, 258);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(30, 13);
            this.lblData.TabIndex = 5;
            this.lblData.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(477, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lista de Jogadores";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(-1, 469);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 93);
            this.panel1.TabIndex = 10;
            // 
            // ListarPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblNomePartida);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlNavegacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstListaJogadores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStatusPartida);
            this.Controls.Add(this.lstPartidas);
            this.Name = "ListarPartida";
            this.Text = "Form1";
            this.pnlNavegacao.ResumeLayout(false);
            this.pnlNavegacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.ListBox lstPartidas;
        private System.Windows.Forms.ComboBox cmbStatusPartida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstListaJogadores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlNavegacao;
        private System.Windows.Forms.Label lblNomePartida;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstNavegacao;
        private System.Windows.Forms.Panel panel1;
    }
}

