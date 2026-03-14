using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabelLoggedINAdmin = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelErrorMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLoggOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRentals = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnCars = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabelLoggedINAdmin,
            this.StatusLabelErrorMsg,
            this.StatusLabelDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 739);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1152, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabelLoggedINAdmin
            // 
            this.StatusLabelLoggedINAdmin.Name = "StatusLabelLoggedINAdmin";
            this.StatusLabelLoggedINAdmin.Size = new System.Drawing.Size(66, 17);
            this.StatusLabelLoggedINAdmin.Text = "Logged in: ";
            // 
            // StatusLabelErrorMsg
            // 
            this.StatusLabelErrorMsg.Name = "StatusLabelErrorMsg";
            this.StatusLabelErrorMsg.Size = new System.Drawing.Size(965, 17);
            this.StatusLabelErrorMsg.Spring = true;
            this.StatusLabelErrorMsg.Text = "Error message: Add throw exceptions here";
            // 
            // StatusLabelDateTime
            // 
            this.StatusLabelDateTime.Name = "StatusLabelDateTime";
            this.StatusLabelDateTime.Size = new System.Drawing.Size(0, 17);
            this.StatusLabelDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnLoggOut);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1152, 50);
            this.panelTop.TabIndex = 2;
            // 
            // btnLoggOut
            // 
            this.btnLoggOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoggOut.BackColor = System.Drawing.Color.Firebrick;
            this.btnLoggOut.FlatAppearance.BorderSize = 0;
            this.btnLoggOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoggOut.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoggOut.ForeColor = System.Drawing.Color.White;
            this.btnLoggOut.Location = new System.Drawing.Point(1044, 0);
            this.btnLoggOut.Name = "btnLoggOut";
            this.btnLoggOut.Size = new System.Drawing.Size(108, 50);
            this.btnLoggOut.TabIndex = 1;
            this.btnLoggOut.Text = "Log out";
            this.btnLoggOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoggOut.UseVisualStyleBackColor = false;
            this.btnLoggOut.Click += new System.EventHandler(this.btnLoggOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Size = new System.Drawing.Size(335, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rent a car Management System";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(86)))), ((int)(((byte)(110)))));
            this.panelMenu.Controls.Add(this.btnRentals);
            this.panelMenu.Controls.Add(this.btnCustomers);
            this.panelMenu.Controls.Add(this.btnCars);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.ForeColor = System.Drawing.Color.White;
            this.panelMenu.Location = new System.Drawing.Point(0, 50);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 689);
            this.panelMenu.TabIndex = 3;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(230)))), ((int)(((byte)(231)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(200, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(952, 689);
            this.panelContent.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnRentals
            // 
            this.btnRentals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(86)))), ((int)(((byte)(110)))));
            this.btnRentals.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRentals.FlatAppearance.BorderSize = 0;
            this.btnRentals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentals.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRentals.Image = ((System.Drawing.Image)(resources.GetObject("btnRentals.Image")));
            this.btnRentals.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRentals.Location = new System.Drawing.Point(0, 120);
            this.btnRentals.Name = "btnRentals";
            this.btnRentals.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRentals.Size = new System.Drawing.Size(200, 60);
            this.btnRentals.TabIndex = 2;
            this.btnRentals.Text = "       Rentals";
            this.btnRentals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRentals.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRentals.UseVisualStyleBackColor = false;
            this.btnRentals.Click += new System.EventHandler(this.btnRentals_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(86)))), ((int)(((byte)(110)))));
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomers.Image")));
            this.btnCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.Location = new System.Drawing.Point(0, 60);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCustomers.Size = new System.Drawing.Size(200, 60);
            this.btnCustomers.TabIndex = 1;
            this.btnCustomers.Text = "      Customers";
            this.btnCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnCars
            // 
            this.btnCars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(86)))), ((int)(((byte)(110)))));
            this.btnCars.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCars.FlatAppearance.BorderSize = 0;
            this.btnCars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCars.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCars.Image = ((System.Drawing.Image)(resources.GetObject("btnCars.Image")));
            this.btnCars.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCars.Location = new System.Drawing.Point(0, 0);
            this.btnCars.Name = "btnCars";
            this.btnCars.Padding = new System.Windows.Forms.Padding(10, 0, 10, 15);
            this.btnCars.Size = new System.Drawing.Size(200, 60);
            this.btnCars.TabIndex = 0;
            this.btnCars.Text = "      Cars";
            this.btnCars.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCars.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCars.UseVisualStyleBackColor = false;
            this.btnCars.Click += new System.EventHandler(this.btnCars_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(86)))), ((int)(((byte)(110)))));
            this.ClientSize = new System.Drawing.Size(1152, 761);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusStrip1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rent a car";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnCars;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnRentals;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelLoggedINAdmin;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelErrorMsg;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelDateTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLoggOut;
    }
}

