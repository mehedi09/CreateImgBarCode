Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Partial Class VB
    Inherits System.Web.UI.Page
    Protected Sub btnGenerate_Click(sender As Object, e As EventArgs)
        Dim barCode As String = txtCode.Text
        Dim imgBarCode As New System.Web.UI.WebControls.Image()
        Using bitMap As New Bitmap(barCode.Length * 40, 80)
            Using graphics__1 As Graphics = Graphics.FromImage(bitMap)
                Dim oFont As New Font("IDAutomationHC39M", 16)
                Dim point As New PointF(2.0F, 2.0F)
                Dim blackBrush As New SolidBrush(Color.Black)
                Dim whiteBrush As New SolidBrush(Color.White)
                graphics__1.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height)
                graphics__1.DrawString("*" & barCode & "*", oFont, blackBrush, point)
            End Using
            Using ms As New MemoryStream()
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                Dim byteImage As Byte() = ms.ToArray()

                Convert.ToBase64String(byteImage)
                imgBarCode.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(byteImage)
            End Using
            plBarCode.Controls.Add(imgBarCode)
        End Using
    End Sub
End Class
