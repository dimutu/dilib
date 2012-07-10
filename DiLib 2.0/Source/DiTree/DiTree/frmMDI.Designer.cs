namespace DiTree
{
    partial class frmMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDI));
            this.statusStripMDI = new System.Windows.Forms.StatusStrip();
            this.menuMDI = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.treeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseResumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.termsOfUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMainNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainExportConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainExportTree = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainDebugPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainDebugNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripMove = new System.Windows.Forms.ToolStrip();
            this.toolStripMoveLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripMoveRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripMoveUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripMoveDown = new System.Windows.Forms.ToolStripButton();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.menuMDI.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.toolStripMove.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMDI
            // 
            this.statusStripMDI.Location = new System.Drawing.Point(0, 445);
            this.statusStripMDI.Name = "statusStripMDI";
            this.statusStripMDI.Size = new System.Drawing.Size(741, 22);
            this.statusStripMDI.TabIndex = 1;
            // 
            // menuMDI
            // 
            this.menuMDI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMDI.Location = new System.Drawing.Point(0, 0);
            this.menuMDI.Name = "menuMDI";
            this.menuMDI.Size = new System.Drawing.Size(741, 24);
            this.menuMDI.TabIndex = 2;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripMenuItem3,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(174, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configFileToolStripMenuItem,
            this.treeFileToolStripMenuItem,
            this.allToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // configFileToolStripMenuItem
            // 
            this.configFileToolStripMenuItem.Name = "configFileToolStripMenuItem";
            this.configFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.configFileToolStripMenuItem.Text = "Config File";
            // 
            // treeFileToolStripMenuItem
            // 
            this.treeFileToolStripMenuItem.Name = "treeFileToolStripMenuItem";
            this.treeFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.treeFileToolStripMenuItem.Text = "Tree File";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.allToolStripMenuItem.Text = "All";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem4,
            this.moveToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(141, 6);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upToolStripMenuItem,
            this.downToolStripMenuItem,
            this.leftToolStripMenuItem,
            this.rightToolStripMenuItem});
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.moveToolStripMenuItem.Text = "Move";
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.upToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.upToolStripMenuItem.Text = "Up";
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.downToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.downToolStripMenuItem.Text = "Down";
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.leftToolStripMenuItem.Text = "Left";
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.rightToolStripMenuItem.Text = "Right";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskToolStripMenuItem,
            this.conditionToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.sequenceToolStripMenuItem,
            this.selectionToolStripMenuItem,
            this.toolStripMenuItem2,
            this.treeToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.insertToolStripMenuItem.Text = "&Insert";
            // 
            // taskToolStripMenuItem
            // 
            this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            this.taskToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.taskToolStripMenuItem.Text = "Task";
            // 
            // conditionToolStripMenuItem
            // 
            this.conditionToolStripMenuItem.Name = "conditionToolStripMenuItem";
            this.conditionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.conditionToolStripMenuItem.Text = "Condition";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // sequenceToolStripMenuItem
            // 
            this.sequenceToolStripMenuItem.Name = "sequenceToolStripMenuItem";
            this.sequenceToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.sequenceToolStripMenuItem.Text = "Sequence";
            // 
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.selectionToolStripMenuItem.Text = "Selection";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 6);
            // 
            // treeToolStripMenuItem
            // 
            this.treeToolStripMenuItem.Name = "treeToolStripMenuItem";
            this.treeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.treeToolStripMenuItem.Text = "Tree";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.viewLogToolStripMenuItem,
            this.controlToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "&Debug";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewLogToolStripMenuItem.Text = "View Log";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauseResumeToolStripMenuItem,
            this.nextTaskToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // pauseResumeToolStripMenuItem
            // 
            this.pauseResumeToolStripMenuItem.Name = "pauseResumeToolStripMenuItem";
            this.pauseResumeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pauseResumeToolStripMenuItem.Text = "Pause/Resume";
            // 
            // nextTaskToolStripMenuItem
            // 
            this.nextTaskToolStripMenuItem.Name = "nextTaskToolStripMenuItem";
            this.nextTaskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nextTaskToolStripMenuItem.Text = "Next Task";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.tileVerticleToolStripMenuItem,
            this.closeToolStripMenuItem1,
            this.closeAllToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile Horizontal";
            // 
            // tileVerticleToolStripMenuItem
            // 
            this.tileVerticleToolStripMenuItem.Name = "tileVerticleToolStripMenuItem";
            this.tileVerticleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileVerticleToolStripMenuItem.Text = "Tile Verticle";
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.termsOfUseToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // termsOfUseToolStripMenuItem
            // 
            this.termsOfUseToolStripMenuItem.Name = "termsOfUseToolStripMenuItem";
            this.termsOfUseToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.termsOfUseToolStripMenuItem.Text = "Terms of Use";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStripMainNew
            // 
            this.toolStripMainNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainNew.Image")));
            this.toolStripMainNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainNew.Name = "toolStripMainNew";
            this.toolStripMainNew.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainNew.Text = "New";
            this.toolStripMainNew.Click += new System.EventHandler(this.toolStripMainNew_Click);
            // 
            // toolStripMainOpen
            // 
            this.toolStripMainOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainOpen.Image")));
            this.toolStripMainOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainOpen.Name = "toolStripMainOpen";
            this.toolStripMainOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainOpen.Text = "Open";
            // 
            // toolStripMainSave
            // 
            this.toolStripMainSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainSave.Image")));
            this.toolStripMainSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainSave.Name = "toolStripMainSave";
            this.toolStripMainSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainSave.Text = "Save";
            this.toolStripMainSave.Click += new System.EventHandler(this.toolStripMainSave_Click);
            // 
            // toolStripMainExportConfig
            // 
            this.toolStripMainExportConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainExportConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainExportConfig.Image")));
            this.toolStripMainExportConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainExportConfig.Name = "toolStripMainExportConfig";
            this.toolStripMainExportConfig.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainExportConfig.Text = "Export Config";
            // 
            // toolStripMainExportTree
            // 
            this.toolStripMainExportTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainExportTree.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainExportTree.Image")));
            this.toolStripMainExportTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainExportTree.Name = "toolStripMainExportTree";
            this.toolStripMainExportTree.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainExportTree.Text = "Export Tree";
            // 
            // toolStripMainDebugPause
            // 
            this.toolStripMainDebugPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainDebugPause.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainDebugPause.Image")));
            this.toolStripMainDebugPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainDebugPause.Name = "toolStripMainDebugPause";
            this.toolStripMainDebugPause.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainDebugPause.Text = "Pause/Resume";
            // 
            // toolStripMainDebugNext
            // 
            this.toolStripMainDebugNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainDebugNext.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainDebugNext.Image")));
            this.toolStripMainDebugNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainDebugNext.Name = "toolStripMainDebugNext";
            this.toolStripMainDebugNext.Size = new System.Drawing.Size(23, 22);
            this.toolStripMainDebugNext.Text = "Debug Next";
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMainNew,
            this.toolStripMainOpen,
            this.toolStripMainSave,
            this.toolStripMainExportConfig,
            this.toolStripMainExportTree,
            this.toolStripMainDebugPause,
            this.toolStripMainDebugNext});
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(741, 25);
            this.toolStripMain.TabIndex = 4;
            this.toolStripMain.Text = "Standard";
            // 
            // toolStripMove
            // 
            this.toolStripMove.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMoveLeft,
            this.toolStripMoveRight,
            this.toolStripMoveUp,
            this.toolStripMoveDown});
            this.toolStripMove.Location = new System.Drawing.Point(185, 24);
            this.toolStripMove.Name = "toolStripMove";
            this.toolStripMove.Size = new System.Drawing.Size(104, 25);
            this.toolStripMove.TabIndex = 1;
            this.toolStripMove.Text = "Movement";
            // 
            // toolStripMoveLeft
            // 
            this.toolStripMoveLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMoveLeft.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMoveLeft.Image")));
            this.toolStripMoveLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMoveLeft.Name = "toolStripMoveLeft";
            this.toolStripMoveLeft.Size = new System.Drawing.Size(23, 22);
            this.toolStripMoveLeft.Text = "Move Left";
            // 
            // toolStripMoveRight
            // 
            this.toolStripMoveRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMoveRight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMoveRight.Image")));
            this.toolStripMoveRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMoveRight.Name = "toolStripMoveRight";
            this.toolStripMoveRight.Size = new System.Drawing.Size(23, 22);
            this.toolStripMoveRight.Text = "Move Right";
            // 
            // toolStripMoveUp
            // 
            this.toolStripMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMoveUp.Image")));
            this.toolStripMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMoveUp.Name = "toolStripMoveUp";
            this.toolStripMoveUp.Size = new System.Drawing.Size(23, 22);
            this.toolStripMoveUp.Text = "Move Up";
            // 
            // toolStripMoveDown
            // 
            this.toolStripMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMoveDown.Image")));
            this.toolStripMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMoveDown.Name = "toolStripMoveDown";
            this.toolStripMoveDown.Size = new System.Drawing.Size(23, 22);
            this.toolStripMoveDown.Text = "Move Down";
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 467);
            this.Controls.Add(this.toolStripMove);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.statusStripMDI);
            this.Controls.Add(this.menuMDI);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMDI;
            this.Name = "frmMDI";
            this.menuMDI.ResumeLayout(false);
            this.menuMDI.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.toolStripMove.ResumeLayout(false);
            this.toolStripMove.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMDI;
        private System.Windows.Forms.MenuStrip menuMDI;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem configFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conditionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem treeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseResumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem termsOfUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripMainNew;
        private System.Windows.Forms.ToolStripButton toolStripMainOpen;
        private System.Windows.Forms.ToolStripButton toolStripMainSave;
        private System.Windows.Forms.ToolStripButton toolStripMainExportConfig;
        private System.Windows.Forms.ToolStripButton toolStripMainExportTree;
        private System.Windows.Forms.ToolStripButton toolStripMainDebugPause;
        private System.Windows.Forms.ToolStripButton toolStripMainDebugNext;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStrip toolStripMove;
        private System.Windows.Forms.ToolStripButton toolStripMoveLeft;
        private System.Windows.Forms.ToolStripButton toolStripMoveRight;
        private System.Windows.Forms.ToolStripButton toolStripMoveUp;
        private System.Windows.Forms.ToolStripButton toolStripMoveDown;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
    }
}

