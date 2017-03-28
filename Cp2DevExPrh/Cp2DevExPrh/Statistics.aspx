<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="Statistics.aspx.cs" Inherits="Cp2DevExPrh.Statistics" %>


<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <br><dx:ASPxButton ID="Button1" runat="server" Text=" Periyot Boyunca Restoranlara Gidilecek Toplam Gün Sayısı" OnClick="ButtonShow1"  />
    <br>
    <br >
    <asp:GridView ID="GridView1" runat="server" HeaderStyle-BackColor="Blue" Visible = "false" ></asp:GridView>
    <hr>
    <br ><dx:ASPxButton ID="Button2" runat="server" Text="Kalan Gidilecek Gün Sayısı" OnClick="ButtonShow2" />
    <br >
    <br >
    <asp:GridView ID="GridView2" runat="server" HeaderStyle-BackColor="Blue"  Visible = "false"></asp:GridView>
    <hr>
    <br><dx:ASPxButton ID="Button3" runat="server" Text="Daha Önce Gidilen Restoranlar" OnClick="ButtonShow3"/>
    <br >
    <br >
    <asp:GridView ID="GridView3" runat="server" HeaderStyle-BackColor="Blue" Visible = "false" ></asp:GridView>

</asp:Content>