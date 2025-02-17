using HuebotBossCounter.Domain.Entities;
using HuebotBossCounter.Domain.Interfaces;
using HuebotBossCounter.Domain.Models;
using HuebotBossCounter.Infra.Context;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HuebotBossCounter
{
    public partial class BossCounter : Form
    {
        private static int lastKill = 0;
        private readonly IUserContext _userContext;
        private readonly IBossContext _bossContext;
        private readonly IKillsContext _killsContext;
        private readonly TabControlHelper tabControlHelper;

        public BossCounter(IUserContext userContext, IBossContext bossContext, IKillsContext killsContext)
        {
            _userContext = userContext;
            _bossContext = bossContext;
            _killsContext = killsContext;
            InitializeComponent();
            tabControlHelper = new TabControlHelper(tabControl1);
            tabControlHelper.HidePage(tabHistorico);
            tabControlHelper.HidePage(tabEstatisticas);
            tabControlHelper.HidePage(tabAdicionar);
            tabControlHelper.HidePage(tabAtualizar);
            txtUsuario.Text = Settings.Default.User.ToString();
            this.ActiveControl = string.IsNullOrEmpty(txtUsuario.Text) ? txtUsuario : txtSenha;
            //var tabControl = new TabControlHelper(tabControl1);
            //tabControl.HidePage(tabHistorico);
            //tabControl.HidePage(tabAdicionar);
        }
        void txtUsuario_GotFocus(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }

        void txtSenha_GotFocus(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Settings.Default.User = txtUsuario.Text;
            Settings.Default.Save();
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtSenha.Text))
                MessageBox.Show("Ambos os campos são obrigatórios.", "Erro");
            else
            {
                var usuario = _userContext.Usuario.Find(f => f.User.ToLower() == txtUsuario.Text.ToLower()).FirstOrDefault();
                if (usuario == null)
                    MessageBox.Show("Usuário não encontrado.", "Erro");
                else
                {
                    byte[] password = Convert.FromBase64String(usuario.Password);
                    string decodedString = System.Text.Encoding.UTF8.GetString(password);
                    if (txtSenha.Text != decodedString)
                        MessageBox.Show("Senha inválida.", "Erro");
                    else
                    {
                        if (decodedString == "123456")
                        {
                            string novaSenha = "";
                            var dialog = ConfirmPassword.PasswordInputBox("Alterar senha padrão", @"É necessário atualizar a senha para continuar.
Nova Senha:", ref novaSenha);
                            if (dialog == DialogResult.OK)
                            {
                                if (novaSenha == decodedString)
                                    MessageBox.Show("Senha nova não pode ser igual a senha antiga.", "Erro");
                                else if (string.IsNullOrEmpty(novaSenha))
                                    MessageBox.Show("Campo de nova senha em branco.", "Erro");
                                else
                                {
                                    usuario.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(novaSenha));
                                    var filter = Builders<Usuario>.Filter.Eq(f => f._id, usuario._id);
                                    _userContext.Usuario.ReplaceOne(filter, usuario);
                                    ShowTabsByPermission(usuario);
                                }
                            }
                        }
                        else
                        {
                            ShowTabsByPermission(usuario);
                        }
                    }
                }
            }
        }

        private void ShowTabsByPermission(Usuario usuario)
        {
            if (usuario.Permissions.Contains("Read"))
            {
                tabControlHelper.ShowPage(tabHistorico);
                tabControlHelper.ShowPage(tabEstatisticas);

            }
            if (usuario.Permissions.Contains("Write"))
            {
                tabControlHelper.ShowPage(tabAdicionar);
                tabControlHelper.ShowPage(tabAtualizar);
            }

            if (usuario.Permissions.Any())
                tabControlHelper.HidePage(tabAutenticacao);
            else
                MessageBox.Show("Usuário sem permissões.", "Erro");

            tabControl1.SelectedTab = usuario.Permissions.Contains("Write")
                ? tabAdicionar
                : usuario.Permissions.Contains("Read")
                    ? tabHistorico
                    : tabAutenticacao;
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            var bosses = _bossContext.Boss.Find(f => true).ToList();
            foreach (var item in bosses)
            {
                cbBossList.Items.Add(item.Name);
                cbBossList2.Items.Add(item.Name);
                cbBossList3.Items.Add(item.Name);
                cbBossList4.Items.Add(item.Name);
            }
        }

        private void cbBossList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastKill = 0;
            var boss = _bossContext.Boss.Find(f => f.Name == cbBossList.SelectedItem.ToString()).FirstOrDefault();
            var players = _userContext.Usuario.Find(f => true).ToList();
            clbDrops.Items.Clear();
            //clbDrops.Items.Add("");
            clbPlayers.Items.Clear();
            //clbPlayers.Items.Add("");
            cbPlayerNumber.Items.Clear();

            foreach (var item in boss.Drops)
                clbDrops.Items.Add(item.ItemName);

            foreach (var item in players)
                clbPlayers.Items.Add(item.User);

            for (int i = 1; i <= 10; i++)
                cbPlayerNumber.Items.Add(i);

            lblBossDrops.Visible = !string.IsNullOrEmpty(cbBossList.SelectedItem.ToString());
            clbDrops.Visible = !string.IsNullOrEmpty(cbBossList.SelectedItem.ToString());
            lblPlayer.Visible = !string.IsNullOrEmpty(cbBossList.SelectedItem.ToString());
            clbPlayers.Visible = !string.IsNullOrEmpty(cbBossList.SelectedItem.ToString());
            rbNoDrops.Visible = !string.IsNullOrEmpty(cbBossList.SelectedItem.ToString());
            rbMultipleDrop.Visible = !string.IsNullOrEmpty(cbBossList.SelectedItem.ToString());
            lblUtilizacao.Visible = !string.IsNullOrEmpty(cbBossList.SelectedItem.ToString());
            btnAdicionar.Visible = !string.IsNullOrEmpty(cbBossList.SelectedItem.ToString());
            lblPlayerNumber.Visible = !string.IsNullOrEmpty(cbBossList.SelectedItem.ToString());
            cbPlayerNumber.Visible = !string.IsNullOrEmpty(cbBossList.SelectedItem.ToString());
            chkFullLobby.Visible = !string.IsNullOrEmpty(cbBossList.SelectedItem.ToString());
        }

        private void rbNoDrops_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoDrops.Checked)
            {
                clbDrops.Enabled = false;
                clbPlayers.Enabled = false;
                for (int i = 0; i < clbDrops.Items.Count; i++)
                {
                    clbDrops.SetItemChecked(i, false);
                }
                for (int i = 0; i < clbPlayers.Items.Count; i++)
                {
                    clbPlayers.SetItemChecked(i, false);
                }
                //clbDrops.SelectedIndex = 0;
                //cbPlayers.SelectedIndex = 0;
            }
            else
            {
                clbDrops.Enabled = true;
                clbPlayers.Enabled = true;
            }
        }

        private void lblUtilizacao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show($@"Basta selecionar o drop e o jogador e clicar em adicionar. Caso seja necessário adicionar mais de um drop na mesma kill, adicione o primeiro por esta tela e depois adicione os outros pela aba ""Atualizar"" utilizando o número da kill como parâmetro.", "Tutorial", MessageBoxButtons.OK);
        }

        private Kills AddDrop(Kills kill, int killNumber, string item, string player)
        {
            if (kill.DropHistory.Any(f => f.KillNumber == killNumber))
            {
                if (kill.DropHistory.FirstOrDefault(f => f.KillNumber == killNumber) != null && kill.DropHistory.FirstOrDefault(f => f.KillNumber == killNumber).Drops != null)
                {
                    kill.DropHistory.FirstOrDefault(f => f.KillNumber == killNumber).Drops.Add(new PlayerDrop
                    {
                        Item = item,
                        Player = player
                    });
                }
            }
            else
            {
                var newDrop = new DropHistory
                {
                    KillNumber = killNumber,
                    PlayersInLobby = Convert.ToInt32(cbPlayerNumber.SelectedItem),
                    Drops = new List<PlayerDrop>
                    {
                        new PlayerDrop
                        {
                            Item = item,
                            Player = player
                        }
                    }
                };
                kill.DropHistory.Add(newDrop);
            }

            return kill;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var kill = _killsContext.Kills.Find(f => f.BossName == cbBossList.SelectedItem.ToString()).FirstOrDefault();

            var filter = Builders<Kills>.Filter.Eq(f => f._id, kill._id);

            var qtdeDrops = clbDrops.CheckedItems.Count;
            var qtdePlayers = clbPlayers.CheckedItems.Count;

            if (rbNoDrops.Checked)
            {
                if (chkFullLobby.Checked)
                {
                    kill.TotalDeaths += 4;
                    _killsContext.Kills.ReplaceOne(filter, kill);
                    MessageBox.Show($"Kills {kill.TotalDeaths - 3} à {kill.TotalDeaths} adicionadas no histórico.", "Sucesso");
                }
                else
                {
                    kill.TotalDeaths += 1;
                    _killsContext.Kills.ReplaceOne(filter, kill);
                    MessageBox.Show($"Kill {kill.TotalDeaths} adicionada no histórico.", "Sucesso");
                }
            }
            else if (rbMultipleDrop.Checked)
            {
                if (qtdeDrops <= 0 || qtdePlayers <= 0)
                    MessageBox.Show("Nenhum drop ou nenhum player selecionado", "Erro");
                else if (qtdeDrops < qtdePlayers)
                    MessageBox.Show("Quantidade de drops menor que a quantidade de jogadores", "Erro");
                else if (qtdeDrops > qtdePlayers)
                    MessageBox.Show("Quantidade de jogadores menor que a quantidade de drops", "Erro");
                else if (Convert.ToInt32(cbPlayerNumber.SelectedItem) <= 0)
                    MessageBox.Show("Kills com drops precisam que seja informado a quantidade de jogadores do lobby", "Erro");
                else if (chkFullLobby.Checked && Convert.ToInt32(cbKillDrop.SelectedItem) <= 0)
                    MessageBox.Show("Não é possível adicionar um lobby completo com drop sem selecionar a kill", "Erro");
                else
                {
                    if (chkFullLobby.Checked)
                    {
                        kill.TotalDeaths += 4;
                        var killNumber = kill.TotalDeaths + (Convert.ToInt32(cbKillDrop.SelectedItem) - 4);
                        AddDrop(kill, killNumber, clbDrops.CheckedItems[0].ToString(), clbPlayers.CheckedItems[0].ToString());
                        lastKill = killNumber;
                        _killsContext.Kills.ReplaceOne(filter, kill);
                        MessageBox.Show($"Kills {kill.TotalDeaths - 3} à {kill.TotalDeaths} adicionadas no histórico.", "Sucesso");
                    }
                    else
                    {
                        kill.TotalDeaths += 1;
                        AddDrop(kill, kill.TotalDeaths, clbDrops.CheckedItems[0].ToString(), clbPlayers.CheckedItems[0].ToString());
                        lastKill = kill.TotalDeaths;
                        _killsContext.Kills.ReplaceOne(filter, kill);
                        MessageBox.Show($"Kill {kill.TotalDeaths} adicionada no histórico.", "Sucesso");
                    }
                }
            }
            else
                MessageBox.Show("Nenhum método selecionado", "Erro");

        }

        private void clbDrops_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int ix = 0; ix < clbDrops.Items.Count; ++ix)
                if (ix != clbDrops.SelectedIndex) clbDrops.SetItemChecked(ix, false);
        }

        private void clbPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int ix = 0; ix < clbPlayers.Items.Count; ++ix)
                if (ix != clbPlayers.SelectedIndex) clbPlayers.SetItemChecked(ix, false);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabAtualizar"])
            {
                if (cbBossList.SelectedItem != null)
                {
                    cbBossList2.SelectedItem = cbBossList.SelectedItem.ToString();
                    var kill = _killsContext.Kills.Find(f => f.BossName == cbBossList2.SelectedItem.ToString()).FirstOrDefault();
                    if (kill.DropHistory.Any())
                    {
                        cbKillNumber.Items.Clear();
                        foreach (var item in kill.DropHistory)
                        {
                            cbKillNumber.Items.Add(item.KillNumber);
                        }
                    }
                    if (lastKill != 0 && cbKillNumber.Items.Contains(lastKill))
                    {
                        cbKillNumber.SelectedItem = lastKill;

                    }
                }
            }
        }

        private void cbKillNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbKillNumber.SelectedItem) != 0)
            {
                lblBossDrops2.Visible = true;
                lblPlayer2.Visible = true;
                clbDrops2.Visible = true;
                clbPlayers2.Visible = true;
                btnAtualizar.Visible = true;
                if (!string.IsNullOrEmpty(cbBossList2.SelectedItem.ToString()))
                {
                    var boss = _bossContext.Boss.Find(f => f.Name == cbBossList2.SelectedItem.ToString()).FirstOrDefault();
                    var players = _userContext.Usuario.Find(f => true).ToList();
                    clbDrops2.Items.Clear();
                    clbPlayers2.Items.Clear();

                    foreach (var item in boss.Drops)
                        clbDrops2.Items.Add(item.ItemName);

                    foreach (var item in players)
                        clbPlayers2.Items.Add(item.User);

                    lblBossDrops2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
                    clbDrops2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
                    lblPlayer2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
                    clbPlayers2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
                    btnAtualizar.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
                }
            }
            else
            {
                lblBossDrops2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
                clbDrops2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
                lblPlayer2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
                clbPlayers2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
                btnAtualizar.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
            }
        }

        private void cbBossList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKillNumber.Items.Clear();
            clbDrops2.Items.Clear();
            clbPlayers2.Items.Clear();
            lblBossDrops2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
            clbDrops2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
            lblPlayer2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
            clbPlayers2.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;
            btnAtualizar.Visible = Convert.ToInt32(cbKillNumber.SelectedItem) != 0;

            var kill = _killsContext.Kills.Find(f => f.BossName == cbBossList2.SelectedItem.ToString()).FirstOrDefault();
            if (kill != null && kill.DropHistory.Any())
            {
                foreach (var item in kill.DropHistory)
                {
                    cbKillNumber.Items.Add(item.KillNumber);
                }
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (cbBossList2.SelectedIndex == -1 || string.IsNullOrEmpty(cbBossList2.SelectedItem.ToString()))
                MessageBox.Show("Selecione um boss.", "Erro");
            else
            {
                var kill = _killsContext.Kills.Find(f => f.BossName == cbBossList2.SelectedItem.ToString()).FirstOrDefault();
                var number = kill.TotalDeaths;
                if (number <= 0)
                    MessageBox.Show("Contagem de kills está em 0.", "Erro");
                else
                {
                    if (kill.DropHistory.Any(f => f.KillNumber == kill.TotalDeaths))
                    {
                        var confirmResult = MessageBox.Show($"A última kill (número {kill.TotalDeaths}) possui drops cadastrados. Tem certeza que deseja removê-la da lista?", "Confirmação necessária", MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {
                            RemoveLastKill(kill);
                            if (cbKillNumber.Items.Contains(kill.TotalDeaths))
                            {
                                cbKillNumber.Items.Clear();
                                cbKillNumber.SelectedItem = 0;
                                foreach (var item in kill.DropHistory)
                                    cbKillNumber.Items.Add(item.KillNumber);
                            }
                            MessageBox.Show($"Kill {number} removida com sucesso.", "Sucesso");
                        }
                    }
                    else
                    {
                        var confirmResult = MessageBox.Show($"Tem certeza que deseja remover a kill {kill.TotalDeaths}?", "Confirmação necessária", MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {
                            RemoveLastKill(kill);
                            MessageBox.Show($"Kill {number} removida com sucesso.", "Sucesso");
                        }
                    }
                }
            }
        }

        private Kills RemoveLastKill(Kills kill)
        {
            if (kill.DropHistory.Any(f => f.KillNumber == kill.TotalDeaths))
            {
                kill.DropHistory.RemoveAll(f => f.KillNumber == kill.TotalDeaths);
            }

            kill.TotalDeaths -= 1;

            var filter = Builders<Kills>.Filter.Eq(f => f._id, kill._id);
            _killsContext.Kills.ReplaceOne(filter, kill);

            return kill;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            var qtdeDrops = clbDrops2.CheckedItems.Count;
            var qtdePlayers = clbPlayers2.CheckedItems.Count;
            if (Convert.ToInt32(cbKillNumber.SelectedItem) <= 0)
                MessageBox.Show("Selecione a kill que deseja adicionar o drop", "Erro");
            else if (qtdeDrops <= 0 || qtdePlayers <= 0)
                MessageBox.Show("Nenhum drop ou nenhum player selecionado", "Erro");
            else if (qtdeDrops < qtdePlayers)
                MessageBox.Show("Quantidade de drops menor que a quantidade de jogadores", "Erro");
            else if (qtdeDrops > qtdePlayers)
                MessageBox.Show("Quantidade de jogadores menor que a quantidade de drops", "Erro");
            else if (Convert.ToInt32(cbPlayerNumber.SelectedItem) <= 0)
                MessageBox.Show("Kills com drops precisam que seja informado a quantidade de jogadores do lobby", "Erro");
            else
            {
                var kill = _killsContext.Kills.Find(f => f.BossName == cbBossList2.SelectedItem.ToString()).FirstOrDefault();
                if (kill != null && kill.DropHistory.Any(f => f.KillNumber == Convert.ToInt32(cbKillNumber.SelectedItem)))
                {
                    AddDrop(kill, Convert.ToInt32(cbKillNumber.SelectedItem), clbDrops2.CheckedItems[0].ToString(), clbPlayers2.CheckedItems[0].ToString());
                    var filter = Builders<Kills>.Filter.Eq(f => f._id, kill._id);
                    _killsContext.Kills.ReplaceOne(filter, kill);
                    MessageBox.Show("Drop atualizado", "Sucesso");
                }
            }

        }

        private void clbDrops2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int ix = 0; ix < clbDrops2.Items.Count; ++ix)
                if (ix != clbDrops2.SelectedIndex) clbDrops2.SetItemChecked(ix, false);
        }

        private void clbPlayers2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int ix = 0; ix < clbPlayers2.Items.Count; ++ix)
                if (ix != clbPlayers2.SelectedIndex) clbPlayers2.SetItemChecked(ix, false);
        }

        private void cbBossList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblKillCount.Visible = cbBossList3.SelectedItem != null && !string.IsNullOrEmpty(cbBossList3.SelectedItem.ToString());
            lblDropCount.Visible = cbBossList3.SelectedItem != null && !string.IsNullOrEmpty(cbBossList3.SelectedItem.ToString());
            lblDiff.Visible = cbBossList3.SelectedItem != null && !string.IsNullOrEmpty(cbBossList3.SelectedItem.ToString());
            lblText.Visible = cbBossList3.SelectedItem != null && !string.IsNullOrEmpty(cbBossList3.SelectedItem.ToString());
            lblText2.Visible = cbBossList3.SelectedItem != null && !string.IsNullOrEmpty(cbBossList3.SelectedItem.ToString());
            lblDiffNumber.Visible = cbBossList3.SelectedItem != null && !string.IsNullOrEmpty(cbBossList3.SelectedItem.ToString());

            if (!string.IsNullOrEmpty(cbBossList3.SelectedItem.ToString()))
            {
                lvDropHistory.Items.Clear();
                lvDropHistory.Columns.Clear();
                var kills = _killsContext.Kills.Find(f => f.BossName == cbBossList3.SelectedItem.ToString()).FirstOrDefault();
                lblKillCount.Text = kills.TotalDeaths.ToString();
                lblDropCount.Text = kills.DropHistory.Count.ToString();
                lblDiffNumber.Text = kills.DropHistory.Any() ? (kills.TotalDeaths - kills.DropHistory.LastOrDefault().KillNumber).ToString() : kills.TotalDeaths.ToString();

                lvDropHistory.View = View.Details;
                lvDropHistory.LabelEdit = true;
                lvDropHistory.AllowColumnReorder = false;
                lvDropHistory.FullRowSelect = true;
                lvDropHistory.GridLines = true;

                //ListViewItem item1 = new ListViewItem("item1", 0);
                //// Place a check mark next to the item.
                //item1.SubItems.Add("1");
                //item1.SubItems.Add("2");
                //item1.SubItems.Add("3");
                //ListViewItem item2 = new ListViewItem("item2", 1);
                //item2.SubItems.Add("4");
                //item2.SubItems.Add("5");
                //item2.SubItems.Add("6");
                //ListViewItem item3 = new ListViewItem("item3", 0);
                //// Place a check mark next to the item.
                //item3.SubItems.Add("7");
                //item3.SubItems.Add("8");
                //item3.SubItems.Add("9");

                // Create columns for the items and subitems.
                // Width of -2 indicates auto-size.
                lvDropHistory.Columns.Add("Kill", -2, HorizontalAlignment.Center);
                lvDropHistory.Columns.Add("Players", -2, HorizontalAlignment.Center);
                lvDropHistory.Columns.Add("Drop", -2, HorizontalAlignment.Center);
                lvDropHistory.Columns.Add("Quem pegou", -2, HorizontalAlignment.Center);
                foreach (var kill in kills.DropHistory)
                {
                    foreach (var drop in kill.Drops)
                    {
                        ListViewItem list = new ListViewItem($"{kill.KillNumber}", 0);
                        list.SubItems.Add($"{kill.PlayersInLobby}");
                        list.SubItems.Add($"{drop.Item}");
                        list.SubItems.Add($"{drop.Player}");
                        lvDropHistory.Items.Add(list);
                    }
                }
                lvDropHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvDropHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                //Add the items to the ListView.
                //lvDropHistory.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
                //foreach (var item in kills.DropHistory)
                //{

                //}
            }
        }

        private void rbMultipleDrop_CheckedChanged(object sender, EventArgs e)
        {
            lblKillDrop.Visible = rbMultipleDrop.Checked;
            cbKillDrop.Visible = rbMultipleDrop.Checked;
        }

        private void cbBossList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listDrops.Visible = !string.IsNullOrEmpty(cbBossList4.SelectedItem.ToString());
            listStats.Visible = !string.IsNullOrEmpty(cbBossList4.SelectedItem.ToString());
            lblLobbySize.Visible = !string.IsNullOrEmpty(cbBossList4.SelectedItem.ToString());
            cbLobbySize.Visible = !string.IsNullOrEmpty(cbBossList4.SelectedItem.ToString());

            lblDiffNumberStatsText.Visible = !string.IsNullOrEmpty(cbBossList4.SelectedItem.ToString());
            lblDiffNumberStats.Visible = !string.IsNullOrEmpty(cbBossList4.SelectedItem.ToString());
            lblKillNumberStatsText.Visible = !string.IsNullOrEmpty(cbBossList4.SelectedItem.ToString());
            lblKillNumberStats.Visible = !string.IsNullOrEmpty(cbBossList4.SelectedItem.ToString());

            if (!string.IsNullOrEmpty(cbBossList4.SelectedItem.ToString()))
            {
                listDrops.Items.Clear();
                cbLobbySize.Items.Clear();
                var boss = _bossContext.Boss.Find(f => f.Name == cbBossList4.SelectedItem.ToString()).FirstOrDefault();
                var kills = _killsContext.Kills.Find(f => f.BossName == cbBossList4.SelectedItem.ToString()).FirstOrDefault();
                var diffNumber = kills.DropHistory.Any() ? (kills.TotalDeaths - kills.DropHistory.LastOrDefault().KillNumber) : kills.TotalDeaths;
                lblKillNumberStats.Text = kills.TotalDeaths.ToString();
                lblDiffNumberStats.Text = diffNumber.ToString();

                List<decimal> listPercentages = new List<decimal>();

                foreach (var item in boss.Drops)
                {
                    listPercentages.Add(item.DropPercent);
                    listDrops.Items.Add($"{item.ItemName}: {item.DropPercent}%");
                }
                int LongestItemLength = 0;
                for (int i = 0; i < listDrops.Items.Count; i++)
                {
                    Graphics g = listDrops.CreateGraphics();
                    int tempLength = Convert.ToInt32((
                            g.MeasureString(
                                    listDrops.Items[i].ToString(),
                                    this.listDrops.Font
                                )
                            ).Width);
                    if (tempLength > LongestItemLength)
                    {
                        LongestItemLength = tempLength;
                    }
                }
                listDrops.Width = LongestItemLength + 1;

                for (int i = 1; i <= (boss.Name == "Arcane Construct" ? 6 : 10); i++)
                {
                    cbLobbySize.Items.Add(i);
                }

                ProbabilityCount(listPercentages, diffNumber);
            }
        }

        private void cbLobbySize_SelectedIndexChanged(object sender, EventArgs e)
        {
            var players = Convert.ToInt32(cbLobbySize.SelectedItem);
            if (players > 0) 
            {
                listDrops.Items.Clear();
                var boss = _bossContext.Boss.Find(f => f.Name == cbBossList4.SelectedItem.ToString()).FirstOrDefault();
                var kills = _killsContext.Kills.Find(f => f.BossName == cbBossList4.SelectedItem.ToString()).FirstOrDefault();
                var diffNumber = kills.DropHistory.Any() ? (kills.TotalDeaths - kills.DropHistory.LastOrDefault().KillNumber) : kills.TotalDeaths;

                List<decimal> listPercentages = new List<decimal>();

                foreach (var item in boss.Drops)
                {
                    var percertToAdd = boss.Name == "Arcane Construct" ? 33 * (players <= 3 ? 0 : players - 3) : 20 * (players <= 5 ? 0 : players - 5);
                    decimal finalPercentage = item.DropPercent + ((item.DropPercent * percertToAdd) / 100);
                    listPercentages.Add(finalPercentage);
                    listDrops.Items.Add($"{item.ItemName}: {finalPercentage}%");
                }
                int LongestItemLength = 0;
                for (int i = 0; i < listDrops.Items.Count; i++)
                {
                    Graphics g = listDrops.CreateGraphics();
                    int tempLength = Convert.ToInt32((
                            g.MeasureString(
                                    listDrops.Items[i].ToString(),
                                    this.listDrops.Font
                                )
                            ).Width);
                    if (tempLength > LongestItemLength)
                    {
                        LongestItemLength = tempLength;
                    }
                }
                listDrops.Width = LongestItemLength + 1;

                ProbabilityCount(listPercentages, diffNumber);
            }
        }

        private void ProbabilityCount(List<decimal> chances, int diff)
        {
            listStats.Items.Clear();
            decimal chanceOfZeroDrops = 1;
            foreach (var chance in chances)
            {
                var chanceOfNot = (100 - chance) / 100;
                chanceOfZeroDrops = chanceOfZeroDrops * chanceOfNot;
            }
            double defaultChance = Double.Round((1 - Convert.ToDouble(chanceOfZeroDrops)) * 100, 2);
            listStats.Items.Add($"Chance de qualquer drop -> {defaultChance}% (Aprox. 1 a cada {Convert.ToInt32(1 / (defaultChance / 100))})");

            double chanceNoDropsAfterKills = Math.Pow(Convert.ToDouble(chanceOfZeroDrops), Convert.ToDouble(diff));
            double chanceAfterKills = Double.Round((1 - chanceNoDropsAfterKills) * 100, 2);
            listStats.Items.Add($"Chance de qualquer drop depois de {diff} kill(s) -> {((diff == 0 ? defaultChance : chanceAfterKills) > 100 ? 100 : (diff == 0 ? defaultChance : chanceAfterKills))}%");
            listStats.Items.Add($"(Considerando {(Convert.ToInt32(cbLobbySize.SelectedItem) <= 0 ? 1 : Convert.ToInt32(cbLobbySize.SelectedItem))} player(s) para todas as kills)");
            //listStats.Items.Add($"(Aprox. 1 a cada {Convert.ToInt32(1 / ((diff == 0 ? defaultChance : chanceAfterKills) / 100))})");
            listStats.Items.Add($"Está dentro da estatística/média de chances? -> {((diff == 0 ? defaultChance : chanceAfterKills) < 100 ? "Sim" : "Não (RIP sorte)")}");
            listStats.Items.Add("");
            listStats.Items.Add("OBS: A probabildade cumulativa é apenas ilustrativa. Chances");
            listStats.Items.Add("de drop independentes não permitem acumular probabilidade.");
        }
    }
}
