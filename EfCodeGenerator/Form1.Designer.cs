namespace EfCodeGenerator
{
    partial class Form1
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
            txtEntity = new TextBox();
            label1 = new Label();
            txtPath = new TextBox();
            label3 = new Label();
            button1 = new Button();
            btnGenerate = new Button();
            label2 = new Label();
            txtContext = new TextBox();
            splitter1 = new Splitter();
            btnFromFile = new Button();
            SuspendLayout();
            // 
            // txtEntity
            // 
            txtEntity.Location = new Point(12, 103);
            txtEntity.Name = "txtEntity";
            txtEntity.Size = new Size(453, 27);
            txtEntity.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 80);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 1;
            label1.Text = "Entity Adı";
            // 
            // txtPath
            // 
            txtPath.Enabled = false;
            txtPath.Location = new Point(12, 35);
            txtPath.Name = "txtPath";
            txtPath.ReadOnly = true;
            txtPath.Size = new Size(411, 27);
            txtPath.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 12);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 4;
            label3.Text = "Path";
            // 
            // button1
            // 
            button1.Location = new Point(429, 33);
            button1.Name = "button1";
            button1.Size = new Size(36, 29);
            button1.TabIndex = 5;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Enabled = false;
            btnGenerate.Location = new Point(98, 214);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(259, 72);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Oluştur";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 142);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 8;
            label2.Text = "Context Adı";
            // 
            // txtContext
            // 
            txtContext.Location = new Point(12, 165);
            txtContext.Name = "txtContext";
            txtContext.Size = new Size(453, 27);
            txtContext.TabIndex = 7;
            txtContext.TextChanged += txtContext_TextChanged;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(4, 403);
            splitter1.TabIndex = 9;
            splitter1.TabStop = false;
            // 
            // btnFromFile
            // 
            btnFromFile.BackColor = SystemColors.ActiveCaption;
            btnFromFile.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnFromFile.ForeColor = SystemColors.ActiveCaptionText;
            btnFromFile.Location = new Point(10, 319);
            btnFromFile.Name = "btnFromFile";
            btnFromFile.Size = new Size(455, 72);
            btnFromFile.TabIndex = 10;
            btnFromFile.TabStop = false;
            btnFromFile.Text = "Otomatik entity çek ve olustur";
            btnFromFile.UseVisualStyleBackColor = false;
            btnFromFile.Click += txtFromFile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 403);
            Controls.Add(btnFromFile);
            Controls.Add(splitter1);
            Controls.Add(label2);
            Controls.Add(txtContext);
            Controls.Add(btnGenerate);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(txtPath);
            Controls.Add(label1);
            Controls.Add(txtEntity);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEntity;
        private Label label1;
        private TextBox txtPath;
        private Label label3;
        private Button button1;
        private Button btnGenerate;
        private Label label2;
        private TextBox txtContext;
        private Splitter splitter1;
        private Button btnFromFile;
    }
}