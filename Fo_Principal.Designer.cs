namespace Youtube.Video.Downloader
{
    partial class Fo_Principal
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fo_Principal));
            txt_link = new TextBox();
            btn_download = new Button();
            Grid_musicas = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Titulo = new DataGridViewTextBoxColumn();
            linkorId_video = new DataGridViewTextBoxColumn();
            Tempo = new DataGridViewTextBoxColumn();
            btn_addlist = new Button();
            btn_excluir = new Button();
            Pbar = new ProgressBar();
            cbx_playlist = new CheckBox();
            cbx_host = new ComboBox();
            cbx_chave = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)Grid_musicas).BeginInit();
            SuspendLayout();
            // 
            // txt_link
            // 
            txt_link.Location = new Point(12, 4);
            txt_link.Name = "txt_link";
            txt_link.Size = new Size(657, 23);
            txt_link.TabIndex = 0;
            // 
            // btn_download
            // 
            btn_download.Location = new Point(12, 493);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(793, 38);
            btn_download.TabIndex = 1;
            btn_download.Text = "Download";
            btn_download.UseVisualStyleBackColor = true;
            btn_download.Click += Btn_download_Click;
            // 
            // Grid_musicas
            // 
            Grid_musicas.AllowUserToAddRows = false;
            Grid_musicas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Grid_musicas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Grid_musicas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_musicas.Columns.AddRange(new DataGridViewColumn[] { ID, Titulo, linkorId_video, Tempo });
            Grid_musicas.Location = new Point(12, 121);
            Grid_musicas.MultiSelect = false;
            Grid_musicas.Name = "Grid_musicas";
            Grid_musicas.ReadOnly = true;
            Grid_musicas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_musicas.Size = new Size(793, 334);
            Grid_musicas.TabIndex = 2;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 40;
            // 
            // Titulo
            // 
            Titulo.HeaderText = "Título Música";
            Titulo.Name = "Titulo";
            Titulo.ReadOnly = true;
            Titulo.Width = 550;
            // 
            // linkorId_video
            // 
            linkorId_video.HeaderText = "id_video";
            linkorId_video.Name = "linkorId_video";
            linkorId_video.ReadOnly = true;
            linkorId_video.Visible = false;
            // 
            // Tempo
            // 
            Tempo.HeaderText = "Tempo";
            Tempo.Name = "Tempo";
            Tempo.ReadOnly = true;
            Tempo.Width = 160;
            // 
            // btn_addlist
            // 
            btn_addlist.Location = new Point(12, 67);
            btn_addlist.Name = "btn_addlist";
            btn_addlist.Size = new Size(419, 35);
            btn_addlist.TabIndex = 3;
            btn_addlist.Text = "Adicionar a Lista";
            btn_addlist.UseVisualStyleBackColor = true;
            btn_addlist.Click += btn_addlist_Click;
            // 
            // btn_excluir
            // 
            btn_excluir.Location = new Point(437, 67);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(368, 35);
            btn_excluir.TabIndex = 4;
            btn_excluir.Text = "Excluir da Lista";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            // 
            // Pbar
            // 
            Pbar.Location = new Point(12, 461);
            Pbar.Name = "Pbar";
            Pbar.Size = new Size(793, 23);
            Pbar.TabIndex = 5;
            // 
            // cbx_playlist
            // 
            cbx_playlist.AutoSize = true;
            cbx_playlist.Location = new Point(675, 4);
            cbx_playlist.Name = "cbx_playlist";
            cbx_playlist.Size = new Size(127, 19);
            cbx_playlist.TabIndex = 6;
            cbx_playlist.Text = "Playlist do Youtube";
            cbx_playlist.UseVisualStyleBackColor = true;
            // 
            // cbx_host
            // 
            cbx_host.FormattingEnabled = true;
            cbx_host.Items.AddRange(new object[] { "1 - youtube-mp3-downloader2.p.rapidapi.com", "2 - youtube-mp3-downloader1.p.rapidapi.com" });
            cbx_host.Location = new Point(469, 33);
            cbx_host.Name = "cbx_host";
            cbx_host.Size = new Size(200, 23);
            cbx_host.TabIndex = 7;
            // 
            // cbx_chave
            // 
            cbx_chave.FormattingEnabled = true;
            cbx_chave.Items.AddRange(new object[] { "1 - 1a0890980fmsh42c4db24ee5c99dp187015jsned15423ee5e2", "2 - 753851eb6dmsh0048fc19d4dbf58p1e9208jsnef0b7965d6f6", "3 - 4f84ec793amshcca1ecf872ad7f4p184291jsn3d3ee1b0cb1d" });
            cbx_chave.Location = new Point(82, 33);
            cbx_chave.Name = "cbx_chave";
            cbx_chave.Size = new Size(200, 23);
            cbx_chave.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 41);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(64, 15);
            label1.TabIndex = 9;
            label1.Text = "Chave API:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(407, 41);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(56, 15);
            label2.TabIndex = 10;
            label2.Text = "Host API:";
            // 
            // Fo_Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 541);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbx_chave);
            Controls.Add(cbx_host);
            Controls.Add(cbx_playlist);
            Controls.Add(Pbar);
            Controls.Add(btn_excluir);
            Controls.Add(btn_addlist);
            Controls.Add(Grid_musicas);
            Controls.Add(btn_download);
            Controls.Add(txt_link);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Fo_Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Youtube Mp3 Dowloader";
            ((System.ComponentModel.ISupportInitialize)Grid_musicas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_link;
        private Button btn_download;
        private DataGridView Grid_musicas;
        private Button btn_addlist;
        private Button btn_excluir;
        private ProgressBar Pbar;
        private CheckBox cbx_playlist;
        private ComboBox cbx_host;
        private ComboBox cbx_chave;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Titulo;
        private DataGridViewTextBoxColumn linkorId_video;
        private DataGridViewTextBoxColumn Tempo;
    }
}
