﻿Imports System.Windows.Forms

Public Class MainForm
    Public ChildForm As Form = Nothing
    Public MenuActive As String
    Private Sub ExitMenu_Click(sender As Object, e As EventArgs) Handles ExitMenu.Click
        Me.Close()
    End Sub
    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'RestrictUserMenu()
        Main() ' Call Sub Main Application
    End Sub

    Private Sub TimeStat_Tick(sender As Object, e As EventArgs) Handles TimeStat.Tick
        TimeStat.Stop()
        ToolProgressBar1.Visible = False
        StatusMessage.Text = ""
        StatusStrip.BackColor = Color.DodgerBlue
        StatusMessage.Text = "Application Ready"
    End Sub

    Private Sub menu501_Click(sender As Object, e As EventArgs) Handles menu501.Click
        'FUserGroup.WindowState = FormWindowState.Maximized
        'FUserGroup.MdiParent = Me
        'FUserGroup.Show()
        'ChildForm.Close()
        LoadMdiChildForm(FUserGroup, "menu501")
    End Sub

    Sub LoadMdiChildForm(CForm As Form, menuname As String)
        Try
            If Not ChildForm Is Nothing Then
                If ChildForm.Name <> CForm.Name Then
                    ChildForm.Close()
                End If
            End If
            ChildForm = CForm
            MenuActive = menuname
            ChildForm.WindowState = FormWindowState.Maximized
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Catch ex As ObjectDisposedException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub RestrictUserMenu(Optional MenuItems As ToolStripMenuItem = Nothing)
        Try
            If MenuItems Is Nothing Then
                For Each toolmenu As ToolStripMenuItem In MenuStrip.Items
                    If MUsers.UserListMenuPrivileges().ContainsKey(toolmenu.Name) Then
                        toolmenu.Visible = MUsers.UserListMenuPrivileges()(toolmenu.Name)("checked")
                    End If
                    RestrictUserMenu(toolmenu)
                Next
            Else
                For Each toolmenu In MenuItems.DropDownItems
                    If MUsers.UserListMenuPrivileges().ContainsKey(toolmenu.Name) Then
                        toolmenu.Visible = MUsers.UserListMenuPrivileges()(toolmenu.Name)("checked")
                    End If
                    RestrictUserMenu(toolmenu)
                Next
            End If

        Catch ex As Exception
            ErrorLogger.WriteToErrorLog("Error has occurred : " & ex.Message, ex.StackTrace, ERROR_STAT, "select", "2")
            MyApplication.ShowStatus("Error has occurred : " & ex.Message, ERROR_STAT, True, 10000)
        End Try
    End Sub

    Private Sub DataTanamanMasukToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles menu102.Click
        LoadMdiChildForm(FTanamanMasuk, "menu102")
    End Sub

    Private Sub menu101_Click(sender As Object, e As EventArgs) Handles menu101.Click
        'FDataTanaman.WindowState = FormWindowState.Maximized
        'FDataTanaman.MdiParent = Me
        'FDataTanaman.Show()
        LoadMdiChildForm(FDataTanaman, "menu101")
    End Sub

    Private Sub menu102_Click(sender As Object, e As EventArgs) Handles menu102.Click
        'FDataBibitTanaman.WindowState = FormWindowState.Maximized
        'FDataBibitTanaman.MdiParent = Me
        'FDataBibitTanaman.Show()
    End Sub

    Private Sub menu201_Click(sender As Object, e As EventArgs) Handles menu201.Click
        LoadMdiChildForm(FDataBibitTanaman, "menu201")
    End Sub

    Private Sub menu301_Click(sender As Object, e As EventArgs) Handles menu301.Click
        LoadMdiChildForm(FDataPelanggan, "menu301")
    End Sub

    Private Sub menu401_Click(sender As Object, e As EventArgs) Handles menu401.Click
        LoadMdiChildForm(FCOAheader, "menu401")
    End Sub

    Private Sub menu402_Click(sender As Object, e As EventArgs) Handles menu402.Click
        LoadMdiChildForm(FCOADetail, "menu402")
    End Sub

    Private Sub menu403_Click(sender As Object, e As EventArgs) Handles menu403.Click
        LoadMdiChildForm(FAkunPosting, "menu403")
    End Sub

    Private Sub menu502_Click(sender As Object, e As EventArgs) Handles menu502.Click
        LoadMdiChildForm(FDataPengguna, "menu502")
    End Sub

    Private Sub menu503_Click(sender As Object, e As EventArgs) Handles menu503.Click
        LoadMdiChildForm(FProfilPerusahaan, "menu503")
    End Sub

    Private Sub menu202_Click(sender As Object, e As EventArgs) Handles menu202.Click
        LoadMdiChildForm(FDataBibitTanamanMasuk, "menu202")
    End Sub
End Class
