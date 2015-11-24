<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PBar = New System.Windows.Forms.ProgressBar()
        Me.Label_DataDate = New System.Windows.Forms.Label()
        Me.DBList = New System.Windows.Forms.ListView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button_GetData = New System.Windows.Forms.Button()
        Me.DataDateChoose = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button_CopyKey = New System.Windows.Forms.Button()
        Me.Button_CopyPW = New System.Windows.Forms.Button()
        Me.Button_CopyID = New System.Windows.Forms.Button()
        Me.Label_msgOutput = New System.Windows.Forms.Label()
        Me.Timer_UI = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PBar)
        Me.GroupBox1.Controls.Add(Me.Label_DataDate)
        Me.GroupBox1.Controls.Add(Me.DBList)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 373)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(6, 350)
        Me.PBar.MarqueeAnimationSpeed = 50
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(368, 17)
        Me.PBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PBar.TabIndex = 2
        '
        'Label_DataDate
        '
        Me.Label_DataDate.AutoSize = True
        Me.Label_DataDate.Location = New System.Drawing.Point(6, 16)
        Me.Label_DataDate.Name = "Label_DataDate"
        Me.Label_DataDate.Size = New System.Drawing.Size(77, 12)
        Me.Label_DataDate.TabIndex = 1
        Me.Label_DataDate.Text = "尚未取得資料"
        '
        'DBList
        '
        Me.DBList.FullRowSelect = True
        Me.DBList.GridLines = True
        Me.DBList.HideSelection = False
        Me.DBList.Location = New System.Drawing.Point(6, 36)
        Me.DBList.Name = "DBList"
        Me.DBList.Size = New System.Drawing.Size(368, 308)
        Me.DBList.TabIndex = 0
        Me.DBList.UseCompatibleStateImageBehavior = False
        Me.DBList.View = System.Windows.Forms.View.Details
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button_GetData)
        Me.GroupBox2.Controls.Add(Me.DataDateChoose)
        Me.GroupBox2.Location = New System.Drawing.Point(390, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(208, 56)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "資料來源日期"
        '
        'Button_GetData
        '
        Me.Button_GetData.Location = New System.Drawing.Point(142, 21)
        Me.Button_GetData.Name = "Button_GetData"
        Me.Button_GetData.Size = New System.Drawing.Size(51, 21)
        Me.Button_GetData.TabIndex = 5
        Me.Button_GetData.Text = "抓取"
        Me.Button_GetData.UseVisualStyleBackColor = True
        '
        'DataDateChoose
        '
        Me.DataDateChoose.Location = New System.Drawing.Point(8, 21)
        Me.DataDateChoose.Name = "DataDateChoose"
        Me.DataDateChoose.Size = New System.Drawing.Size(118, 22)
        Me.DataDateChoose.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button_CopyKey)
        Me.GroupBox3.Controls.Add(Me.Button_CopyPW)
        Me.GroupBox3.Controls.Add(Me.Button_CopyID)
        Me.GroupBox3.Location = New System.Drawing.Point(390, 74)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(208, 106)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "複製至剪貼簿 (請先選取左方資料)"
        '
        'Button_CopyKey
        '
        Me.Button_CopyKey.Enabled = False
        Me.Button_CopyKey.Location = New System.Drawing.Point(8, 77)
        Me.Button_CopyKey.Name = "Button_CopyKey"
        Me.Button_CopyKey.Size = New System.Drawing.Size(193, 22)
        Me.Button_CopyKey.TabIndex = 2
        Me.Button_CopyKey.Text = "複製序號"
        Me.Button_CopyKey.UseVisualStyleBackColor = True
        '
        'Button_CopyPW
        '
        Me.Button_CopyPW.Enabled = False
        Me.Button_CopyPW.Location = New System.Drawing.Point(8, 49)
        Me.Button_CopyPW.Name = "Button_CopyPW"
        Me.Button_CopyPW.Size = New System.Drawing.Size(193, 22)
        Me.Button_CopyPW.TabIndex = 1
        Me.Button_CopyPW.Text = "複製密碼"
        Me.Button_CopyPW.UseVisualStyleBackColor = True
        '
        'Button_CopyID
        '
        Me.Button_CopyID.Enabled = False
        Me.Button_CopyID.Location = New System.Drawing.Point(8, 21)
        Me.Button_CopyID.Name = "Button_CopyID"
        Me.Button_CopyID.Size = New System.Drawing.Size(193, 22)
        Me.Button_CopyID.TabIndex = 0
        Me.Button_CopyID.Text = "複製帳號"
        Me.Button_CopyID.UseVisualStyleBackColor = True
        '
        'Label_msgOutput
        '
        Me.Label_msgOutput.AutoSize = True
        Me.Label_msgOutput.Location = New System.Drawing.Point(396, 190)
        Me.Label_msgOutput.Name = "Label_msgOutput"
        Me.Label_msgOutput.Size = New System.Drawing.Size(74, 12)
        Me.Label_msgOutput.TabIndex = 8
        Me.Label_msgOutput.Text = "正在初始化..."
        '
        'Timer_UI
        '
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.LinkLabel3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.LinkLabel2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.LinkLabel1)
        Me.GroupBox4.Location = New System.Drawing.Point(390, 238)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(208, 138)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "資料來源"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 12)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "ESET 官方網站"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(20, 115)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(102, 12)
        Me.LinkLabel3.TabIndex = 13
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "http://www.eset.com/"
        Me.LinkLabel3.Text = "http://www.eset.com/"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "ESET 官方授權憑證轉換"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(20, 75)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(132, 12)
        Me.LinkLabel2.TabIndex = 11
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = "https://my.eset.com/convert"
        Me.LinkLabel2.Text = "https://my.eset.com/convert"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "NOD32 免費防毒序號(天天更新) "
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(20, 35)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(128, 12)
        Me.LinkLabel1.TabIndex = 8
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "http://www.trynod32.com/"
        Me.LinkLabel1.Text = "http://www.trynod32.com/"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 380)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label_msgOutput)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TryNOD32 帳號密碼取得工具(2015-11-24) - MapleHuang(stan60250@gmail.com)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DBList As System.Windows.Forms.ListView
    Friend WithEvents Label_DataDate As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button_GetData As System.Windows.Forms.Button
    Friend WithEvents DataDateChoose As System.Windows.Forms.DateTimePicker
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button_CopyPW As System.Windows.Forms.Button
    Friend WithEvents Button_CopyID As System.Windows.Forms.Button
    Friend WithEvents Button_CopyKey As System.Windows.Forms.Button
    Friend WithEvents Label_msgOutput As System.Windows.Forms.Label
    Friend WithEvents Timer_UI As System.Windows.Forms.Timer
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel

End Class
