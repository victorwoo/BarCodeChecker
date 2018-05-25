namespace 商品条码检验报告
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmMain : Form
    {
        private BarcodeSample sample = null;

        public frmMain()
        {
            this.InitializeComponent();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount > 0)
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    this.sample = this.setBarcodeSampleValue(this.dataGridView1);
                    frmPrint print = new frmPrint(this.sample);
                    print.Text = "检验数据——" + this.sample.SerialNumber;
                    print.ShowDialog();
                }
                else
                {
                    MessageBox.Show("未选中数据！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("没有数据！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDataImport_Click(object sender, EventArgs e)
        {
            try
            {
                string str = this.textBox1.Text.Trim();
                if ((str != null) && (str != ""))
                {
                    this.dataGridView1.DataSource = DataReadHelper.ExcelRead(this.textBox1.Text.Trim());
                }
                else
                {
                    MessageBox.Show("未选择厂商信息文件", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("数据文件有问题" + exception.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel文件(*.xls,*.xlsx)|*.xls;*.xlsx";
            dialog.RestoreDirectory = false;
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = dialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmHis().ShowDialog();
        }

       protected BarcodeSample setBarcodeSampleValue(DataGridView dgv)
        {
            this.sample = new BarcodeSample();
            if ((dgv.RowCount > 0) && (dgv.SelectedRows.Count > 0))
            {
                this.sample.SerialNumber = dgv.SelectedRows[0].Cells[1].Value.ToString();
                this.sample.BarCodeNumber = dgv.SelectedRows[0].Cells[2].Value.ToString();
                this.sample.SampleName = dgv.SelectedRows[0].Cells[3].Value.ToString();
                this.sample.PrintFormat = dgv.SelectedRows[0].Cells[4].Value.ToString();
                this.sample.BarcodeType = dgv.SelectedRows[0].Cells[5].Value.ToString();
                this.sample.CustomerName = dgv.SelectedRows[0].Cells[6].Value.ToString();
                this.sample.CustomerContactPersoner = dgv.SelectedRows[0].Cells[7].Value.ToString();
                this.sample.CustomerContactNumber = dgv.SelectedRows[0].Cells[8].Value.ToString();
                this.sample.CustomerContactAddress = dgv.SelectedRows[0].Cells[9].Value.ToString();
                this.sample.BussinessType = dgv.SelectedRows[0].Cells[10].Value.ToString();
                this.sample.RegisterPoint = dgv.SelectedRows[0].Cells[11].Value.ToString();
            }
            return this.sample;
        }
    }
}

