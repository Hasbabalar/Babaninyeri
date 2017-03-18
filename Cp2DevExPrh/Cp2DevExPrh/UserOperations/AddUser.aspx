<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="AddUser.aspx.cs" Inherits="Cp2DevExPrh.UserOperations.AddUser" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

<dx:ASPxTextBox ID="tbUserName" runat="server" Width="200px" Caption="Kullanıcı adı">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        <RequiredField ErrorText="Kullanıcı adı alanı doldurulması gereklidir." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
<dx:ASPxTextBox ID="tbUserMail" runat="server" Width="200px" Caption="Kullanıcı e-posta">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        <RegularExpression ValidationExpression="^\w+([-+.'%]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 
            ErrorText="Geçersiz e-posta adresi."/>
        <RequiredField ErrorText="Kullanıcı e-posta alanı doldurulması gereklidir." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
<br />
<dx:ASPxButton ID="btnAddUser" runat="server" Text="Kullanıcı ekle" OnClick="btnAddUser_Click" ValidationGroup="LoginUserValidationGroup">
</dx:ASPxButton>

</asp:Content>
