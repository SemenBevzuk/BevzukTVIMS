﻿namespace BevzukTVIMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProbability = new System.Windows.Forms.TextBox();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_MaxDeviation = new System.Windows.Forms.TextBox();
            this.dataGridView_characteristics = new System.Windows.Forms.DataGridView();
            this.chart_IFR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_D = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView_segments = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_count_segments = new System.Windows.Forms.TextBox();
            this.button_add_segments = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_a_significance_level = new System.Windows.Forms.TextBox();
            this.dataGridView_q_probabilities = new System.Windows.Forms.DataGridView();
            this.button_compare_hypotheses = new System.Windows.Forms.Button();
            this.textBox_result = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_characteristics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_IFR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_segments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_q_probabilities)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вероятность p:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Число экспериментов: ";
            // 
            // textBoxProbability
            // 
            this.textBoxProbability.Location = new System.Drawing.Point(260, 221);
            this.textBoxProbability.Name = "textBoxProbability";
            this.textBoxProbability.Size = new System.Drawing.Size(84, 26);
            this.textBoxProbability.TabIndex = 2;
            this.textBoxProbability.Text = "0,7";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(260, 269);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(84, 26);
            this.textBoxAmount.TabIndex = 3;
            this.textBoxAmount.Text = "10";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(38, 326);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(306, 36);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = " Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(38, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1074, 188);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 468);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1074, 119);
            this.dataGridView1.TabIndex = 6;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(930, 205);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(176, 200);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Сброс";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(380, 207);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(544, 198);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Максимальное отклонение:";
            // 
            // textBox_MaxDeviation
            // 
            this.textBox_MaxDeviation.Location = new System.Drawing.Point(38, 419);
            this.textBox_MaxDeviation.Name = "textBox_MaxDeviation";
            this.textBox_MaxDeviation.Size = new System.Drawing.Size(306, 26);
            this.textBox_MaxDeviation.TabIndex = 10;
            this.textBox_MaxDeviation.Text = "0";
            // 
            // dataGridView_characteristics
            // 
            this.dataGridView_characteristics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_characteristics.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView_characteristics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_characteristics.Location = new System.Drawing.Point(38, 607);
            this.dataGridView_characteristics.Name = "dataGridView_characteristics";
            this.dataGridView_characteristics.RowTemplate.Height = 28;
            this.dataGridView_characteristics.Size = new System.Drawing.Size(1074, 92);
            this.dataGridView_characteristics.TabIndex = 11;
            // 
            // chart_IFR
            // 
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisY.Maximum = 1D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.Name = "ChartArea1";
            this.chart_IFR.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart_IFR.Legends.Add(legend2);
            this.chart_IFR.Location = new System.Drawing.Point(1139, 12);
            this.chart_IFR.Name = "chart_IFR";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_IFR.Series.Add(series2);
            this.chart_IFR.Size = new System.Drawing.Size(533, 591);
            this.chart_IFR.TabIndex = 12;
            this.chart_IFR.Text = "chart2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1144, 624);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "D = ";
            // 
            // textBox_D
            // 
            this.textBox_D.Location = new System.Drawing.Point(1188, 621);
            this.textBox_D.Name = "textBox_D";
            this.textBox_D.Size = new System.Drawing.Size(224, 26);
            this.textBox_D.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1429, 627);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Зелёный - теоретическая.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1429, 663);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Красный - экспериментальный";
            // 
            // dataGridView_segments
            // 
            this.dataGridView_segments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_segments.Location = new System.Drawing.Point(38, 724);
            this.dataGridView_segments.Name = "dataGridView_segments";
            this.dataGridView_segments.RowTemplate.Height = 28;
            this.dataGridView_segments.Size = new System.Drawing.Size(1074, 125);
            this.dataGridView_segments.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1136, 727);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Число отрезков:";
            // 
            // textBox_count_segments
            // 
            this.textBox_count_segments.Location = new System.Drawing.Point(1362, 721);
            this.textBox_count_segments.Name = "textBox_count_segments";
            this.textBox_count_segments.Size = new System.Drawing.Size(310, 26);
            this.textBox_count_segments.TabIndex = 19;
            this.textBox_count_segments.TextChanged += new System.EventHandler(this.textBox_count_segments_TextChanged);
            // 
            // button_add_segments
            // 
            this.button_add_segments.Location = new System.Drawing.Point(1140, 762);
            this.button_add_segments.Name = "button_add_segments";
            this.button_add_segments.Size = new System.Drawing.Size(532, 34);
            this.button_add_segments.TabIndex = 20;
            this.button_add_segments.Text = "Ввести интервалы";
            this.button_add_segments.UseVisualStyleBackColor = true;
            this.button_add_segments.Click += new System.EventHandler(this.button_add_segments_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1136, 818);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Уровень значимости:";
            // 
            // textBox_a_significance_level
            // 
            this.textBox_a_significance_level.Location = new System.Drawing.Point(1362, 812);
            this.textBox_a_significance_level.Name = "textBox_a_significance_level";
            this.textBox_a_significance_level.Size = new System.Drawing.Size(310, 26);
            this.textBox_a_significance_level.TabIndex = 22;
            this.textBox_a_significance_level.Text = "0,05";
            this.textBox_a_significance_level.TextChanged += new System.EventHandler(this.textBox_a_significance_level_TextChanged);
            // 
            // dataGridView_q_probabilities
            // 
            this.dataGridView_q_probabilities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_q_probabilities.Location = new System.Drawing.Point(38, 886);
            this.dataGridView_q_probabilities.Name = "dataGridView_q_probabilities";
            this.dataGridView_q_probabilities.RowTemplate.Height = 28;
            this.dataGridView_q_probabilities.Size = new System.Drawing.Size(1074, 125);
            this.dataGridView_q_probabilities.TabIndex = 23;
            // 
            // button_compare_hypotheses
            // 
            this.button_compare_hypotheses.Location = new System.Drawing.Point(1148, 886);
            this.button_compare_hypotheses.Name = "button_compare_hypotheses";
            this.button_compare_hypotheses.Size = new System.Drawing.Size(524, 70);
            this.button_compare_hypotheses.TabIndex = 24;
            this.button_compare_hypotheses.Text = "Сравнить";
            this.button_compare_hypotheses.UseVisualStyleBackColor = true;
            this.button_compare_hypotheses.Click += new System.EventHandler(this.button_compare_hypotheses_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(1148, 985);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(524, 26);
            this.textBox_result.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 1062);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.button_compare_hypotheses);
            this.Controls.Add(this.dataGridView_q_probabilities);
            this.Controls.Add(this.textBox_a_significance_level);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_add_segments);
            this.Controls.Add(this.textBox_count_segments);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView_segments);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_D);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chart_IFR);
            this.Controls.Add(this.dataGridView_characteristics);
            this.Controls.Add(this.textBox_MaxDeviation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.textBoxProbability);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_characteristics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_IFR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_segments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_q_probabilities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProbability;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_MaxDeviation;
        private System.Windows.Forms.DataGridView dataGridView_characteristics;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_IFR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_D;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView_segments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_count_segments;
        private System.Windows.Forms.Button button_add_segments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_a_significance_level;
        private System.Windows.Forms.DataGridView dataGridView_q_probabilities;
        private System.Windows.Forms.Button button_compare_hypotheses;
        private System.Windows.Forms.TextBox textBox_result;
    }
}

