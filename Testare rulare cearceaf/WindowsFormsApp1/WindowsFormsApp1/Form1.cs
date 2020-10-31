using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double getComutation(int age_beg, int dur_years)
        {
            dataGridView2.Rows.Add(100);
            string gender = "m";

            int freq_payment = 1, si_suminsured = 1000;
            double tir = 2.75 / 100.00, beta = 12.00 / 100.00, gamma = 1.00 / 100.00;
            double alpha1 = Math.Min(3.60 / 100 * dur_years, 72.00 / 100);
            double alpha2 = Math.Min(1.20 / 100 * dur_years, 24.00 / 100);
            double alpha3 = Math.Min(0.60 / 100 * dur_years, 12.00 / 100);
            double alpha0 = 3.60 / 100.00;
            double alpha_max = 72.00 / 100.00;
            string ind_partener = "Yes";
            double lambda = 68.00 / 100.00, bonus_pc = 10.00 / 100.00, bonus_dur_min = 10.00, dcx = 1.00, surr_tax = 10.00 / 100.00, surr_wait_period_m = 24.00, paidup_tax = 2.00, paidup_wait_period_m = 12.00;
            double[] qx_table_1 = { 0.915, 0.068628, 0.042417, 0.02728, 0.020213, 0.02426, 0.0182, 0.019214, 0.017195, 0.020233, 0.02226, 0.020241, 0.025307, 0.022276, 0.032408, 0.036471, 0.041551, 0.041569, 0.053757, 0.054801, 0.060924, 0.057913, 0.062013, 0.067137, 0.065147, 0.056022, 0.06013, 0.050988, 0.059176, 0.063295, 0.072529, 0.076671, 0.082868, 0.088056, 0.104531, 0.114899, 0.123248, 0.137796, 0.152403, 0.171199, 0.181824, 0.202855, 0.236453, 0.264042, 0.283502, 0.33657, 0.40378, 0.420159, 0.451541, 0.526886, 0.593751, 0.664977, 0.711605, 0.786415, 0.876086, 0.956927, 1.001957, 1.095686, 1.177492, 1.257396, 1.368212, 1.442964, 1.5869, 1.66999, 1.784204, 1.886291, 2.036179, 2.23139, 2.437348, 2.61707, 2.880372, 3.068067, 3.391261, 3.781768, 4.11201, 4.557215, 4.973247, 5.692179, 6.148432, 6.837715, 7.545335, 8.381227, 9.422882, 10.562301, 11.628443, 12.755882, 13.988375, 15.299379, 16.672533, 18.128696, 19.657752, 21.256556, 22.944135, 24.678074, 26.510539, 28.393882, 30.396084, 32.41688, 34.531694, 36.705202, 100 };
            double[] qx_vector_used = { };
            qx_vector_used = new double[qx_table_1.Length];
            for (int i = 0; i < qx_table_1.Length; i++)
            {
                qx_vector_used[i] = qx_table_1[i] / 100;

            }

            double alpha = Math.Min(alpha0 * dur_years, alpha_max);



            double[] durata = { };
            durata = new double[qx_vector_used.Length];

            double[] indice= { };
            indice = new double[qx_vector_used.Length];
            

            
            for(int i=1;i<=59;i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i;
            }    
            
            
            for (int i = 1; i <= 59; i++)
            {
                if (i == 1)
                {


                    dataGridView2.Rows[0].Cells[0].Value = i;
                    dataGridView2.Rows[0].Cells[1].Value = i - 1;
                    dataGridView2.Rows[0].Cells[2].Value = Convert.ToInt32(dataGridView1.Rows[age_beg].Cells[0].Value) + i - 1;
                    dataGridView2.Rows[0].Cells[3].Value = qx_vector_used[Convert.ToInt32(dataGridView1.Rows[age_beg].Cells[0].Value)];//aici ramane fara -i din cauza for-ului
                    dataGridView2.Rows[0].Cells[4].Value = 1;
                    dataGridView2.Rows[0].Cells[5].Value = 1;
                    dataGridView2.Rows[0].Cells[6].Value = Math.Round(Math.Pow(1 / (1 + tir), 1.00), 8);
                    dataGridView2.Rows[0].Cells[7].Value = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[4].Value) * Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[5].Value);
                    dataGridView2.Rows[0].Cells[8].Value = Math.Round(Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[4].Value) * Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[6].Value) * Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[3].Value), 8);
                    dataGridView2.Rows[0].Cells[17].Value = alpha1;
                }
                if (i > 1)
                {
                    dataGridView2.Rows[i - 1].Cells[0].Value = i;
                    dataGridView2.Rows[i - 1].Cells[1].Value = i - 1;
                    dataGridView2.Rows[i - 1].Cells[2].Value = Convert.ToInt32(dataGridView1.Rows[age_beg].Cells[0].Value) + i - 1;
                    Console.WriteLine(Convert.ToInt32(dataGridView1.Rows[age_beg].Cells[0].Value));
                   dataGridView2.Rows[i - 1].Cells[3].Value = qx_vector_used[Convert.ToInt32(dataGridView1.Rows[age_beg].Cells[0].Value)];
                   
                   dataGridView2.Rows[i - 1].Cells[4].Value = Math.Round((1 - qx_vector_used[i-2]) * Convert.ToDouble(dataGridView2.Rows[i - 2].Cells[4].Value), 8);
                    dataGridView2.Rows[i - 1].Cells[5].Value = Math.Pow((1 / (1 + tir)), (i - 1));
                    dataGridView2.Rows[i - 1].Cells[6].Value = Math.Round(Math.Pow(1 / (1 + tir), (i + dcx - 1)), 8);
                    dataGridView2.Rows[i - 1].Cells[7].Value = Math.Round((Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[4].Value) * Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[5].Value)), 8);
                    dataGridView2.Rows[i - 1].Cells[8].Value = Math.Round(Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[4].Value) * Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[6].Value) * Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[3].Value), 8);
                    if (i == 2)
                    {
                        dataGridView2.Rows[i - 1].Cells[17].Value = alpha2 * Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[7].Value);
                    }
                    if (i == 3)
                    {
                        dataGridView2.Rows[i - 1].Cells[17].Value = alpha3 * Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[7].Value);
                    }
                    if (i != 2 && i != 3)
                    {
                        dataGridView2.Rows[i - 1].Cells[17].Value = 0;
                    }
                }
            }
            double sum_alpha;
            sum_alpha = Convert.ToDouble(dataGridView2.Rows[2].Cells[18].Value);
            for (int i = 1; i <= dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[2].Cells[18].Value = Convert.ToDouble(dataGridView2.Rows[0].Cells[17].Value) + Convert.ToDouble(dataGridView2.Rows[1].Cells[17].Value) + Convert.ToDouble(dataGridView2.Rows[2].Cells[17].Value);

            }

            for (int i = 0; i <= dur_years; i++)
            {
                dataGridView2.Rows[i].Cells[10].Value = Convert.ToDouble(dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[7].Value);
                dataGridView2.Rows[i].Cells[12].Value = Convert.ToDouble(dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[8].Value);
                
                
               
                dataGridView2.Rows[i].Cells[14].Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[10].Value) / Convert.ToDouble(dataGridView2.Rows[i].Cells[7].Value);
                dataGridView2.Rows[i].Cells[15].Value = (Convert.ToDouble(dataGridView2.Rows[i].Cells[11].Value) - Convert.ToDouble(dataGridView2.Rows[i].Cells[12].Value)) / Convert.ToDouble(dataGridView2.Rows[i].Cells[7].Value);
                dataGridView2.Rows[i].Cells[16].Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[14].Value) + Convert.ToDouble(dataGridView2.Rows[i].Cells[15].Value);
            

            }
            
            for (int i = dur_years - 1; i >= 0; i--)
            {
                dataGridView2.Rows[dur_years].Cells[9].Value = Convert.ToDouble(dataGridView2.Rows[dur_years].Cells[7].Value);
                dataGridView2.Rows[i].Cells[9].Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[7].Value) + Convert.ToDouble(dataGridView2.Rows[i + 1].Cells[9].Value);

                dataGridView2.Rows[dur_years].Cells[11].Value = Convert.ToDouble(dataGridView2.Rows[dur_years].Cells[8].Value);
                dataGridView2.Rows[i].Cells[11].Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value) + Convert.ToDouble(dataGridView2.Rows[i + 1].Cells[11].Value);

            }
            for(int i=0;i<=dur_years;i++)
                dataGridView2.Rows[i].Cells[13].Value = (Convert.ToDouble(dataGridView2.Rows[i].Cells[9].Value) - Convert.ToDouble(dataGridView2.Rows[i].Cells[10].Value)) / Convert.ToDouble(dataGridView2.Rows[i].Cells[7].Value);
            return (sum_alpha);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(59);
            

            string gender = "m";

           for (int age_beg = 0; age_beg <59; age_beg++)
            {
                for (int dur_years = 1; dur_years < 30; dur_years++)
                {
                    double sum_alpha = getComutation(age_beg, dur_years);


                    int freq_payment = 1, si_suminsured = 1000;
                    double tir = 2.75 / 100.00, beta = 12.00 / 100.00, gamma = 1.00 / 100.00;
                    double alpha1 = Math.Min(3.60 / 100 * dur_years, 72.00 / 100);
                    double alpha2 = Math.Min(1.20 / 100 * dur_years, 24.00 / 100);
                    double alpha3 = Math.Min(0.60 / 100 * dur_years, 12.00 / 100);
                    double alpha0 = 3.60 / 100.00;
                    double alpha_max = 72.00 / 100.00;
                    string ind_partener = "Yes";
                    double lambda = 68.00 / 100.00, bonus_pc = 10.00 / 100.00, bonus_dur_min = 10.00, dcx = 1.00, surr_tax = 10.00 / 100.00, surr_wait_period_m = 24.00, paidup_tax = 2.00, paidup_wait_period_m = 12.00;
                    double[] qx_table_1 = { 0.915, 0.068628, 0.042417, 0.02728, 0.020213, 0.02426, 0.0182, 0.019214, 0.017195, 0.020233, 0.02226, 0.020241, 0.025307, 0.022276, 0.032408, 0.036471, 0.041551, 0.041569, 0.053757, 0.054801, 0.060924, 0.057913, 0.062013, 0.067137, 0.065147, 0.056022, 0.06013, 0.050988, 0.059176, 0.063295, 0.072529, 0.076671, 0.082868, 0.088056, 0.104531, 0.114899, 0.123248, 0.137796, 0.152403, 0.171199, 0.181824, 0.202855, 0.236453, 0.264042, 0.283502, 0.33657, 0.40378, 0.420159, 0.451541, 0.526886, 0.593751, 0.664977, 0.711605, 0.786415, 0.876086, 0.956927, 1.001957, 1.095686, 1.177492, 1.257396, 1.368212, 1.442964, 1.5869, 1.66999, 1.784204, 1.886291, 2.036179, 2.23139, 2.437348, 2.61707, 2.880372, 3.068067, 3.391261, 3.781768, 4.11201, 4.557215, 4.973247, 5.692179, 6.148432, 6.837715, 7.545335, 8.381227, 9.422882, 10.562301, 11.628443, 12.755882, 13.988375, 15.299379, 16.672533, 18.128696, 19.657752, 21.256556, 22.944135, 24.678074, 26.510539, 28.393882, 30.396084, 32.41688, 34.531694, 36.705202, 100 };
                    double[] qx_vector_used = { };
                    qx_vector_used = new double[qx_table_1.Length];
                    for (int i = 0; i < qx_table_1.Length; i++)
                    {
                        qx_vector_used[i] = qx_table_1[i] / 100;

                    }

                    double alpha = Math.Min(alpha0 * dur_years, alpha_max);



                    double[] durata = { };
                    durata = new double[qx_vector_used.Length];
                    //double sum_alpha;
                    // sum_alpha = Convert.ToDouble(dataGridView2.Rows[2].Cells[18].Value);


                    


                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //                                                           DECLARARE  VARIABILE                                                                                       //
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////







                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //                                                            NUMERE DE COMUTATIE                                                                                       //
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////






                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //                                                           GENERARE TARIF                                                                                             //
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////









                    double P_gross_y_pc = Math.Round(Convert.ToDouble(dataGridView2.Rows[0].Cells[16].Value) / ((1 - gamma - beta) * Convert.ToDouble(dataGridView2.Rows[0].Cells[13].Value) - sum_alpha), 8);
                    double P_gross_y_amount = P_gross_y_pc * si_suminsured * 1;
                    double P_gross_bonus_amount = si_suminsured * (lambda * bonus_pc * Convert.ToDouble(dataGridView2.Rows[0].Cells[14].Value)) / ((1 - beta - gamma) * Convert.ToDouble(dataGridView2.Rows[0].Cells[13].Value) - sum_alpha);






                        if (age_beg < 29)
                        {

                                    dataGridView1.Rows[Convert.ToInt32(dataGridView1.Rows[age_beg].Cells[0].Value)].Cells[dur_years].Value = P_gross_y_amount + P_gross_bonus_amount;


                        }
                        if (age_beg >= 29)
                        {
                            for (dur_years = 0; dur_years < 59 - age_beg; dur_years++)
                               dataGridView1.Rows[Convert.ToInt32(dataGridView1.Rows[age_beg].Cells[0].Value)].Cells[dur_years].Value = P_gross_y_amount + P_gross_bonus_amount;
                        }



                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                     dataGridView1.Rows[i].Cells[0].Value = i+16;

                        for (int j = 0; j < 30; j++)
                            if (dataGridView1.Rows[i].Cells[j].Value == null)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = 999;
                            }

                    }



                    dataGridView1.ReadOnly = true;
                    button1.Enabled = false;
                    button1.BackColor = System.Drawing.SystemColors.Window;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
