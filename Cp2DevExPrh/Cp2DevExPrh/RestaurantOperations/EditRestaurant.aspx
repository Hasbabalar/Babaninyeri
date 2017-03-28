<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="EditRestaurant.aspx.cs" Inherits="Cp2DevExPrh.RestaurantOperations.EditRestaurant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<dx:ASPxTextBox ID="tbEditRestaurantName" runat="server" Width="200px" Caption="Güncellemek istenen Restoran adı">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        <RequiredField ErrorText="Restoran adı alanı doldurulması gereklidir." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
    
    <br />
    
    <asp:DropDownList ID="tbEditRestaurantTransportationType" runat="server" Width="200px" Caption="Restoran Ulaşım Tipi">
    <asp:ListItem Text="Ulaşım Tipini Seçiniz" Value="0"></asp:ListItem>
    <asp:ListItem Text="Yaya" Value="1"></asp:ListItem>
    <asp:ListItem Text="Araba" Value="2"></asp:ListItem>

    </asp:DropDownList>

    <br />
     <br />
    <asp:DropDownList ID="tbEditRestaurantWeatherType" runat="server" Width="200px" Caption="Restoran Ulaşım Tipi">
    <asp:ListItem Text="Hava Durumuna Duyarlı mı? " Value="0"></asp:ListItem>
    <asp:ListItem Text="Duyarlı" Value="1"></asp:ListItem>
    <asp:ListItem Text="Duyarsız" Value="2"></asp:ListItem>

    </asp:DropDownList>


 <br />
<br />
<dx:ASPxButton ID="btnEditRestaurant" runat="server" Text="Restoranı Güncelle" OnClick="btnEditRestaurant_Click" ValidationGroup="LoginUserValidationGroup">
</dx:ASPxButton>








</asp:Content>
