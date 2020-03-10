﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Serialization.Models;
using Newtonsoft.Json;
using System.Windows;

namespace User_Serialization.Serializers
{
    public class JsonUserSerializer : IUserSerializer
    {
        public void Deserialize(FileStream fileStream)
        {
            throw new NotImplementedException();
        }

        public void Serialize(IEnumerable<User> users, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                string serializedText = JsonConvert.SerializeObject(users);
                byte[] serializedData = Encoding.UTF8.GetBytes(serializedText);
                fs.Write(serializedData, 0, serializedData.Length);
                fs.Flush();
            }
        }
    }
}
