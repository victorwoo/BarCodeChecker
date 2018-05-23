namespace 商品条码检验报告
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmHis : Form
    {
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtQymc;
        private DateTimePicker dtpjsJyrq;
        private Label label3;
        private DateTimePicker dtpqsJyrq;
        private Button btnSearchbyname;
        private Button btnSearch;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;

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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
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

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.groupBox2 = new GroupBox();
            this.dataGridView1 = new DataGridView();
            this.label1 = new Label();
            this.label2 = new Label();
            this.btnSearch = new Button();
            this.btnSearchbyname = new Button();
            this.dtpqsJyrq = new DateTimePicker();
            this.label3 = new Label();
            this.dtpjsJyrq = new DateTimePicker();
            this.txtQymc = new TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.txtQymc);
            this.groupBox1.Controls.Add(this.dtpjsJyrq);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpqsJyrq);
            this.groupBox1.Controls.Add(this.btnSearchbyname);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x343, 0x94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件设置";
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new Point(13, 0xa7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x343, 0x139);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据";
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(7, 0x15);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.Size = new Size(0x336, 0x11d);
            this.dataGridView1.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x11, 0x2a);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "按照检验日期查询：";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x13, 0x60);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "按照企业名称查询：";
            this.btnSearch.Location = new Point(0x2ab, 0x25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(0x4b, 0x17);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询(S)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
            this.btnSearchbyname.Location = new Point(0x2ab, 0x5b);
            this.btnSearchbyname.Name = "btnSearchbyname";
            this.btnSearchbyname.Size = new Size(0x4b, 0x17);
            this.btnSearchbyname.TabIndex = 3;
            this.btnSearchbyname.Text = "查询(S)";
            this.btnSearchbyname.UseVisualStyleBackColor = true;
            this.btnSearchbyname.Click += new EventHandler(this.btnSearchbyname_Click);
            this.dtpqsJyrq.Location = new Point(0x88, 0x26);
            this.dtpqsJyrq.Name = "dtpqsJyrq";
            this.dtpqsJyrq.Size = new Size(200, 0x15);
            this.dtpqsJyrq.TabIndex = 4;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x173, 0x2a);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x11, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "至";
            this.dtpjsJyrq.Location = new Point(420, 0x26);
            this.dtpjsJyrq.Name = "dtpjsJyrq";
            this.dtpjsJyrq.Size = new Size(200, 0x15);
            this.dtpjsJyrq.TabIndex = 6;
            this.txtQymc.Location = new Point(0x8a, 0x5d);
            this.txtQymc.Name = "txtQymc";
            this.txtQymc.Size = new Size(0x17d, 0x15);
            this.txtQymc.TabIndex = 7;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(860, 0x1e5);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.MaximizeBox = false;
            base.Name = "frmHis";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "历史检验数据";
            base.Load += new EventHandler(this.frmHis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }
    }
}

