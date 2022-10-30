using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Serialization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClearInput();
        }

        private void ClearInput()
        {
            textBox1.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            numericUpDown1.Value = 0; 
            comboBox2.SelectedIndex = 4;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            User user = new User(textBox1.Text, comboBox1.SelectedIndex, (int)numericUpDown1.Value);
            
            ListViewItem LVI = new ListViewItem(user.Name);
            LVI.Tag = user;

            listView1.Items.Add(LVI);

            ClearInput();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                User user = (User)listView1.SelectedItems[0].Tag;
                if(user != null)
                {
                    textBox1.Text = user.Name;
                    comboBox1.SelectedIndex = user.Sex;
                    numericUpDown1.Value = user.Age;
                }
            }
            else if(listView1.SelectedItems.Count == 0)
            {
                ClearInput();
            }
        }



        public void Arr()
        {

            XmlSerializer xml = new XmlSerializer(typeof(User[]));

            User[] arr = new User[5];
            string path = @"..\..\..\For-array.txt";
            using (FileStream fs = new FileStream(@"..\..\..\UserArray.xml", FileMode.OpenOrCreate))
            {
                string[] str = File.ReadAllLines(path);
                for (int i = 0; i < str.Length; i += 3)
                {
                    arr[i/3] = new User(str[i], int.Parse(str[i + 1]), int.Parse(str[i + 2]));
                }
                xml.Serialize(fs, arr);
            }
            using (FileStream fs = new FileStream(@"..\..\..\UserArray.xml", FileMode.OpenOrCreate))
            {
                User[] UserDes = (User[])xml.Deserialize(fs);
                File.AppendAllText(path, "\nAfter serialization and diserialization:");

                foreach (var item in UserDes)
                {
                    File.AppendAllText(path, $"\nName: {item.Name}\nSex : {item.Sex}\nAge : {item.Age}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            foreach (ListViewItem item in listView1.Items)
            {
                if(item.Tag != null)
                {
                    users.UserList.Add((User)item.Tag);
                }
            }

            CheckType(users);
        }

        private void Add(User user)
        {
            ListViewItem LVI = new ListViewItem(user.Name);
            LVI.Tag = user;

            listView1.Items.Add(LVI);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Users users = CheckTypeDes();

            ClearInput();
            foreach (User user in users.UserList)
            {
                Add(user);
            }
        }
        private void CheckType(Users users)
        {
            if(comboBox2.SelectedIndex == 0)
                SerializeJSON(users);
            else if (comboBox2.SelectedIndex == 2)
                SerializeXML(users);
            else if (comboBox2.SelectedIndex == 1)
               SerializeSOAP(users);
            else
                SerializeBinary(users);
        }
        private Users CheckTypeDes()
        {
            if (comboBox2.SelectedIndex == 0)
                return DeserializationJSON();
            else if (comboBox2.SelectedIndex == 2)
                return DeserializeXML();
            else if (comboBox2.SelectedIndex == 1)
                return DeserializationSOAP();
            else
                return DeserializationBinary();
        }

        // array 
        private void button4_Click(object sender, EventArgs e) => Arr();
        // 3 Task
        private void button5_Click(object sender, EventArgs e) => XMLSelector();
        // 4 Task
        private void button6_Click(object sender, EventArgs e) => LinqToXML();















        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
