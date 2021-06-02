
namespace WordMeaning
{
    partial class Form2
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
            this.WordLBL = new System.Windows.Forms.Label();
            this.ScoreLBL = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LevelLBL = new System.Windows.Forms.Label();
            this.AnswerBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WordLBL
            // 
            this.WordLBL.AutoSize = true;
            this.WordLBL.Location = new System.Drawing.Point(13, 31);
            this.WordLBL.Name = "WordLBL";
            this.WordLBL.Size = new System.Drawing.Size(41, 13);
            this.WordLBL.TabIndex = 0;
            this.WordLBL.Text = "Kelime:";
            // 
            // ScoreLBL
            // 
            this.ScoreLBL.AutoSize = true;
            this.ScoreLBL.Location = new System.Drawing.Point(118, 50);
            this.ScoreLBL.Name = "ScoreLBL";
            this.ScoreLBL.Size = new System.Drawing.Size(32, 13);
            this.ScoreLBL.TabIndex = 1;
            this.ScoreLBL.Text = "Skor:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // LevelLBL
            // 
            this.LevelLBL.AutoSize = true;
            this.LevelLBL.Location = new System.Drawing.Point(12, 9);
            this.LevelLBL.Name = "LevelLBL";
            this.LevelLBL.Size = new System.Drawing.Size(42, 13);
            this.LevelLBL.TabIndex = 3;
            this.LevelLBL.Text = "Seviye:";
            // 
            // AnswerBTN
            // 
            this.AnswerBTN.Location = new System.Drawing.Point(12, 73);
            this.AnswerBTN.Name = "AnswerBTN";
            this.AnswerBTN.Size = new System.Drawing.Size(100, 23);
            this.AnswerBTN.TabIndex = 4;
            this.AnswerBTN.Text = "Cevapla";
            this.AnswerBTN.UseVisualStyleBackColor = true;
            this.AnswerBTN.Click += new System.EventHandler(this.AnswerBTN_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 108);
            this.Controls.Add(this.AnswerBTN);
            this.Controls.Add(this.LevelLBL);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ScoreLBL);
            this.Controls.Add(this.WordLBL);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WordLBL;
        private System.Windows.Forms.Label ScoreLBL;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label LevelLBL;
        private System.Windows.Forms.Button AnswerBTN;
    }
}