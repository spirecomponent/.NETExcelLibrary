Imports Microsoft.VisualBasic
Imports System
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports Spire.Xls

Namespace Spire.Xls.Sample
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private WithEvents btnRun As System.Windows.Forms.Button
		Private WithEvents btnAbout As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		''' <summary>
		''' Required designer variable.
		''' </summary
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()
			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnRun = New System.Windows.Forms.Button()
			Me.btnAbout = New System.Windows.Forms.Button()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' btnRun
			' 
			Me.btnRun.Location = New System.Drawing.Point(448, 56)
			Me.btnRun.Name = "btnRun"
			Me.btnRun.Size = New System.Drawing.Size(72, 23)
			Me.btnRun.TabIndex = 2
			Me.btnRun.Text = "Run"
'			Me.btnRun.Click += New System.EventHandler(Me.btnRun_Click);
			' 
			' btnAbout
			' 
			Me.btnAbout.Location = New System.Drawing.Point(528, 56)
			Me.btnAbout.Name = "btnAbout"
			Me.btnAbout.Size = New System.Drawing.Size(75, 23)
			Me.btnAbout.TabIndex = 3
			Me.btnAbout.Text = "Close"
'			Me.btnAbout.Click += New System.EventHandler(Me.btnAbout_Click);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(134)))
			Me.label1.Location = New System.Drawing.Point(16, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(494, 14)
			Me.label1.TabIndex = 4
			Me.label1.Text = "The sample demonstrates how to set interior formatting in an excel workbook."
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
			Me.ClientSize = New System.Drawing.Size(616, 94)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.btnAbout)
			Me.Controls.Add(Me.btnRun)
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "Form1"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Spire.XLS sample"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub ExcelDocViewer(ByVal fileName As String)
			Try
				System.Diagnostics.Process.Start(fileName)
			Catch
			End Try
		End Sub

		Private Sub btnRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRun.Click
			Dim workbook As New Workbook()
			Dim sheet As Worksheet = workbook.Worksheets(0)

			workbook.Version = ExcelVersion.Version2007


			Dim maxColor As Integer = System.Enum.GetValues(GetType(ExcelColors)).Length
            Dim random As New Random()
			For i As Integer = 2 To 39

				Dim backKnownColor As ExcelColors = CType(random.Next(1,maxColor \ 2), ExcelColors)

				sheet.Range("A1").Text = "Color Name"
				sheet.Range("B1").Text = "Red"
				sheet.Range("C1").Text = "Green"
				sheet.Range("D1").Text = "Blue"
				sheet.Range("E1:K1").Merge()
				sheet.Range("E1:K1").Text = "Gradient"
				sheet.Range("A1:K1").Style.Font.IsBold = True
				sheet.Range("A1:K1").Style.Font.Size = 11

				Dim colorName As String = backKnownColor.ToString()
				sheet.Range(String.Format("A{0}",i)).Text = colorName
				sheet.Range(String.Format("B{0}", i)).Text = workbook.GetPaletteColor(backKnownColor).R.ToString()
				sheet.Range(String.Format("C{0}", i)).Text = workbook.GetPaletteColor(backKnownColor).G.ToString()
				sheet.Range(String.Format("D{0}", i)).Text = workbook.GetPaletteColor(backKnownColor).B.ToString()

				sheet.Range(String.Format("E{0}:K{0}",i)).Merge()
				sheet.Range(String.Format("E{0}:K{0}", i)).Text = colorName
				sheet.Range(String.Format("E{0}:K{0}", i)).Style.Interior.FillPattern = ExcelPatternType.Gradient
				sheet.Range(String.Format("E{0}:K{0}", i)).Style.Interior.Gradient.BackKnownColor = backKnownColor
				sheet.Range(String.Format("E{0}:K{0}", i)).Style.Interior.Gradient.ForeKnownColor = ExcelColors.White
				sheet.Range(String.Format("E{0}:K{0}", i)).Style.Interior.Gradient.GradientStyle = GradientStyleType.Vertical
				sheet.Range(String.Format("E{0}:K{0}", i)).Style.Interior.Gradient.GradientVariant = GradientVariantsType.ShadingVariants1
			Next i

			sheet.AutoFitColumn(1)

			workbook.SaveToFile("Sample.xlsx")

			ExcelDocViewer(workbook.FileName)
		End Sub

		Private Sub btnAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbout.Click
			Close()
		End Sub


	End Class
End Namespace