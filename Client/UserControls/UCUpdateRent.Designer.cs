
using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCUpdateRent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRentsForUser = new System.Windows.Forms.DataGridView();
            this.btnUpdateRent = new System.Windows.Forms.Button();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentsForUser)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRentsForUser
            // 
            this.dgvRentsForUser.AllowUserToAddRows = false;
            this.dgvRentsForUser.AllowUserToDeleteRows = false;
            this.dgvRentsForUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentsForUser.Location = new System.Drawing.Point(14, 21);
            this.dgvRentsForUser.Name = "dgvRentsForUser";
            this.dgvRentsForUser.ReadOnly = true;
            this.dgvRentsForUser.Size = new System.Drawing.Size(600, 252);
            this.dgvRentsForUser.TabIndex = 0;
            // 
            // btnUpdateRent
            // 
            this.btnUpdateRent.Location = new System.Drawing.Point(389, 313);
            this.btnUpdateRent.Name = "btnUpdateRent";
            this.btnUpdateRent.Size = new System.Drawing.Size(137, 49);
            this.btnUpdateRent.TabIndex = 1;
            this.btnUpdateRent.Text = "Razduži";
            this.btnUpdateRent.UseVisualStyleBackColor = true;
            // 
            // txtKm
            // 
            this.txtKm.Location = new System.Drawing.Point(141, 325);
            this.txtKm.Name = "txtKm";
            this.txtKm.Size = new System.Drawing.Size(100, 20);
            this.txtKm.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zavrsna kilometraza";
            // 
            // UCUpdateRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKm);
            this.Controls.Add(this.btnUpdateRent);
            this.Controls.Add(this.dgvRentsForUser);
            this.Name = "UCUpdateRent";
            this.Size = new System.Drawing.Size(634, 412);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentsForUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRentsForUser;
        private System.Windows.Forms.Button btnUpdateRent;
        private TextBox txtKm;
        private Label label1;

        public DataGridView DgvRentsForUser { get => dgvRentsForUser; set => dgvRentsForUser = value; }
        public Button BtnUpdateRent { get => btnUpdateRent; set => btnUpdateRent = value; }
        public TextBox TxtKm { get => txtKm; set => txtKm = value; }
    }
}
