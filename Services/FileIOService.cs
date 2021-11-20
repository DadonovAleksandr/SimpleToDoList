using Newtonsoft.Json;
using SimpleToDoList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDoList.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<TodoModel> LoadData()
        {
            if (!File.Exists(PATH))
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TodoModel>();
            }
            else
            {
                string input = File.ReadAllText(PATH);
                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(input);
            }
        }

        public void SaveData(object todoDataList)
        {
            using(StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }
        }
    }
}
