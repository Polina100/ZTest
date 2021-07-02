using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZTest;

namespace TODOFile
{
    class TODOFILE
    {
        private string Path;
        public TODOFILE(string path)
        {
            Path = path;
        }
        public List<ToDo> ReadF()
        {
            var fileExist = File.Exists(Path);
            if (!fileExist)
            {
                File.CreateText(Path).Dispose();
                return new List<ToDo>();
            }
            using (var reader = File.OpenText(Path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<ToDo>>(fileText);
            }
        }

        public void SaveF(List<ToDo> list)
        {
            using (StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(list);
                writer.Write(output);
            }

        }
    }
}
