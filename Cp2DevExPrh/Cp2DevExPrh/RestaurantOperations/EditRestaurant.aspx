<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="EditRestaurant.aspx.cs" Inherits="Cp2DevExPrh.RestaurantOperations.EditRestaurant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<dx:ASPxTextBox ID="tbRestaurantName" runat="server" Width="200px" Caption="Bilgilerini düzenlemek istediğiniz restoran adını giriniz: ">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        <RequiredField ErrorText="Restoran adı alanı doldurulması gereklidir." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
<dx:ASPxButton ID="btnEditRestoran" runat="server" Text="Restoran ara" OnClick="btnEditRestoran_Click" ValidationGroup="LoginUserValidationGroup">
</dx:ASPxButton>

 <br/><br/><br/><br/><br/>

<dx:ASPxTextBox ID="tbEditRestaurantName" runat="server" Width="200px" Caption="Restaurant adı: ">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
    </ValidationSettings>
</dx:ASPxTextBox>

<dx:ASPxTextBox ID="tbEditRestaurantTransportationType" runat="server" Width="200px" Caption="Restoran Ulaşım Tipi:: ">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        
    </ValidationSettings>
</dx:ASPxTextBox>

<dx:ASPxTextBox ID="tbEditRestaurantWeatherType" runat="server" Width="200px" Caption="Restoran Hava Duyarlılığı:: ">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        
    </ValidationSettings>
</dx:ASPxTextBox>

<dx:ASPxButton ID="btnEditRestaurant" runat="server" Text="Restaurant" OnClick="btnEnableEdit_Click" ValidationGroup="LoginUserValidationGroup">
</dx:ASPxButton>

</asp:Content>
