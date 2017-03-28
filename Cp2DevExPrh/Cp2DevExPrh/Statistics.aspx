<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="Statistics.aspx.cs" Inherits="Cp2DevExPrh.Statistics" %>



<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:GridView ID="GridView1" runat="server" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" HeaderStyle-Font-Bold="True" Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="orange"><tr><td>Önümüzdeki Periyot Boyunca Restoranlara Gidilme Oranları</td></tr></table>' CaptionAlign="Top" ></asp:GridView>
    
    <asp:GridView ID="GridView2" runat="server" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" HeaderStyle-Font-Bold="True" Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="orange"><tr><td>Kalan Gidilecek Gün Sayısı</td></tr></table>' CaptionAlign="Top" ></asp:GridView>
   
</asp:Content>