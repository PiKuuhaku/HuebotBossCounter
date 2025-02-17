namespace HuebotBossCounter
{
    partial class BossCounter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BossCounter));
            tabControl1 = new TabControl();
            tabAutenticacao = new TabPage();
            lblGameName = new Label();
            label1 = new Label();
            btnLogin = new Button();
            lblSenha = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            txtSenha = new TextBox();
            tabHistorico = new TabPage();
            lblDiffNumber = new Label();
            lblDiff = new Label();
            lvDropHistory = new ListView();
            lblDropCount = new Label();
            lblText2 = new Label();
            lblKillCount = new Label();
            lblText = new Label();
            lblBossList3 = new Label();
            cbBossList3 = new ComboBox();
            tabAdicionar = new TabPage();
            lblPlayerNumber = new Label();
            cbPlayerNumber = new ComboBox();
            lblUtilizacao = new LinkLabel();
            clbPlayers = new CheckedListBox();
            clbDrops = new CheckedListBox();
            rbMultipleDrop = new RadioButton();
            rbNoDrops = new RadioButton();
            lblPlayer = new Label();
            lblBossDrops = new Label();
            btnAdicionar = new Button();
            lblBossList = new Label();
            cbBossList = new ComboBox();
            tabAtualizar = new TabPage();
            btnAtualizar = new Button();
            btnRemover = new Button();
            label5 = new Label();
            cbKillNumber = new ComboBox();
            label4 = new Label();
            cbBossList2 = new ComboBox();
            clbPlayers2 = new CheckedListBox();
            clbDrops2 = new CheckedListBox();
            lblPlayer2 = new Label();
            lblBossDrops2 = new Label();
            tabControl1.SuspendLayout();
            tabAutenticacao.SuspendLayout();
            tabHistorico.SuspendLayout();
            tabAdicionar.SuspendLayout();
            tabAtualizar.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabAutenticacao);
            tabControl1.Controls.Add(tabHistorico);
            tabControl1.Controls.Add(tabAdicionar);
            tabControl1.Controls.Add(tabAtualizar);
            tabControl1.Location = new Point(4, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(372, 295);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            tabControl1.Enter += tabControl1_Enter;
            // 
            // tabAutenticacao
            // 
            tabAutenticacao.Controls.Add(lblGameName);
            tabAutenticacao.Controls.Add(label1);
            tabAutenticacao.Controls.Add(btnLogin);
            tabAutenticacao.Controls.Add(lblSenha);
            tabAutenticacao.Controls.Add(lblUsuario);
            tabAutenticacao.Controls.Add(txtUsuario);
            tabAutenticacao.Controls.Add(txtSenha);
            tabAutenticacao.Location = new Point(4, 24);
            tabAutenticacao.Name = "tabAutenticacao";
            tabAutenticacao.Padding = new Padding(3);
            tabAutenticacao.Size = new Size(364, 267);
            tabAutenticacao.TabIndex = 0;
            tabAutenticacao.Text = "Autenticação";
            tabAutenticacao.UseVisualStyleBackColor = true;
            // 
            // lblGameName
            // 
            lblGameName.AutoSize = true;
            lblGameName.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGameName.Location = new Point(53, 54);
            lblGameName.Name = "lblGameName";
            lblGameName.Size = new Size(263, 45);
            lblGameName.TabIndex = 4;
            lblGameName.Text = "THE WORLD RPG";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(-2, 8);
            label1.Name = "label1";
            label1.Size = new Size(374, 45);
            label1.TabIndex = 1;
            label1.Text = "HUEBOT BOSS COUNTER";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(142, 231);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Acessar";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(8, 190);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(39, 15);
            lblSenha.TabIndex = 3;
            lblSenha.Text = "Senha";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(3, 142);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuário";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(53, 134);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(308, 23);
            txtUsuario.TabIndex = 0;
            txtUsuario.Enter += txtUsuario_GotFocus;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(53, 182);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(308, 23);
            txtSenha.TabIndex = 1;
            txtSenha.UseSystemPasswordChar = true;
            txtSenha.Enter += txtSenha_GotFocus;
            // 
            // tabHistorico
            // 
            tabHistorico.Controls.Add(lblDiffNumber);
            tabHistorico.Controls.Add(lblDiff);
            tabHistorico.Controls.Add(lvDropHistory);
            tabHistorico.Controls.Add(lblDropCount);
            tabHistorico.Controls.Add(lblText2);
            tabHistorico.Controls.Add(lblKillCount);
            tabHistorico.Controls.Add(lblText);
            tabHistorico.Controls.Add(lblBossList3);
            tabHistorico.Controls.Add(cbBossList3);
            tabHistorico.Location = new Point(4, 24);
            tabHistorico.Name = "tabHistorico";
            tabHistorico.Size = new Size(364, 267);
            tabHistorico.TabIndex = 2;
            tabHistorico.Text = "Histórico";
            tabHistorico.UseVisualStyleBackColor = true;
            // 
            // lblDiffNumber
            // 
            lblDiffNumber.AutoSize = true;
            lblDiffNumber.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiffNumber.Location = new Point(166, 46);
            lblDiffNumber.Name = "lblDiffNumber";
            lblDiffNumber.Size = new Size(68, 30);
            lblDiffNumber.TabIndex = 11;
            lblDiffNumber.Text = "99999";
            lblDiffNumber.Visible = false;
            // 
            // lblDiff
            // 
            lblDiff.AutoSize = true;
            lblDiff.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiff.Location = new Point(120, 46);
            lblDiff.Name = "lblDiff";
            lblDiff.Size = new Size(52, 30);
            lblDiff.TabIndex = 10;
            lblDiff.Text = "Diff:";
            lblDiff.Visible = false;
            // 
            // lvDropHistory
            // 
            lvDropHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvDropHistory.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lvDropHistory.Location = new Point(0, 76);
            lvDropHistory.Name = "lvDropHistory";
            lvDropHistory.Size = new Size(364, 197);
            lvDropHistory.TabIndex = 9;
            lvDropHistory.UseCompatibleStateImageBehavior = false;
            // 
            // lblDropCount
            // 
            lblDropCount.AutoSize = true;
            lblDropCount.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDropCount.Location = new Point(297, 45);
            lblDropCount.Name = "lblDropCount";
            lblDropCount.Size = new Size(68, 30);
            lblDropCount.TabIndex = 8;
            lblDropCount.Text = "99999";
            lblDropCount.Visible = false;
            // 
            // lblText2
            // 
            lblText2.AutoSize = true;
            lblText2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText2.Location = new Point(232, 45);
            lblText2.Name = "lblText2";
            lblText2.Size = new Size(73, 30);
            lblText2.TabIndex = 7;
            lblText2.Text = "Drops:";
            lblText2.Visible = false;
            // 
            // lblKillCount
            // 
            lblKillCount.AutoSize = true;
            lblKillCount.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKillCount.Location = new Point(51, 46);
            lblKillCount.Name = "lblKillCount";
            lblKillCount.Size = new Size(68, 30);
            lblKillCount.TabIndex = 5;
            lblKillCount.Text = "99999";
            lblKillCount.Visible = false;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText.Location = new Point(6, 46);
            lblText.Name = "lblText";
            lblText.Size = new Size(54, 30);
            lblText.TabIndex = 4;
            lblText.Text = "Kills:";
            lblText.Visible = false;
            // 
            // lblBossList3
            // 
            lblBossList3.AutoSize = true;
            lblBossList3.Location = new Point(6, 4);
            lblBossList3.Name = "lblBossList3";
            lblBossList3.Size = new Size(94, 15);
            lblBossList3.TabIndex = 3;
            lblBossList3.Text = "Selecione o Boss";
            // 
            // cbBossList3
            // 
            cbBossList3.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBossList3.FormattingEnabled = true;
            cbBossList3.Location = new Point(6, 22);
            cbBossList3.Name = "cbBossList3";
            cbBossList3.Size = new Size(355, 23);
            cbBossList3.TabIndex = 2;
            cbBossList3.SelectedIndexChanged += cbBossList3_SelectedIndexChanged;
            // 
            // tabAdicionar
            // 
            tabAdicionar.Controls.Add(lblPlayerNumber);
            tabAdicionar.Controls.Add(cbPlayerNumber);
            tabAdicionar.Controls.Add(lblUtilizacao);
            tabAdicionar.Controls.Add(clbPlayers);
            tabAdicionar.Controls.Add(clbDrops);
            tabAdicionar.Controls.Add(rbMultipleDrop);
            tabAdicionar.Controls.Add(rbNoDrops);
            tabAdicionar.Controls.Add(lblPlayer);
            tabAdicionar.Controls.Add(lblBossDrops);
            tabAdicionar.Controls.Add(btnAdicionar);
            tabAdicionar.Controls.Add(lblBossList);
            tabAdicionar.Controls.Add(cbBossList);
            tabAdicionar.Location = new Point(4, 24);
            tabAdicionar.Name = "tabAdicionar";
            tabAdicionar.Padding = new Padding(3);
            tabAdicionar.Size = new Size(364, 267);
            tabAdicionar.TabIndex = 1;
            tabAdicionar.Text = "Adicionar";
            tabAdicionar.UseVisualStyleBackColor = true;
            // 
            // lblPlayerNumber
            // 
            lblPlayerNumber.AutoSize = true;
            lblPlayerNumber.Location = new Point(7, 56);
            lblPlayerNumber.Name = "lblPlayerNumber";
            lblPlayerNumber.Size = new Size(122, 15);
            lblPlayerNumber.TabIndex = 16;
            lblPlayerNumber.Text = "Numero de jogadores";
            lblPlayerNumber.Visible = false;
            // 
            // cbPlayerNumber
            // 
            cbPlayerNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPlayerNumber.FormattingEnabled = true;
            cbPlayerNumber.Location = new Point(135, 52);
            cbPlayerNumber.Name = "cbPlayerNumber";
            cbPlayerNumber.Size = new Size(42, 23);
            cbPlayerNumber.TabIndex = 15;
            cbPlayerNumber.Visible = false;
            // 
            // lblUtilizacao
            // 
            lblUtilizacao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUtilizacao.AutoSize = true;
            lblUtilizacao.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUtilizacao.Location = new Point(253, 74);
            lblUtilizacao.Name = "lblUtilizacao";
            lblUtilizacao.Size = new Size(105, 21);
            lblUtilizacao.TabIndex = 14;
            lblUtilizacao.TabStop = true;
            lblUtilizacao.Text = "Como Utilizar";
            lblUtilizacao.Visible = false;
            lblUtilizacao.LinkClicked += lblUtilizacao_LinkClicked;
            // 
            // clbPlayers
            // 
            clbPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            clbPlayers.CheckOnClick = true;
            clbPlayers.Enabled = false;
            clbPlayers.FormattingEnabled = true;
            clbPlayers.Location = new Point(193, 116);
            clbPlayers.Name = "clbPlayers";
            clbPlayers.ScrollAlwaysVisible = true;
            clbPlayers.Size = new Size(165, 112);
            clbPlayers.TabIndex = 13;
            clbPlayers.Visible = false;
            clbPlayers.SelectedIndexChanged += clbPlayers_SelectedIndexChanged;
            // 
            // clbDrops
            // 
            clbDrops.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            clbDrops.CheckOnClick = true;
            clbDrops.Enabled = false;
            clbDrops.FormattingEnabled = true;
            clbDrops.Location = new Point(6, 116);
            clbDrops.Name = "clbDrops";
            clbDrops.ScrollAlwaysVisible = true;
            clbDrops.Size = new Size(184, 112);
            clbDrops.TabIndex = 12;
            clbDrops.Visible = false;
            clbDrops.SelectedIndexChanged += clbDrops_SelectedIndexChanged;
            // 
            // rbMultipleDrop
            // 
            rbMultipleDrop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbMultipleDrop.AutoSize = true;
            rbMultipleDrop.Location = new Point(274, 52);
            rbMultipleDrop.Name = "rbMultipleDrop";
            rbMultipleDrop.Size = new Size(79, 19);
            rbMultipleDrop.TabIndex = 11;
            rbMultipleDrop.Text = "Com drop";
            rbMultipleDrop.UseVisualStyleBackColor = true;
            rbMultipleDrop.Visible = false;
            // 
            // rbNoDrops
            // 
            rbNoDrops.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbNoDrops.AutoSize = true;
            rbNoDrops.Checked = true;
            rbNoDrops.Location = new Point(180, 52);
            rbNoDrops.Name = "rbNoDrops";
            rbNoDrops.Size = new Size(76, 19);
            rbNoDrops.TabIndex = 9;
            rbNoDrops.TabStop = true;
            rbNoDrops.Text = "Sem drop";
            rbNoDrops.UseVisualStyleBackColor = true;
            rbNoDrops.Visible = false;
            rbNoDrops.CheckedChanged += rbNoDrops_CheckedChanged;
            // 
            // lblPlayer
            // 
            lblPlayer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPlayer.AutoSize = true;
            lblPlayer.Location = new Point(193, 97);
            lblPlayer.Name = "lblPlayer";
            lblPlayer.Size = new Size(49, 15);
            lblPlayer.TabIndex = 7;
            lblPlayer.Text = "Jogador";
            lblPlayer.Visible = false;
            // 
            // lblBossDrops
            // 
            lblBossDrops.AutoSize = true;
            lblBossDrops.Location = new Point(6, 97);
            lblBossDrops.Name = "lblBossDrops";
            lblBossDrops.Size = new Size(33, 15);
            lblBossDrops.TabIndex = 5;
            lblBossDrops.Text = "Drop";
            lblBossDrops.Visible = false;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Anchor = AnchorStyles.Bottom;
            btnAdicionar.Location = new Point(146, 238);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(72, 23);
            btnAdicionar.TabIndex = 3;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Visible = false;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // lblBossList
            // 
            lblBossList.AutoSize = true;
            lblBossList.Location = new Point(6, 4);
            lblBossList.Name = "lblBossList";
            lblBossList.Size = new Size(94, 15);
            lblBossList.TabIndex = 1;
            lblBossList.Text = "Selecione o Boss";
            // 
            // cbBossList
            // 
            cbBossList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBossList.FormattingEnabled = true;
            cbBossList.Location = new Point(6, 22);
            cbBossList.Name = "cbBossList";
            cbBossList.Size = new Size(355, 23);
            cbBossList.TabIndex = 0;
            cbBossList.SelectedIndexChanged += cbBossList_SelectedIndexChanged;
            // 
            // tabAtualizar
            // 
            tabAtualizar.Controls.Add(btnAtualizar);
            tabAtualizar.Controls.Add(btnRemover);
            tabAtualizar.Controls.Add(label5);
            tabAtualizar.Controls.Add(cbKillNumber);
            tabAtualizar.Controls.Add(label4);
            tabAtualizar.Controls.Add(cbBossList2);
            tabAtualizar.Controls.Add(clbPlayers2);
            tabAtualizar.Controls.Add(clbDrops2);
            tabAtualizar.Controls.Add(lblPlayer2);
            tabAtualizar.Controls.Add(lblBossDrops2);
            tabAtualizar.Location = new Point(4, 24);
            tabAtualizar.Name = "tabAtualizar";
            tabAtualizar.Size = new Size(364, 267);
            tabAtualizar.TabIndex = 3;
            tabAtualizar.Text = "Atualizar";
            tabAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAtualizar.Location = new Point(146, 238);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(72, 23);
            btnAtualizar.TabIndex = 23;
            btnAtualizar.Text = "Add Drop";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Visible = false;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(6, 52);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(184, 23);
            btnRemover.TabIndex = 22;
            btnRemover.Text = "Remover última kill adicionada";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(192, 4);
            label5.Name = "label5";
            label5.Size = new Size(171, 15);
            label5.TabIndex = 21;
            label5.Text = "Qual kill deseja adicionar drop?";
            // 
            // cbKillNumber
            // 
            cbKillNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbKillNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKillNumber.FormattingEnabled = true;
            cbKillNumber.Location = new Point(193, 22);
            cbKillNumber.Name = "cbKillNumber";
            cbKillNumber.Size = new Size(165, 23);
            cbKillNumber.TabIndex = 20;
            cbKillNumber.SelectedIndexChanged += cbKillNumber_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 4);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 19;
            label4.Text = "Selecione o Boss";
            // 
            // cbBossList2
            // 
            cbBossList2.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBossList2.FormattingEnabled = true;
            cbBossList2.Location = new Point(6, 22);
            cbBossList2.Name = "cbBossList2";
            cbBossList2.Size = new Size(184, 23);
            cbBossList2.TabIndex = 18;
            cbBossList2.SelectedIndexChanged += cbBossList2_SelectedIndexChanged;
            // 
            // clbPlayers2
            // 
            clbPlayers2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clbPlayers2.CheckOnClick = true;
            clbPlayers2.FormattingEnabled = true;
            clbPlayers2.Location = new Point(193, 116);
            clbPlayers2.Name = "clbPlayers2";
            clbPlayers2.ScrollAlwaysVisible = true;
            clbPlayers2.Size = new Size(165, 112);
            clbPlayers2.TabIndex = 17;
            clbPlayers2.Visible = false;
            clbPlayers2.SelectedIndexChanged += clbPlayers2_SelectedIndexChanged;
            // 
            // clbDrops2
            // 
            clbDrops2.CheckOnClick = true;
            clbDrops2.FormattingEnabled = true;
            clbDrops2.Location = new Point(6, 116);
            clbDrops2.Name = "clbDrops2";
            clbDrops2.ScrollAlwaysVisible = true;
            clbDrops2.Size = new Size(184, 112);
            clbDrops2.TabIndex = 16;
            clbDrops2.Visible = false;
            clbDrops2.SelectedIndexChanged += clbDrops2_SelectedIndexChanged;
            // 
            // lblPlayer2
            // 
            lblPlayer2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPlayer2.AutoSize = true;
            lblPlayer2.Location = new Point(193, 97);
            lblPlayer2.Name = "lblPlayer2";
            lblPlayer2.Size = new Size(49, 15);
            lblPlayer2.TabIndex = 15;
            lblPlayer2.Text = "Jogador";
            lblPlayer2.Visible = false;
            // 
            // lblBossDrops2
            // 
            lblBossDrops2.AutoSize = true;
            lblBossDrops2.Location = new Point(6, 97);
            lblBossDrops2.Name = "lblBossDrops2";
            lblBossDrops2.Size = new Size(33, 15);
            lblBossDrops2.TabIndex = 14;
            lblBossDrops2.Text = "Drop";
            lblBossDrops2.Visible = false;
            // 
            // BossCounter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 311);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(400, 350);
            Name = "BossCounter";
            Text = "Huebot Boss Counter";
            tabControl1.ResumeLayout(false);
            tabAutenticacao.ResumeLayout(false);
            tabAutenticacao.PerformLayout();
            tabHistorico.ResumeLayout(false);
            tabHistorico.PerformLayout();
            tabAdicionar.ResumeLayout(false);
            tabAdicionar.PerformLayout();
            tabAtualizar.ResumeLayout(false);
            tabAtualizar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public TabControl tabControl1;
        public TabPage tabAutenticacao;
        public TabPage tabAdicionar;
        public TabPage tabHistorico;
        private Label lblSenha;
        private Label lblUsuario;
        private Button btnLogin;
        private Label label1;
        public TextBox txtSenha;
        public TextBox txtUsuario;
        private Label lblBossList;
        private ComboBox cbBossList;
        private Button btnAdicionar;
        private RadioButton rbMultipleDrop;
        private RadioButton rbSingleDrop;
        private RadioButton rbNoDrops;
        private CheckedListBox clbPlayers;
        private CheckedListBox clbDrops;
        private Label lblPlayer;
        private Label lblBossDrops;
        private Label lblGameName;
        private LinkLabel lblUtilizacao;
        private TabPage tabAtualizar;
        private Label label4;
        private ComboBox cbBossList2;
        private CheckedListBox clbPlayers2;
        private CheckedListBox clbDrops2;
        private Label lblPlayer2;
        private Label lblBossDrops2;
        private Label label5;
        private ComboBox cbKillNumber;
        private Button btnRemover;
        private Button btnAtualizar;
        private Label lblPlayerNumber;
        private ComboBox cbPlayerNumber;
        private Label lblBossList3;
        private ComboBox cbBossList3;
        private Label lblKillCount;
        private Label lblText;
        private ListView lvDropHistory;
        private Label lblDropCount;
        private Label lblText2;
        private Label lblDiffNumber;
        private Label lblDiff;
    }
}
