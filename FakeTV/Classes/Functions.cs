using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FakeTV
{
    class Functions
    {
        public bool CheckURLExists(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";

            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CreateDirs()
        {
            Directory.CreateDirectory("categories");
            Directory.CreateDirectory("channels");
            Directory.CreateDirectory("playlists");
            Directory.CreateDirectory("logos");
            Directory.CreateDirectory("shows");
            Directory.CreateDirectory("seasons");
        }

        public bool GrabPlexLibrary(string PlexIP, string PlexPort, string PlexToken)
        {
            // download our categories
            var url = "http://" + PlexIP + ":" + PlexPort + "/library/sections?X-Plex-Token=" + PlexToken;
            if (CheckURLExists(url))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(url, "categories.xml");
                }
            }
            else
            {
                return false;
            }

            // parse categories for their IDs (keys)
            XDocument coordinates = XDocument.Load("categories.xml");

            var items = coordinates.Descendants("Directory")
               .Select(node => (string)node.Attribute("key").Value.ToString())
               .ToList();

            // download each categories XML data file
            foreach (var item in items)
            {
                var url2 = "http://" + PlexIP + ":" + PlexPort + "/library/sections/" + item + "/all?X-Plex-Token=" + PlexToken;
                if (CheckURLExists(url2))
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(url2, "categories/cat" + item + ".xml");
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public string[] ParseChanCFGFile(FileInfo file)
        {
            Debug.WriteLine("Parsing " + file.FullName);
            var ReadLines = File.ReadAllLines(file.FullName);
            List<string> lines = new List<string>();
            lines.Add(Path.GetFileNameWithoutExtension(file.Name));
            int i = 0;
            foreach (var line in ReadLines)
            {
                lines.Add(line);
                Debug.WriteLine("Line " + i++ + ": " + line);
            }
            return lines.ToArray();
        }

        public void KillVLC()
        {
            foreach (var process in Process.GetProcessesByName("vlc"))
            {
                process.Kill();
            }
        }

        public List<T> Shuffle<T>(List<T> list)
        {
            Random rnd = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                int k = rnd.Next(0, i);
                T value = list[k];
                list[k] = list[i];
                list[i] = value;
            }
            return list;
        }
    }
}
