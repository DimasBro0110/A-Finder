using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AnagrammFinder
{
    class Table
    {
        private Dictionary<int, LinkedList<string>> table =
                new Dictionary<int, LinkedList<string>>();

        private string file_in_name;
        private string file_out_name;

        private void setter()
        {
            Encoding enc = Encoding.GetEncoding(1251);
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(this.file_in_name, enc);
                string line = "";
                int sum = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (char ch in line.ToLower())
                    {
                        sum *= (int)ch;
                    }
                    this.setValues(sum, line);
                    sum = 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Возможно был введен неверный путь к файлу / имени файла");
            }
            finally
            {
                if (sr != null)
                {
                    sr.Dispose();
                    sr.Close();
                }
            }
        }

        private void setValues(int hash, string word)
        {
            if (this.table.ContainsKey(hash))
            {
                this.table[hash].AddLast(word);
            }
            else
            {
                LinkedList<string> lst = new LinkedList<string>();
                lst.AddLast(word);
                this.table.Add(hash, lst);
            }
        }

        public Table(string in_name, string out_name)
        {
            this.file_in_name = in_name;
            this.file_out_name = out_name;
            this.setter();
        }

        public void downloadToFile()
        {
            if (this.table.Count != 0)
            {
                Encoding enc = Encoding.GetEncoding(1251);
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(this.file_out_name, false, enc);
                    foreach (KeyValuePair<int, LinkedList<string>> cur in this.table)
                    {
                        if (cur.Value.Count() > 1)
                        {
                            foreach (string word in cur.Value)
                            {
                                sw.Write(word + " ");
                            }
                            sw.WriteLine();
                        }
                    }
                    Console.WriteLine("Данные были выгружены, смотрите {0} файл", this.file_out_name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Возможно был введен неверный путь к файлу / имени файла");
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Dispose();
                        sw.Close();
                    }
                }
            }
        }

        ~Table()
        {
            foreach (KeyValuePair<int, LinkedList<string>> kv in this.table)
            {
                kv.Value.Clear();
            }
            this.table.Clear();
        }
    }

}
