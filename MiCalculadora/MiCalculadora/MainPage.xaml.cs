using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

/*Alumnos: Rogelio Zuñiga Estrada               010127169
           Francisco Raul Alvarado Romero       010113251
           Daniel Ayala Domínguez               010125921
 */
namespace MiCalculadora
{
    public partial class MainPage : ContentPage
    {
        private string operacion;
        private double num1;
        private double num2;
        private double memoria;
        private double resultado;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnNum_Clicked(object sender, EventArgs e)
        {
            Button botonDigto = (Button)sender;
            if(resultado !=0 || lblScreen.Text == "Error")
            {
                lblScreen.Text = "0";
            }

            if (lblScreen.Text == "0")
            {
                lblScreen.Text = "";
                resultado = 0;
            }

            if(botonDigto.Text != ".")
            {
                lblScreen.Text = lblScreen.Text + botonDigto.Text;
            }else if (!lblScreen.Text.Contains("."))
            {
                lblScreen.Text = lblScreen.Text + ".";
            }
        }

        private void btnOperacion_Clicked(object sender, EventArgs e)
        {
            var botonOp = (Button)sender;

            switch (botonOp.Text)
            {
                case "+":
                    operacion = "suma";
                    break;
                case "\u2212":
                    operacion = "resta";
                    break;
                case "x":
                    operacion = "multiplicacion";
                    break;
                case "\u00F7":
                    operacion = "division";
                    break;
            }
            num1 = Convert.ToDouble(lblScreen.Text);
            lblScreen.Text = "0";
        }

        private void btnIgual_Clicked(object sender, EventArgs e)
        {
            num2 = Convert.ToDouble(lblScreen.Text);
            switch (operacion)
            {
                case "suma":
                    resultado = num1 + num2;
                    break;
                case "resta":
                    resultado = num1 - num2;
                    break;
                case "multiplicacion":
                    resultado = num1 * num2;
                    break;
                case "division":
                    if(num1/num2 == 0)
                    {
                        lblScreen.Text = "No se puede dividir entre 0";
                    }
                    else
                    {
                        resultado = num1 / num2;
                    }
                    break;
            }
            lblScreen.Text = Convert.ToString(resultado);
        }

        private void btnInverso_Clicked(object sender, EventArgs e)
        {
            if(!lblScreen.Text.Equals("Error"))
            {
                num1 = Convert.ToDouble(lblScreen.Text);
                if (num1 != 0)
                {
                    resultado = 1 / num1;
                    lblScreen.Text = resultado.ToString();
                }
                else
                {
                    lblScreen.Text = "Error";
                }
            }
        }

        private void btnCuadrado_Clicked(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(lblScreen.Text);
            try
            {
                resultado = Math.Pow(num1, 2);
                lblScreen.Text = Convert.ToString(resultado);
            }
            catch (Exception ex)
            {
                lblScreen.Text = "Escriba un numero";
                Console.WriteLine("Error: " + ex.Message);
            }
            
        }

        private void btnRaiz_Clicked(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(lblScreen.Text);
            resultado = Math.Sqrt(num1);
            lblScreen.Text = Convert.ToString(resultado);
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            lblScreen.Text = "";
        }

        private void btnMS_Clicked(object sender, EventArgs e)
        {
            if(!lblScreen.Text.Equals("Error"))
            {
                memoria = Convert.ToDouble(lblScreen.Text);
                btnMR.IsEnabled = true;
            }
        }

        private void btnMR_Clicked(object sender, EventArgs e)
        {
            if(!lblScreen.Text.Equals("Error"))
            {
                lblScreen.Text = Convert.ToString(memoria);
            }
        }
    }

}

