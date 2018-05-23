namespace 商品条码检验报告
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Configuration;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmPrint : Form
    {
        private IContainer components = null;
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

        public frmPrint(BarcodeSample sample)
        {
            this.InitializeComponent();
            this.sample = sample;
        }

        private void btnDataSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "文本文件（*.txt）|*.txt",
                RestoreDirectory = false,
                FilterIndex = 1
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = dialog.FileName;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.technic = new TestResult();
            this.reality = new TestResult();
            this.setTestValue(DataReadHelper.TextRead(this.textBox1.Text.Trim()), this.technic, this.reality);
            PrintHelper.Print(PrintType.PrintView, this.sample, this.technic, this.reality);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Exception exception;
            this.technic = new TestResult();
            this.reality = new TestResult();
            this.technic.DecodingData = this.sample.BarCodeNumber;
            try
            {
                this.technic.SymbolLevel = ConfigurationManager.AppSettings["jsfhdj"];
                this.technic.SizeOfZ = ConfigurationManager.AppSettings["jszcc"];
                this.technic.IsValidBarcode = ConfigurationManager.AppSettings["jscsdmyxx"];
            }
            catch (Exception exception1)
            {
                exception = exception1;
                MessageBox.Show("配置文件有误！" + exception.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.txtRHeight.Text.Trim() != "")
            {
                this.reality.BarHeight = Convert.ToInt32(this.txtRHeight.Text.Trim());
            }
            else
            {
                MessageBox.Show("条高不能为空！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.txtRLeft.Text.Trim() != "")
            {
                this.reality.LeftBlank = this.txtRLeft.Text.Trim();
            }
            else
            {
                MessageBox.Show("左侧空白区不能为空！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.txtRRight.Text.Trim() != "")
            {
                this.reality.RightBlank = this.txtRRight.Text.Trim();
            }
            else
            {
                MessageBox.Show("右侧空白区不能为空！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog {
                Filter = "Excel文件(*.xls)|*.xls",
                RestoreDirectory = false,
                FilterIndex = 0,
                FileName = this.sample.SerialNumber
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string templateFile = Application.StartupPath + ConfigurationManager.AppSettings["template"];
                    this.setTestValue(DataReadHelper.TextRead(this.textBox1.Text.Trim()), this.technic, this.reality);
                    this.reality.IsValidBarcode = this.technic.DecodingData.Equals(this.reality.DecodingData) ? "有效" : "无效";
                    if (PrintHelper.Save(this.sample, this.technic, this.reality, dialog.FileName, templateFile))
                    {
                        MessageBox.Show("检测数据生成成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        try
                        {
                            new Quatity().insertTestingData(this.sample, this.technic, this.reality);
                        }
                        catch (Exception exception2)
                        {
                            exception = exception2;
                            MessageBox.Show(exception.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        base.Close();
                    }
                    else
                    {
                        MessageBox.Show("检测数据生成失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception exception3)
                {
                    exception = exception3;
                    MessageBox.Show("生成数据异常！" + exception.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        public void BuildReport(string fileName)
        {
            this.technic = new TestResult();
            this.reality = new TestResult();
            string templateFile = Application.StartupPath + ConfigurationManager.AppSettings["template"];
            this.setTestValue(DataReadHelper.TextRead(this.textBox1.Text.Trim()), this.technic, this.reality);
            if (PrintHelper.Save(this.sample, this.technic, this.reality, fileName, templateFile))
            {
                MessageBox.Show("检测数据生成成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("检测数据生成失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
        }

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
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2a2, 0x173);
            base.Controls.Add(this.btnPrint);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.btnDataSelect);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.Name = "frmPrint";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmPrint";
            base.Load += new EventHandler(this.frmPrint_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void setTestValue(Hashtable htable, TestResult technic, TestResult reality)
        {
            if (htable == null)
            {
                throw new Exception("没找到厂商信息！");
            }
            try
            {
                foreach (string str in htable.Keys)
                {
                    switch (str)
                    {
                        case "标识数据译码":
                            reality.DecodingData = htable[str].ToString();
                            break;

                        case "扫描反射率曲线等级":
                            reality.SymbolLevel = htable[str].ToString();
                            break;

                        case "模块宽度Z(um)":
                            if (!htable[str].Equals(""))
                            {
                                reality.SizeOfZ = Math.Round((double) (double.Parse(htable[str].ToString()) * 0.001), 3, MidpointRounding.AwayFromZero).ToString("0.000");
                            }
                            break;

                        case "检测日期":
                            reality.TestDate = Convert.ToDateTime(htable[str].ToString());
                            break;

                        case "符号类型":
                            reality.BarcodeType = htable[str].ToString();
                            break;

                        case "放大比":
                            if (!htable[str].Equals(""))
                            {
                                technic.BarHeight = Convert.ToInt32(Math.Round((double) (double.Parse(htable[str].ToString()) * 22.85), 0, MidpointRounding.AwayFromZero));
                                technic.LeftBlank = Math.Round((double) (double.Parse(htable[str].ToString()) * 3.63), 1, MidpointRounding.AwayFromZero).ToString("0.0");
                                technic.RightBlank = Math.Round((double) (double.Parse(htable[str].ToString()) * 2.31), 1, MidpointRounding.AwayFromZero).ToString("0.0");
                            }
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static double strTodouble(string str)
        {
            string s = "";
            foreach (char ch in str)
            {
                if ((ch >= '0') && (ch <= ':'))
                {
                    s = s + ch;
                }
            }
            return double.Parse(s);
        }
    }
}

