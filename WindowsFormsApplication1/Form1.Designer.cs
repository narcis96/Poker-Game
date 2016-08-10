namespace WindowsFormsApplication1
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
            this.numericUpDownNumarJucatori = new System.Windows.Forms.NumericUpDown();
            this.Ok = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Joc_nou = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.Button();
            this.Call = new System.Windows.Forms.Button();
            this.Raise = new System.Windows.Forms.Button();
            this.numericUpRaise = new System.Windows.Forms.NumericUpDown();
            this.buttonAllIn = new System.Windows.Forms.Button();
            this.labelPot = new System.Windows.Forms.Label();
            this.buttoFold = new System.Windows.Forms.Button();
            this.labelNume = new System.Windows.Forms.Label();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumarJucatori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpRaise)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownNumarJucatori
            // 
            this.numericUpDownNumarJucatori.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownNumarJucatori.Location = new System.Drawing.Point(536, 418);
            this.numericUpDownNumarJucatori.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownNumarJucatori.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNumarJucatori.Name = "numericUpDownNumarJucatori";
            this.numericUpDownNumarJucatori.Size = new System.Drawing.Size(51, 29);
            this.numericUpDownNumarJucatori.TabIndex = 0;
            this.numericUpDownNumarJucatori.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Ok
            // 
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Ok.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ok.Location = new System.Drawing.Point(364, 561);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 35);
            this.Ok.TabIndex = 1;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(536, 463);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(51, 29);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Numar jucatori";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(155, 468);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dificultate";
            // 
            // Joc_nou
            // 
            this.Joc_nou.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Joc_nou.Location = new System.Drawing.Point(12, 561);
            this.Joc_nou.Name = "Joc_nou";
            this.Joc_nou.Size = new System.Drawing.Size(106, 35);
            this.Joc_nou.TabIndex = 5;
            this.Joc_nou.Text = "Joc nou";
            this.Joc_nou.UseVisualStyleBackColor = true;
            this.Joc_nou.Visible = false;
            this.Joc_nou.Click += new System.EventHandler(this.Joc_nou_Click);
            // 
            // Check
            // 
            this.Check.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Check.Location = new System.Drawing.Point(613, 402);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(75, 34);
            this.Check.TabIndex = 6;
            this.Check.Text = "Check";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Visible = false;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // Call
            // 
            this.Call.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Call.Location = new System.Drawing.Point(694, 402);
            this.Call.Name = "Call";
            this.Call.Size = new System.Drawing.Size(75, 34);
            this.Call.TabIndex = 7;
            this.Call.Text = "Call";
            this.Call.UseVisualStyleBackColor = true;
            this.Call.Visible = false;
            this.Call.Click += new System.EventHandler(this.Call_Click);
            // 
            // Raise
            // 
            this.Raise.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Raise.Location = new System.Drawing.Point(613, 442);
            this.Raise.Name = "Raise";
            this.Raise.Size = new System.Drawing.Size(75, 34);
            this.Raise.TabIndex = 8;
            this.Raise.Text = "Raise";
            this.Raise.UseVisualStyleBackColor = true;
            this.Raise.Visible = false;
            this.Raise.Click += new System.EventHandler(this.Raise_Click);
            // 
            // numericUpRaise
            // 
            this.numericUpRaise.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpRaise.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpRaise.Location = new System.Drawing.Point(694, 447);
            this.numericUpRaise.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpRaise.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpRaise.Name = "numericUpRaise";
            this.numericUpRaise.Size = new System.Drawing.Size(75, 29);
            this.numericUpRaise.TabIndex = 9;
            this.numericUpRaise.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpRaise.Visible = false;
            // 
            // buttonAllIn
            // 
            this.buttonAllIn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAllIn.Location = new System.Drawing.Point(613, 522);
            this.buttonAllIn.Name = "buttonAllIn";
            this.buttonAllIn.Size = new System.Drawing.Size(156, 34);
            this.buttonAllIn.TabIndex = 10;
            this.buttonAllIn.Text = "All - In";
            this.buttonAllIn.UseVisualStyleBackColor = true;
            this.buttonAllIn.Visible = false;
            this.buttonAllIn.Click += new System.EventHandler(this.buttonAllIn_Click);
            // 
            // labelPot
            // 
            this.labelPot.AutoSize = true;
            this.labelPot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPot.Location = new System.Drawing.Point(25, 371);
            this.labelPot.Name = "labelPot";
            this.labelPot.Size = new System.Drawing.Size(52, 24);
            this.labelPot.TabIndex = 11;
            this.labelPot.Text = "Pot : ";
            this.labelPot.Visible = false;
            // 
            // buttoFold
            // 
            this.buttoFold.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttoFold.Location = new System.Drawing.Point(613, 482);
            this.buttoFold.Name = "buttoFold";
            this.buttoFold.Size = new System.Drawing.Size(156, 34);
            this.buttoFold.TabIndex = 12;
            this.buttoFold.Text = "Fold";
            this.buttoFold.UseVisualStyleBackColor = true;
            this.buttoFold.Visible = false;
            this.buttoFold.Click += new System.EventHandler(this.buttoFold_Click);
            // 
            // labelNume
            // 
            this.labelNume.AutoSize = true;
            this.labelNume.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNume.Location = new System.Drawing.Point(155, 510);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(62, 24);
            this.labelNume.TabIndex = 13;
            this.labelNume.Text = "Nume";
            // 
            // textBoxNume
            // 
            this.textBoxNume.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNume.Location = new System.Drawing.Point(483, 505);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(104, 29);
            this.textBoxNume.TabIndex = 14;
            // 
            // Form1
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(793, 608);
            this.Controls.Add(this.textBoxNume);
            this.Controls.Add(this.labelNume);
            this.Controls.Add(this.buttoFold);
            this.Controls.Add(this.labelPot);
            this.Controls.Add(this.buttonAllIn);
            this.Controls.Add(this.numericUpRaise);
            this.Controls.Add(this.Raise);
            this.Controls.Add(this.Call);
            this.Controls.Add(this.Check);
            this.Controls.Add(this.Joc_nou);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.numericUpDownNumarJucatori);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PokerGame";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumarJucatori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpRaise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownNumarJucatori;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Joc_nou;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.Button Call;
        private System.Windows.Forms.Button Raise;
        private System.Windows.Forms.NumericUpDown numericUpRaise;
        private System.Windows.Forms.Button buttonAllIn;
        private System.Windows.Forms.Label labelPot;
        private System.Windows.Forms.Button buttoFold;
        private System.Windows.Forms.Label labelNume;
        private System.Windows.Forms.TextBox textBoxNume;
    }
}

