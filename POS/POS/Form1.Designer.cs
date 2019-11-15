namespace POS
{
    partial class Form1
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
            this.dtgSale = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.btnPayCash = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSale)).BeginInit();
            this.pnlTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgSale
            // 
            this.dtgSale.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSale.Location = new System.Drawing.Point(11, 150);
            this.dtgSale.Name = "dtgSale";
            this.dtgSale.Size = new System.Drawing.Size(588, 204);
            this.dtgSale.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(77, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(231, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(177, 374);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(116, 40);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(299, 374);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(116, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(77, 60);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(121, 20);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quantity";
            // 
            // pnlTotal
            // 
            this.pnlTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlTotal.Controls.Add(this.lblTotal);
            this.pnlTotal.Controls.Add(this.label8);
            this.pnlTotal.Location = new System.Drawing.Point(335, 2);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(275, 78);
            this.pnlTotal.TabIndex = 30;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Square721 BT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.LightYellow;
            this.lblTotal.Location = new System.Drawing.Point(86, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(178, 33);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Php 0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Square721 BT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightYellow;
            this.label8.Location = new System.Drawing.Point(11, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 26);
            this.label8.TabIndex = 1;
            this.label8.Text = "Total:";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(27, 562);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Payment:";
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtPaymentAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaymentAmount.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentAmount.ForeColor = System.Drawing.SystemColors.Window;
            this.txtPaymentAmount.Location = new System.Drawing.Point(84, 555);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(170, 33);
            this.txtPaymentAmount.TabIndex = 31;
            // 
            // btnPayCash
            // 
            this.btnPayCash.Location = new System.Drawing.Point(260, 555);
            this.btnPayCash.Name = "btnPayCash";
            this.btnPayCash.Size = new System.Drawing.Size(117, 33);
            this.btnPayCash.TabIndex = 33;
            this.btnPayCash.Text = "Cash Payment";
            this.btnPayCash.UseVisualStyleBackColor = true;
            this.btnPayCash.Click += new System.EventHandler(this.btnPayCash_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "REFERENCE LANG NINYO INI HA...... GOD BLESS..";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 612);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPayCash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPaymentAmount);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dtgSale);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dtgSale)).EndInit();
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgSale;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label8;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.Button btnPayCash;
        private System.Windows.Forms.Label label4;
    }
}

