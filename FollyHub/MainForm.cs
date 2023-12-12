namespace Follyverse
{
    public partial class MainForm : Form
    {
        public ZipForm zipForm;
        public static string Path;
        public static string DefaultServer = "";
        public static List<Panel> panels = new List<Panel>();
        public List<ProjectPanel> projPanel = new List<ProjectPanel>();
        public static List<TamesProject> projects = new List<TamesProject>();
        public const int PerPage = 15;
        int currentPage = 1;
        public static Button Unreal, URP, HDRP;
        System.Windows.Forms.Timer timer;

        public MainForm()
        {
            InitializeComponent();
           Path = Application.ExecutablePath;
            zipForm = new ZipForm();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
             pButtons.Visible = false;
            URP = burp;
            HDRP = bhdrp;
            Unreal = bunreal;

            backBrowse.Dock = DockStyle.Fill;
            pagePanel.Dock = DockStyle.Bottom;
            projectTable.Dock = DockStyle.Fill;

            DoubleBuffered = true;
            panels.Add(backPanel);

            GetSavedProjects();

            projPanel = new List<ProjectPanel>();

            for (int i = 0; i < 15; i++)
                projPanel.Add(new ProjectPanel(projectTable));

            for (int i = 0; i < panels.Count; i++)
                SetDoubleBuffered(panels[i]);
            AttemptPage(1);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            switch (ZipThread.type)
            {
                case ZipThread.OperationType.Importing:
                    progressBar1.Value = (ZipThread.processed * 100 / ZipThread.total);
                    if (ZipThread.processed == ZipThread.total)
                    {
                        timer.Stop();
                        progressBar1.Value = 0;
                        progressLabel.Text = $" Unzipped (successful: {ZipThread.successful}, failed: {ZipThread.total}.";
                        ImportUnzipped(ZipThread.items);
                    }
                    break;
                case ZipThread.OperationType.Copying:
                    progressBar1.Value = (ZipThread.processed * 100 / ZipThread.total);
                    if (ZipThread.processed == ZipThread.total)
                    {
                        //  timer.Stop();
                        progressBar1.Value = 0;
                        progressLabel.Text = " Operation 2/2 (Unzipping ...) ";
                        ZipThread.UnzipFiles(ZipThread.items);
                    }
                    break;
            }
        }

        int currentSource = 0;

        public void AttemptPage(int p)
        {
            int page =  currentPage;
            if ((p - 1) * PerPage >= projects.Count)
                page = projects.Count / 15 + 1;
            else
                page = p;
            for (int i = 0; i < PerPage; i++)
                if (i + (page - 1) * PerPage < projects.Count)
                {
                    projPanel[i].Visible = true;
                    projPanel[i].GetFrom(projects[i + (page - 1) * PerPage]);
                }
                else
                    projPanel[i].Visible = false;
            pageNumber.Text = page + " of " + (projects.Count / 15 + 1);
          currentPage = page;;
        }
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        private void PageChangeClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int n = 0;
            switch (b.Name)
            {
                case "bb5": n = -5; break;
                case "bb1": n = -1; break;
                case "bf1": n = 1; break;
                case "bf5": n = 5; break;
            }
            if (currentPage + n < 1)
                AttemptPage(1);
            else
                AttemptPage(currentPage + n);
        }
        public int currentMode = 0;
     

        private void brefresh_clicked(object sender, EventArgs e)
        {
            GetSavedProjects();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        
        public static string GetFileName(string path)
        {
            int slash = Math.Max(path.LastIndexOf('/'), path.LastIndexOf('\\'));
            int dot = path.LastIndexOf('.');
            if (dot < slash)
                dot = path.Length;
            return path.Substring(slash + 1, dot - slash - 1);
        }
        void GetSavedProject(string folder)
        {
            string path = (folder[^1] == '\\' || folder[^1] == '/') ? folder : folder + '/';
            if (File.Exists(path + "description.ini"))
            {
                TamesProject project = TamesProject.FromINI(path);
                if (project != null)
                {
                    int sp = SameProject(project, projects);
                    if (sp >= 0)
                        projects[sp] = project;
                    else if (sp == -2)
                    {
                        projects.Add(project);
                    }
                }
            }
        }
        void GetSavedProjects()
        {
            try
            {
                string path = TamesProject.GetFolderOf(Path);
                path += "Projects/";
                 if (!Directory.Exists(path))
                    return;
                string[] folders = Directory.GetDirectories(path);
                foreach (string folder in folders)
                    GetSavedProject(folder);
                List<string> newFiles = new List<string>();
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                    if (file.EndsWith(".zip"))
                    {
                        bool found = false;
                        string name = GetFileName(file);
                        for (int i = 0; i < projects.Count; i++)
                            if (projects[i].projectID == name) 
                            { found = true; break; }
                        if (!found) newFiles.Add(name);
                    }
                if (newFiles.Count > 0)
                {
                    zipForm.SetList(newFiles);
                    zipForm.ShowDialog();
                    if (zipForm.result != ZipResult.None)
                    {
                        List<string> selected = new List<string>();
                        for (int i = 0; i < zipForm.selection.Count; i++)
                            selected.Add(newFiles[zipForm.selection[i]]);
                        timer.Start();
                        ZipThread.UnzipFiles(selected);
                    }
                }
            }
            catch { }
            //    ApplyFilters();
        }

        private void bimport_files_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Zip files!*.zip";
            ofd.Multiselect = true;
            ofd.ShowDialog();
            if (ofd.FileNames.Length > 0)
            {
                var zipFiles = new List<string>();
                zipFiles.AddRange(ofd.FileNames);
                ZipThread.type = ZipThread.OperationType.Copying;
                ZipThread.CopyZipFiles(ofd.FileNames);
                progressLabel.Text = " Operation 1/2 (Copying ...) ";
                timer.Start();
            }
        }

        private void bimport_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.ShowDialog();
            if (Directory.Exists(ofd.SelectedPath))
            {
                var zipFiles = new List<string>();
                zipFiles.Add(ofd.SelectedPath);
                ZipThread.type = ZipThread.OperationType.Copying;
                ZipThread.CopyFolder(ofd.SelectedPath);
                progressLabel.Text = " Operation 1/2 (Copying ...) ";
                timer.Start();
            }
        }
        void ImportUnzipped(List<string> projectNames)
        {
            for (int i = 0; i < projectNames.Count; i++)
                GetSavedProject(Path + projectNames[i] + '/');
            AttemptPage(currentPage);
        }
        int SameProject(TamesProject pd, List<TamesProject> pds)
        {
            for (int i = 0; i < pds.Count; i++)
                if (pd.Equals(pds[i]))
                {
                    if (pd.lastModified != pds[i].lastModified)
                        return i;
                    else return -1;
                }
            return -2;
        }
    }
}