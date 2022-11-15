Imports System.Drawing.Printing

Public Class Notepad
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        If TextBox1.Modified Then
            Dim a As MsgBoxResult
            a = MsgBox("do you want to save changes", MsgBoxStyle.YesNoCancel, "New Document")
            If a = MsgBoxResult.No Then
                TextBox1.Clear()
            ElseIf a = MsgBoxResult.Cancel Then
            ElseIf a = MsgBoxResult.Yes Then
                SaveFileDialog1.ShowDialog()
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
                TextBox1.Clear()

            End If
        Else
            TextBox1.Clear()
        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OenToolStripMenuItem.Click
        If TextBox1.Modified Then
            Dim ask As MsgBoxResult
            ask = MsgBox("do you want to save changes", MsgBoxStyle.YesNoCancel, "Open Document")
            If ask = MsgBoxResult.No Then
                OpenFileDialog1.ShowDialog()
                TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            ElseIf ask = MsgBoxResult.Cancel Then
            ElseIf ask = MsgBoxResult.Yes Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
                TextBox1.Clear()

            End If
        Else
            OpenFileDialog1.ShowDialog()
            Try
                TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            Catch ex As Exception

            End Try
            TextBox1.Clear()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
        If My.Computer.FileSystem.FileExists(SaveFileDialog1.FileName) Then
            Dim ask As MsgBoxResult
            ask = MsgBox("File already exist,would you like to replace it?", MsgBoxStyle.YesNoCancel, "File Exist")
            If ask = MsgBoxResult.Cancel Then
                SaveFileDialog1.ShowDialog()
            ElseIf ask = MsgBoxResult.Yes Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
            End If
        Else
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
        Me.Close()
    End Sub
    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        If TextBox1.CanUndo Then
            TextBox1.Undo()
        End If
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click


    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        My.Computer.Clipboard.Clear()
        If TextBox1.SelectionLength > 0 Then
            My.Computer.Clipboard.SetText(TextBox1.SelectedText)

        End If
        TextBox1.SelectedText = ""
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        My.Computer.Clipboard.Clear()
        If TextBox1.SelectionLength > 0 Then
            My.Computer.Clipboard.SetText(TextBox1.SelectedText)

        End If

    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        If My.Computer.Clipboard.ContainsText Then
            TextBox1.Paste()
        End If
    End Sub

    Private Sub FindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindToolStripMenuItem.Click
        Dim a As String
        Dim b As String
        a = InputBox("Enter text to be found")
        b = InStr(TextBox1.Text, a)
        If b Then
            TextBox1.Focus()
            TextBox1.SelectionStart = b - 1
            TextBox1.SelectionLength = Len(a)
        Else
            MsgBox("Text Not Found.")
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        TextBox1.Font = FontDialog1.Font
    End Sub

    Private Sub FontColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        TextBox1.ForeColor = ColorDialog1.Color
    End Sub

    Private Sub BackColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        TextBox1.BackColor = ColorDialog1.Color
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click

    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
        If My.Computer.FileSystem.FileExists(SaveFileDialog1.FileName) Then
            Dim ask As MsgBoxResult
            ask = MsgBox("File already exist,would you like to replace it?", MsgBoxStyle.YesNoCancel, "File Exist")
            If ask = MsgBoxResult.Cancel Then
                SaveFileDialog1.ShowDialog()
            ElseIf ask = MsgBoxResult.Yes Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
            End If
        Else
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        PrintDialog1.Document = PrintDocument1
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        PrintDialog1.AllowSomePages = True
        '  PrintDialog1.PageSetupDialo


        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PrintSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintSetupToolStripMenuItem.Click
        PageSetupDialog1.ShowDialog()

    End Sub

    Private Sub ZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem.Click

    End Sub

    Private Sub Notepad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ico As New System.Drawing.Icon("C:\Users\shour\Downloads\notepad.ico")
        Me.Icon = ico
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

End Class
