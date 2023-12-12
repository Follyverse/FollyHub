using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Follyverse
{
    public class ProjectPanel
    {
        Panel imagePanel;
        Panel infoPanel;
        Panel buttonPanel;
        Panel basePanel;
        Label server;
        Label title, author;
        Label description;
        Button run;
        public TamesProject project;
        public int[] filters;
        public bool Visible { get { return basePanel.Visible; } set { basePanel.Visible = value; } }
        public ProjectPanel(Panel parent)
        {

            basePanel = new Panel();
            MainForm.panels.Add(basePanel);
            basePanel.Height = 150;
            basePanel.Dock = DockStyle.Top;
           basePanel.BackColor = Color.FromArgb(50, 0, 0, 0);
            parent.Controls.Add(basePanel);

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.Transparent;
            //    panel.AutoSize = true;
            // panel.Height = 80;
            // panel.Width = 200;

            buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.BackColor = Color.Transparent;
            buttonPanel.Height = 30;
            basePanel.Controls.Add(buttonPanel);

            server = new Label();
            server.Dock = DockStyle.Left;
            buttonPanel.Controls.Add(server);

            infoPanel = new Panel();
            infoPanel.Dock = DockStyle.Fill;
            panel.Controls.Add(infoPanel);



            imagePanel = new Panel();
            imagePanel.Dock = DockStyle.Left;
            imagePanel.Width = 100;
            imagePanel.BackColor = Color.Transparent;
            panel.Controls.Add(imagePanel);


            run = new Button();
            run.Dock = DockStyle.Right;
            run.Text = "  Run";
            run.FlatAppearance.BorderSize = 0;
            run.FlatStyle = FlatStyle.Flat;
            run.BackColor = Color.MidnightBlue;
            run.Cursor = Cursors.Hand;
            run.ImageAlign = ContentAlignment.MiddleLeft;
            run.TextAlign = ContentAlignment.MiddleRight;
            run.TextImageRelation = TextImageRelation.ImageBeforeText;
            run.Click += Connect;
            buttonPanel.Controls.Add(run);
            
            ContextMenuStrip menuStrip = new ContextMenuStrip();
            menuStrip.Items.AddRange(new ToolStripMenuItem[] { new ToolStripMenuItem("As LAN Client", null, null, "tsi1"), new ToolStripMenuItem("As LAN Server", null, null, "tsi2"), new ToolStripMenuItem("Offline", null, null, "tsi3"), new ToolStripMenuItem("Online", null, null, "tsi4") });
            menuStrip.ItemClicked += MenuStrip_Click;
            run.ContextMenuStrip = menuStrip;
            description = new Label();
            description.MaximumSize = new Size(350, 0);
       
            description.Dock = DockStyle.Fill;
            description.ForeColor = Color.White;
            infoPanel.Controls.Add(description);

            author = new Label();
            author.Dock = DockStyle.Top;
           author.BackColor = Color.Transparent;
            author.Font = new Font(author.Font, FontStyle.Italic);
            infoPanel.Controls.Add(author);

            title = new Label();
            title.Dock = DockStyle.Top;
          title.ForeColor = Color.Gold;
            title.Font = new Font(title.Font, FontStyle.Bold);
            infoPanel.Controls.Add(title);

            basePanel.Controls.Add(panel);

        }

        private void MenuStrip_Click(object? sender, ToolStripItemClickedEventArgs e)
        {

            ToolStripItem tsi = e.ClickedItem;
            int selected = -1;
            if (tsi != null)
            {
                selected = int.Parse(tsi.Name[3] + "");
                if (selected > 0)
                    project.Run(selected);
            }
        }

        private void Connect(object? sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (project.HasServer)
                {
                    if (button.ContextMenuStrip.Items.Count == 3)
                        button.ContextMenuStrip.Items.Add(new ToolStripMenuItem("Connect", null, null, "Connect"));
                }
                else if (button.ContextMenuStrip.Items.Count > 3)
                    button.ContextMenuStrip.Items.RemoveAt(3);
                button.ContextMenuStrip.Show(button, 0, 0);
            }
        }
        private void Open(object? sender, EventArgs e)
        {
        }
        public void GetFrom(TamesProject folder)
        {
            title.Text = folder.title;
            author.Text = folder.author;
            description.Text = folder.description;
            server.Text = folder.server;
            project = folder;
            if (folder.thumbnail == null)
                imagePanel.BackgroundImage = null;
            else
            {
                imagePanel.BackgroundImage = folder.thumbnail;
                imagePanel.BackgroundImageLayout = ImageLayout.Zoom;
            }
            run.Image = project.platform switch
            {
                TamesProject.Unreal => MainForm.Unreal.Image,
                TamesProject.Unity_URP => MainForm.URP.Image,
                TamesProject.Unity_HDRP => MainForm.HDRP.Image,
                _ => null
            };
        }
    }
}
