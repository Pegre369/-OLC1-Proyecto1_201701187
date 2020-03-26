namespace Proyecto1_201701187
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadThompsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entrada = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AFN = new System.Windows.Forms.ComboBox();
            this.AFD = new System.Windows.Forms.ComboBox();
            this.Tabla = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1108, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 28);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 28);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 28);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadThompsonToolStripMenuItem,
            this.saveTokenToolStripMenuItem,
            this.saveErroresToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(67, 28);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // loadThompsonToolStripMenuItem
            // 
            this.loadThompsonToolStripMenuItem.Name = "loadThompsonToolStripMenuItem";
            this.loadThompsonToolStripMenuItem.Size = new System.Drawing.Size(209, 28);
            this.loadThompsonToolStripMenuItem.Text = "Load Thompson";
            this.loadThompsonToolStripMenuItem.Click += new System.EventHandler(this.loadThompsonToolStripMenuItem_Click);
            // 
            // saveTokenToolStripMenuItem
            // 
            this.saveTokenToolStripMenuItem.Name = "saveTokenToolStripMenuItem";
            this.saveTokenToolStripMenuItem.Size = new System.Drawing.Size(209, 28);
            this.saveTokenToolStripMenuItem.Text = "Save Token";
            this.saveTokenToolStripMenuItem.Click += new System.EventHandler(this.saveTokenToolStripMenuItem_Click);
            // 
            // saveErroresToolStripMenuItem
            // 
            this.saveErroresToolStripMenuItem.Name = "saveErroresToolStripMenuItem";
            this.saveErroresToolStripMenuItem.Size = new System.Drawing.Size(209, 28);
            this.saveErroresToolStripMenuItem.Text = "Save Errores";
            // 
            // entrada
            // 
            this.entrada.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entrada.Location = new System.Drawing.Point(30, 81);
            this.entrada.Name = "entrada";
            this.entrada.Size = new System.Drawing.Size(511, 441);
            this.entrada.TabIndex = 1;
            this.entrada.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input File";
            // 
            // AFN
            // 
            this.AFN.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AFN.FormattingEnabled = true;
            this.AFN.Location = new System.Drawing.Point(46, 575);
            this.AFN.Name = "AFN";
            this.AFN.Size = new System.Drawing.Size(191, 36);
            this.AFN.TabIndex = 4;
            this.AFN.SelectedIndexChanged += new System.EventHandler(this.AFN_SelectedIndexChanged);
            // 
            // AFD
            // 
            this.AFD.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AFD.FormattingEnabled = true;
            this.AFD.Location = new System.Drawing.Point(350, 575);
            this.AFD.Name = "AFD";
            this.AFD.Size = new System.Drawing.Size(191, 36);
            this.AFD.TabIndex = 5;
            this.AFD.SelectedIndexChanged += new System.EventHandler(this.AFD_SelectedIndexChanged);
            // 
            // Tabla
            // 
            this.Tabla.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tabla.FormattingEnabled = true;
            this.Tabla.Location = new System.Drawing.Point(689, 575);
            this.Tabla.Name = "Tabla";
            this.Tabla.Size = new System.Drawing.Size(191, 36);
            this.Tabla.TabIndex = 6;
            this.Tabla.SelectedIndexChanged += new System.EventHandler(this.Tabla_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 544);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "AFN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(345, 544);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "AFD";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(684, 544);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Table";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(560, 81);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(511, 441);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(555, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Console";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 636);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tabla);
            this.Controls.Add(this.AFD);
            this.Controls.Add(this.AFN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entrada);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadThompsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTokenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveErroresToolStripMenuItem;
        private System.Windows.Forms.RichTextBox entrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AFN;
        private System.Windows.Forms.ComboBox AFD;
        private System.Windows.Forms.ComboBox Tabla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
    }
}

