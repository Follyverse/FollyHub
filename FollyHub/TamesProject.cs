using System.Diagnostics;
using System.Net;

namespace Follyverse
{
    public class TamesProject
    {
        public const int Unity_URP = 1;
        public const int Unity_HDRP = 2;
        public const int Unreal = 3;

        public Image thumbnail = null;
        public int version = 1000;
        public string title = "";
        public string folderPath = "";
        //   public ParentFolder parent;
        //   public string pathOnLocal;
        public string author, description, server, port, altPort, projectID = "";
        public long lastModified;
        public bool success = false;
        public bool visible = false;
        public bool HasServer = false;
        public int platform = Unity_URP;

        static int GetPlatform(string p)
        {
            if (p.ToLower() == "unity_urp")
                return Unity_URP;
            else if (p.ToLower() == "unity_hdrp")
                return Unity_HDRP;
            else if (p.ToLower() == "unreal")
                return Unreal;
            return -1;
        }
        public static string GetFolderOf(string path)
        {
            int p = path.LastIndexOf('/');
            int q = path.LastIndexOf('\\');
            if (p > q) q = p;
            return path.Substring(0, q + 1);
        }
        static int GetVersion(string s)
        {
            try
            {
                int r = int.Parse(s);
                return r;
            }
            catch (Exception) { return -1; }
        }
        public static TamesProject FromINI(string path)
        {
            TamesProject project = null;
            string[] lines = File.ReadAllLines(path + "description.ini");
            if (lines.Length > 12)
            {
                int version = GetVersion(lines[0]);
                int platform = GetPlatform(lines[1]);
                string title = lines[2];
                string author = lines[3];
                string id = lines[4];
                string server = lines[5];
                string port = lines[6];
                string altport = lines[7];
                string desc = "";

                for (int i = 12; i < lines.Length; i++)
                    desc += i == 8 ? lines[i] : "\r\n" + lines[i];
                if (platform >= 0)
                    project = new TamesProject()
                    {
                        version = version,
                        platform = platform,
                        title = title,
                        author = author,
                        projectID = id,
                        server = server,
                        port = port,
                        altPort = altport,
                        description = desc,
                        folderPath = path
                    };
            }
            if (File.Exists(path + "thumbnail.jpg"))
            {
                project.thumbnail = Image.FromFile(path + "thumbnail.jpg");
            }
            return project;
        }

        public string PathToArg(string s)
        {
            return s.Replace(" ", "*");
        }
        public void Run(string args)
        {
            if (platform == Unity_URP)
                RunUnity(args);
        }
        public void RunUnity(string args)
        {
            string exe, path = GetFolderOf(MainForm.Path);// Application.ExecutablePath);
            exe = path + "Versions/";
            path += "Projects/";
            string exeFile = exe + (platform == Unity_URP ? "Unity-urp" : "Unity-hdrp");
            exeFile += "-" + version + "/Tames.exe";
            string argpath = args + " path:" + PathToArg(path + projectID) + "/";
            if (File.Exists(exeFile))
            {
                Process process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = exeFile,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        RedirectStandardInput = true,
                        Arguments = argpath,
                        CreateNoWindow = false,
                        WorkingDirectory = string.Empty,
                    }
                };
                process.Start();
            }
            else
                Thread.Sleep(100);

        }
        public void Run(int type)
        {
            switch (type)
            {
                case 1: ShowIP(false); break;
                case 2: ShowIP(true); break;
                case 3: RunOffline(); break;
                case 4: RunAsClient(true); break;
            }
        }

        public void RunOffline()
        {
            Run("offline");
        }
        public void RunAsServer()
        {
            string args = "server port:" + port + "," + altPort;
            Run(args);
        }
        public void RunAsClient(bool web)
        {
            ClientDialog cd = new ClientDialog();
            cd.IP = server;
            cd.Port1 = port;
            cd.Port2 = altPort;
            cd.project = this;
            string args;
            cd.SetLabel(web ? "Leave empty for default server." : "Ask your server host to give you this address.");
            DialogResult result = cd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string server = cd.IP == "" ? MainForm.DefaultServer : cd.IP;
                args = "address:" + cd.IP + " port:" + cd.Port1 + "," + cd.Port2 + " name:" + cd.Nickname;
                cd.Dispose();
                Run(args);
            }
            else cd.Dispose();
        }
        public void ShowIP(bool server)
        {
            if (server)
            {
                var hostName = Dns.GetHostName();
              
                IPAddress[] ipaddress = Dns.GetHostAddresses(hostName);
             
                string local = "";
                string ip4 = "";
                foreach (IPAddress ip in ipaddress)
                    if (ip.ToString().StartsWith("192.") || ip.ToString().StartsWith("10."))
                    {
                        local = ip.ToString();
                        break;
                    }

                DialogResult dr = MessageBox.Show("Your local IP address is:\r\n" + local + "\r\nTo connect, other users will need this address. Press Yes to copy it to clipboard. \r\nYour main and 2nd ports are: "+port+", "+altPort, "IP Declaration", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    Clipboard.SetText(local);
                RunAsServer();
            }
            else
                RunAsClient(false);
        }
      
    }
}