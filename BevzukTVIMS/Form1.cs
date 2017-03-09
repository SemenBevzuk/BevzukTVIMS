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
            //путь к картиночке, можно выпилить
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                experiment.p = double.Parse(textBoxProbability.Text);
                experiment.NumberOfExperiments = int.Parse(textBoxAmount.Text);
                experiment.Run();

               
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.RowCount = 2;
                dataGridView1.ColumnCount = experiment.ListRandomVariables.Count;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].HeaderText=experiment.ListRandomVariables[i].value.ToString();
                }
                dataGridView1.Rows[0].HeaderCell.Value = "Встретилось";
                dataGridView1.Rows[1].HeaderCell.Value = "Вероятность";

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                     dataGridView1.Rows[0].Cells[i].Value = experiment.ListRandomVariables[i].count;
                     dataGridView1.Rows[1].Cells[i].Value = experiment.ListRandomVariables[i].probability;
                }
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

                chart1.Series.Clear();
                Series mySeriesOfPoint = new Series("Func");
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                mySeriesOfPoint.Points.AddXY(0, 0);
                for (int i = 0; i<experiment.ListRandomVariables.Count; i++)
                {
                    mySeriesOfPoint.Points.AddXY(experiment.ListRandomVariables[i].value, experiment.ListRandomVariables[i].probability);
                }
                //Добавляем созданный набор точек в Chart
                chart1.Series.Add(mySeriesOfPoint);
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
            experiment.Clear();
            chart1.Series.Clear();
        }
    }
}
