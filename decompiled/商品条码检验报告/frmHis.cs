namespace 商品条码检验报告
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmHis : Form
    {
        public frmHis()
        {
            this.InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime qsrq = Convert.ToDateTime(this.dtpqsJyrq.Value.ToShortDateString());
            DateTime jsrq = Convert.ToDateTime(this.dtpjsJyrq.Value.ToShortDateString());
            try
            {
                this.dataGridView1.DataSource = new Quatity().getHistoryTesting(qsrq, jsrq);
            }
            catch (Exception exception)
            {
                MessageBox.Show("获取历史数据异常" + exception.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnSearchbyname_Click(object sender, EventArgs e)
        {
            if (this.txtQymc.Text.Trim() == "")
            {
                MessageBox.Show("企业名称不能为空！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                try
                {
                    this.dataGridView1.DataSource = new Quatity().getHistoryTesting(this.txtQymc.Text.Trim());
                }
                catch (Exception exception)
                {
                    MessageBox.Show("获取历史数据异常" + exception.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }


        private void frmHis_Load(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.DataSource = new Quatity().getHistoryTesting();
            }
            catch (Exception exception)
            {
                MessageBox.Show("获取历史数据异常" + exception.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


    }
}

