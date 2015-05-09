﻿Public Class FDataBibitTanamanAdd
    Private Model As New MBibitTanaman
    Public isEdit As Boolean = False
    Shared Property txtMmtrg2 As Object


    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        'MessageBox.Show(Model.EscapeString(TextBox1.Text))
        'Exit Sub
        If DataIsValid() Then
            Dim res As Integer

            Model.GetKey1 = Model.EscapeString(txtKeyID1.Text)
            Model.GetKey2 = Model.EscapeString(txtKeyID2.Text)
            Model.mmtrg2 = "2"
            Model.mmtrhid = Model.EscapeString(txtMmtrhid.Text)
            Model.mmtrg1 = Model.EscapeString(txtKode2.Text)
            Model.mmtrname = Model.EscapeString(txtJnsTanaman.Text)
            Model.polybag = cmbPolybag.Text
            Model.mmtrunit = txtSatuan.Text
            Model.mmtrprice = Convert.ToDouble(txtHarga.Text)
            Model.mmtrid1 = txtKode.Text + txtKode2.Text + txtKode3.Text
            Model.mmtrid2 = txtKode.Text + "2" + txtKode3.Text
            'If txtKeyID1.Text <> "" And txtKeyID2.Text <> "" Then
            If isEdit Then
                res = Model.UpdateData() And Model.UpdateData1()
                'MyApplication.ShowStatus("Data has been updated")
            Else
                res = Model.InsertData() And Model.InsertData1()
                'MyApplication.ShowStatus("Data has been saved")
            End If
            FDataBibitTanaman.init()
            Me.Close()
        End If
    End Sub

    Private Sub txtJnsTanaman_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJnsTanaman.KeyPress
        txtJnsTanaman.ReadOnly = True
        txtJnsTanaman.BackColor = Color.White
    End Sub

    Private Sub FDataBibitTanamanAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtKode2.Text = "1"
        statmsg.Text = ""

        txtJnsTanaman.Focus()
    End Sub

    Private Sub Prompt_Click(sender As Object, e As EventArgs) Handles Prompt.Click
        FjenisBibitTanaman.ShowDialog()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        FjenisBibitTanaman.Refresh()
        Me.Close()
    End Sub

    Private Sub cmbPolybag_Leave(sender As Object, e As EventArgs) Handles cmbPolybag.Leave
        Dim keyunique As String = txtKode2.Text + txtKode3.Text + txtMmtrhid.Text
        If Not isEdit Then
            If Not Model.IfKeyExist(keyunique) Then
                statmsg.Text = ""
                statmsg.ForeColor = Color.Green
            Else
                statmsg.Text = "Silahkan pilih Polybag yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtKode3.Text = ""
                cmbPolybag.Focus()
            End If
        ElseIf keyunique <> Tunique.Text Then

            If Not Model.IfKeyExist(keyunique) Then
                statmsg.Text = ""
                statmsg.ForeColor = Color.Green
            Else
                statmsg.Text = "Silahkan pilih Polybag yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtKode3.Text = ""
                cmbPolybag.Focus()
            End If
        Else
            statmsg.Text = ""
            statmsg.ForeColor = Color.Green
        End If
    End Sub

    Private Sub cmbPolybag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPolybag.SelectedIndexChanged
        If cmbPolybag.SelectedItem = "P25" Then
            txtKode3.Text = "025"
        ElseIf cmbPolybag.SelectedItem = "P35" Then
            txtKode3.Text = "035"
        ElseIf cmbPolybag.SelectedItem = "P50" Then
            txtKode3.Text = "050"
        ElseIf cmbPolybag.SelectedItem = "P80" Then
            txtKode3.Text = "080"
        Else
            txtKode3.Text = "150"
        End If
        cmbPolybag_Leave(sender, e)
    End Sub

    Private Sub txtHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHarga.KeyPress
        'If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        e.Handled = MyApplication.ValidNumber(e)
    End Sub

    Private Sub txtKode3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKode3.KeyDown
        txtKode3.ReadOnly = True
        txtKode3.BackColor = Color.White
    End Sub

    Private Sub txtKode3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode3.KeyPress
        txtKode3.ReadOnly = True
        txtKode3.BackColor = Color.White
    End Sub

    Private Sub cmbPolybag_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPolybag.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtKode_Leave(sender As Object, e As EventArgs) Handles txtKode.Leave
        Dim mmtrid As String = txtKode.Text + txtKode2.Text + txtKode3.Text
        If Not isEdit Then
            If Not Model.IfKeyExist(mmtrid) Then
                statmsg.Text = ""
                statmsg.ForeColor = Color.Green
            Else
                statmsg.Text = "Kode sudah ada, silahkan masukan kode yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtKode.Focus()
            End If
        End If


    End Sub

    Private Sub txtKode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtKode2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode2.KeyPress
        txtKode2.ReadOnly = True
        txtKode2.BackColor = Color.White
    End Sub

    Private Sub txtSatuan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSatuan.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Function DataIsValid() As Boolean
        DataIsValid = True
        Dim mmtrid As String = txtKode.Text + txtKode2.Text + txtKode3.Text

        If txtKeyID1.Text <> "" Then
            If txtKeyID1.Text <> txtKode.Text + txtKode2.Text + txtKode3.Text + txtMmtrg1.Text Then
                If Model.IfKeyExist(mmtrid) Then
                    statmsg.Text = "Kode sudah ada, silahkan masukan Kode yang lain."
                    statmsg.ForeColor = Color.DarkRed
                    txtKode.Focus()
                    DataIsValid = False
                    Exit Function
                Else
                    statmsg.Text = "Kode Valid"
                    statmsg.ForeColor = Color.Green
                    DataIsValid = True
                End If
            End If
        Else
            If Model.IfKeyExist(mmtrid) Then
                statmsg.Text = "Kode sudah ada, silahkan masukan Kode yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtKode.Focus()
                DataIsValid = False
                Exit Function
            Else
                statmsg.Text = "Kode Valid"
                statmsg.ForeColor = Color.Green
                DataIsValid = True
            End If
        End If

        Dim keyunique As String = txtKode2.Text + txtKode3.Text + txtMmtrhid.Text
        If Not isEdit Then
            If Not Model.IfKeyExist(keyunique) Then
                statmsg.Text = ""
                statmsg.ForeColor = Color.Green
            Else
                statmsg.Text = "Silahkan pilih Polybag yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtKode3.Text = ""
                cmbPolybag.Focus()
                DataIsValid = False
            End If
        ElseIf keyunique <> Tunique.Text Then
            If Not Model.IfKeyExist(keyunique) Then
                statmsg.Text = ""
                statmsg.ForeColor = Color.Green
            Else
                statmsg.Text = "Silahkan pilih Polybag yang lain."
                statmsg.ForeColor = Color.DarkRed
                txtKode3.Text = ""
                cmbPolybag.Focus()
                DataIsValid = False
                Exit Function
            End If
        End If

        If txtJnsTanaman.Text = "" Then
            'MessageBox.Show("User group cannot be empty")
            statmsg.Text = "Jenis Tanaman tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtJnsTanaman.Focus()
            DataIsValid = False
            Exit Function
        ElseIf cmbPolybag.Text = "" Then
            'MessageBox.Show("User group cannot be empty")
            statmsg.Text = "Polybag tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtKode.Focus()
            DataIsValid = False
            Exit Function
        ElseIf txtKode.Text = "" Then
            'MessageBox.Show("User group cannot be empty")
            statmsg.Text = "Kode tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtKode.Focus()
            DataIsValid = False
            Exit Function
        ElseIf txtKode3.Text = "" Then
            'MessageBox.Show("User group cannot be empty")
            statmsg.Text = "Kode tidak boleh kosong !"
            statmsg.ForeColor = Color.DarkRed
            txtKode3.Focus()
            DataIsValid = False
            Exit Function
        ElseIf txtKode.Text <> "" Then
            If Len(txtKode.Text) < 5 Then
                'MessageBox.Show("User group cannot be empty")
                statmsg.Text = "Kode tidak boleh kurang dari 5 digit !"
                statmsg.ForeColor = Color.DarkRed
                txtKode.Focus()
                DataIsValid = False
                Exit Function
            ElseIf UBound(Split(txtKode.Text, " ")) > 0 Then
                statmsg.Text = "Kode tidak menggunakan spasi !"
                statmsg.ForeColor = Color.DarkRed
                txtKode.Focus()
                DataIsValid = False
                Exit Function
            End If
        End If
        Return DataIsValid
    End Function
    Private Sub txtHarga_Validated(sender As Object, e As EventArgs) Handles txtHarga.Validated
        txtHarga.Text = Format(CDec(txtHarga.Text), "##,##0")
    End Sub
End Class