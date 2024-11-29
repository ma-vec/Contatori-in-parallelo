using System.Threading;
namespace Counter_parallelo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private string OttieniIdRadio() //salva il nome al monmento del clic fuori dal ciclo altrimenti verrebbe modificato a ogni clic
        {
            if (radioButton1.Checked)
            {
                return "radioButton1";
            }
            else if (radioButton2.Checked)
            {
                return "radioButton2";
            }
            else if (radioButton3.Checked)
            {
                return "radioButton3";
            }
            else
            {
                return null;
            }
        }

        private void threadPiu()
        {
            string NomeRadio;
            int valore;

            NomeRadio = OttieniIdRadio();
            while (true)
            {
                switch (NomeRadio)
                {
                    case "radioButton1":
                        valore = Convert.ToInt16(label1.Text);
                        Thread.Sleep(1000);
                        valore++;
                        Invoke(new Action(() => label1.Text = valore.ToString())); //l'uso di invoke permette di aggiornare UI dal flusso principale
                        break;
                    case "radioButton2":
                        valore = Convert.ToInt16(label2.Text);
                        Thread.Sleep(1000);
                        valore++;
                        Invoke(new Action(() => label2.Text = valore.ToString()));
                        break;
                    case "radioButton3":
                        valore = Convert.ToInt16(label3.Text);
                        Thread.Sleep(1000);
                        valore++;
                        Invoke(new Action(() => label3.Text = valore.ToString()));
                        break;

                    default:
                        MessageBox.Show("Seleziona un radio button", "Errore");
                        break;
                }

            }
        }

        private void threadMeno()
        {
            string NomeRadio;
            int valore;
            NomeRadio = OttieniIdRadio();
            while (true)
            {
                switch (NomeRadio)
                {
                    case "radioButton1":
                        valore = Convert.ToInt16(label1.Text);
                        Thread.Sleep(1000);
                        valore--;
                        Invoke(new Action(() => label1.Text = valore.ToString())); //l'uso di invoke permette di aggiornare UI dal flusso principale
                        break;
                    case "radioButton2":
                        valore = Convert.ToInt16(label2.Text);
                        Thread.Sleep(1000);
                        valore--;
                        Invoke(new Action(() => label2.Text = valore.ToString()));
                        break;
                    case "radioButton3":
                        valore = Convert.ToInt16(label3.Text);
                        Thread.Sleep(1000);
                        valore--;
                        Invoke(new Action(() => label3.Text = valore.ToString()));
                        break;

                    default:
                        MessageBox.Show("Seleziona un radio button", "Errore");
                        break;
                }

            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Thread plus = new Thread(threadPiu);
            plus.Start();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            Thread minus = new Thread(threadMeno);
            minus.Start();
        }
    }
}
