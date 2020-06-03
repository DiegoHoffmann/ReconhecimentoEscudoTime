namespace ReconhecimentoEscudoTime
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoxCam = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTempo = new System.Windows.Forms.TextBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.picBoxCaptura = new System.Windows.Forms.PictureBox();
            this.btnTreinar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTreino = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCaptura)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxCam
            // 
            this.picBoxCam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoxCam.Location = new System.Drawing.Point(12, 7);
            this.picBoxCam.Name = "picBoxCam";
            this.picBoxCam.Size = new System.Drawing.Size(400, 300);
            this.picBoxCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxCam.TabIndex = 0;
            this.picBoxCam.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(463, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time identificado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(551, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tempo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 373);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Score";
            // 
            // txtTempo
            // 
            this.txtTempo.Location = new System.Drawing.Point(597, 400);
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.Size = new System.Drawing.Size(25, 20);
            this.txtTempo.TabIndex = 6;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(597, 366);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(48, 20);
            this.txtScore.TabIndex = 7;
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(312, 257);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(83, 37);
            this.btnCarregar.TabIndex = 10;
            this.btnCarregar.Text = "Carregar";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // picBoxCaptura
            // 
            this.picBoxCaptura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoxCaptura.Location = new System.Drawing.Point(467, 7);
            this.picBoxCaptura.Name = "picBoxCaptura";
            this.picBoxCaptura.Size = new System.Drawing.Size(400, 300);
            this.picBoxCaptura.TabIndex = 11;
            this.picBoxCaptura.TabStop = false;
            // 
            // btnTreinar
            // 
            this.btnTreinar.Location = new System.Drawing.Point(6, 23);
            this.btnTreinar.Name = "btnTreinar";
            this.btnTreinar.Size = new System.Drawing.Size(107, 25);
            this.btnTreinar.TabIndex = 12;
            this.btnTreinar.Text = "Treinar";
            this.btnTreinar.UseVisualStyleBackColor = true;
            this.btnTreinar.Click += new System.EventHandler(this.btnTreinar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTreino);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.btnTreinar);
            this.groupBox1.Location = new System.Drawing.Point(12, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 172);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Treinamento";
            // 
            // txtTreino
            // 
            this.txtTreino.Location = new System.Drawing.Point(6, 54);
            this.txtTreino.Multiline = true;
            this.txtTreino.Name = "txtTreino";
            this.txtTreino.Size = new System.Drawing.Size(388, 112);
            this.txtTreino.TabIndex = 18;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(119, 23);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(275, 25);
            this.progressBar.TabIndex = 13;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(597, 322);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(232, 26);
            this.txtTime.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(628, 407);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Segundos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 512);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picBoxCaptura);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtTempo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxCam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Escudo Time";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCaptura)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxCam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTempo;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.PictureBox picBoxCaptura;
        private System.Windows.Forms.Button btnTreinar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtTreino;
        private System.Windows.Forms.Label label4;
    }
}

