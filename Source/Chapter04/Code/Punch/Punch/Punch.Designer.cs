namespace Punch
{
  partial class Punch
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be 
    /// disposed; otherwise, false.</param>
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
      this.cmdPunch = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtHoursToday = new System.Windows.Forms.TextBox();
      this.cmbWeek = new System.Windows.Forms.ComboBox();
      this.txtSat = new System.Windows.Forms.TextBox();
      this.txtFri = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.txtSun = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtThu = new System.Windows.Forms.TextBox();
      this.txtWed = new System.Windows.Forms.TextBox();
      this.txtTue = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtMon = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // cmdPunch
      // 
      this.cmdPunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmdPunch.Location = new System.Drawing.Point(17, 204);
      this.cmdPunch.Name = "cmdPunch";
      this.cmdPunch.Size = new System.Drawing.Size(168, 38);
      this.cmdPunch.TabIndex = 0;
      this.cmdPunch.Text = "Punch In";
      this.cmdPunch.UseVisualStyleBackColor = true;
      this.cmdPunch.Click += new System.EventHandler(this.cmdPunch_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(29, 271);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(105, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Hours Worked today";
      // 
      // txtHoursToday
      // 
      this.txtHoursToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtHoursToday.Location = new System.Drawing.Point(28, 289);
      this.txtHoursToday.Name = "txtHoursToday";
      this.txtHoursToday.ReadOnly = true;
      this.txtHoursToday.Size = new System.Drawing.Size(142, 20);
      this.txtHoursToday.TabIndex = 2;
      // 
      // cmbWeek
      // 
      this.cmbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbWeek.FormattingEnabled = true;
      this.cmbWeek.Items.AddRange(new object[] {
            "This Week",
            "Last Week"});
      this.cmbWeek.Location = new System.Drawing.Point(12, 43);
      this.cmbWeek.Name = "cmbWeek";
      this.cmbWeek.Size = new System.Drawing.Size(141, 21);
      this.cmbWeek.TabIndex = 4;
      this.cmbWeek.SelectedIndexChanged += new System.EventHandler(this.cmbWeek_SelectedIndexChanged);
      // 
      // txtSat
      // 
      this.txtSat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtSat.Location = new System.Drawing.Point(471, 112);
      this.txtSat.Name = "txtSat";
      this.txtSat.ReadOnly = true;
      this.txtSat.Size = new System.Drawing.Size(64, 20);
      this.txtSat.TabIndex = 31;
      this.txtSat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtFri
      // 
      this.txtFri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtFri.Location = new System.Drawing.Point(396, 112);
      this.txtFri.Name = "txtFri";
      this.txtFri.ReadOnly = true;
      this.txtFri.Size = new System.Drawing.Size(64, 20);
      this.txtFri.TabIndex = 33;
      this.txtFri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(471, 89);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(49, 13);
      this.label7.TabIndex = 30;
      this.label7.Text = "Saturday";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(321, 89);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(51, 13);
      this.label5.TabIndex = 34;
      this.label5.Text = "Thursday";
      // 
      // txtSun
      // 
      this.txtSun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtSun.Location = new System.Drawing.Point(21, 112);
      this.txtSun.Name = "txtSun";
      this.txtSun.ReadOnly = true;
      this.txtSun.Size = new System.Drawing.Size(64, 20);
      this.txtSun.TabIndex = 29;
      this.txtSun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(396, 89);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(35, 13);
      this.label6.TabIndex = 32;
      this.label6.Text = "Friday";
      // 
      // txtThu
      // 
      this.txtThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtThu.Location = new System.Drawing.Point(321, 112);
      this.txtThu.Name = "txtThu";
      this.txtThu.ReadOnly = true;
      this.txtThu.Size = new System.Drawing.Size(64, 20);
      this.txtThu.TabIndex = 35;
      this.txtThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtWed
      // 
      this.txtWed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtWed.Location = new System.Drawing.Point(246, 112);
      this.txtWed.Name = "txtWed";
      this.txtWed.ReadOnly = true;
      this.txtWed.Size = new System.Drawing.Size(64, 20);
      this.txtWed.TabIndex = 37;
      this.txtWed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtTue
      // 
      this.txtTue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtTue.Location = new System.Drawing.Point(171, 112);
      this.txtTue.Name = "txtTue";
      this.txtTue.ReadOnly = true;
      this.txtTue.Size = new System.Drawing.Size(64, 20);
      this.txtTue.TabIndex = 39;
      this.txtTue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(246, 89);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(64, 13);
      this.label4.TabIndex = 36;
      this.label4.Text = "Wednesday";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(171, 89);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(48, 13);
      this.label3.TabIndex = 38;
      this.label3.Text = "Tuesday";
      // 
      // txtMon
      // 
      this.txtMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtMon.Location = new System.Drawing.Point(96, 112);
      this.txtMon.Name = "txtMon";
      this.txtMon.ReadOnly = true;
      this.txtMon.Size = new System.Drawing.Size(67, 20);
      this.txtMon.TabIndex = 27;
      this.txtMon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(96, 89);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(45, 13);
      this.label2.TabIndex = 26;
      this.label2.Text = "Monday";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(21, 89);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(43, 13);
      this.label8.TabIndex = 28;
      this.label8.Text = "Sunday";
      // 
      // punch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(556, 386);
      this.Controls.Add(this.txtSat);
      this.Controls.Add(this.txtFri);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtSun);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.txtThu);
      this.Controls.Add(this.txtWed);
      this.Controls.Add(this.txtTue);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtMon);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.cmbWeek);
      this.Controls.Add(this.txtHoursToday);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cmdPunch);
      this.Name = "punch";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Punch form";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cmdPunch;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtHoursToday;
    private System.Windows.Forms.ComboBox cmbWeek;
    private System.Windows.Forms.TextBox txtSat;
    private System.Windows.Forms.TextBox txtFri;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtSun;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtThu;
    private System.Windows.Forms.TextBox txtWed;
    private System.Windows.Forms.TextBox txtTue;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtMon;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label8;
  }
}

