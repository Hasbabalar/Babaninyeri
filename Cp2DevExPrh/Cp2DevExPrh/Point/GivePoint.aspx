<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="GivePoint.aspx.cs" Inherits="Cp2DevExPrh.Point.GivePoint" %>



<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    
    <dx:ASPxButton ID="Button1" runat="server" Text="Excel Indir" OnClick="Button_Download" />
    <h4><asp:Literal ID="ltConnecitonMessage" runat="server" /></h4>
    <asp:GridView ID="GridView1" runat="server" ></asp:GridView>
    <asp:GridView ID="GridView2"  runat="server"  ></asp:GridView>
    <asp:GridView ID="GridView3"  runat="server"  ></asp:GridView>
    <asp:FileUpload ID="FileUpload2" runat="server" />
    <dx:ASPxButton ID="Button2" runat="server" Text="Excel Yukle" OnClick="Button_Import" />

</asp:Content>