namespace DemoLoterias {
    partial class frmDemoLoteria {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cmbSelecLoteria = new System.Windows.Forms.ComboBox();
            this.btnResultado = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConcurso = new System.Windows.Forms.TextBox();
            this.txtDataSorteio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbSelecLoteria
            // 
            this.cmbSelecLoteria.FormattingEnabled = true;
            this.cmbSelecLoteria.Items.AddRange(new object[] {
            "Quina",
            "Mega Sena",
            "Dupla Sena",
            "Lotomania",
            "Lotofácil",
            "Loteria Federal"});
            this.cmbSelecLoteria.Location = new System.Drawing.Point(12, 26);
            this.cmbSelecLoteria.Name = "cmbSelecLoteria";
            this.cmbSelecLoteria.Size = new System.Drawing.Size(316, 21);
            this.cmbSelecLoteria.TabIndex = 0;
            this.cmbSelecLoteria.Text = "Selecione a loteria desejada...";
            this.cmbSelecLoteria.SelectedValueChanged += new System.EventHandler(this.cmbSelecLoteria_SelectedValueChanged);
            // 
            // btnResultado
            // 
            this.btnResultado.Enabled = false;
            this.btnResultado.Location = new System.Drawing.Point(334, 26);
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.Size = new System.Drawing.Size(118, 23);
            this.btnResultado.TabIndex = 1;
            this.btnResultado.Text = "Obter Resultado";
            this.btnResultado.UseVisualStyleBackColor = true;
            this.btnResultado.Click += new System.EventHandler(this.btnResultado_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.Location = new System.Drawing.Point(15, 102);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(437, 184);
            this.txtResultado.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Concurso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data do Sorteio:";
            // 
            // txtConcurso
            // 
            this.txtConcurso.Location = new System.Drawing.Point(73, 55);
            this.txtConcurso.Name = "txtConcurso";
            this.txtConcurso.ReadOnly = true;
            this.txtConcurso.Size = new System.Drawing.Size(100, 20);
            this.txtConcurso.TabIndex = 5;
            // 
            // txtDataSorteio
            // 
            this.txtDataSorteio.Location = new System.Drawing.Point(293, 55);
            this.txtDataSorteio.Name = "txtDataSorteio";
            this.txtDataSorteio.ReadOnly = true;
            this.txtDataSorteio.Size = new System.Drawing.Size(100, 20);
            this.txtDataSorteio.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dezenas Sorteadas:";
            // 
            // frmDemoLoteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 298);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDataSorteio);
            this.Controls.Add(this.txtConcurso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.btnResultado);
            this.Controls.Add(this.cmbSelecLoteria);
            this.Name = "frmDemoLoteria";
            this.Text = "Demonstação de uso Loterias Caixa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSelecLoteria;
        private System.Windows.Forms.Button btnResultado;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConcurso;
        private System.Windows.Forms.TextBox txtDataSorteio;
        private System.Windows.Forms.Label label3;
    }
}

