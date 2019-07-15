namespace AutomataGUI.View
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem(new string[] {
            "State"}, "(none)", System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem(new string[] {
            "EndState"}, "(none)", System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem(new string[] {
            "StartState"}, "(none)", System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem(new string[] {
            "Transition"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsLatex = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsPNG = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFromXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleDebugRenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStateCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTransitionCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolboxListView = new System.Windows.Forms.ListView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.checkBoxEnd = new System.Windows.Forms.CheckBox();
            this.checkBoxStart = new System.Windows.Forms.CheckBox();
            this.textBoxLabel = new System.Windows.Forms.TextBox();
            this.labelLabel = new System.Windows.Forms.Label();
            this.panelRendering = new System.Windows.Forms.Panel();
            this.horizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.verticalScrollBar = new System.Windows.Forms.VScrollBar();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1013, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAsMenu,
            this.ImportFromXML,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exportAsMenu
            // 
            this.exportAsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAsXML,
            this.exportAsLatex,
            this.exportAsPNG});
            this.exportAsMenu.Name = "exportAsMenu";
            this.exportAsMenu.Size = new System.Drawing.Size(137, 22);
            this.exportAsMenu.Text = "Export as";
            // 
            // exportAsXML
            // 
            this.exportAsXML.Name = "exportAsXML";
            this.exportAsXML.Size = new System.Drawing.Size(134, 22);
            this.exportAsXML.Text = "XML File";
            this.exportAsXML.Click += new System.EventHandler(this.ExportAsXML_Click);
            // 
            // exportAsLatex
            // 
            this.exportAsLatex.Name = "exportAsLatex";
            this.exportAsLatex.Size = new System.Drawing.Size(134, 22);
            this.exportAsLatex.Text = "LaTeX File";
            this.exportAsLatex.Click += new System.EventHandler(this.ExportAsLatex_Click);
            // 
            // exportAsPNG
            // 
            this.exportAsPNG.Name = "exportAsPNG";
            this.exportAsPNG.Size = new System.Drawing.Size(134, 22);
            this.exportAsPNG.Text = "PNG Image";
            this.exportAsPNG.Click += new System.EventHandler(this.ExportAsPNG_Click);
            // 
            // ImportFromXML
            // 
            this.ImportFromXML.Name = "ImportFromXML";
            this.ImportFromXML.Size = new System.Drawing.Size(137, 22);
            this.ImportFromXML.Text = "Import XML";
            this.ImportFromXML.Click += new System.EventHandler(this.ImportFromXML_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centerToolStripMenuItem,
            this.reorderToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            this.centerToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.centerToolStripMenuItem.Text = "center scroll";
            this.centerToolStripMenuItem.Click += new System.EventHandler(this.CenterToolStripMenuItem_Click);
            // 
            // reorderToolStripMenuItem
            // 
            this.reorderToolStripMenuItem.Name = "reorderToolStripMenuItem";
            this.reorderToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.reorderToolStripMenuItem.Text = "reorder";
            this.reorderToolStripMenuItem.Click += new System.EventHandler(this.ReorderToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logToConsoleToolStripMenuItem,
            this.toggleDebugRenderToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // logToConsoleToolStripMenuItem
            // 
            this.logToConsoleToolStripMenuItem.Name = "logToConsoleToolStripMenuItem";
            this.logToConsoleToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.logToConsoleToolStripMenuItem.Text = "log to console";
            this.logToConsoleToolStripMenuItem.Click += new System.EventHandler(this.LogToConsoleToolStripMenuItem_Click);
            // 
            // toggleDebugRenderToolStripMenuItem
            // 
            this.toggleDebugRenderToolStripMenuItem.Name = "toggleDebugRenderToolStripMenuItem";
            this.toggleDebugRenderToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.toggleDebugRenderToolStripMenuItem.Text = "toggle debug render";
            this.toggleDebugRenderToolStripMenuItem.Click += new System.EventHandler(this.ToggleDebugRenderToolStripMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLeft,
            this.toolStripStatusLabelStateCount,
            this.toolStripStatusLabelTransitionCount});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 577);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1013, 22);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "mainStatusStrip";
            // 
            // toolStripStatusLabelLeft
            // 
            this.toolStripStatusLabelLeft.Name = "toolStripStatusLabelLeft";
            this.toolStripStatusLabelLeft.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabelLeft.Text = "ready";
            // 
            // toolStripStatusLabelStateCount
            // 
            this.toolStripStatusLabelStateCount.Name = "toolStripStatusLabelStateCount";
            this.toolStripStatusLabelStateCount.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabelStateCount.Text = "0 States";
            // 
            // toolStripStatusLabelTransitionCount
            // 
            this.toolStripStatusLabelTransitionCount.Name = "toolStripStatusLabelTransitionCount";
            this.toolStripStatusLabelTransitionCount.Size = new System.Drawing.Size(73, 17);
            this.toolStripStatusLabelTransitionCount.Text = "0 Transitions";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.IsSplitterFixed = true;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.splitContainer1);
            this.mainSplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainSplitContainer.Panel1MinSize = 180;
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.panelRendering);
            this.mainSplitContainer.Panel2.Controls.Add(this.horizontalScrollBar);
            this.mainSplitContainer.Panel2.Controls.Add(this.verticalScrollBar);
            this.mainSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainSplitContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainSplitContainer.Size = new System.Drawing.Size(1013, 553);
            this.mainSplitContainer.SplitterDistance = 180;
            this.mainSplitContainer.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolboxListView);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonDelete);
            this.splitContainer1.Panel2.Controls.Add(this.buttonCancel);
            this.splitContainer1.Panel2.Controls.Add(this.buttonApply);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxEnd);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxStart);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxLabel);
            this.splitContainer1.Panel2.Controls.Add(this.labelLabel);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(180, 553);
            this.splitContainer1.SplitterDistance = 333;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolboxListView
            // 
            this.toolboxListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolboxListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20});
            this.toolboxListView.LabelEdit = true;
            this.toolboxListView.Location = new System.Drawing.Point(0, 0);
            this.toolboxListView.MultiSelect = false;
            this.toolboxListView.Name = "toolboxListView";
            this.toolboxListView.Size = new System.Drawing.Size(180, 333);
            this.toolboxListView.TabIndex = 1;
            this.toolboxListView.UseCompatibleStateImageBehavior = false;
            this.toolboxListView.View = System.Windows.Forms.View.Tile;
            this.toolboxListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.toolboxListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ToolboxListView_MouseDoubleClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(12, 163);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(152, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 134);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(152, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(12, 105);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(152, 23);
            this.buttonApply.TabIndex = 4;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // checkBoxEnd
            // 
            this.checkBoxEnd.AutoSize = true;
            this.checkBoxEnd.Location = new System.Drawing.Point(54, 55);
            this.checkBoxEnd.Name = "checkBoxEnd";
            this.checkBoxEnd.Size = new System.Drawing.Size(68, 17);
            this.checkBoxEnd.TabIndex = 3;
            this.checkBoxEnd.Text = "Endstate";
            this.checkBoxEnd.UseVisualStyleBackColor = true;
            // 
            // checkBoxStart
            // 
            this.checkBoxStart.AutoSize = true;
            this.checkBoxStart.Location = new System.Drawing.Point(54, 32);
            this.checkBoxStart.Name = "checkBoxStart";
            this.checkBoxStart.Size = new System.Drawing.Size(71, 17);
            this.checkBoxStart.TabIndex = 2;
            this.checkBoxStart.Text = "Startstate";
            this.checkBoxStart.UseVisualStyleBackColor = true;
            // 
            // textBoxLabel
            // 
            this.textBoxLabel.Location = new System.Drawing.Point(54, 6);
            this.textBoxLabel.Name = "textBoxLabel";
            this.textBoxLabel.Size = new System.Drawing.Size(110, 20);
            this.textBoxLabel.TabIndex = 1;
            // 
            // labelLabel
            // 
            this.labelLabel.AutoSize = true;
            this.labelLabel.Location = new System.Drawing.Point(12, 9);
            this.labelLabel.Name = "labelLabel";
            this.labelLabel.Size = new System.Drawing.Size(36, 13);
            this.labelLabel.TabIndex = 0;
            this.labelLabel.Text = "Label:";
            // 
            // panelRendering
            // 
            this.panelRendering.BackColor = System.Drawing.Color.White;
            this.panelRendering.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRendering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRendering.Location = new System.Drawing.Point(0, 0);
            this.panelRendering.Name = "panelRendering";
            this.panelRendering.Size = new System.Drawing.Size(812, 536);
            this.panelRendering.TabIndex = 2;
            this.panelRendering.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelRendering_Paint);
            this.panelRendering.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelRendering_MouseDown);
            this.panelRendering.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelRendering_MouseMove);
            this.panelRendering.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelRendering_MouseUp);
            // 
            // horizontalScrollBar
            // 
            this.horizontalScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalScrollBar.Enabled = false;
            this.horizontalScrollBar.Location = new System.Drawing.Point(0, 536);
            this.horizontalScrollBar.Maximum = 200;
            this.horizontalScrollBar.Minimum = -200;
            this.horizontalScrollBar.Name = "horizontalScrollBar";
            this.horizontalScrollBar.Size = new System.Drawing.Size(812, 17);
            this.horizontalScrollBar.TabIndex = 1;
            this.horizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HorizontalScrollBar_Scroll);
            // 
            // verticalScrollBar
            // 
            this.verticalScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.verticalScrollBar.Enabled = false;
            this.verticalScrollBar.Location = new System.Drawing.Point(812, 0);
            this.verticalScrollBar.Maximum = 200;
            this.verticalScrollBar.Minimum = -200;
            this.verticalScrollBar.Name = "verticalScrollBar";
            this.verticalScrollBar.Size = new System.Drawing.Size(17, 553);
            this.verticalScrollBar.TabIndex = 0;
            this.verticalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VerticalScrollBar_Scroll);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 599);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.DoubleBuffered = true;
            this.Name = "MainWindow";
            this.Text = "Automata GUI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLeft;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView toolboxListView;
        private System.Windows.Forms.HScrollBar horizontalScrollBar;
        private System.Windows.Forms.VScrollBar verticalScrollBar;
        private System.Windows.Forms.Panel panelRendering;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStateCount;
        private System.Windows.Forms.ToolStripMenuItem exportAsMenu;
        private System.Windows.Forms.ToolStripMenuItem exportAsXML;
        private System.Windows.Forms.ToolStripMenuItem exportAsLatex;
        private System.Windows.Forms.ToolStripMenuItem ImportFromXML;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTransitionCount;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.Label labelLabel;
        private System.Windows.Forms.TextBox textBoxLabel;
        private System.Windows.Forms.CheckBox checkBoxEnd;
        private System.Windows.Forms.CheckBox checkBoxStart;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.ToolStripMenuItem logToConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleDebugRenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsPNG;
        private System.Windows.Forms.ToolStripMenuItem reorderToolStripMenuItem;
    }
}

