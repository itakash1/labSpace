using lab04;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
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

        private void BinaryAcceptButton_Click(object sender, EventArgs e)
        {
            string[] vectorEls = BinaryInput.Text.Split(' ');
            ArrayVector vector = new ArrayVector(vectorEls.Length);
            try
            {
                for (int i = 0; i < vector.Length; i++) 
                {
                    vector[i] = int.Parse(vectorEls[i]);
                }
                FileStream inpStream = new FileStream("forVector.bin", FileMode.OpenOrCreate);
                Vectors.OutputVector(vector, inpStream);
                inpStream.Close();
                BinaryInput.Text = "";
            }
            catch
            {
                MessageBox.Show("Некорректный ввод!");
            }

        }

        private void OutputBinaryButton_Click(object sender, EventArgs e)
        {
            FileStream outStream = new FileStream("forVector.bin", FileMode.OpenOrCreate);
            string vecInString = Vectors.InputVector(outStream).ToString();
            BinaryOutput.Text = vecInString;
        }

        private void TextInputButton_Click(object sender, EventArgs e)
        {
            string[] vectorEls = TextInput.Text.Split(' ');
            ArrayVector vector = new ArrayVector(vectorEls.Length);
            try
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i] = int.Parse(vectorEls[i]);
                }
                FileStream inpStream = new FileStream("forVector.txt", FileMode.OpenOrCreate);
                StreamWriter print = new StreamWriter(inpStream);
                Vectors.WriteVector(vector, print);
                inpStream.Close();
                TextInput.Text = "";
            }
            catch
            {
                MessageBox.Show("Некорректный ввод!");
            }
        }

        private void TextOutputButton_Click(object sender, EventArgs e)
        {
            FileStream inpStream = new FileStream("forVector.txt", FileMode.OpenOrCreate);
            StreamReader print = new StreamReader(inpStream);
            IVectorable vec = Vectors.ReadVector(print);
            TextOutput.Text = vec.ToString();
        }

        private void SerializeInputButton_Click(object sender, EventArgs e)
        {
            string[] vectorEls = SerializeInput.Text.Split(' ');
            ArrayVector vector = new ArrayVector(vectorEls.Length);
            try
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i] = int.Parse(vectorEls[i]);
                }
                FileStream inpStream = new FileStream("forVector.json", FileMode.OpenOrCreate);
                StreamWriter streamWriter = new StreamWriter(inpStream);
                string serializedVector = JsonSerializer.Serialize(vector);
                streamWriter.Write(serializedVector);
                streamWriter.Close();
                inpStream.Close();
                SerializeInput.Text = "";
            }
            catch
            {
                MessageBox.Show("Некорректный ввод!");
            }
        }

        private void SerializeOutputButton_Click(object sender, EventArgs e)
        {
            FileStream inpStream = new FileStream("forVector.json", FileMode.OpenOrCreate);
            ArrayVector vec = JsonSerializer.Deserialize<ArrayVector>(inpStream);
            SerializeOutput.Text = vec.ToString();
        }

        private void BinaryInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
