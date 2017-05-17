using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BevzukTVIMS
{
    public partial class Form1 : Form
    {
        Experiment experiment = new Experiment();
        public Form1()
        {
            InitializeComponent();
            //pictureBox1.Load("C://Projects//BevzukTVIMS//BevzukTVIMS//image.jpg");
            //инициализация таблицы характеристик
            dataGridView_characteristics.Rows.Clear();
            dataGridView_characteristics.Columns.Clear();
            dataGridView_characteristics.RowCount = 1;
            dataGridView_characteristics.ColumnCount = 8;
            dataGridView_characteristics.Columns[0].HeaderText = "E(\u03B7)";
            dataGridView_characteristics.Columns[1].HeaderText = "x";
            dataGridView_characteristics.Columns[2].HeaderText = "| E(\u03B7) - x |";
            dataGridView_characteristics.Columns[3].HeaderText = "D(\u03B7)";
            dataGridView_characteristics.Columns[4].HeaderText = "S^2";
            dataGridView_characteristics.Columns[5].HeaderText = "| D(\u03B7) - S^2 |";
            dataGridView_characteristics.Columns[6].HeaderText = "Me";
            dataGridView_characteristics.Columns[7].HeaderText = "R";
            dataGridView_characteristics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_characteristics.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                experiment.p = double.Parse(textBoxProbability.Text);
                experiment.NumberOfExperiments = int.Parse(textBoxAmount.Text);
                experiment.Run();

                //инициализация таблицы вероятностей
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.RowCount = 3;
                dataGridView1.ColumnCount = experiment.ListRandomVariables.Count;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].HeaderText = experiment.ListRandomVariables[i].value.ToString();
                }
                dataGridView1.Rows[0].HeaderCell.Value = "Произошло";
                dataGridView1.Rows[1].HeaderCell.Value = "Частота";
                dataGridView1.Rows[2].HeaderCell.Value = "Вероятность";

                //заполнение таблицы вероятностей
                double maxDeviation = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Rows[0].Cells[i].Value = experiment.ListRandomVariables[i].count;
                    dataGridView1.Rows[1].Cells[i].Value = experiment.ListRandomVariables[i].frequency;
                    dataGridView1.Rows[2].Cells[i].Value = experiment.ListRandomVariables[i].probability;
                    //поиск максимального отклонения
                    double temp = Math.Abs(experiment.ListRandomVariables[i].frequency - experiment.ListRandomVariables[i].probability);
                    if (temp > maxDeviation)
                    {
                        maxDeviation = temp;
                    }
                }
                experiment.M = maxDeviation;

                //заполнение таблицы характеристик
                dataGridView_characteristics.Rows.Clear();
                dataGridView_characteristics.Rows[0].Cells[0].Value = Convert.ToString(experiment.expected_value);
                dataGridView_characteristics.Rows[0].Cells[1].Value = Convert.ToString(experiment.selective_mean);
                dataGridView_characteristics.Rows[0].Cells[2].Value = Convert.ToString(Math.Abs(experiment.expected_value - experiment.selective_mean));
                dataGridView_characteristics.Rows[0].Cells[3].Value = Convert.ToString(experiment.dispersion);
                dataGridView_characteristics.Rows[0].Cells[4].Value = Convert.ToString(experiment.selective_dispersion);
                dataGridView_characteristics.Rows[0].Cells[5].Value = Convert.ToString(Math.Abs(experiment.dispersion - experiment.selective_dispersion));
                dataGridView_characteristics.Rows[0].Cells[6].Value = Convert.ToString(experiment.selective_median);
                dataGridView_characteristics.Rows[0].Cells[7].Value = Convert.ToString(experiment.R);

                textBox_MaxDeviation.Text = Convert.ToString(maxDeviation);

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                dataGridView_characteristics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_characteristics.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                //график 
                chart1.Series.Clear();
                Series mySeriesOfPoint = new Series("Func");
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                mySeriesOfPoint.Points.AddXY(0, 0);
                for (int i = 0; i < experiment.ListRandomVariables.Count; i++)
                {
                    mySeriesOfPoint.Points.AddXY(experiment.ListRandomVariables[i].value, experiment.ListRandomVariables[i].frequency);
                }
                //Добавляем созданный набор точек в Chart
                chart1.Series.Add(mySeriesOfPoint);

                //график ИФР
                chart_IFR.Series.Clear();
                Series SeriesOfPoints_Calculated = new Series("ИНФ расчётная");
                SeriesOfPoints_Calculated.ChartType = SeriesChartType.Line;
                SeriesOfPoints_Calculated.Points.AddXY(0, 0);
                SeriesOfPoints_Calculated.Color = Color.Red;
                SeriesOfPoints_Calculated.BorderWidth = 3;
                double func_value = 0;
                for (int i = 0; i < experiment.ListRandomVariables.Count; i++)
                {
                    SeriesOfPoints_Calculated.Points.AddXY(i + 1, func_value);
                    func_value += experiment.ListRandomVariables[i].frequency;
                    SeriesOfPoints_Calculated.Points.AddXY(i + 1, func_value);
                }
                SeriesOfPoints_Calculated.Points.AddXY(experiment.ListRandomVariables.Count + 1, func_value);
                chart_IFR.Series.Add(SeriesOfPoints_Calculated);

                Series SeriesOfPoints_Expected = new Series("ИНФ теоретическая");
                SeriesOfPoints_Expected.ChartType = SeriesChartType.Line;
                SeriesOfPoints_Expected.Points.AddXY(0, 0);
                SeriesOfPoints_Expected.Color = Color.ForestGreen;
                SeriesOfPoints_Expected.BorderWidth = 2;
                func_value = 0;
                for (int i = 0; i < experiment.ListRandomVariables.Count; i++)
                {
                    SeriesOfPoints_Expected.Points.AddXY(i + 1, func_value);
                    func_value += experiment.ListRandomVariables[i].probability;
                    SeriesOfPoints_Expected.Points.AddXY(i + 1, func_value);
                }
                SeriesOfPoints_Expected.Points.AddXY(experiment.ListRandomVariables.Count + 1, func_value);
                chart_IFR.Series.Add(SeriesOfPoints_Expected);
                textBox_D.Text = Convert.ToString(experiment.D);
            }
            catch
            {
                MessageBox.Show("Введите данные корректно");
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            dataGridView_characteristics.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView_q_probabilities.Rows.Clear();
            dataGridView_q_probabilities.Columns.Clear();
            dataGridView_q_probabilities.Refresh();

            dataGridView_segments.Rows.Clear();
            dataGridView_segments.Columns.Clear();
            dataGridView_segments.Refresh();

            textBox_MaxDeviation.Text = "";
            textBox_D.Text = "";
            experiment.Clear();
            chart1.Series.Clear();
            chart_IFR.Series.Clear();
        }

        private void textBox_count_segments_TextChanged(object sender, EventArgs e)
        {
            DataTable table_intervals = new DataTable();
            DataView view;
            int columnCount;
            if (Int32.TryParse(textBox_count_segments.Text, out columnCount))
            {
                experiment.z_count_intervals = columnCount;
                for (int i = 1; i < columnCount; i++)
                {
                    table_intervals.Columns.Add("z_" + (i).ToString());
                }
                DataRow str1 = table_intervals.NewRow();
                table_intervals.Rows.Add(str1);
                view = new DataView(table_intervals);
                dataGridView_segments.DataSource = view;
                experiment.z_interval_boundaries = new double[columnCount - 1];
            }
        }

        private void button_add_segments_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < experiment.z_interval_boundaries.Length; i++)
            {
                experiment.z_interval_boundaries[i] =
                    Convert.ToInt32(dataGridView_segments.CurrentRow.Cells[i].Value);
            }

            DataTable table = new DataTable();
            DataView view;
            experiment.FindProbability_q();
            int columnCount = experiment.z_count_intervals +1;
            table.Columns.Add(" ");
            table.Columns.Add("(-oo; z_1)");
            for (int i = 1; i < experiment.z_count_intervals-1; i++)
            {
                table.Columns.Add("[z_" + i +";" + "z_" + (i+1) +")");
            }
            table.Columns.Add("[z_" + (experiment.z_count_intervals-1) + ";+oo)");
            DataRow str = table.NewRow();
            str[0] = "q:";
            for (int i = 1; i < columnCount; i++)
            {
                str[i] = experiment.q[i-1];
            }
            table.Rows.Add(str);
            view = new DataView(table);
            dataGridView_q_probabilities.DataSource = view;
        }

        private void textBox_a_significance_level_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBox_a_significance_level.Text, out experiment.a_significance_level);
        }

        private void button_compare_hypotheses_Click(object sender, EventArgs e)
        {
            textBox_result.Clear();
            textBox_result.AppendText(experiment.TestHypothesis().ToString());
        }
    }
}
