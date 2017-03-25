<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="AddRestaurant.aspx.cs" Inherits="Cp2DevExPrh.RestaurantOperations.AddRestaurant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<dx:ASPxTextBox ID="tbRestaurantName" runat="server" Width="200px" Caption="Restoran adı">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        <RequiredField ErrorText="Restoran adı alanı doldurulması gereklidir." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
<dx:ASPxTextBox ID="tbRestaurantTransportationType" runat="server" Width="200px" Caption="Restoran Ulaşım Tipi">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
           <RequiredField ErrorText="Restoran Ulaşım Tipinin doldurulması gereklidir." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
    <dx:ASPxTextBox ID="tbRestaurantWeatherType" runat="server" Width="200px" Caption="Restoran Hava Duyarlılığı">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
           <RequiredField ErrorText="Restoran Hava Durumu Duyarlılığı doldurulması gereklidir." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
<br />
<dx:ASPxButton ID="btnAddRestaurant" runat="server" Text="Restoran ekle" OnClick="btnAddRestaurant_Click" ValidationGroup="LoginUserValidationGroup">
</dx:ASPxButton>








</asp:Content>
