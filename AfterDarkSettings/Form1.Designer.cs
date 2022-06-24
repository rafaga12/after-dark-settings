﻿namespace AfterDarkSettings
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
            this.ModulesListView = new System.Windows.Forms.ListView();
            this.ModuleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectButton = new System.Windows.Forms.Button();
            this.FolderComboBox = new System.Windows.Forms.ComboBox();
            this.RandomCheckBox = new System.Windows.Forms.CheckBox();
            this.MuteCheckBox = new System.Windows.Forms.CheckBox();
            this.PreviewCheckBox = new System.Windows.Forms.CheckBox();
            this.TaskbarCheckBox = new System.Windows.Forms.CheckBox();
            this.RandomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ModuleConfig = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.RandomNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ModulesListView
            // 
            this.ModulesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ModuleName});
            this.ModulesListView.HideSelection = false;
            this.ModulesListView.Location = new System.Drawing.Point(12, 40);
            this.ModulesListView.Name = "ModulesListView";
            this.ModulesListView.Size = new System.Drawing.Size(221, 369);
            this.ModulesListView.TabIndex = 0;
            this.ModulesListView.UseCompatibleStateImageBehavior = false;
            this.ModulesListView.View = System.Windows.Forms.View.Details;
            this.ModulesListView.SelectedIndexChanged += new System.EventHandler(this.ModulesListView_SelectedIndexChanged);
            // 
            // ModuleName
            // 
            this.ModuleName.Text = "Module Name";
            this.ModuleName.Width = 200;
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(12, 415);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(221, 23);
            this.SelectButton.TabIndex = 1;
            this.SelectButton.Text = "Apply";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // FolderComboBox
            // 
            this.FolderComboBox.FormattingEnabled = true;
            this.FolderComboBox.Location = new System.Drawing.Point(12, 13);
            this.FolderComboBox.Name = "FolderComboBox";
            this.FolderComboBox.Size = new System.Drawing.Size(221, 21);
            this.FolderComboBox.TabIndex = 2;
            this.FolderComboBox.SelectedIndexChanged += new System.EventHandler(this.FolderComboBox_SelectedIndexChanged);
            // 
            // RandomCheckBox
            // 
            this.RandomCheckBox.AutoSize = true;
            this.RandomCheckBox.Location = new System.Drawing.Point(239, 15);
            this.RandomCheckBox.Name = "RandomCheckBox";
            this.RandomCheckBox.Size = new System.Drawing.Size(82, 17);
            this.RandomCheckBox.TabIndex = 3;
            this.RandomCheckBox.Text = "Randomizer";
            this.RandomCheckBox.UseVisualStyleBackColor = true;
            this.RandomCheckBox.CheckedChanged += new System.EventHandler(this.RandomCheckBox_CheckedChanged);
            // 
            // MuteCheckBox
            // 
            this.MuteCheckBox.AutoSize = true;
            this.MuteCheckBox.Location = new System.Drawing.Point(239, 40);
            this.MuteCheckBox.Name = "MuteCheckBox";
            this.MuteCheckBox.Size = new System.Drawing.Size(84, 17);
            this.MuteCheckBox.TabIndex = 4;
            this.MuteCheckBox.Text = "Mute Sound";
            this.MuteCheckBox.UseVisualStyleBackColor = true;
            // 
            // PreviewCheckBox
            // 
            this.PreviewCheckBox.AutoSize = true;
            this.PreviewCheckBox.Location = new System.Drawing.Point(239, 63);
            this.PreviewCheckBox.Name = "PreviewCheckBox";
            this.PreviewCheckBox.Size = new System.Drawing.Size(133, 17);
            this.PreviewCheckBox.TabIndex = 5;
            this.PreviewCheckBox.Text = "Animated Mini Preview";
            this.PreviewCheckBox.UseVisualStyleBackColor = true;
            // 
            // TaskbarCheckBox
            // 
            this.TaskbarCheckBox.AutoSize = true;
            this.TaskbarCheckBox.Location = new System.Drawing.Point(239, 86);
            this.TaskbarCheckBox.Name = "TaskbarCheckBox";
            this.TaskbarCheckBox.Size = new System.Drawing.Size(118, 17);
            this.TaskbarCheckBox.TabIndex = 6;
            this.TaskbarCheckBox.Text = "Control On Taskbar";
            this.TaskbarCheckBox.UseVisualStyleBackColor = true;
            // 
            // RandomNumericUpDown
            // 
            this.RandomNumericUpDown.Location = new System.Drawing.Point(327, 14);
            this.RandomNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.RandomNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RandomNumericUpDown.Name = "RandomNumericUpDown";
            this.RandomNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.RandomNumericUpDown.TabIndex = 7;
            this.RandomNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Minutes";
            // 
            // ModuleConfig
            // 
            this.ModuleConfig.ColumnCount = 3;
            this.ModuleConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.ModuleConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.ModuleConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.ModuleConfig.Location = new System.Drawing.Point(503, 12);
            this.ModuleConfig.Name = "ModuleConfig";
            this.ModuleConfig.RowCount = 10;
            this.ModuleConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ModuleConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ModuleConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ModuleConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ModuleConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ModuleConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ModuleConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ModuleConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ModuleConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ModuleConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ModuleConfig.Size = new System.Drawing.Size(285, 426);
            this.ModuleConfig.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ModuleConfig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RandomNumericUpDown);
            this.Controls.Add(this.TaskbarCheckBox);
            this.Controls.Add(this.PreviewCheckBox);
            this.Controls.Add(this.MuteCheckBox);
            this.Controls.Add(this.RandomCheckBox);
            this.Controls.Add(this.FolderComboBox);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.ModulesListView);
            this.Name = "Form1";
            this.Text = "After Dark Settings";
            ((System.ComponentModel.ISupportInitialize)(this.RandomNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ModulesListView;
        private System.Windows.Forms.ColumnHeader ModuleName;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.ComboBox FolderComboBox;
        private System.Windows.Forms.CheckBox RandomCheckBox;
        private System.Windows.Forms.CheckBox MuteCheckBox;
        private System.Windows.Forms.CheckBox PreviewCheckBox;
        private System.Windows.Forms.CheckBox TaskbarCheckBox;
        private System.Windows.Forms.NumericUpDown RandomNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel ModuleConfig;
    }
}

