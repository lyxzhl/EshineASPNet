using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
namespace csswrap
{
    public partial class main : Form
    {
        public string folderpath;

        public main()
        {
            InitializeComponent();
        }


        bool getfolderpath()
        {
            if (this.textBox1.Text == "")
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.textBox1.Text = folderpath = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    return false;
                }
            }
            else {
                folderpath = this.textBox1.Text;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(! getfolderpath()) return;
            

            //[customerName] [varchar](50) NULL,
            Regex r = new Regex(@"\[\w*\]");

            Match mch = Regex.Match(this.richTextBox3.Lines[0], @"dbo\]\.\[(?<tname>\w+)\]");
            string tname = mch.Groups["tname"].Value;//table name

            mch = Regex.Match(this.richTextBox3.Lines[1], @"\[(?<idname>\w+)\]");
            string idname=mch.Groups["idname"].Value;


            string s1, s2;
            StringBuilder sb1 = new StringBuilder();//model前部分
            StringBuilder sb2 = new StringBuilder();//model后部分
            StringBuilder sb3 = new StringBuilder();//sqlServerDal
            StringBuilder sb4 = new StringBuilder();//sqlServerDal
            StringBuilder sb5 = new StringBuilder();//sqlServerDal
            StringBuilder sb6 = new StringBuilder();//sqlServerDal
            StringBuilder sb7 = new StringBuilder();//interface
            StringBuilder sb8 = new StringBuilder();//bll
            StringBuilder sb9 = new StringBuilder();//sqlServerDal
            StringBuilder sb10 = new StringBuilder();//DALFactory



            sb1.Append("using System;\n\n");
            sb1.Append("namespace Model\n{\n");
            sb1.Append("public class " + tname + "\n{\n");
            sb1.Append("private int _" + idname + " = 0;\n");
            sb2.Append("public int " + idname + "{get { return _" + idname + "; }\n\tset { _" + idname + " = value; }}\n\n");

            sb3.Append("using System;\n");
            sb3.Append("using System.Text;\n");
            sb3.Append("using System.Data;\n\n");
            sb3.Append("namespace SQLServerDAL\n{\n");
            sb3.Append("public class sql_" + tname + ":IDAL." + tname + "Dal\n{\n");
            sb3.Append("DBunit.SQLAccess sql = new DBunit.SQLAccess();\n");
            sb3.Append("DateTime baddate = DateTime.Parse(\"1900-01-01\");\n");
            sb3.Append("public int Add(Model."+tname+" "+tname+")\n{\n");
            sb3.Append("StringBuilder strsql = new StringBuilder();\n");
            sb3.Append("strsql.Append(\"insert into " + tname + " values (\");\n");


            sb4.Append("public Model." + tname + " get" + tname + "(DataTable dt)\n{\n");
            sb4.Append("Model." + tname + " " + tname + " = new Model." + tname + "();\n");
            sb4.Append(tname + "." + idname + " = int.Parse( dt.Rows[0][\"" + idname + "\"].ToString());\n");

            sb7.Append("using System.Data;\n\n");
            sb7.Append("namespace IDAL\n{\n");
            sb7.Append("public interface " + tname + "Dal\n{\n");
            sb7.Append("int Add(Model." + tname + " " + tname + ");\n");


            sb8.Append("using System.Data;\n\n");
            sb8.Append("namespace Bll\n{\n");
            sb8.Append("public class " + tname + "Bll\n{\n");
            sb8.Append("IDAL." + tname + "Dal itu = DALFactory." + tname + "_Factory.Createusers();\n");
            sb8.Append("public int Add(Model." + tname + " " + tname + ")\n{\n");
            sb8.Append("return itu.Add(" + tname + ");\n}\n");


            sb9.Append("public Model." + tname + " get" + tname + "(int id)\n{\n");
            sb9.Append("StringBuilder strsql = new StringBuilder();\n");
            sb9.Append("strsql.Append(\"select * from " + tname + " where \");\n");
            sb9.Append("strsql.AppendFormat(\"" + idname + "='{0}'\", id);\n");
            sb9.Append("DataTable dt = sql.ExecuteDataSet(strsql.ToString()).Tables[0];\n");
            sb9.Append("if (dt.Rows.Count < 1) return null;\n\n");
            sb9.Append("return get" + tname + "(dt);\n}\n");

            sb7.Append("Model." + tname + " get" + tname + "(int id);\n");
            sb7.Append("Model." + tname + " get" + tname + "(DataTable dt);\n");
            sb8.Append("public Model." + tname + " get" + tname + "(int id)\n{\n");
            sb8.Append("return itu.get" + tname + "(id);\n}\n");
            sb8.Append("public Model." + tname + " get" + tname + "(DataTable dt)\n{\n");
            sb8.Append("return itu.get" + tname + "(dt);\n}\n");

            sb5.Append("public int update(Model." + tname + " " + tname + ")\n{\n");
            sb5.Append("StringBuilder strsql = new StringBuilder();\n");
            sb5.Append("strsql.Append(\"update " + tname + " set \");\n");
            sb7.Append("int update(Model." + tname + " " + tname + ");\n");
            sb8.Append("public int update(Model." + tname + " " + tname + ")\n{\n");
            sb8.Append("return itu.update(" + tname + ");\n}\n");


            sb10.Append("using System.Reflection;\n\n");
            sb10.Append("namespace DALFactory\n{\n");
            sb10.Append("public class " + tname + "_Factory\n{\n");
            sb10.Append("static readonly string path = System.Configuration.ConfigurationManager.AppSettings[\"DAL\"];\n");
            sb10.Append("public static IDAL." + tname + "Dal Createusers()\n{\n");
            sb10.Append("string classname = path + \".sql_" + tname + "\";\n");
            sb10.Append("return (IDAL." + tname + "Dal)Assembly.Load(path).CreateInstance(classname);\n}\n");
            sb10.Append("}\n}");


            for (int i = 2; i < this.richTextBox3.Lines.Length; i++)//0行是表名，1行是id
            {
                if (this.richTextBox3.Lines[i].Contains("] ["))
                {
                    //this.richTextBox4.Text += r.Matches(this.richTextBox3.Lines[i]).Count;

                    s1 = r.Matches(this.richTextBox3.Lines[i])[0].ToString();
                    s1 = s1.Substring(1, s1.Length - 2);
                    s2 = r.Matches(this.richTextBox3.Lines[i])[1].ToString();
                    s2 = s2.Substring(1, s2.Length - 2);

                    

                    switch (s2)
                    {
                        case "varchar": sb1.Append("private string _" + s1 + " = \"\";\n");
                            sb2.Append("public string " + s1 + "{get { return _" + s1 + "; }\n\tset { _" + s1 + " = value; }}\n\n");
                            sb3.Append("strsql.AppendFormat(\"'{0}',\", " + tname + "." + s1 + ");\n");
                            sb4.Append(tname + "." + s1 + " = dt.Rows[0][\"" + s1 + "\"].ToString();\n");
                            sb5.Append("strsql.AppendFormat(\" " + s1 + " ='{0}',\", " + tname + "." + s1 + ");\n");
                            break;
                        case "nvarchar": sb1.Append("private string _" + s1 + " = \"\";\n");
                            sb2.Append("public string " + s1 + "{get { return _" + s1 + "; }\n\tset { _" + s1 + " = value; }}\n\n");
                            sb3.Append("strsql.AppendFormat(\"N'{0}',\", " + tname + "." + s1 + ");\n");
                            sb4.Append(tname + "." + s1 + " = dt.Rows[0][\"" + s1 + "\"].ToString();\n");
                            sb5.Append("strsql.AppendFormat(\" " + s1 + " =N'{0}',\", " + tname + "." + s1 + ");\n");
                            break;
                        case "text": sb1.Append("private string _" + s1 + " = \"\";\n");
                            sb2.Append("public string " + s1 + "{get { return _" + s1 + "; }\n\tset { _" + s1 + " = value; }}\n\n");
                            sb3.Append("strsql.AppendFormat(\"'{0}',\", " + tname + "." + s1 + ");\n");
                            sb4.Append(tname + "." + s1 + " = dt.Rows[0][\"" + s1 + "\"].ToString();\n");
                            sb5.Append("strsql.AppendFormat(\" " + s1 + " ='{0}',\", " + tname + "." + s1 + ");\n");
                            break;
                        case "datetime": sb1.Append("private DateTime _" + s1 + "= DateTime.Parse(\"1900-01-01\");\n");
                            sb2.Append("public DateTime " + s1 + "{get { return _" + s1 + "; }\n\tset { _" + s1 + " = value; }}\n\n");
                            sb3.Append("strsql.AppendFormat(\"{0},\", " + tname + "." + s1 + " == baddate ? \"null\" :\"'\" + " + tname + "." + s1 + ".ToString() +\"'\");\n");
                            sb4.Append(tname + "." + s1 + "  = dt.Rows[0][\"" + s1 + "\"].ToString() == \"\" ? baddate : DateTime.Parse(dt.Rows[0][\"" + s1 + "\"].ToString());\n");
                            sb5.Append("strsql.AppendFormat(\" " + s1 + " ={0},\", " + tname + "." + s1 + " == baddate ? \"null\" :\"'\" + " + tname + "." + s1 + ".ToString() +\"'\");\n");
                            break;
                        case "int": sb1.Append("private int _" + s1 + " = 0;\n");
                            sb2.Append("public int " + s1 + "{get { return _" + s1 + "; }\n\tset { _" + s1 + " = value; }}\n\n");
                            sb3.Append("strsql.AppendFormat(\"{0},\", " + tname + "." + s1 + ");\n");
                            sb4.Append(tname + "." + s1 + " = int.Parse( dt.Rows[0][\"" + s1 + "\"].ToString());\n");
                            sb5.Append("strsql.AppendFormat(\" " + s1 + " ='{0}',\", " + tname + "." + s1 + ");\n");
                            break;
                        case "decimal": sb1.Append("private decimal _" + s1 + " = 0M;\n");
                            sb2.Append("public decimal " + s1 + "{get { return _" + s1 + "; }\n\tset { _" + s1 + " = value; }}\n\n");
                            sb3.Append("strsql.AppendFormat(\"{0},\", " + tname + "." + s1 + ");\n");
                            sb4.Append(tname + "." + s1 + " = decimal.Parse( dt.Rows[0][\"" + s1 + "\"].ToString());\n");
                            sb5.Append("strsql.AppendFormat(\" " + s1 + " ='{0}',\", " + tname + "." + s1 + ");\n");
                            break;
                        case "float": sb1.Append("private double _" + s1 + " = 0.0;\n");
                            sb2.Append("public double " + s1 + "{get { return _" + s1 + "; }\n\tset { _" + s1 + " = value; }}\n\n");
                            sb3.Append("strsql.AppendFormat(\"{0},\", " + tname + "." + s1 + ");\n");
                            sb4.Append(tname + "." + s1 + " = double.Parse( dt.Rows[0][\"" + s1 + "\"].ToString());\n");
                            sb5.Append("strsql.AppendFormat(\" " + s1 + " ='{0}',\", " + tname + "." + s1 + ");\n");
                            break;
                        default: sb1.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n");
                            sb2.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n");
                            break;
                    }
                }
            }

            sb2.Append("}\n}");

            //strsql.AppendFormat("N'{0}',", customers.customerSafeA2);

            sb3.Remove(sb3.ToString().LastIndexOf(",\",") , 1);
            sb3.Append("strsql.Append(\") select SCOPE_IDENTITY()\");\n");
            sb3.Append("return Convert.ToInt32(sql.ExecuteSc(strsql.ToString()));\n}\n");

            sb4.Append("return " + tname + ";\n}\n");

            sb5.Remove(sb5.ToString().LastIndexOf(",\","), 1);
            sb5.Append("strsql.AppendFormat(\" where " + idname + "={0}\", " + tname + "." + idname + ");\n");
            sb5.Append("return sql.ExecuteNonQuery(strsql.ToString());\n}\n");

            sb6.Append("public int Delete(int " + idname + ")\n{\n");
            sb6.Append("return sql.ExecuteNonQuery(\"delete from " + tname + " where " + idname + "=\" + " + idname + ");\n}\n");
            sb6.Append("public DataTable Select(string ss)\n{\n");
            sb6.Append("return sql.ExecuteDataSet(ss).Tables[0];\n}\n");

            sb7.Append("int Delete(int " + idname + ");\n");
            sb7.Append("DataTable Select(string ss);\n");
            sb7.Append("}\n}");

            sb8.Append("public int Delete(int " + idname + ")\n{\n");
            sb8.Append("return itu.Delete(" + idname + ");\n}\n");
            sb8.Append("public DataTable Select(string ss)\n{\n");
            sb8.Append("return itu.Select(ss);\n}\n}\n}");

            sb6.Append("}\n}");

            this.richTextBox4.Text = sb1.ToString() + "\n\n" + sb2.ToString();//model
            this.richTextBox7.Text = sb3.ToString() + "\n\n" + sb4.ToString() + "\n\n" + sb9.ToString() + "\n\n" + sb5.ToString() + "\n\n" + sb6.ToString();//sqlserverdal
            this.richTextBox8.Text = sb7.ToString();//idal
            this.richTextBox9.Text = sb8.ToString();//bll
            this.richTextBox14.Text = sb10.ToString();//dalfactory

            string filepath = folderpath + "\\Bll\\" + tname + "Bll.cs";
            if (File.Exists(filepath))
            {
                FileInfo fileInfo = new FileInfo(filepath);
                fileInfo.MoveTo(folderpath + "\\Bll\\" + tname + "Bll"+DateTime.Now.ToString("yyyyMMddHHmmss") +".cs");
            }
            File.AppendAllText(filepath, this.richTextBox9.Text.Replace("\n", "\r\n"), Encoding.Default);

            filepath = folderpath + "\\Model\\" + tname + ".cs";
            if (File.Exists(filepath)) File.Delete(filepath);
            File.AppendAllText(filepath, this.richTextBox4.Text.Replace("\n", "\r\n"), Encoding.Default);

            filepath = folderpath + "\\SQLServerDAL\\sql_" + tname + ".cs";
            if (File.Exists(filepath)) File.Delete(filepath);
            File.AppendAllText(filepath, this.richTextBox7.Text.Replace("\n", "\r\n"), Encoding.Default);

            filepath = folderpath + "\\IDAL\\" + tname + "Dal.cs";
            if (File.Exists(filepath)) File.Delete(filepath);
            File.AppendAllText(filepath, this.richTextBox8.Text.Replace("\n", "\r\n"), Encoding.Default);

            filepath = folderpath + "\\DALFactory\\" + tname + "_Factory.cs";
            if (File.Exists(filepath)) File.Delete(filepath);
            File.AppendAllText(filepath, this.richTextBox14.Text.Replace("\n", "\r\n"), Encoding.Default);

        }

        private void main_Load(object sender, EventArgs e)
        {
            string s= Application.StartupPath;
            s = s.Substring(0, s.LastIndexOf('\\'));
            s = s.Substring(0, s.LastIndexOf('\\'));
            s = s.Substring(0, s.LastIndexOf('\\'));
            this.textBox1.Text= folderpath = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] result = Encoding.Default.GetBytes(this.richTextBox5.Text);  
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            this.richTextBox6.Text = BitConverter.ToString(output).Replace("-", "").ToLower(); 
        }
        

        private void richTextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            unsafe
            {
                int length = 0;
                int minlen = this.richTextBox12.Text.Length > this.richTextBox13.Text.Length ? this.richTextBox13.Text.Length : this.richTextBox12.Text.Length;
                string s1 = this.richTextBox12.Text;
                string s2 = this.richTextBox13.Text;
                fixed (char* a = s1, b=s2 )
                {
                    char* x = a;
                    char* y = b;

                    do
                    {
                        if (*(x++) != *(y++))
                        {
                            this.richTextBox12.Select(length, 100);
                            this.richTextBox13.Select(length, 100);
                            this.richTextBox12.SelectionColor = Color.Red;
                            this.richTextBox13.SelectionColor = Color.Red;
                            this.richTextBox12.SelectionLength = 0;
                            this.richTextBox13.SelectionLength = 0;
                            break;
                        }
                    }
                    while (++length < minlen);
                }

                
            }
        }

    }
}
