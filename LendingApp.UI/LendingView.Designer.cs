
namespace LendingApp.UI
{
    partial class LendingView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.AddLoanBtn = new System.Windows.Forms.Button();
            this.ProcessLoansBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asset Value:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(97, 10);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 3;
            // 
            // AddLoanBtn
            // 
            this.AddLoanBtn.Location = new System.Drawing.Point(13, 97);
            this.AddLoanBtn.Name = "AddLoanBtn";
            this.AddLoanBtn.Size = new System.Drawing.Size(75, 23);
            this.AddLoanBtn.TabIndex = 4;
            this.AddLoanBtn.Text = "Add";
            this.AddLoanBtn.UseVisualStyleBackColor = true;
            this.AddLoanBtn.Click += new System.EventHandler(this.AddLoanBtn_Click);
            // 
            // ProcessLoansBtn
            // 
            this.ProcessLoansBtn.Location = new System.Drawing.Point(13, 158);
            this.ProcessLoansBtn.Name = "ProcessLoansBtn";
            this.ProcessLoansBtn.Size = new System.Drawing.Size(151, 23);
            this.ProcessLoansBtn.TabIndex = 5;
            this.ProcessLoansBtn.Text = "Process Loans";
            this.ProcessLoansBtn.UseVisualStyleBackColor = true;
            this.ProcessLoansBtn.Click += new System.EventHandler(this.ProcessLoansBtn_Click);
            // 
            // LendingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProcessLoansBtn);
            this.Controls.Add(this.AddLoanBtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LendingView";
            this.Text = "LendingApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button AddLoanBtn;
        private System.Windows.Forms.Button ProcessLoansBtn;
    }
}

