<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="DeleteUser.aspx.cs" Inherits="Cp2DevExPrh.UserOperations.DeleteUser" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

<dx:ASPxTextBox ID="tbUserName" runat="server" Width="200px" Caption="Silmek istediğiniz kullanıcının adını giriniz: ">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        <RequiredField ErrorText="Kullanıcı adı alanı doldurulması gereklidir." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
<dx:ASPxButton ID="btnDeleteUser" runat="server" Text="Kullanıcıyı sil" OnClick="btnDeleteUser_Click" ValidationGroup="LoginUserValidationGroup">
</dx:ASPxButton>
</asp:Content>
