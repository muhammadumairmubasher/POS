using System;
using System.Collections.Generic;
using System.IO;
using POS_BO;

namespace POS_DAL
{
    public class BaseDAL
    {
        internal void save(string text, string filename)
        {
            StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, filename), append: true);
            sw.WriteLine(text);
            sw.Close();
        }
        //return complete Data of file in the form of List of Strings 
        internal List<string> Read(string filename)
        {
            List<String> list = new List<string>();
            StreamReader sr;
            try{
                sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, filename));
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }

            }
            catch(Exception ex){
               Console.WriteLine(ex.GetType()+" "+ex.Message );
            }
            return list; //return complete Data of file
        }
        public void deleteFile(string filename)
        {
            File.Delete(Path.Combine(Environment.CurrentDirectory, filename));
        }
        public int generateID(string filename)
        {
            int count=0;
            StreamReader sr;
            try{
                sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, filename));
                while (sr.ReadLine() != null)
                {
                   count++;
                }
            }
            catch{

            }
            return ++count;
        }

    }
}
