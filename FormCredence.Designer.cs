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
            this.lblCredType = new System.Windows.Forms.Label();
            this.cboCredType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dteCredDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBiller = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTaxSSubject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboIncomeSubject = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCredType
            // 
            this.lblCredType.AutoSize = true;
            this.lblCredType.Location = new System.Drawing.Point(52, 94);
            this.lblCredType.Name = "lblCredType";
            this.lblCredType.Size = new System.Drawing.Size(41, 12);
            this.lblCredType.TabIndex = 0;
            this.lblCredType.Text = "凭证字";
            // 
            // cboCredType
            // 
            this.cboCredType.FormattingEnabled = true;
            this.cboCredType.Location = new System.Drawing.Point(101, 90);
            this.cboCredType.Name = "cboCredType";
            this.cboCredType.Size = new System.Drawing.Size(121, 20);
            this.cboCredType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "凭证日期";
            // 
            // dteCredDate
            // 
            this.dteCredDate.Location = new System.Drawing.Point(326, 89);
            this.dteCredDate.Name = "dteCredDate";
            this.dteCredDate.Size = new System.Drawing.Size(124, 21);
            this.dteCredDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "制单人";
            // 
            // cboBiller
            // 
            this.cboBiller.FormattingEnabled = true;
            this.cboBiller.Location = new System.Drawing.Point(535, 91);
            this.cboBiller.Name = "cboBiller";
            this.cboBiller.Size = new System.Drawing.Size(150, 20);
            this.cboBiller.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(277, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "请选择凭证主表信息：";
            // 
            // cboTaxSSubject
            // 
            this.cboTaxSSubject.FormattingEnabled = true;
            this.cboTaxSSubject.Location = new System.Drawing.Point(101, 126);
            this.cboTaxSSubject.Name = "cboTaxSSubject";
            this.cboTaxSSubject.Size = new System.Drawing.Size(227, 20);
            this.cboTaxSSubject.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "应交税费科目";
            // 
            // cboIncomeSubject
            // 
            this.cboIncomeSubject.FormattingEnabled = true;
            this.cboIncomeSubject.Location = new System.Drawing.Point(451, 124);
            this.cboIncomeSubject.Name = "cboIncomeSubject";
            this.cboIncomeSubject.Size = new System.Drawing.Size(234, 20);
            this.cboIncomeSubject.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(359, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "主营业务科目";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(200, 177);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(343, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cboAccount
            // 
            this.cboAccount.FormattingEnabled = true;
            this.cboAccount.Location = new System.Drawing.Point(102, 55);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(348, 20);
            this.cboAccount.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "转入账套";
            // 
            // FormCredence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 223);
            this.Controls.Add(this.cboAccount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboIncomeSubject);
            this.Controls.Add(this.cboTaxSSubject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboBiller);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dteCredDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCredType);
            this.Controls.Add(this.lblCredType);
            this.Name = "FormCredence";
            this.Text = "转速达凭证";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCredType;
        private System.Windows.Forms.ComboBox cboCredType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dteCredDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBiller;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTaxSSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboIncomeSubject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboAccount;
        private System.Windows.Forms.Label label5;
    }
}