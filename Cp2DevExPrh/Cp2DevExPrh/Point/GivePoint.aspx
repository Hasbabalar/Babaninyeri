<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="GivePoint.aspx.cs" Inherits="Cp2DevExPrh.Point.GivePoint" %>



<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    

    <h3>Lütfen Kullanıcı Adınızı Seçerek Exceli İndiriniz!</h3>
    <p>not:Puanlamanız 30 Günü Tamamlayacak Şekilde Olmalıdır.</p>
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <br>
    <br>
    <dx:ASPxButton ID="Button1" runat="server" Text="Excel Indir"  OnClick="Button_Download" />
    <br>
    <hr>
    <br>
    <asp:GridView ID="GridView1" runat="server" ></asp:GridView>
    <asp:GridView ID="GridView2"  runat="server" Visible="false"  ></asp:GridView>
    <asp:GridView ID="GridView3"  runat="server" Visible="false"  ></asp:GridView>
    <br>
    <div>
        <p>not:Lütfen Yüklediğiniz Excel Dosyasının İsminin "Puanlama" Olduğuna Dikkat Ediniz!</p>
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <br>
        <dx:ASPxButton ID="Button2" runat="server" class="btn btn-primary" Text="Excel Yukle"   OnClick="Button_Import" />
    </div>
    

</asp:Content>