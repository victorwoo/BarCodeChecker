

namespace 商品条码检验报告
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Configuration;
    using System.Drawing;
    using System.Windows.Forms;

	public partial class frmPrint: Form
	{
        public frmPrint(BarcodeSample sample)
        {
            this.InitializeComponent();
            this.sample = sample;
        }

        private void btnDataSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "文本文件（*.txt）|*.txt";
            dialog.RestoreDirectory = false;
            dialog.FilterIndex = 1;
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
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel文件(*.xls)|*.xls";
            dialog.RestoreDirectory = false;
            dialog.FilterIndex = 0;
            dialog.FileName = this.sample.SerialNumber;
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

	    private void frmPrint_Load(object sender, EventArgs e)
	    {
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
                                reality.SizeOfZ = Math.Round((double)(double.Parse(htable[str].ToString()) * 0.001), 3, MidpointRounding.AwayFromZero).ToString("0.000");
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
                                technic.BarHeight = Convert.ToInt32(Math.Round((double)(double.Parse(htable[str].ToString()) * 22.85), 0, MidpointRounding.AwayFromZero));
                                technic.LeftBlank = Math.Round((double)(double.Parse(htable[str].ToString()) * 3.63), 1, MidpointRounding.AwayFromZero).ToString("0.0");
                                technic.RightBlank = Math.Round((double)(double.Parse(htable[str].ToString()) * 2.31), 1, MidpointRounding.AwayFromZero).ToString("0.0");
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
