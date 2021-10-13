<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PRINT_FEES_PREVIEW
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.fees_id_combobox = New System.Windows.Forms.ComboBox
        Me.button_generate_invoice = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.PRINT_FEES1 = New Student_Management_System.PRINT_FEES
        Me.SuspendLayout()
        '
        'fees_id_combobox
        '
        Me.fees_id_combobox.FormattingEnabled = True
        Me.fees_id_combobox.Location = New System.Drawing.Point(412, 28)
        Me.fees_id_combobox.Name = "fees_id_combobox"
        Me.fees_id_combobox.Size = New System.Drawing.Size(121, 21)
        Me.fees_id_combobox.TabIndex = 1
        '
        'button_generate_invoice
        '
        Me.button_generate_invoice.Location = New System.Drawing.Point(539, 29)
        Me.button_generate_invoice.Name = "button_generate_invoice"
        Me.button_generate_invoice.Size = New System.Drawing.Size(146, 20)
        Me.button_generate_invoice.TabIndex = 2
        Me.button_generate_invoice.Text = "Generate Invoice"
        Me.button_generate_invoice.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = 0
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReportSource = Me.PRINT_FEES1
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1070, 443)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'PRINT_FEES_PREVIEW
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 443)
        Me.Controls.Add(Me.button_generate_invoice)
        Me.Controls.Add(Me.fees_id_combobox)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "PRINT_FEES_PREVIEW"
        Me.Text = "PRINT_FEES_PREVIEW"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents PRINT_FEES1 As Student_Management_System.PRINT_FEES
    Friend WithEvents fees_id_combobox As System.Windows.Forms.ComboBox
    Friend WithEvents button_generate_invoice As System.Windows.Forms.Button
End Class
