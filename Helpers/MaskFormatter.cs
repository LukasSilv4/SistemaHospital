using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Tela_PI.Helpers
{
    public static class MaskFormatter
    {

        public static void ApplyCpfMask(this TextBox textBox)
        {
            // Configuração inicial do placeholder
            textBox.ForeColor = Color.Gray;
            textBox.Text = "___.___.___-__";
            if (string.IsNullOrWhiteSpace(textBox.Text.Replace("_", "").Replace(".", "").Replace("-", "")))
            {
                // Aplica placeholder apenas se não foi digitado nada
            }

            textBox.MaxLength = 14;


            textBox.TextChanged += (sender, e) =>
            {


                var currentTextBox = (TextBox)sender;     // 2 ERROS : textBox não pode ser declarado nesse escopo / sender não existe no constexto atual
                if (textBox.Text == "___.___.___-__" || textBox.ForeColor == Color.Gray)
                    return;
                int cursorPos = textBox.SelectionStart;
                bool isDeleting = cursorPos < textBox.Text.Length;

                // Remove tudo que não é número
                string numbersOnly = new string(currentTextBox.Text.Where(char.IsDigit).ToArray());

                // Limita a 11 dígitos
                if (numbersOnly.Length > 11)
                {
                    numbersOnly = numbersOnly.Substring(0, 11);
                }

                //formatação desejada =  123.456.789-10
                string formattedText = numbersOnly.Substring(0);
                if (numbersOnly.Length <= 3)
                {
                    formattedText = numbersOnly;
                }
                else if (numbersOnly.Length <= 6)
                {
                    formattedText = $"{numbersOnly.Substring(0, 3)} {numbersOnly.Substring(3)}";
                }
                else if (numbersOnly.Length <= 9)
                {
                    formattedText = $"{numbersOnly.Substring(0, 3)}.{numbersOnly.Substring(3, 3)}.{numbersOnly.Substring(6)}";
                }
                else if (numbersOnly.Length <= 11)
                {
                    formattedText = $"{numbersOnly.Substring(0, 3)}.{numbersOnly.Substring(3, 3)}.{numbersOnly.Substring(6, 3)}-{numbersOnly.Substring(9)}";
                }
                else
                {
                    textBox.Text = numbersOnly.Substring(0, 11);
                }
                textBox.ForeColor = SystemColors.WindowText;

               
                if (currentTextBox.Text != formattedText) 
                {
                    currentTextBox.Text = formattedText;
                    currentTextBox.SelectionStart = cursorPos <= formattedText.Length ? cursorPos : formattedText.Length;
                    if (isDeleting)
                    {
                        textBox.SelectionStart = cursorPos;
                    }
                    else
                    {
                        // Avança o cursor após pontos/traço
                        if (numbersOnly.Length == 3 || numbersOnly.Length == 6)
                            textBox.SelectionStart = cursorPos + 1;
                        else if (numbersOnly.Length == 9)
                            textBox.SelectionStart = cursorPos + 2;
                        else
                            textBox.SelectionStart = cursorPos + 1;
                    }
                }   
                
            };
            textBox.Enter += (sender, e) =>
            {
                var tb = (TextBox)sender;
                if (tb.Text == "___.___.___-__")
                {
                    tb.Text = "";
                    tb.ForeColor = SystemColors.WindowText;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                var tb = (TextBox)sender;
                if (string.IsNullOrWhiteSpace(tb.Text.Replace(".", "").Replace("-", "")))
                {
                    tb.Text = "___.___.___-__";
                    tb.ForeColor = Color.Gray;
                }
            };

        }
    }
}