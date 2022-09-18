namespace Session2
{
    partial class EMMEmployee
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
            this.label1 = new System.Windows.Forms.Label();
            this.assetsTable = new System.Windows.Forms.DataGridView();
            this.AssetSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastClosedEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfEMs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.assetsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Assets:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // assetsTable
            // 
            this.assetsTable.AllowUserToResizeRows = false;
            this.assetsTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.assetsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assetsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AssetSN,
            this.AssetName,
            this.LastClosedEM,
            this.NumberOfEMs});
            this.assetsTable.Location = new System.Drawing.Point(14, 52);
            this.assetsTable.Name = "assetsTable";
            this.assetsTable.RowHeadersVisible = false;
            this.assetsTable.RowTemplate.Height = 25;
            this.assetsTable.Size = new System.Drawing.Size(887, 196);
            this.assetsTable.TabIndex = 1;
            this.assetsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.assetTable_CellContentClick);
            // 
            // AssetSN
            // 
            this.AssetSN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AssetSN.HeaderText = "Asset SN";
            this.AssetSN.Name = "AssetSN";
            this.AssetSN.ReadOnly = true;
            // 
            // AssetName
            // 
            this.AssetName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AssetName.HeaderText = "Asset Name";
            this.AssetName.Name = "AssetName";
            this.AssetName.ReadOnly = true;
            // 
            // LastClosedEM
            // 
            this.LastClosedEM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastClosedEM.HeaderText = "Last Closed EM";
            this.LastClosedEM.Name = "LastClosedEM";
            this.LastClosedEM.ReadOnly = true;
            // 
            // NumberOfEMs
            // 
            this.NumberOfEMs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumberOfEMs.HeaderText = "Number of EMs";
            this.NumberOfEMs.Name = "NumberOfEMs";
            this.NumberOfEMs.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send Emergency Maintenance Request";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // EMMEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 303);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.assetsTable);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Helvetica", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EMMEmployee";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emergency Maintenance Management";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assetsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DataGridView assetsTable;
        private DataGridViewTextBoxColumn AssetSN;
        private DataGridViewTextBoxColumn AssetName;
        private DataGridViewTextBoxColumn LastClosedEM;
        private DataGridViewTextBoxColumn NumberOfEMs;
        private Button button1;
    }
}