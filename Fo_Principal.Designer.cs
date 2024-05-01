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
            txt_link = new TextBox();
            btn_download = new Button();
            Grid_musicas = new DataGridView();
            btn_addlist = new Button();
            btn_excluir = new Button();
            progressBar1 = new ProgressBar();
            cbx_playlist = new CheckBox();
            ID = new DataGridViewTextBoxColumn();
            Titulo = new DataGridViewTextBoxColumn();
            linkorId_video = new DataGridViewTextBoxColumn();
            Tempo = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)Grid_musicas).BeginInit();
            SuspendLayout();
            // 
            // txt_link
            // 
            txt_link.Location = new Point(12, 29);
            txt_link.Name = "txt_link";
            txt_link.Size = new Size(419, 23);
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
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Grid_musicas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Grid_musicas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_musicas.Columns.AddRange(new DataGridViewColumn[] { ID, Titulo, linkorId_video, Tempo });
            Grid_musicas.Location = new Point(12, 121);
            Grid_musicas.Name = "Grid_musicas";
            Grid_musicas.ReadOnly = true;
            Grid_musicas.RowTemplate.Height = 25;
            Grid_musicas.Size = new Size(793, 334);
            Grid_musicas.TabIndex = 2;
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
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 461);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(793, 23);
            progressBar1.TabIndex = 5;
            // 
            // cbx_playlist
            // 
            cbx_playlist.AutoSize = true;
            cbx_playlist.Location = new Point(448, 33);
            cbx_playlist.Name = "cbx_playlist";
            cbx_playlist.Size = new Size(136, 19);
            cbx_playlist.TabIndex = 6;
            cbx_playlist.Text = "É playlist do Youtube";
            cbx_playlist.UseVisualStyleBackColor = true;
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
            // Fo_Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 541);
            Controls.Add(cbx_playlist);
            Controls.Add(progressBar1);
            Controls.Add(btn_excluir);
            Controls.Add(btn_addlist);
            Controls.Add(Grid_musicas);
            Controls.Add(btn_download);
            Controls.Add(txt_link);
            Name = "Fo_Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
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
        private ProgressBar progressBar1;
        private CheckBox cbx_playlist;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Titulo;
        private DataGridViewTextBoxColumn linkorId_video;
        private DataGridViewTextBoxColumn Tempo;
    }
}
