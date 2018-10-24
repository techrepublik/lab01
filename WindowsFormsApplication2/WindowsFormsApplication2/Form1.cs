using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2.dat;
using System.Threading;
using WindowsFormsApplication2.model;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private Thread t1;
        private Thread t2;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t1.Start();
        }

        void DisplayPersons() //this is a method to display persons from database
        {
            using (var d = new AdventureWorks2014Entities())
            {
                //var listPerson = d.People.ToList();
                var listPerson = d.People.Take(200).ToList();
                    
                 var i = 0;
                foreach (var person in listPerson)
                {
                    if (listBox1.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(DisplayPersons));
                    }
                    else
                    {
                        listBox1.Items.Add(String.Format("{0}, {1} {2}", 
                            person.LastName, person.FirstName, person.MiddleName));
                        i += 1;
                        label2.Text = i.ToString();
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
            }
        }

        private void DisplayEmps() //this is a method to display persons from database
        {
            Emp emp = new Emp();
            var listEmps = emp.GetEmployees();
            foreach (var e in listEmps)
            {
                if (listBox2.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(DisplayEmps));
                }
                else
                {
                    listBox2.Items.Add(String.Format("({0}, {1} {2})  {3}-{4}", 
                        e.LastName, e.FirstName, e.MiddleName, e.NationalIdNumber, e.JobTitle));
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            t1 = new Thread(DisplayPersons);
            t2 = new Thread(DisplayEmps);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //t2 = new Thread(DisplayEmps);
            t2.Start();

        }
    }
}
