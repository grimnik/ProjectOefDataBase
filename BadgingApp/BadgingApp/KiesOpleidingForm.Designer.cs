namespace BadgingApp
{
    partial class KiesOpleidingForm
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
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.opleidingDataSet = new BadgingApp.OpleidingDataSet();
            this.opleidingsInfoesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.opleidingsInfoesTableAdapter = new BadgingApp.OpleidingDataSetTableAdapters.OpleidingsInfoesTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.opleidingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opleidingsInfoesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.opleidingsInfoesBindingSource;
            this.comboBox1.DisplayMember = "Opleiding";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(775, 28);
            this.comboBox1.TabIndex = 0;
            // 
            // opleidingDataSet
            // 
            this.opleidingDataSet.DataSetName = "OpleidingDataSet";
            this.opleidingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // opleidingsInfoesBindingSource
            // 
            this.opleidingsInfoesBindingSource.DataMember = "OpleidingsInfoes";
            this.opleidingsInfoesBindingSource.DataSource = this.opleidingDataSet;
            // 
            // opleidingsInfoesTableAdapter
            // 
            this.opleidingsInfoesTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(13, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // KiesOpleidingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "KiesOpleidingForm";
            this.Text = "KiesOpleidingForm";
            this.Load += new System.EventHandler(this.KiesOpleidingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.opleidingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opleidingsInfoesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private OpleidingDataSet opleidingDataSet;
        private System.Windows.Forms.BindingSource opleidingsInfoesBindingSource;
        private OpleidingDataSetTableAdapters.OpleidingsInfoesTableAdapter opleidingsInfoesTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}