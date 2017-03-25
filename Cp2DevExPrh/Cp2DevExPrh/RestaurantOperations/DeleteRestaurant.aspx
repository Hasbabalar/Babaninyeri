<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="DeleteRestaurant.aspx.cs" Inherits="Cp2DevExPrh.RestaurantOperations.DeleteRestaurant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<dx:ASPxTextBox ID="tbRestaurantName" runat="server" Width="200px" Caption="Silmek istediğiniz restoran adını giriniz: ">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        <RequiredField ErrorText="Restoran adı alanı doldurulması gereklidir." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
<dx:ASPxButton ID="btnDeleteUser" runat="server" Text="Restoranı sil" OnClick="btnDeleteRestaurant_Click" ValidationGroup="LoginUserValidationGroup">
</dx:ASPxButton>




</asp:Content>
