namespace 商品条码检验报告
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmMain : Form
    {
        private BarcodeSample sample = null;
        private IContainer components = null;
        private Button btnFileSelect;
        private Button btnDataImport;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
        private OpenFileDialog openFileDialog1;
        private Button btnBuild;
        private GroupBox groupBox1;
        private Button button1;

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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnFileSelect = new Button();
            this.btnDataImport = new Button();
            this.dataGridView1 = new DataGridView();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.openFileDialog1 = new OpenFileDialog();
            this.btnBuild = new Button();
            this.groupBox1 = new GroupBox();
            this.button1 = new Button();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.btnFileSelect.Location = new Point(0x256, 0x19);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new Size(0x5f, 0x1c);
            this.btnFileSelect.TabIndex = 0;
            this.btnFileSelect.Text = "选择文件(S)";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new EventHandler(this.btnFileSelect_Click);
            this.btnDataImport.Location = new Point(750, 110);
            this.btnDataImport.Name = "btnDataImport";
            this.btnDataImport.Size = new Size(0x76, 0x20);
            this.btnDataImport.TabIndex = 2;
            this.btnDataImport.Text = "导入厂商信息(I)";
            this.btnDataImport.UseVisualStyleBackColor = true;
            this.btnDataImport.Click += new EventHandler(this.btnDataImport_Click);
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.Size = new Size(0x2b9, 0x124);
            this.dataGridView1.TabIndex = 3;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 0x21);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x71, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "送检厂商信息目录：";
            this.textBox1.Location = new Point(0x83, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x1a9, 0x15);
            this.textBox1.TabIndex = 5;
            this.openFileDialog1.FileName = "openFileDialog1";
            this.btnBuild.Location = new Point(750, 0xd8);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new Size(0x76, 0x23);
            this.btnBuild.TabIndex = 6;
            this.btnBuild.Text = "生成检验数据(B)";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new EventHandler(this.btnBuild_Click);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new Point(14, 0x4c);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x2c5, 0x13f);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "送检厂商信息";
            this.button1.Location = new Point(750, 0x13b);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x76, 0x21);
            this.button1.TabIndex = 9;
            this.button1.Text = "历史检验数据(H)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x37c, 400);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.btnBuild);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.btnDataImport);
            base.Controls.Add(this.btnFileSelect);
            base.MaximizeBox = false;
            base.Name = "frmMain";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "商品条码符号检验数据";
            ((ISupportInitialize) this.dataGridView1).EndInit();
            this.groupBox1.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
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

