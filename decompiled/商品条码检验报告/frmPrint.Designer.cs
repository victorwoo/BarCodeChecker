namespace 商品条码检验报告
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Configuration;
    using System.Drawing;
    using System.Windows.Forms;

	partial class frmPrint
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
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.btnDataSelect = new Button();
            this.btnSave = new Button();
            this.groupBox1 = new GroupBox();
            this.txtRRight = new TextBox();
            this.txtRLeft = new TextBox();
            this.txtRHeight = new TextBox();
            this.label5 = new Label();
            this.label4 = new Label();
            this.label3 = new Label();
            this.openFileDialog1 = new OpenFileDialog();
            this.btnPrint = new Button();
            this.saveFileDialog1 = new SaveFileDialog();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x20, 0x31);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "检测数据文件：";
            this.textBox1.Location = new Point(0x7f, 0x2e);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(390, 0x15);
            this.textBox1.TabIndex = 1;
            this.btnDataSelect.Location = new Point(0x225, 0x2e);
            this.btnDataSelect.Name = "btnDataSelect";
            this.btnDataSelect.Size = new Size(0x58, 0x17);
            this.btnDataSelect.TabIndex = 2;
            this.btnDataSelect.Text = "选择文件(S)";
            this.btnDataSelect.UseVisualStyleBackColor = true;
            this.btnDataSelect.Click += new EventHandler(this.btnDataSelect_Click);
            this.btnSave.Location = new Point(0x67, 0x13c);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x76, 0x21);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "生成报告并保存(S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.groupBox1.Controls.Add(this.txtRRight);
            this.groupBox1.Controls.Add(this.txtRLeft);
            this.groupBox1.Controls.Add(this.txtRHeight);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new Point(12, 0x5f);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(650, 0xc6);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "其他检验数据项";
            this.txtRRight.Location = new Point(0x188, 0x8f);
            this.txtRRight.Name = "txtRRight";
            this.txtRRight.Size = new Size(0xc9, 0x15);
            this.txtRRight.TabIndex = 7;
            this.txtRLeft.Location = new Point(0x73, 0x8f);
            this.txtRLeft.Name = "txtRLeft";
            this.txtRLeft.Size = new Size(0x95, 0x15);
            this.txtRLeft.TabIndex = 6;
            this.txtRHeight.Location = new Point(0x73, 0x35);
            this.txtRHeight.Name = "txtRHeight";
            this.txtRHeight.Size = new Size(0x95, 0x15);
            this.txtRHeight.TabIndex = 5;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x135, 0x92);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x4d, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "右侧空白区：";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x20, 0x92);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x4d, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "左侧空白区：";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x38, 0x38);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x35, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "条  高：";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new Point(0x1a7, 0x13c);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x7a, 0x21);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "生成报告并打印(P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x2a2, 0x173);
            base.Controls.Add(this.btnPrint);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.btnDataSelect);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.Name = "frmPrintA";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmPrint";
            base.Load += new EventHandler(this.frmPrint_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

		#endregion

	    private Label label1;
	    private TextBox textBox1;
	    private Button btnDataSelect;
	    private Button btnSave;
	    private GroupBox groupBox1;
	    private OpenFileDialog openFileDialog1;
	    private Button btnPrint;
	    private SaveFileDialog saveFileDialog1;
	    private TextBox txtRRight;
	    private TextBox txtRLeft;
	    private TextBox txtRHeight;
	    private Label label5;
	    private Label label4;
	    private Label label3;
	    private BarcodeSample sample = null;
	    private TestResult reality = null;
	    private TestResult technic = null;
	}
}