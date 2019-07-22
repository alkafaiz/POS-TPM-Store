namespace POS_TPM__store
{
    partial class FormUpdateStock
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConfirmUpdate = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCrtStock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnADDStock = new System.Windows.Forms.Button();
            this.btnAdd5 = new System.Windows.Forms.Button();
            this.btnAdd10 = new System.Windows.Forms.Button();
            this.btnAdd50 = new System.Windows.Forms.Button();
            this.btnAdd30 = new System.Windows.Forms.Button();
            this.btnAdd100 = new System.Windows.Forms.Button();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownADDSTOCK = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewFullItem = new System.Windows.Forms.DataGridView();
            this.ColProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdd500 = new System.Windows.Forms.Button();
            this.dataGridViewUPDATESTOCK = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAddedStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNewStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownADDSTOCK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFullItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUPDATESTOCK)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(1026, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 51);
            this.btnClose.TabIndex = 60;
            this.btnClose.Text = "&CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConfirmUpdate
            // 
            this.btnConfirmUpdate.BackColor = System.Drawing.Color.Green;
            this.btnConfirmUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirmUpdate.Location = new System.Drawing.Point(592, 438);
            this.btnConfirmUpdate.Name = "btnConfirmUpdate";
            this.btnConfirmUpdate.Size = new System.Drawing.Size(98, 51);
            this.btnConfirmUpdate.TabIndex = 59;
            this.btnConfirmUpdate.Text = "CONFIRM UPDATE";
            this.btnConfirmUpdate.UseVisualStyleBackColor = false;
            this.btnConfirmUpdate.Click += new System.EventHandler(this.btnConfirmUpdate_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.Yellow;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelect.Location = new System.Drawing.Point(285, 21);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(89, 26);
            this.btnSelect.TabIndex = 57;
            this.btnSelect.Text = "Select >>";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(125, 86);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(177, 24);
            this.txtSupplier.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 18);
            this.label9.TabIndex = 55;
            this.label9.Text = "Suplier";
            // 
            // txtCrtStock
            // 
            this.txtCrtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrtStock.Location = new System.Drawing.Point(125, 146);
            this.txtCrtStock.Name = "txtCrtStock";
            this.txtCrtStock.ReadOnly = true;
            this.txtCrtStock.Size = new System.Drawing.Size(177, 24);
            this.txtCrtStock.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 53;
            this.label5.Text = "Current Stock";
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(125, 56);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(177, 24);
            this.txtDesc.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 41;
            this.label2.Text = "Description";
            // 
            // txtSearchCode
            // 
            this.txtSearchCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCode.Location = new System.Drawing.Point(86, 21);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.Size = new System.Drawing.Size(177, 26);
            this.txtSearchCode.TabIndex = 40;
            this.txtSearchCode.TextChanged += new System.EventHandler(this.txtSearchCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Search";
            // 
            // btnADDStock
            // 
            this.btnADDStock.BackColor = System.Drawing.Color.SteelBlue;
            this.btnADDStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnADDStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnADDStock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnADDStock.Location = new System.Drawing.Point(213, 100);
            this.btnADDStock.Name = "btnADDStock";
            this.btnADDStock.Size = new System.Drawing.Size(89, 26);
            this.btnADDStock.TabIndex = 65;
            this.btnADDStock.Text = "ADD";
            this.btnADDStock.UseVisualStyleBackColor = false;
            this.btnADDStock.Click += new System.EventHandler(this.btnADDStock_Click);
            // 
            // btnAdd5
            // 
            this.btnAdd5.BackColor = System.Drawing.Color.DimGray;
            this.btnAdd5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd5.Location = new System.Drawing.Point(101, 33);
            this.btnAdd5.Name = "btnAdd5";
            this.btnAdd5.Size = new System.Drawing.Size(44, 24);
            this.btnAdd5.TabIndex = 66;
            this.btnAdd5.Text = "5";
            this.btnAdd5.UseVisualStyleBackColor = false;
            this.btnAdd5.Click += new System.EventHandler(this.btnAdd5_Click);
            // 
            // btnAdd10
            // 
            this.btnAdd10.BackColor = System.Drawing.Color.DimGray;
            this.btnAdd10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd10.Location = new System.Drawing.Point(151, 33);
            this.btnAdd10.Name = "btnAdd10";
            this.btnAdd10.Size = new System.Drawing.Size(44, 24);
            this.btnAdd10.TabIndex = 67;
            this.btnAdd10.Text = "10";
            this.btnAdd10.UseVisualStyleBackColor = false;
            this.btnAdd10.Click += new System.EventHandler(this.btnAdd10_Click);
            // 
            // btnAdd50
            // 
            this.btnAdd50.BackColor = System.Drawing.Color.DimGray;
            this.btnAdd50.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd50.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd50.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd50.Location = new System.Drawing.Point(101, 63);
            this.btnAdd50.Name = "btnAdd50";
            this.btnAdd50.Size = new System.Drawing.Size(44, 24);
            this.btnAdd50.TabIndex = 69;
            this.btnAdd50.Text = "50";
            this.btnAdd50.UseVisualStyleBackColor = false;
            this.btnAdd50.Click += new System.EventHandler(this.btnAdd50_Click);
            // 
            // btnAdd30
            // 
            this.btnAdd30.BackColor = System.Drawing.Color.DimGray;
            this.btnAdd30.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd30.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd30.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd30.Location = new System.Drawing.Point(201, 33);
            this.btnAdd30.Name = "btnAdd30";
            this.btnAdd30.Size = new System.Drawing.Size(44, 24);
            this.btnAdd30.TabIndex = 68;
            this.btnAdd30.Text = "30";
            this.btnAdd30.UseVisualStyleBackColor = false;
            this.btnAdd30.Click += new System.EventHandler(this.btnAdd30_Click);
            // 
            // btnAdd100
            // 
            this.btnAdd100.BackColor = System.Drawing.Color.DimGray;
            this.btnAdd100.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd100.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd100.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd100.Location = new System.Drawing.Point(151, 63);
            this.btnAdd100.Name = "btnAdd100";
            this.btnAdd100.Size = new System.Drawing.Size(44, 24);
            this.btnAdd100.TabIndex = 70;
            this.btnAdd100.Text = "100";
            this.btnAdd100.UseVisualStyleBackColor = false;
            this.btnAdd100.Click += new System.EventHandler(this.btnAdd100_Click);
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(125, 116);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(177, 24);
            this.txtCategory.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 72;
            this.label4.Text = "Category";
            // 
            // numericUpDownADDSTOCK
            // 
            this.numericUpDownADDSTOCK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownADDSTOCK.Location = new System.Drawing.Point(9, 33);
            this.numericUpDownADDSTOCK.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownADDSTOCK.Name = "numericUpDownADDSTOCK";
            this.numericUpDownADDSTOCK.Size = new System.Drawing.Size(68, 24);
            this.numericUpDownADDSTOCK.TabIndex = 74;
            // 
            // dataGridViewFullItem
            // 
            this.dataGridViewFullItem.AllowUserToAddRows = false;
            this.dataGridViewFullItem.AllowUserToDeleteRows = false;
            this.dataGridViewFullItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFullItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColProductCode,
            this.ColDesc,
            this.ColStock});
            this.dataGridViewFullItem.Location = new System.Drawing.Point(12, 72);
            this.dataGridViewFullItem.MultiSelect = false;
            this.dataGridViewFullItem.Name = "dataGridViewFullItem";
            this.dataGridViewFullItem.ReadOnly = true;
            this.dataGridViewFullItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFullItem.Size = new System.Drawing.Size(362, 417);
            this.dataGridViewFullItem.TabIndex = 75;
            // 
            // ColProductCode
            // 
            this.ColProductCode.HeaderText = "Product Code";
            this.ColProductCode.Name = "ColProductCode";
            this.ColProductCode.ReadOnly = true;
            // 
            // ColDesc
            // 
            this.ColDesc.HeaderText = "Description";
            this.ColDesc.Name = "ColDesc";
            this.ColDesc.ReadOnly = true;
            this.ColDesc.Width = 160;
            // 
            // ColStock
            // 
            this.ColStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColStock.HeaderText = "Current Stock";
            this.ColStock.Name = "ColStock";
            this.ColStock.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtProductCode);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCategory);
            this.groupBox1.Controls.Add(this.txtCrtStock);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSupplier);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(388, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 190);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 41;
            this.label6.Text = "Product Code";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(125, 26);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Size = new System.Drawing.Size(177, 24);
            this.txtProductCode.TabIndex = 42;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownADDSTOCK);
            this.groupBox2.Controls.Add(this.btnAdd5);
            this.groupBox2.Controls.Add(this.btnAdd10);
            this.groupBox2.Controls.Add(this.btnAdd30);
            this.groupBox2.Controls.Add(this.btnADDStock);
            this.groupBox2.Controls.Add(this.btnAdd500);
            this.groupBox2.Controls.Add(this.btnAdd100);
            this.groupBox2.Controls.Add(this.btnAdd50);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(388, 282);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 142);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update Stock";
            // 
            // btnAdd500
            // 
            this.btnAdd500.BackColor = System.Drawing.Color.DimGray;
            this.btnAdd500.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd500.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd500.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd500.Location = new System.Drawing.Point(201, 63);
            this.btnAdd500.Name = "btnAdd500";
            this.btnAdd500.Size = new System.Drawing.Size(44, 24);
            this.btnAdd500.TabIndex = 70;
            this.btnAdd500.Text = "500";
            this.btnAdd500.UseVisualStyleBackColor = false;
            this.btnAdd500.Click += new System.EventHandler(this.btnAdd500_Click);
            // 
            // dataGridViewUPDATESTOCK
            // 
            this.dataGridViewUPDATESTOCK.AllowUserToAddRows = false;
            this.dataGridViewUPDATESTOCK.AllowUserToDeleteRows = false;
            this.dataGridViewUPDATESTOCK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUPDATESTOCK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.ColCurrentStock,
            this.ColAddedStock,
            this.ColNewStock});
            this.dataGridViewUPDATESTOCK.Location = new System.Drawing.Point(719, 72);
            this.dataGridViewUPDATESTOCK.MultiSelect = false;
            this.dataGridViewUPDATESTOCK.Name = "dataGridViewUPDATESTOCK";
            this.dataGridViewUPDATESTOCK.ReadOnly = true;
            this.dataGridViewUPDATESTOCK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUPDATESTOCK.Size = new System.Drawing.Size(425, 417);
            this.dataGridViewUPDATESTOCK.TabIndex = 78;
            this.dataGridViewUPDATESTOCK.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUPDATESTOCK_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // ColCurrentStock
            // 
            this.ColCurrentStock.HeaderText = "Current Stock";
            this.ColCurrentStock.Name = "ColCurrentStock";
            this.ColCurrentStock.ReadOnly = true;
            this.ColCurrentStock.Width = 50;
            // 
            // ColAddedStock
            // 
            this.ColAddedStock.HeaderText = "Added Stock";
            this.ColAddedStock.Name = "ColAddedStock";
            this.ColAddedStock.ReadOnly = true;
            this.ColAddedStock.Width = 50;
            // 
            // ColNewStock
            // 
            this.ColNewStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNewStock.HeaderText = "New Stock";
            this.ColNewStock.Name = "ColNewStock";
            this.ColNewStock.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(83, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = ": Product code, Description, or Supplier";
            // 
            // FormUpdateStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 510);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewUPDATESTOCK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewFullItem);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirmUpdate);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtSearchCode);
            this.Controls.Add(this.label1);
            this.Name = "FormUpdateStock";
            this.Text = "FormUpdateStock";
            this.Load += new System.EventHandler(this.FormUpdateStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownADDSTOCK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFullItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUPDATESTOCK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConfirmUpdate;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCrtStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnADDStock;
        private System.Windows.Forms.Button btnAdd5;
        private System.Windows.Forms.Button btnAdd10;
        private System.Windows.Forms.Button btnAdd50;
        private System.Windows.Forms.Button btnAdd30;
        private System.Windows.Forms.Button btnAdd100;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownADDSTOCK;
        private System.Windows.Forms.DataGridView dataGridViewFullItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewUPDATESTOCK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd500;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAddedStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNewStock;
    }
}