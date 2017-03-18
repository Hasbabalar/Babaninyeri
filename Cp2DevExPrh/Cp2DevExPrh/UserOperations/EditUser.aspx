<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Main.master" CodeBehind="EditUser.aspx.cs" Inherits="Cp2DevExPrh.UserOperations.EditUser" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

<dx:ASPxTextBox ID="tbUserName" runat="server" Width="200px" Caption="Bilgilerini düzenlemek istediğiniz kullanıcının adını giriniz: ">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        <RequiredField ErrorText="Kullanıcı adı alanı doldurulması gereklidir." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
<dx:ASPxButton ID="btnEditUser" runat="server" Text="Kullanıcı ara" OnClick="btnEditUser_Click" ValidationGroup="LoginUserValidationGroup">
</dx:ASPxButton>

<br/><br/><br/><br/><br/>


<dx:ASPxTextBox ID="tbEditUserName" runat="server" Width="200px" Caption="Kullanıcı adı: ">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
    </ValidationSettings>
</dx:ASPxTextBox>

<dx:ASPxTextBox ID="tbEditUserMail" runat="server" Width="200px" Caption="Kullanıcı e-posta:: ">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        <RegularExpression ValidationExpression="^\w+([-+.'%]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 
            ErrorText="Geçersiz e-posta adresi."/>
    </ValidationSettings>
</dx:ASPxTextBox>
<dx:ASPxButton ID="btnEnableEditing" runat="server" Text="Kullanıcı bilgilerini güncelle" OnClick="btnEnableEditing_Click" ValidationGroup="LoginUserValidationGroup">
</dx:ASPxButton>




</asp:Content>
