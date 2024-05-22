using Lab12;
using LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.Serialization;
#pragma warning disable SYSLIB0011

namespace LAB_16
{
    public static class Serializer
    {
        public static async Task SerializeToXml(this Tree<Challenge> tree, string filePath)
        {
            var serializer = new XmlSerializer(typeof(Tree<Challenge>));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await Task.Run(() => serializer.Serialize(stream, tree));
            }
        }

        public static void DeserializeFromXml(this Tree<Challenge> tree, string filePath)
        {
            var serializer = new XmlSerializer(typeof(Tree<Challenge>));
            Tree<Challenge> tempChallenges = new Tree<Challenge>();

            using (var stream = File.OpenRead(filePath))
            {
                tempChallenges = (Tree<Challenge>)serializer.Deserialize(stream);
                stream.Close();
            }

            tree.Clear();
            foreach (var item in tempChallenges)
                tree.Add(item);
        }

        public static async Task SerializeToJson(this Tree<Challenge> tree, string filePath)
        {
            var options1 = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string json = "";
            await Task.Run(() => json = JsonSerializer.Serialize(tree, options1));

            using (var streamWriter = new StreamWriter(filePath))
            {
                await streamWriter.WriteAsync(json);
            }
        }

        public static void DeserializeFromJson(this Tree<Challenge> tree, string filePath)
        {
            var options1 = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            var json = File.ReadAllText(filePath);
            var tmp = new Tree<Challenge>();
            tmp = JsonSerializer.Deserialize<Tree<Challenge>>(json, options1);

            tree.Clear();
            foreach (var item in tmp)
                tree.Add(item);
        }

        public static async Task SerializeToBinary(this Tree<Challenge> tree, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                await Task.Run(() => formatter.Serialize(fs, tree));
            }
        }

        public static void DeserializeFromBinary(this Tree<Challenge> tree, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                var tmp = (Tree<Challenge>)formatter.Deserialize(stream);
                tree.Clear();
                foreach (var item in tmp)
                    tree.Add(item);
            }
        }
    }
}
