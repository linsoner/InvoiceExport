namespace BaiwangExport
{
    partial class FormCredence
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblTaxNumber = new System.Windows.Forms.Label();
            this.cboGroupBy = new System.Windows.Forms.ComboBox();
            this.lblGroupBy = new System.Windows.Forms.Label();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboIncomeSubject = new System.Windows.Forms.ComboBox();
            this.cboTaxSSubject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBiller = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dteCredDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCredType = new System.Windows.Forms.ComboBox();
            this.lblCredType = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fenluno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rawdebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rawcredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brief = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subID_D_Name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.subID_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.splitContainer1);
            this.mainPanel.Size = new System.Drawing.Size(1264, 610);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblTaxNumber);
            this.splitContainer1.Panel1.Controls.Add(this.cboGroupBy);
            this.splitContainer1.Panel1.Controls.Add(this.lblGroupBy);
            this.splitContainer1.Panel1.Controls.Add(this.cboAccount);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.cboIncomeSubject);
            this.splitContainer1.Panel1.Controls.Add(this.cboTaxSSubject);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.cboBiller);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dteCredDate);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cboCredType);
            this.splitContainer1.Panel1.Controls.Add(this.lblCredType);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 610);
            this.splitContainer1.SplitterDistance = 120;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblTaxNumber
            // 
            this.lblTaxNumber.AutoSize = true;
            this.lblTaxNumber.Location = new System.Drawing.Point(480, 13);
            this.lblTaxNumber.Name = "lblTaxNumber";
            this.lblTaxNumber.Size = new System.Drawing.Size(29, 12);
            this.lblTaxNumber.TabIndex = 32;
            this.lblTaxNumber.Text = "税号";
            this.lblTaxNumber.Visible = false;
            // 
            // cboGroupBy
            // 
            this.cboGroupBy.FormattingEnabled = true;
            this.cboGroupBy.Items.AddRange(new object[] {
            "按购货单位合并",
            "按购货单位和期别合并"});
            this.cboGroupBy.Location = new System.Drawing.Point(597, 34);
            this.cboGroupBy.Name = "cboGroupBy";
            this.cboGroupBy.Size = new System.Drawing.Size(150, 20);
            this.cboGroupBy.TabIndex = 31;
            // 
            // lblGroupBy
            // 
            this.lblGroupBy.AutoSize = true;
            this.lblGroupBy.Location = new System.Drawing.Point(540, 38);
            this.lblGroupBy.Name = "lblGroupBy";
            this.lblGroupBy.Size = new System.Drawing.Size(53, 12);
            this.lblGroupBy.TabIndex = 30;
            this.lblGroupBy.Text = "合并方式";
            // 
            // cboAccount
            // 
            this.cboAccount.FormattingEnabled = true;
            this.cboAccount.Location = new System.Drawing.Point(126, 9);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(348, 20);
            this.cboAccount.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "转入账套";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "主营业务收入科目";
            // 
            // cboIncomeSubject
            // 
            this.cboIncomeSubject.FormattingEnabled = true;
            this.cboIncomeSubject.Location = new System.Drawing.Point(125, 85);
            this.cboIncomeSubject.Name = "cboIncomeSubject";
            this.cboIncomeSubject.Size = new System.Drawing.Size(349, 20);
            this.cboIncomeSubject.TabIndex = 24;
            // 
            // cboTaxSSubject
            // 
            this.cboTaxSSubject.FormattingEnabled = true;
            this.cboTaxSSubject.Location = new System.Drawing.Point(125, 59);
            this.cboTaxSSubject.Name = "cboTaxSSubject";
            this.cboTaxSSubject.Size = new System.Drawing.Size(349, 20);
            this.cboTaxSSubject.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "应交税费科目";
            // 
            // cboBiller
            // 
            this.cboBiller.FormattingEnabled = true;
            this.cboBiller.Location = new System.Drawing.Point(597, 9);
            this.cboBiller.Name = "cboBiller";
            this.cboBiller.Size = new System.Drawing.Size(150, 20);
            this.cboBiller.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "制单人";
            // 
            // dteCredDate
            // 
            this.dteCredDate.Location = new System.Drawing.Point(350, 34);
            this.dteCredDate.Name = "dteCredDate";
            this.dteCredDate.Size = new System.Drawing.Size(124, 21);
            this.dteCredDate.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "凭证日期";
            // 
            // cboCredType
            // 
            this.cboCredType.FormattingEnabled = true;
            this.cboCredType.Location = new System.Drawing.Point(125, 34);
            this.cboCredType.Name = "cboCredType";
            this.cboCredType.Size = new System.Drawing.Size(121, 20);
            this.cboCredType.TabIndex = 17;
            // 
            // lblCredType
            // 
            this.lblCredType.AutoSize = true;
            this.lblCredType.Location = new System.Drawing.Point(72, 37);
            this.lblCredType.Name = "lblCredType";
            this.lblCredType.Size = new System.Drawing.Size(41, 12);
            this.lblCredType.TabIndex = 16;
            this.lblCredType.Text = "凭证字";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fenluno,
            this.rawdebit,
            this.rawcredit,
            this.brief,
            this.moneyid,
            this.rate,
            this.subID_D_Name,
            this.subID_D,
            this.billNumber,
            this.credit,
            this.debit,
            this.vendor});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1264, 486);
            this.dataGridView1.TabIndex = 0;
            // 
            // fenluno
            // 
            this.fenluno.DataPropertyName = "fenluno";
            this.fenluno.HeaderText = "分录号";
            this.fenluno.Name = "fenluno";
            this.fenluno.Visible = false;
            // 
            // rawdebit
            // 
            this.rawdebit.DataPropertyName = "rawdebit";
            this.rawdebit.HeaderText = "借方汇率";
            this.rawdebit.Name = "rawdebit";
            this.rawdebit.Visible = false;
            // 
            // rawcredit
            // 
            this.rawcredit.DataPropertyName = "rawcredit";
            this.rawcredit.HeaderText = "贷方汇率";
            this.rawcredit.Name = "rawcredit";
            this.rawcredit.Visible = false;
            // 
            // brief
            // 
            this.brief.DataPropertyName = "brief";
            this.brief.HeaderText = "摘要";
            this.brief.Name = "brief";
            this.brief.Width = 330;
            // 
            // moneyid
            // 
            this.moneyid.DataPropertyName = "moneyid";
            this.moneyid.HeaderText = "币种ID";
            this.moneyid.Name = "moneyid";
            this.moneyid.Visible = false;
            // 
            // rate
            // 
            this.rate.DataPropertyName = "rate";
            this.rate.HeaderText = "汇率";
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            this.rate.Visible = false;
            // 
            // subID_D_Name
            // 
            this.subID_D_Name.DataPropertyName = "subID_D_Name";
            this.subID_D_Name.HeaderText = "应收账款科目";
            this.subID_D_Name.Name = "subID_D_Name";
            this.subID_D_Name.Width = 250;
            // 
            // subID_D
            // 
            this.subID_D.DataPropertyName = "subid";
            this.subID_D.HeaderText = "科目ID";
            this.subID_D.Name = "subID_D";
            this.subID_D.Visible = false;
            // 
            // billNumber
            // 
            this.billNumber.DataPropertyName = "billNumber";
            this.billNumber.HeaderText = "附件数";
            this.billNumber.Name = "billNumber";
            this.billNumber.Width = 80;
            // 
            // credit
            // 
            this.credit.DataPropertyName = "credit";
            this.credit.HeaderText = "税额";
            this.credit.Name = "credit";
            this.credit.ReadOnly = true;
            // 
            // debit
            // 
            this.debit.DataPropertyName = "debit";
            this.debit.HeaderText = "含税金额";
            this.debit.Name = "debit";
            this.debit.ReadOnly = true;
            this.debit.Width = 120;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "购货单位";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            this.vendor.Width = 200;
            // 
            // FormCredence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Name = "FormCredence";
            this.Text = "转速达凭证";
            this.mainPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cboAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboIncomeSubject;
        private System.Windows.Forms.ComboBox cboTaxSSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBiller;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteCredDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCredType;
        private System.Windows.Forms.Label lblCredType;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboGroupBy;
        private System.Windows.Forms.Label lblGroupBy;
        private System.Windows.Forms.Label lblTaxNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn fenluno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rawdebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn rawcredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn brief;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneyid;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewComboBoxColumn subID_D_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn subID_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn billNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
    }
}